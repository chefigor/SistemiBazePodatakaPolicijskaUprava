using System;
using System.Collections.Generic;
using System.Text;
using UpravaLibrary.Entiteti;

namespace UpravaLibrary.DTOs
{
	public class PatrolaView
	{
		public int PatrolaId { get; set; }
		public ObicanPolicajacView Vodja { get; set; }
		public ObicanPolicajacView Partner { get; set; }
		public SluzbenoVoziloView Vozilo { get; set; }
		public IList<IntervencijaView> Intervencije { get; set; }

		public PatrolaView()
		{
		}

		public PatrolaView(Patrola p)
		{
			PatrolaId = p.PatrolaId;
		}
	}
}