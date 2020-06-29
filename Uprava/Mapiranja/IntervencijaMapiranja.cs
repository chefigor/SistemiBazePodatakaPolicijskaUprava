using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Uprava.Entiteti;

namespace Uprava.Mapiranja
{
	public class IntervencijaMapiranja:ClassMap<Intervencija>
	{
		public IntervencijaMapiranja()
		{
			Table("INTERVENCIJA");

            Id(x => x.IntervencijaId , "INTERVENCIJAID").GeneratedBy.TriggerIdentity();
          

			Map(x => x.Vreme, "VREME");
			Map(x => x.Datum, "DATUM");
			Map(x => x.Opis, "OPIS");

			References(x => x.Patrola).Column("PATROLAID").LazyLoad();
			References(x => x.Objekat).Column("OBJEKATID").LazyLoad();
		}
	}
}
