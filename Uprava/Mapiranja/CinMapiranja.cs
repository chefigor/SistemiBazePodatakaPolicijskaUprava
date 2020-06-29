using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Uprava.Entiteti;

namespace Uprava.Mapiranja
{
	public class CinMapiranja:ClassMap<Cin>
	{
		public CinMapiranja()
		{
			Table("CIN");

			Id(x => x.CinId, "CINID").GeneratedBy.TriggerIdentity();

			Map(x => x.Naziv, "NAZIV");
			Map(x => x.DatumSticanja, "DATUM_STICANJA");

			References(x => x.PripadaPolicajcu).Column("POLICAJACID").LazyLoad();
		}
	}
}
