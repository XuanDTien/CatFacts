using CatFacts.Application.DTO;
using CatFacts.Application.Services;
using CatFacts.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatFacts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatFactController : Controller
    {
        private readonly ICatFactService _catFactService;

        public CatFactController(ICatFactService catFactService)
        {
            _catFactService = catFactService;
        }

        [HttpGet]
        public async Task<ApiResult> GetCatFact()
        {
            ApiResult result = await _catFactService.FetchAndSave();
            return result;
        }
    }
}
