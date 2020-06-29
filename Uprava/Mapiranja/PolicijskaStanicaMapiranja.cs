using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using FluentNHibernate.Utils;
using Uprava.Entiteti;

namespace Uprava.Mapiranja
{
	public class PolicijskaStanicaMapiranja : ClassMap<PolicijskaStanica>
	{
		public PolicijskaStanicaMapiranja()
		{
			Table("POLICIJSKA_STANICA");

			Id(x => x.StanicaId, "STANICAID").GeneratedBy.TriggerIdentity();

			Map(x => x.Naziv, "NAZIV");
			Map(x => x.Adresa, "ADRESA");
			Map(x => x.Opstina, "OPSTINA");
			Map(x => x.DatumOsnivanja, "DATUM_OSNIVANJA");
			Map(x => x.BrojSluzbenihVozila, "BROJ_SLUZBENIH_VOZILA");

			References(x => x.Sef).Column("SEFID").LazyLoad();
			References(x => x.Zamenik).Column("ZAMENIKID").LazyLoad();

			HasMany(x => x.Policajci).KeyColumn("STANICAID").LazyLoad().Cascade.All().Inverse();
			HasMany(x => x.DrziObjekte).KeyColumn("STANICAID").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.SluzbenaVozila).KeyColumn("STANICAID").LazyLoad().Cascade.All().Inverse();

        }
	}
}
