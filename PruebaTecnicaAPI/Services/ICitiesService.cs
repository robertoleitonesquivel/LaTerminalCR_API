using PruebaTecnicaAPI.Models;

namespace PruebaTecnicaAPI.Services
{
	public interface ICitiesService
	{
		Task<List<Cities>> GetCitiesAsync();	
	}
}
