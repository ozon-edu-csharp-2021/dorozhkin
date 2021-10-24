using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public async Task<ActionResult<MerchItem>> RequestMerch(CancellationToken token)
        {
            var merch = await _merchService.RequestMerch(token);

            if (merch is null)
                return NotFound();
            
            return Ok(merch);
        }
        
        [HttpGet]
        public async Task<ActionResult<MerchIssuesInfo>> GetMerchIssuesInfo(CancellationToken token)
        {
            var merchIssuesInfo = await _merchService.GetMerchIssuesInfo(token);
            
            if (merchIssuesInfo is null)
                return NotFound();
            
            return Ok(merchIssuesInfo);
        }
    }
}