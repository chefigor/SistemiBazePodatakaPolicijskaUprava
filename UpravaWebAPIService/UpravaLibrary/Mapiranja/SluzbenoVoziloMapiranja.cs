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
	public class SluzbenoVoziloMapiranja : ClassMap<SluzbenoVozilo>
	{
		public SluzbenoVoziloMapiranja()
		{
			Table("SLUZBENO_VOZILO");

			Id(x => x.VoziloId, "VOZILOID").GeneratedBy.TriggerIdentity();

			Map(x => x.RegistarskaOznaka, "REGISTARSKA_OZNAKA");
			Map(x => x.Proizvodjac, "PROIZVODJAC");
			Map(x => x.Boja, "BOJA");
			Map(x => x.Tip, "TIP");
			Map(x => x.Model, "MODEL");

			//References(x => x.Patrola).Column("PATROLAID");
			References(x => x.Stanica).Column("STANICAID").LazyLoad();
			HasOne(x => x.Patrola).PropertyRef(nameof(Patrola.Vozilo));
		}
	}
}