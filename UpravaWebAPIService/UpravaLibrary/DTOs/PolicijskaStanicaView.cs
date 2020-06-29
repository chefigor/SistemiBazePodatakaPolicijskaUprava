using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpravaLibrary.Entiteti;

namespace UpravaLibrary.DTOs
{
	public class PolicijskaStanicaView
	{
		public int StanicaId { get; set; }
		public string Naziv { get; set; }
		public string Adresa { get; set; }
		public string Opstina { get; set; }
		public DateTime DatumOsnivanja { get; set; }
		public PolicajacView Sef { get; set; }
		public PolicajacView Zamenik { get; set; }
		public int BrojSluzbenihVozila { get; protected  set; }

		public IList<PolicajacView> Policajci { get; set; }
		public IList<ObjekatView> Objekti { get; set; }
		public IList<SluzbenoVoziloView> SluzbenaVozila { get; set; }

		public PolicijskaStanicaView()
		{
		}

		public PolicijskaStanicaView(PolicijskaStanica p)
		{
			StanicaId = p.StanicaId;
			Naziv = p.Naziv;
			Adresa = p.Adresa;
			Opstina = p.Opstina;
			DatumOsnivanja = p.DatumOsnivanja;
			BrojSluzbenihVozila = p.BrojSluzbenihVozila;
		}
	}
}