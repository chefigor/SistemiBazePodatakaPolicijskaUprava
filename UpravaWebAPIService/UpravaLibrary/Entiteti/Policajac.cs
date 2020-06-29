using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpravaLibrary.Entiteti
{
	public class Policajac
	{
		public virtual int PolicajacId { get; set; }
		public virtual string Ime { get; set; }
		public virtual string ImeRoditelja { get; set; }
		public virtual string Prezime { get; set; }
		public virtual char Pol { get; set; }
		public virtual string Jmbg { get; set; }
		public virtual string Adresa { get; set; }
		public virtual DateTime DatumRodjenja { get; set; }
		public virtual DateTime DatumSticanjaDiplome { get; set; }
		public virtual string Kurs { get; set; }
		public virtual string Skola { get; set; }
		public virtual string NazivObrazovanja { get; set; }
		public virtual DateTime DatumPrijema { get; set; }
		public virtual string? Pozicija { get; set; }
		public virtual string TipPosla { get; set; }
		public virtual PolicijskaStanica PolicijskaStanica { get; set; }

		public virtual IList<Cin> Cinovi { get; set; }

		public Policajac()
		{
			Cinovi = new List<Cin>();
		}
	}

	public class VanredniPolicajac : Policajac
	{
		public virtual IList<Vestina> Vestine { get; set; }
		public virtual IList<Sertifikat> Sertifikati { get; set; }
		public virtual IList<Kurs> Kursevi { get; set; }

		public VanredniPolicajac()
		{
			Vestine = new List<Vestina>();
			Sertifikati = new List<Sertifikat>();
			Kursevi = new List<Kurs>();
		}
	}

	public class PozornikPolicajac : Policajac
	{
		public virtual IList<Ulica> Ulice { get; set; }

		public PozornikPolicajac()
		{
			Ulice = new List<Ulica>();
		}
	}

	public class ObicanPolicajac : Policajac
	{
		public virtual Patrola VodjaPatrole { get; set; }
		public virtual Patrola PartnerUPatroli { get; set; }
	}
}