namespace PruebaTecnicaAPI.Models
{
	public class Cities
	{
		public string id { get; set; }
		public string name { get; set; }
		public string url { get; set; }
		public string type { get; set; }
		public List<Substop> substops { get; set; }
	}

	public class Substop
	{
		public string id { get; set; }
		public string name { get; set; }
		public string url { get; set; }
		public string type { get; set; }
	}
}
