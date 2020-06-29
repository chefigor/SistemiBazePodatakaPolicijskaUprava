﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpravaLibrary.Entiteti;
using FluentNHibernate.Mapping;

namespace UpravaLibrary.Mapiranja
{
	public class KursMapiranja : ClassMap<Kurs>
	{
		public KursMapiranja()
		{
			Table("KURS");

			Id(x => x.KursId, "KURSID").GeneratedBy.TriggerIdentity();

			Map(x => x.Naziv, "NAZIV");
			Map(x => x.DatumZavrsetka, "DATUM_ZAVRSETKA");

			References(x => x.Policajac).Column("POLICAJACID").LazyLoad();
		}
	}
}