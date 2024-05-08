using CatFacts.Application.DTO;

namespace CatFacts.Application.Services.Interfaces
{
    public interface ICatFactService
    {
        Task<ApiResult> FetchAndSave();
    }
}
