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
	public class SertifikatMapiranja : ClassMap<Sertifikat>
	{
		public SertifikatMapiranja()
		{
			Table("SERTIFIKAT");

			Id(x => x.SertifikatId, "SERTIFIKATID").GeneratedBy.TriggerIdentity();

			Map(x => x.DatumSticanja, "DATUM_STICANJA");
			Map(x => x.Naziv, "NAZIV");

			References(x => x.Policajac).Column("POLICAJACID");
		}
	}
}