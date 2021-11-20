using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OzonEdu.MerchApi.HttpModels;
using OzonEdu.MerchApi.Infrastructure.Commands.GetMerchRequestInfoCommand;
using OzonEdu.MerchApi.Infrastructure.Commands.RequestMerchCommand;
using MerchIssueInfo = OzonEdu.MerchApi.HttpModels.MerchIssueInfo;

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
            RequestMerchRequest requestMerch, CancellationToken token)
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

            var merchIssuesInfo = response.MerchIssuesInfo
                .Select(merchIssueInfo => new MerchIssueInfo
                {
                    MerchPack = merchIssueInfo.MerchPack,
                    Status = merchIssueInfo.Status
                }).ToList();

            var merchIssueInfoResponse = new MerchIssueInfoResponse
            {
                MerchIssuesInfo = merchIssuesInfo
            };

            return Ok(merchIssueInfoResponse);
        }
    }
}