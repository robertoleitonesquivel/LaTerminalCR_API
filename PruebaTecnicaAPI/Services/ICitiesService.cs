using PruebaTecnicaAPI.Models;

namespace PruebaTecnicaAPI.Services
{
	public interface ICitiesService
	{
		Task<List<Cities>> GetCitiesAsync();
		Task<DetailCities> GetDetailCities(string id);

	}
}
