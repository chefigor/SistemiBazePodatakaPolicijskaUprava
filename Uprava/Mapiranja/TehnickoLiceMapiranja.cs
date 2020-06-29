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
	public class TehnickoLiceMapiranja:ClassMap<TehnickoLice>
	{
		public TehnickoLiceMapiranja()
		{
			Table("TEHNICKO_LICE");

			Id(x => x.TehnicarId, "TEHNICARID").GeneratedBy.TriggerIdentity();

			

			Map(x => x.Ime, "IME");
			Map(x => x.KontaktBr, "KONTAKT_BR");
			Map(x => x.Prezime, "PREZIME");
		

			

		}
	}
}
