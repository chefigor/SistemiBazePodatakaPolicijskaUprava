using System;
using System.Collections.Generic;
using System.Text;
using UpravaLibrary.Entiteti;

namespace UpravaLibrary.DTOs
{
	public class KursView
	{
		public int KursId { get; set; }
		public VanredniPolicajacView Policajac { get; set; }
		public string Naziv { get; set; }
		public DateTime DatumZavrsetka { get; set; }

		public KursView()
		{
		}

		public KursView(Kurs k)
		{
			KursId = k.KursId;
			Naziv = k.Naziv;
			DatumZavrsetka = k.DatumZavrsetka;
		}
	}
}