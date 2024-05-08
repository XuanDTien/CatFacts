using CatFacts.Application.DTO;
using CatFacts.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CatFacts.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICatFactService _catfactService;

        public ApiResult apiResult { get; set; }
        public IndexModel(ICatFactService catfactService)
        {
            _catfactService = catfactService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            apiResult = await _catfactService.FetchAndSave();

            return Page();
        }

    }
}
