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
	public class PatrolaMapiranja:ClassMap<Patrola>
	{
		public PatrolaMapiranja()
		{
			Table("PATROLA");

			Id(x => x.PatrolaId, "PATROLAID").GeneratedBy.TriggerIdentity();

			References(x => x.Vodja).Column("VODJAID").LazyLoad();
			References(x => x.Partner).Column("PARTNERID").LazyLoad();
			References(x => x.Vozilo).Column("VOZILOID").LazyLoad();

            HasMany(x => x.ImalaIntervencije).KeyColumn("INTERVENCIJAID").Cascade.All().Inverse();
            
        }
	}
}
