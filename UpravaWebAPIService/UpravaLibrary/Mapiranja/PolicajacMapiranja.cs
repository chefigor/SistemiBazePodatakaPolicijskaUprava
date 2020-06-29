using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using FluentNHibernate.Utils;
using UpravaLibrary.Entiteti;

namespace UpravaLibrary.Mapiranja
{
	public class PolicajacMapiranja : ClassMap<Policajac>
	{
		public PolicajacMapiranja()
		{
			Table("POLICAJAC");

			Id(x => x.PolicajacId, "POLICAJACID").GeneratedBy.TriggerIdentity();

			DiscriminateSubClassesOnColumn("TIP_POSLA");

			Map(x => x.Ime, "IME");
			Map(x => x.ImeRoditelja, "IME_RODITELJA");
			Map(x => x.Prezime, "PREZIME");
			Map(x => x.Pol, "POL");
			Map(x => x.Jmbg, "JMBG");
			Map(x => x.Adresa, "ADRESA");
			Map(x => x.DatumRodjenja, "DATUM_RODJENJA");
			Map(x => x.DatumSticanjaDiplome, "DATUM_STICANJA_DIPLOME");
			Map(x => x.Kurs, "KURS");
			Map(x => x.Skola, "SKOLA");
			Map(x => x.NazivObrazovanja, "NAZIV_OBRAZOVANJA");
			Map(x => x.DatumPrijema, "DATUM_PRIJEMA");
			Map(x => x.Pozicija, "POZICIJA");

			References(x => x.PolicijskaStanica).Column("STANICAID").LazyLoad();

			HasMany(x => x.Cinovi).KeyColumn("POLICAJACID").LazyLoad().Cascade.All().Inverse();
		}
	}

	internal class VanredniPolicajacMapiranja : SubclassMap<VanredniPolicajac>
	{
		public VanredniPolicajacMapiranja()
		{
			DiscriminatorValue("VANREDNI");

			HasMany(x => x.Kursevi).KeyColumn("POLICAJACID").LazyLoad().Cascade.All().Inverse();
			HasMany(x => x.Sertifikati).KeyColumn("POLICAJACID").LazyLoad().Cascade.All().Inverse();
			HasMany(x => x.Vestine).KeyColumn("POLICAJACID").LazyLoad().Cascade.All().Inverse();
		}
	}

	internal class PozornikPolicajacjMapiranja : SubclassMap<PozornikPolicajac>
	{
		public PozornikPolicajacjMapiranja()
		{
			DiscriminatorValue("POZORNIK");
			HasMany(x => x.Ulice).KeyColumn("POLICAJACID").LazyLoad().Cascade.All().Inverse();
		}
	}

	internal class ObicanPolicajacMapiranja : SubclassMap<ObicanPolicajac>
	{
		public ObicanPolicajacMapiranja()
		{
			HasOne(x => x.VodjaPatrole).ForeignKey("VODJAID").LazyLoad();

			HasOne(x => x.PartnerUPatroli).ForeignKey("PARNERID").LazyLoad();
			DiscriminatorValue("OBICAN");
		}
	}
}