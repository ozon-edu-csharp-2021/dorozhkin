using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OzonEdu.MerchApi.HttpModels;
using OzonEdu.MerchApi.Models;
using OzonEdu.MerchApi.Services.Interfaces;

namespace OzonEdu.MerchApi.Controllers.V1
{
    [ApiController]
    [Route("v1/api/merch")]
    public class MerchController : ControllerBase
    {
        private readonly IMerchService _merchService;

        public MerchController(IMerchService merchService)
        {
            _merchService = merchService;
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<MerchItemResponse>> RequestMerch(long id, CancellationToken token)
        {
            var merchItem = await _merchService.RequestMerch(id, token);

            if (merchItem is null)
                return NotFound();

            var merchItemResponse = new MerchItemResponse
            {
                MerchName = merchItem.MerchName,
            };

            return Ok(merchItemResponse);
        }
        
        [HttpPost]
        public async Task<ActionResult<MerchIssueInfoResponse>> GetMerchIssueInfo(MerchIssuePostViewModel merchIssuePostViewModel, CancellationToken token)
        {
            var merchIssuesInfo = await _merchService.GetMerchIssuesInfo(new MerchIssueModel
            {
                MerchName = merchIssuePostViewModel.MerchName,
                DateIssue = merchIssuePostViewModel.DateIssue
            }, token);
            
            if (merchIssuesInfo is null)
                return NotFound();

            var merchIssueInfoResponse = new MerchIssueInfoResponse
            {
                MerchName = merchIssuesInfo.MerchName,
                Quantity = merchIssuesInfo.Quantity
            };
            
            return Ok(merchIssueInfoResponse);
        }
    }
}