using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OzonEdu.MerchApi.HttpModels;
using OzonEdu.MerchApi.Infrastructure.Commands.GetMerchRequestInfoCommand;
using OzonEdu.MerchApi.Infrastructure.Commands.RequestMerchCommand;

namespace OzonEdu.MerchApi.Controllers.V1
{
    [ApiController]
    [Route("v1/api/merch")]
    public class MerchController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MerchController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost("RequestMerch")]
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

        [HttpPost("GetMerchIssueInfo")]
        public async Task<ActionResult<MerchIssueInfoResponse>> RequestMerchIssueInfo(
            MerchIssuePostViewModel merchIssue, CancellationToken token)
        {
            var getMerchRequestInfoCommand = new GetMerchRequestInfoCommand
            {
                EmployeeName = merchIssue.EmployeeName
            };

            var response = await _mediator.Send(getMerchRequestInfoCommand, token);

            var merchIssueInfoResponse = new MerchIssueInfoResponse
            {
                MerchPacks = response.MerchPacks
            };

            return Ok(merchIssueInfoResponse);
        }
    }
}