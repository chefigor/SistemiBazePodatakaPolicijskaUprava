using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Uprava.Entiteti;

namespace Uprava.Mapiranja
{
	public  class AlarmniSistemMapiranja:ClassMap<AlarmniSistem>
	{
		public AlarmniSistemMapiranja()
		{
			Table("ALARMNI_SISTEM");

			Id(x => x.SerijskiBr, "SERIJSKIBR").GeneratedBy.Assigned();
			
			DiscriminateSubClassesOnColumn("TIP");

			Map(x => x.Proizvodjac, "PROIZVODJAC");
			Map(x => x.Model, "MODEL");
			Map(x => x.GodinaProizvodnje, "GODINA_PROIZVODNJE");
			Map(x => x.DatumInstalacije, "DATUM_INSTALACIJE");
			Map(x => x.DatumPoslednjegTesta, "DATUM_POSLEDNJEG_TESTA");
			Map(x => x.DatumPoslednjegServisiranja, "DATUM_POSLEDNJEG_SERVISIRANJA");
			Map(x => x.OtklonjenKvar, "OTKLONJEN_KVAR");
			

			References(x => x.PripadaObjektu).Column("OBJEKATID").LazyLoad();

			HasMany(x => x.Zaduzen).KeyColumn("SERIJSKIBR").Cascade.All().Inverse();
		}

	}

	class ToplotniAlarmniSisetmMapiranja:SubclassMap<ToplotniAlarmniSistem>
	{
		public ToplotniAlarmniSisetmMapiranja()
		{
			DiscriminatorValue("TOPLOTNI");
			Map(x => x.HorizontalnaRezolucija, "HORIZONTALNA_REZOLUCIJA");
			Map(x => x.VertikalnaRezolucija, "VERTIKALNA_REZOLUCIJA");
		}
	}

	class UltrazvucniAlarmniSistemMapiranja : SubclassMap<UltrazvucniAlarmniSistem>
	{
		public UltrazvucniAlarmniSistemMapiranja()
		{
			DiscriminatorValue("ULTRAZVUCNI");
			Map(x => x.Frekvencija, "FREKVENCIJA");

		}
	}

	class DetekcijaPokretaAlarmniSistemMapiranja : SubclassMap<DetekcijaPokretaAlarmniSistem>
	{
		public DetekcijaPokretaAlarmniSistemMapiranja()
		{
			DiscriminatorValue("DETEKCIJA_POKRETA");
			Map(x => x.Osetljivost, "OSETLJIVOST");

		}
	}
}
