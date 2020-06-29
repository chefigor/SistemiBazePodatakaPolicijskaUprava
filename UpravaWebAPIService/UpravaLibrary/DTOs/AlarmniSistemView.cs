using System;
using System.Collections.Generic;
using System.Text;
using UpravaLibrary.Entiteti;

namespace UpravaLibrary.DTOs
{
	public class AlarmniSistemView
	{
		public string SerijskiBr { get; set; }

		public string Proizvodjac { get; set; }
		public string Model { get; set; }
		public string GodinaProizvodnje { get; set; }
		public DateTime DatumInstalacije { get; set; }
		public string Tip { get; set; }

		public ObjekatView Objekat { get; set; }
		public DateTime DatumPoslednjegTesta { get; set; }
		public DateTime DatumPoslednjegServisiranja { get; set; }
		public string OtklonjenKvar { get; set; }
		public IList<ZaduzenView> Zaduzen { get; set; }

		public AlarmniSistemView()
		{
			Zaduzen = new List<ZaduzenView>();
		}

		public AlarmniSistemView(AlarmniSistem a)
		{
			SerijskiBr = a.SerijskiBr;
			Proizvodjac = a.Proizvodjac;
			Model = a.Model;
			GodinaProizvodnje = a.GodinaProizvodnje;
			DatumInstalacije = a.DatumInstalacije;
			Tip = a.Tip;
			DatumPoslednjegServisiranja = a.DatumPoslednjegTesta;
			DatumPoslednjegServisiranja = a.DatumPoslednjegServisiranja;
			OtklonjenKvar = a.OtklonjenKvar;
		}
	}

	public class ToplotniAlarmniSistemView : AlarmniSistemView
	{
		public string HorizontalnaRezolucija { get; set; }
		public string VertikalnaRezolucija { get; set; }

		public ToplotniAlarmniSistemView()
		{
		}

		public ToplotniAlarmniSistemView(ToplotniAlarmniSistem t) : base(t)
		{
			HorizontalnaRezolucija = t.HorizontalnaRezolucija;
			VertikalnaRezolucija = t.VertikalnaRezolucija;
		}
	}

	public class UltrazvucniAlarmniSistemView : AlarmniSistemView
	{
		public string Frekvencija { get; set; }

		public UltrazvucniAlarmniSistemView()
		{
		}

		public UltrazvucniAlarmniSistemView(UltrazvucniAlarmniSistem u) : base(u)
		{
			Frekvencija = u.Frekvencija;
		}
	}

	public class DetekcijaPokretaAlarmniSistemView : AlarmniSistemView
	{
		public string Osetljivost { get; set; }

		public DetekcijaPokretaAlarmniSistemView()
		{
		}

		public DetekcijaPokretaAlarmniSistemView(DetekcijaPokretaAlarmniSistem d) : base(d)
		{
			Osetljivost = d.Osetljivost;
		}
	}
}