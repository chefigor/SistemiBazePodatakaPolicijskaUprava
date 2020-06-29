using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpravaLibrary.Entiteti;

namespace UpravaLibrary.DTOs
{
	public class PolicajacView
	{
		public int PolicajacId { get; set; }
		public string Ime { get; set; }
		public string ImeRoditelja { get; set; }
		public string Prezime { get; set; }
		public char Pol { get; set; }
		public string Jmbg { get; set; }
		public string Adresa { get; set; }
		public DateTime DatumRodjenja { get; set; }
		public DateTime DatumSticanjaDiplome { get; set; }
		public string Kurs { get; set; }
		public string Skola { get; set; }
		public string NazivObrazovanja { get; set; }
		public DateTime DatumPrijema { get; set; }
		public string? Pozicija { get; set; }
		public string TipPosla { get; set; }
		public PolicijskaStanicaView PolicijskaStanica { get; set; }

		public IList<CinView> Cinovi { get; set; }

		public PolicajacView()
		{
		}

		public PolicajacView(Policajac p)
		{
			PolicajacId = p.PolicajacId;
			Ime = p.Ime;
			ImeRoditelja = p.ImeRoditelja;
			Prezime = p.Prezime;
			Pol = p.Pol;
			Jmbg = p.Jmbg;
			Adresa = p.Adresa;
			DatumRodjenja = p.DatumRodjenja;
			DatumSticanjaDiplome = p.DatumSticanjaDiplome;
			Kurs = p.Kurs;
			Skola = p.Skola;
			NazivObrazovanja = p.NazivObrazovanja;
			DatumPrijema = p.DatumPrijema;
			Pozicija = p.Pozicija;
			TipPosla = p.TipPosla;
		}
	}

	public class VanredniPolicajacView : PolicajacView
	{
		public IList<VestinaView> Vestine { get; set; }
		public IList<SertifikatView> Sertifikati { get; set; }
		public IList<KursView> Kursevi { get; set; }

		public VanredniPolicajacView()
		{ }

		public VanredniPolicajacView(VanredniPolicajac v) : base(v)
		{
		}
	}

	public class PozornikPolicajacView : PolicajacView
	{
		public IList<UlicaView> Ulice { get; set; }

		public PozornikPolicajacView()
		{ }

		public PozornikPolicajacView(PozornikPolicajac p) : base(p)
		{
		}
	}

	public class ObicanPolicajacView : PolicajacView
	{
		public PatrolaView VodjaPatrole { get; set; }
		public PatrolaView PartnerUPatroli { get; set; }

		public ObicanPolicajacView()
		{ }

		public ObicanPolicajacView(ObicanPolicajac o) : base(o)
		{
		}
	}
}