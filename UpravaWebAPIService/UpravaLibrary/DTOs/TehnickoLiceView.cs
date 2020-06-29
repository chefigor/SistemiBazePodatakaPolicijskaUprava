using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpravaLibrary.Entiteti;

namespace UpravaLibrary.DTOs
{
	public class TehnickoLiceView
	{
		public int TehnicarId { get; set; }
		public string Ime { get; set; }
		public string Prezime { get; set; }
		public string KontaktBr { get; set; }
		public IList<ZaduzenView> ZaduzenZa { get; set; }

		public TehnickoLiceView()
		{
		}

		public TehnickoLiceView(TehnickoLice t)
		{
			TehnicarId = t.TehnicarId;
			Ime = t.Ime;
			Prezime = t.Prezime;
			KontaktBr = t.KontaktBr;
		}
	}
}