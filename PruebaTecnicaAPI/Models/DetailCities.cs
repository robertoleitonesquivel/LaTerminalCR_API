using static System.Collections.Specialized.BitVector32;

namespace PruebaTecnicaAPI.Models
{
	public class DetailCities
	{
		public string id { get; set; }
		public string displayName { get; set; }
		public string name { get; set; }
		public string state { get; set; }
		public string url { get; set; }
		public string latitude { get; set; }
		public string longitude { get; set; }
		public string type { get; set; }
		public List<Station> station { get; set; }
	}

	public class Station
	{
		public string id { get; set; }
		public string displayName { get; set; }
		public string name { get; set; }
		public string state { get; set; }
		public string country { get; set; }
		public string url { get; set; }
		public string latitude { get; set; }
		public string longitude { get; set; }
		public string address { get; set; }
		public string zipcode { get; set; }
		public string type { get; set; }
		public List<string> images { get; set; }
	}
}
