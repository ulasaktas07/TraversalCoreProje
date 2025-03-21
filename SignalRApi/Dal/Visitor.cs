﻿namespace SignalRApi.Dal
{
	public enum ECity
	{
		Edirne=1,
		İstanbul=2,
		Ankara=3,
		Antalya=4,
		Rize = 5
	}
	public class Visitor
	{
		public int VisitorID { get; set; }
		public ECity ECity { get; set; }
		public int CityVisitCount { get; set; }
		public DateTime VisitDate { get; set; }
	}
}
