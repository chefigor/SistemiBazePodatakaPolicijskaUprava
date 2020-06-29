using System;
using System.Collections.Generic;
using System.Text;
using UpravaLibrary.Entiteti;

namespace UpravaLibrary.DTOs
{
	public class ObjekatView
	{
		public int ObjekatId { get; set; }
		public string Adresa { get; set; }
		public double Povrsina { get; set; }
		public string TipObjekta { get; set; }
		public PolicijskaStanicaView PolicijskaStanica { get; set; }
		public string Ime { get; set; }
		public string Prezime { get; set; }
		public string Broj { get; set; }
		public IList<IntervencijaView> Intervencije { get; set; }
		public IList<AlarmniSistemView> Alarmi { get; set; }

		public ObjekatView()
		{
		}

		public ObjekatView(Objekat o)
		{
			ObjekatId = o.ObjekatId;
			Adresa = o.Adresa;
			Povrsina = o.Povrsina;
			TipObjekta = o.TipObjekta;
			Ime = o.Ime;
			Prezime = o.Prezime;
			Broj = o.Broj;
		}
	}
}