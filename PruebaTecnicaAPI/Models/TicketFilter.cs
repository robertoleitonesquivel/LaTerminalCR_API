namespace PruebaTecnicaAPI.Models
{
	public class TicketFilter
	{
		public string id { get; set; }
		public Company company { get; set; }
		public From from { get; set; }
		public To to { get; set; }
		public int availableSeats { get; set; }
		public bool withBPE { get; set; }
		public Departure departure { get; set; }
		public Arrival arrival { get; set; }
		public int travelDuration { get; set; }
		public string travelDistance { get; set; }
		public string seatClass { get; set; }
		public Price price { get; set; }
		public double insurance { get; set; }
		public bool allowCanceling { get; set; }
		public string travelCancellationLimitDate { get; set; }
		public int travelCancellationFee { get; set; }
		public bool manualConfirmation { get; set; }
		public DateTime? orderDate { get; set; }	
	}

	public class To
	{
		public string id { get; set; }
		public string name { get; set; }
	}
	public class Arrival
	{
		public string date { get; set; }
		public string time { get; set; }
	}

	public class Company
	{
		public string id { get; set; }
		public string name { get; set; }
	}

	public class Departure
	{
		public string date { get; set; }
		public string time { get; set; }
	}

	public class From
	{
		public string id { get; set; }
		public string name { get; set; }
	}

	public class Price
	{
		public decimal seatPrice { get; set; }
		public decimal taxPrice { get; set; }
		public decimal price { get; set; }
	}
}
