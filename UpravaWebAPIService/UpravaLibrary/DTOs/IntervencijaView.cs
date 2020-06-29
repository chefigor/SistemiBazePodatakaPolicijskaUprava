using System;
using System.Collections.Generic;
using System.Text;
using UpravaLibrary.Entiteti;

namespace UpravaLibrary.DTOs
{
	public class IntervencijaView
	{
		public int IntervencijaId { get; set; }
		public string Vreme { get; set; }
		public DateTime Datum { get; set; }
		public string Opis { get; set; }
		public PatrolaView Patrola { get; set; }
		public ObjekatView Objekat { get; set; }

		public IntervencijaView()
		{
		}

		public IntervencijaView(Intervencija i)
		{
			IntervencijaId = i.IntervencijaId;
			Vreme = i.Vreme;
			Datum = i.Datum;
			Opis = i.Opis;
		}
	}
}