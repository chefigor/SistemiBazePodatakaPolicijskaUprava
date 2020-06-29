using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using UpravaLibrary.Entiteti;

namespace UpravaLibrary.Mapiranja
{
	public class UlicaMapiranja : ClassMap<Ulica>
	{
		public UlicaMapiranja()
		{
			Table("ULICA");
			Id(x => x.UlicaId, "ULICAID").GeneratedBy.TriggerIdentity();

			Map(x => x.Naziv, "NAZIV");
			References(x => x.Policajac).Column("POLICAJACID").LazyLoad();
		}
	}
}