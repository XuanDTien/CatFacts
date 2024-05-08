using CatFacts.Application.DTO;
using CatFacts.Application.Services.Interfaces;
using CatFacts.Domain.Entities;
using Newtonsoft.Json;

namespace CatFacts.Application.Services
{
    public class CatFactService : ICatFactService
    {

        private readonly HttpClient _httpClient;

        public CatFactService(HttpClient httpClient) {  _httpClient = httpClient; }

        public async Task<ApiResult> FetchAndSave()
        {
            try
            {
                string catFactUrl = "https://catfact.ninja/fact";

                HttpResponseMessage response = await _httpClient.GetAsync(catFactUrl);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();

                    CatFactDto catFactDto = JsonConvert.DeserializeObject<CatFactDto>(json);

                    string file = "catfact.txt";

                    using (StreamWriter writer = File.AppendText(file))
                    {
                        await writer.WriteLineAsync(json);
                    }

                    return new ApiResult(true, "Saved to file", catFactDto);
                }
                else
                {
                    return new ApiResult(false, "Cannot fetch the data");
                }
            }
            catch (Exception ex)
            {
                return new ApiResult(false, ex.Message);
            }
        }

    }
}
