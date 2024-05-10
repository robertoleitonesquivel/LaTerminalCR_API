using PruebaTecnicaAPI.Common;
using PruebaTecnicaAPI.Models;
using System.Text.Json;

namespace PruebaTecnicaAPI.Services
{
	public class CitiesService : ICitiesService
	{

		private readonly ICommon _common;

        public CitiesService(ICommon common)
        {
            _common = common;
        }

        public async Task<List<Cities>> GetCitiesAsync()
		{
			var response = await _common.ExecuteHttpRequestAsync(HttpMethod.Get, "stops");
			return JsonSerializer.Deserialize<List<Cities>>(await response.Content.ReadAsStringAsync());
		}

		public async Task<DetailCities> GetDetailCities(string id)
		{
			var response = await _common.ExecuteHttpRequestAsync(HttpMethod.Get, $"stops/{id}");
			return JsonSerializer.Deserialize<DetailCities>(await response.Content.ReadAsStringAsync());
		}
	}
}
