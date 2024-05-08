using CatFacts.Domain.Entities;

namespace CatFacts.Application.DTO
{
    public class ApiResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public CatFactDto? CatFactDto { get; set; }

        public ApiResult(bool success, string message, CatFactDto catFactDto)
        {
            Success = success;
            Message = message;
            CatFactDto = catFactDto;
        }

        public ApiResult(bool success, string message) { Success = success; Message = message;}
    }
}
