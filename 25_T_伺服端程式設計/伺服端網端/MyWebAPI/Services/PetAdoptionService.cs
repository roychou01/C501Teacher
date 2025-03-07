using MyWebAPI.APIModels;
using Newtonsoft.Json;

namespace MyWebAPI.Services
{
    public class PetAdoptionService
    {
        private readonly HttpClient _client;

        public PetAdoptionService(HttpClient client)
        {
            _client = client;
        }


        public async Task<IEnumerable<PetAdoptionData>> GetData(string? param,int page = 1, int pageSize = 50)
        {

            int skip = getItemSkip(page);
            string url = $"https://data.moa.gov.tw/Service/OpenData/TransService.aspx?UnitId=QcbUEzN6E6DL&$top={pageSize}&$skip={skip}{param}";
            var resp = await _client.GetStringAsync(url);
            var collection = JsonConvert.DeserializeObject<IEnumerable<PetAdoptionData>>(resp);

            return collection;

        }


        private int getItemSkip(int page, int pageSize = 50)
        {
            return pageSize * (page - 1);
        }

    }
}
