using System;
using System.Collections.Generic;
using System.Text;
using UpravaLibrary.Entiteti;

namespace UpravaLibrary.DTOs
{
	public class ZaduzenView
	{
		public int ZaduzenId { get; set; }
		public AlarmniSistemView Alarm { get; set; }
		public TehnickoLiceView Tehnicar { get; set; }
		public DateTime DatumOd { get; set; }
		public DateTime DatumDo { get; set; }

		public ZaduzenView()
		{
		}

		public ZaduzenView(Zaduzen z)
		{
			ZaduzenId = z.ZaduzenId;
			DatumOd = z.DatumOd;
			DatumDo = z.DatumDo;
		}
	}
}