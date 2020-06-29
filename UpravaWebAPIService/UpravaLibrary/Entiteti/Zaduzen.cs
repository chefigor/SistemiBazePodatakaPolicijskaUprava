﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpravaLibrary.Entiteti
{
	public class Zaduzen
	{
		public virtual int ZaduzenId { get; set; }
		public virtual AlarmniSistem Alarm { get; set; }
		public virtual TehnickoLice Tehnicar { get; set; }
		public virtual DateTime DatumOd { get; set; }
		public virtual DateTime DatumDo { get; set; }
	}
}