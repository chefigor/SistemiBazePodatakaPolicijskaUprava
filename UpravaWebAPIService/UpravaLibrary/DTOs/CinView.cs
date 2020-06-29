using System;
using System.Collections.Generic;
using System.Text;
using UpravaLibrary.Entiteti;

namespace UpravaLibrary.DTOs
{
	public class CinView
	{
		public int CinId { get; set; }
		public PolicajacView Policajac { get; set; }
		public string Naziv { get; set; }
		public DateTime DatumSticanja { get; set; }

		public CinView()
		{
		}

		public CinView(Cin c)
		{
			CinId = c.CinId;
			Naziv = c.Naziv;
			DatumSticanja = c.DatumSticanja;
		}
	}
}