using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common.Controllers;
using System.Threading.Tasks;
using Umbraco_Azure_test.Services;
using Umbraco_Azure_test.Models;

namespace Umbraco_Azure_test.Controllers
{
    [Route("umbraco/api/[controller]/[action]")]
    public class ExternalApiApiController : UmbracoApiController
    {
        private readonly IExternalApiService _externalApiService;

        public ExternalApiApiController(IExternalApiService externalApiService)
        {
            _externalApiService = externalApiService;
        }

        [HttpGet]
        public async Task<ActionResult<JokeModel>> GetJoke()
        {
            var joke = await _externalApiService.GetJokeAsync();
            return Ok(joke);
        }
    }
}
