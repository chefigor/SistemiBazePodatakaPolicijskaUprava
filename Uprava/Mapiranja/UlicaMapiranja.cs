using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Uprava.Entiteti;

namespace Uprava.Mapiranja
{
   public class UlicaMapiranja : ClassMap<Ulica>
    {
        public UlicaMapiranja()
        {
            Table("ULICA");
            Id(x => x.UlicaId, "ULICAID").GeneratedBy.TriggerIdentity();

            Map(x => x.Naziv, "NAZIV");
            References(x => x.PripadaPolicajcu).Column("POLICAJACID").LazyLoad();

        }
    }
}
