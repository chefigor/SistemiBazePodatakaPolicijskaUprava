using System;
using System.Collections.Generic;
using System.Text;
using UpravaLibrary.Entiteti;

namespace UpravaLibrary.DTOs
{
	public class SkolskiPolicajacView : PolicajacView
	{
		public string SrednjaIliOsnovna { get; set; }
		public string NazivSkole { get; set; }
		public string AdresaSkole { get; set; }
		public string OsobaZaKontakt { get; set; }
		public string BrojTelefonaSkole { get; set; }

		public SkolskiPolicajacView()
		{
		}

		public SkolskiPolicajacView(SkolskiPolicajac s) : base(s)
		{
			SrednjaIliOsnovna = s.SrednjaIliOsnovna;
			NazivSkole = s.NazivSkole;
			AdresaSkole = s.AdresaSkole;
			OsobaZaKontakt = s.OsobaZaKontakt;
			BrojTelefonaSkole = s.BrojTelefonaSkole;
		}
	}
}