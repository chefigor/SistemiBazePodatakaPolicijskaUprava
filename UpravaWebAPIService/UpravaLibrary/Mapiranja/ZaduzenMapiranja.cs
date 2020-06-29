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
	public class ZaduzenMapiranja : ClassMap<Zaduzen>
	{
		public ZaduzenMapiranja()
		{
			Table("ZADUZEN");

			Id(x => x.ZaduzenId, "ZADUZENID").GeneratedBy.TriggerIdentity();

			Map(x => x.DatumOd, "DATUM_OD");
			Map(x => x.DatumDo, "DATUM_DO");

			References(x => x.Alarm).Column("SERIJSKIBR").LazyLoad();
			References(x => x.Tehnicar).Column("TEHNICARID").LazyLoad();
		}
	}
}