using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchApi.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchPackAggregate;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchPackAggregate.Entities;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchRequestAggregate;
using OzonEdu.MerchApi.Infrastructure.Commands.GetMerchRequestInfoCommand;

namespace OzonEdu.MerchApi.Infrastructure.Handlers.MerchRequestAggregate
{
    public class GetMerchRequestInfoCommandHandler : IRequestHandler<GetMerchRequestInfoCommand, GetMerchRequestInfoCommandResponse>
    {
        private readonly IMerchRequestRepository _requestRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMerchPackRepository _merchPackRepository;

        public GetMerchRequestInfoCommandHandler(IMerchRequestRepository requestRepository, IEmployeeRepository employeeRepository, IMerchPackRepository merchPackRepository)
        {
            _requestRepository = requestRepository;
            _employeeRepository = employeeRepository;
            _merchPackRepository = merchPackRepository;
        }

        public async Task<GetMerchRequestInfoCommandResponse> Handle(GetMerchRequestInfoCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.FindByNameAsync(request.EmployeeName, cancellationToken);

            if (employee is null)
                throw new Exception("Employee was not found");
            
            var merchRequests = await _requestRepository.FindByEmployeeIdAsync(employee.Id, cancellationToken);
            
            if (merchRequests.Count == 0)
                throw new Exception("Merch requests was not found");

            var merchPacks = new List<MerchPack>();
            
            foreach (var merchRequest in merchRequests)
            {
                var merchPack = await _merchPackRepository.FindByIdAsync(merchRequest.MerchPackId, cancellationToken);
                merchPacks.Add(merchPack);
            }

            var response = new GetMerchRequestInfoCommandResponse
            {
                MerchPacks = merchPacks.Select(merchPack => merchPack.NamePack.Value).ToList()
            };

            return response;
        }
    }
}