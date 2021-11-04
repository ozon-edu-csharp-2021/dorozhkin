using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OzonEdu.MerchApi.HttpModels;
using OzonEdu.MerchApi.Infrastructure.Commands;
using OzonEdu.MerchApi.Infrastructure.Commands.RequestMerchCommand;
using OzonEdu.MerchApi.Services.Interfaces;

namespace OzonEdu.MerchApi.Controllers.V1
{
    [ApiController]
    [Route("v1/api/merch")]
    public class MerchController : ControllerBase
    {
        private readonly IMerchService _merchService;
        private readonly IMediator _mediator;

        public MerchController(IMerchService merchService, IMediator mediator)
        {
            _merchService = merchService;
            _mediator = mediator;
        }
        
        [HttpPost("request")]
        public async Task<ActionResult<RequestMerchResponse>> RequestMerch(
            RequestMerchPostViewModel requestMerch, CancellationToken token)
        {
            var requestMerchCommand = new RequestMerchCommand
            {
                EmployeeId = requestMerch.EmployeeId,
                MerchPackId = requestMerch.MerchPackId
            };

            var result = await _mediator.Send(requestMerchCommand, token);

            var requestMerchResponse = new RequestMerchResponse
            {
                Status = result.Status
            };

            return Ok(requestMerchResponse);
        }

        // [HttpGet("{id:long}")]
        // public async Task<ActionResult<MerchItemResponse>> RequestMerch(long id, CancellationToken token)
        // {
        //     var merchItem = await _merchService.RequestMerch(id, token);
        //
        //     if (merchItem is null)
        //         return NotFound();
        //
        //     var merchItemResponse = new MerchItemResponse
        //     {
        //         MerchName = merchItem.MerchName,
        //     };
        //
        //     return Ok(merchItemResponse);
        // }

        // [HttpPost]
        // public async Task<ActionResult<MerchIssueInfoResponse>> GetMerchIssueInfo(
        //     MerchIssuePostViewModel merchIssuePostViewModel, CancellationToken token)
        // {
        //     var merchIssuesInfo = await _merchService.GetMerchIssuesInfo(new MerchIssueModel
        //         (merchIssuePostViewModel.MerchName, merchIssuePostViewModel.EmployeeName), token);
        //
        //     if (merchIssuesInfo is null)
        //         return NotFound();
        //
        //     var merchIssueInfoResponse = new MerchIssueInfoResponse
        //     {
        //         MerchName = merchIssuesInfo.MerchName,
        //         Quantity = merchIssuesInfo.Quantity
        //     };
        //
        //     return Ok(merchIssueInfoResponse);
        // }
        //
        
        //
        // [HttpPost]
        // public async Task<ActionResult<MerchIssueInfoResponse>> GetMerchPackInfo(
        //     MerchIssuePostViewModel merchIssuePostViewModel, CancellationToken token)
        // {
        //     var getMerchPackInfoCommand = new GetMerchPackInfoCommand
        //     {
        //         Name = merchIssuePostViewModel.MerchName
        //     };
        //     
        //     var result = await _mediator.Send(getMerchPackInfoCommand, token);
        //
        //     var merchIssueInfoResponse = new MerchIssueInfoResponse
        //     {
        //         MerchName = result.Name
        //     };
        //
        //     return Ok(merchIssueInfoResponse);
        // }
    }
}