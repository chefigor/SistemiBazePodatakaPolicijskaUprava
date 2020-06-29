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
	public class ObjekatMapiranja : ClassMap<Objekat>
	{
		public ObjekatMapiranja()
		{
			Table("OBJEKAT");

			Id(x => x.ObjekatId, "OBJEKATID").GeneratedBy.TriggerIdentity();

			Map(x => x.Adresa, "ADRESA");
			Map(x => x.Povrsina, "POVRSINA");
			Map(x => x.TipObjekta, "TIP_OBJEKTA");
			Map(x => x.Ime, "IME");
			Map(x => x.Prezime, "PREZIME");
			Map(x => x.Broj, "BROJ");

			References(x => x.PolicijskaStanica).Column("STANICAID").LazyLoad();

			HasMany(x => x.Alarmi).KeyColumn("OBJEKATID").LazyLoad().Cascade.All().Inverse();
			HasMany(x => x.Intervencije).KeyColumn("OBJEKATID").LazyLoad().Cascade.All().Inverse();
		}
	}
}