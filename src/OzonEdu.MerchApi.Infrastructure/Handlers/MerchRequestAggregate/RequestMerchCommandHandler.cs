using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchApi.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchApi.Domain.AggregationModels.EmployeeAggregate.Entities;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchPackAggregate;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchPackAggregate.Entities;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchRequestAggregate;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchRequestAggregate.Entities;
using OzonEdu.MerchApi.Domain.DomainServices;
using OzonEdu.MerchApi.Infrastructure.Commands.CheckMerchInStockCommand;
using OzonEdu.MerchApi.Infrastructure.Commands.RequestMerchCommand;
using OzonEdu.MerchApi.Infrastructure.Commands.ReserveMerchInStockCommand;
using OzonEdu.MerchApi.Infrastructure.Commands.SubscribeToSupplyCommand;

namespace OzonEdu.MerchApi.Infrastructure.Handlers.MerchRequestAggregate
{
    public class RequestMerchCommandHandler : IRequestHandler<RequestMerchCommand, RequestMerchCommandResponse>
    {
        private readonly IMediator _mediator;
        private readonly IMerchRequestRepository _merchRequestRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMerchPackRepository _merchPackRepository;

        public RequestMerchCommandHandler(IMediator mediator, IMerchRequestRepository merchRequestRepository,
            IEmployeeRepository employeeRepository, IMerchPackRepository merchPackRepository)
        {
            _mediator = mediator;
            _merchRequestRepository = merchRequestRepository;
            _employeeRepository = employeeRepository;
            _merchPackRepository = merchPackRepository;
        }

        public async Task<RequestMerchCommandResponse> Handle(RequestMerchCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                var employeeInDb = await GetEmployeeInDbAsync(request.EmployeeId, cancellationToken);
                var merchPackInDb = await GetMerchPackInDbAsync(request.MerchPackId, cancellationToken);
                var merchRequestsAlreadyIssued =
                    await _merchRequestRepository.GetByEmployeeIdWithMerchPackIdAsync(employeeInDb.Id, merchPackInDb.Id,
                        cancellationToken);

                if (merchRequestsAlreadyIssued is not null)
                    return new RequestMerchCommandResponse
                    {
                        Status = $"This merch {request.MerchPackId} has already been issued"
                    };


                var merchRequest = MerchRequestDomainService.CreateMerchRequest(employeeInDb, merchPackInDb);
                var isMerchInStock = await CheckMerchInStockAsync(merchRequest, cancellationToken);

                if (isMerchInStock)
                {
                    var stockResponse = await ReserveMerchInStock(merchRequest, cancellationToken);
                    merchRequest.SetInProcessStatus(stockResponse.ReserveCodeStatus);
                }
                else
                {
                    var stockResponse = await SubscribeToSupplyInStock(merchRequest, cancellationToken);
                    merchRequest.SetWaitingSupplyStatus(stockResponse.SupplyCodeStatus);
                }

                await _merchRequestRepository.CreateAsync(merchRequest, cancellationToken);

                return new RequestMerchCommandResponse
                {
                    Status = $"Merch request {merchRequest.Id} created. Your status {merchRequest.Status.Name}."
                };
            }
            catch (Exception e)
            {
                return new RequestMerchCommandResponse
                {
                    Status = e.Message
                };
            }
        }

        private async Task<Employee> GetEmployeeInDbAsync(long id, CancellationToken cancellationToken)
        {
            var employeeInDb = await _employeeRepository.FindByIdAsync(id, cancellationToken);
            if (employeeInDb is null)
                throw new Exception($"Employee with ID {id} was not found");

            return employeeInDb;
        }

        private async Task<MerchPack> GetMerchPackInDbAsync(long id, CancellationToken cancellationToken)
        {
            var merchPackInDb = await _merchPackRepository.FindByIdAsync(id, cancellationToken);
            if (merchPackInDb is null)
                throw new Exception($"Merch pack with ID {id} was not found");

            return merchPackInDb;
        }

        private async Task<bool> CheckMerchInStockAsync(MerchRequest merchRequest, CancellationToken cancellationToken)
        {
            var merchPack = await _merchPackRepository.FindByIdAsync(merchRequest.MerchPackId, cancellationToken);
            var skuList = merchPack.MerchItems.Select(merchItem => merchItem.Sku.Value);

            var createAvailabilityMerchInStockRequestCommand = new CheckMerchInStockCommand
            {
                SkuCollection = skuList
            };
            var stockResponse = await _mediator.Send(createAvailabilityMerchInStockRequestCommand, cancellationToken);

            return stockResponse.InStock;
        }

        private async Task<ReserveMerchInStockCommandResponse> ReserveMerchInStock(MerchRequest merchRequest,
            CancellationToken cancellationToken)
        {
            var merchPack = await _merchPackRepository.FindByIdAsync(merchRequest.MerchPackId, cancellationToken);
            var skuList = merchPack.MerchItems.Select(merchItem => merchItem.Sku.Value);
            
            var reserveMerchInStockCommand = new ReserveMerchInStockCommand
            {
                SkuCollection = skuList
            };
            var response = await _mediator.Send(reserveMerchInStockCommand, cancellationToken);
            return response;
        }

        private async Task<SubscribeToSupplyCommandResponse> SubscribeToSupplyInStock(MerchRequest merchRequest,
            CancellationToken cancellationToken)
        {
            var merchPack = await _merchPackRepository.FindByIdAsync(merchRequest.MerchPackId, cancellationToken);
            var skuList = merchPack.MerchItems.Select(merchItem => merchItem.Sku.Value);
            
            var subscribeToSupplyCommand = new SubscribeToSupplyCommand
            {
                SkuCollection = skuList
            };
            var response = await _mediator.Send(subscribeToSupplyCommand, cancellationToken);
            return response;
        }
    }
}