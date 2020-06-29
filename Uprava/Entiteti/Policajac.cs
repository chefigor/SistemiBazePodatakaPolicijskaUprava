using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uprava.Entiteti
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
		public virtual PolicijskaStanica PripadaPolicijskaStanica { get; set; }
		public virtual Patrola VodjaPatrole { get; set; }
		public virtual Patrola PartnerUPatroli { get; set; }

		public virtual IList<Cin> Cinovi { get; set; }

		public Policajac()
		{
			Cinovi = new List<Cin>();
		}

		#region ToStringFunc

		public override string ToString()
		{
			StringBuilder displayStringBuilder = new StringBuilder();
			displayStringBuilder.AppendFormat("Id:{0},Ime:{1},Ime Roditelja:{2},Prezime:{3},Pol:{4},JMBG:{5},Adresa{6}",
				PolicajacId, Ime, ImeRoditelja[0], Prezime, Pol, Jmbg, Adresa);
			displayStringBuilder.AppendLine();
			displayStringBuilder.AppendFormat(
				"Datum rodjenja:{0},Datum sticanja diplome:{1},Kurs:{2},Skola:{3},Naziv obrazovanja:{4}", DatumRodjenja,
				DatumSticanjaDiplome, Kurs, Skola, NazivObrazovanja);
			displayStringBuilder.AppendLine();
			if (String.IsNullOrEmpty(Pozicija))
			{
				displayStringBuilder.AppendFormat("Pozicija:{0}", Pozicija);
				displayStringBuilder.AppendLine();

			}

			if (String.IsNullOrEmpty(TipPosla))
			{
				displayStringBuilder.AppendFormat("Tip posla:{0}", TipPosla);
				displayStringBuilder.AppendLine();

			}

			displayStringBuilder.AppendFormat("Pripada policijskoj stanici id:{0} , naziv:{1}",
				PripadaPolicijskaStanica.StanicaId, PripadaPolicijskaStanica.Naziv);
			displayStringBuilder.AppendLine();

			if (VodjaPatrole != null)
			{
				displayStringBuilder.AppendFormat("Vodja patrole sa id-jem:{0}", VodjaPatrole.PatrolaId);
				displayStringBuilder.AppendLine();
			}

			if (PartnerUPatroli != null)
			{
				displayStringBuilder.AppendFormat("Partner u patroli sa id-jem :{0}", PartnerUPatroli.PatrolaId);
				displayStringBuilder.AppendLine();
			}

			if (Cinovi.Count != 0)
			{
				displayStringBuilder.AppendFormat("Cinvoi:");
				displayStringBuilder.AppendLine();
				foreach (var cin in Cinovi)
				{
					displayStringBuilder.AppendFormat("Naziv:{0},Datum sticanja:{1}", cin.Naziv,
						cin.DatumSticanja);
					displayStringBuilder.AppendLine();
				}
			}

			return displayStringBuilder.ToString();


		}

		#endregion
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

		#region toStringFunc

		public override string ToString()
		{
			StringBuilder displayStringBuilder = new StringBuilder();
			displayStringBuilder.AppendLine();
			if (Vestine.Count != 0)
			{
				displayStringBuilder.AppendFormat("Vestine:");
				displayStringBuilder.AppendLine();
				foreach (var vestina in Vestine)
				{
					displayStringBuilder.AppendFormat("Naziv:{0}", vestina.Naziv);
					displayStringBuilder.AppendLine();
				}
			}

			if (Sertifikati.Count != 0)
			{
				displayStringBuilder.AppendFormat("Sertifikati:");
				displayStringBuilder.AppendLine();
				foreach (var sertifikat in Sertifikati)
				{
					displayStringBuilder.AppendFormat("Naziv:{0},Datum sticanja:{1}", sertifikat.Naziv,
						sertifikat.DatumSticanja);
					displayStringBuilder.AppendLine();
				}
			}

			if (Kursevi.Count != 0)
			{
				displayStringBuilder.AppendFormat("Kursevi:");
				displayStringBuilder.AppendLine();
				foreach (var kurs in Kursevi)
				{
					displayStringBuilder.AppendFormat("Naziv:{0},Datum zavrsetka:{1}", kurs.Naziv, kurs.DatumZavrsetka);
					displayStringBuilder.AppendLine();
				}
			}

			return base.ToString() + displayStringBuilder.ToString();
		}

		#endregion
	}


	public class PozornikPolicajac : Policajac
		{
			public virtual IList<Ulica> Ulice { get; set; }

			public PozornikPolicajac()
			{
				Ulice = new List<Ulica>();
			}

			#region toStringFunc

			public override string ToString()
			{
				StringBuilder displayStringBuilder = new StringBuilder();
				displayStringBuilder.AppendLine();
				if (Ulice.Count != 0)
				{
					displayStringBuilder.AppendFormat("Ulice:");
					displayStringBuilder.AppendLine();
					foreach (var ulica in Ulice)
					{
						displayStringBuilder.AppendFormat("Naziv ulice:{0}",ulica.Naziv);
						displayStringBuilder.AppendLine();
					}
				}

				return base.ToString() + displayStringBuilder.ToString();
			}

			#endregion
	}

	public class ObicanPolicajac : Policajac
	{
		
	}
}


