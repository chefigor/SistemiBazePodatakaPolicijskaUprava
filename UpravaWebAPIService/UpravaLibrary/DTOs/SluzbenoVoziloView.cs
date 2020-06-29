using System;
using System.Collections.Generic;
using System.Text;
using UpravaLibrary.Entiteti;

namespace UpravaLibrary.DTOs
{
	public class SluzbenoVoziloView
	{
		public int VoziloId { get;  set; }
		public string RegistarskaOznaka { get; set; }
		public string Proizvodjac { get; set; }
		public string Boja { get; set; }
		public string Tip { get; set; }
		public string Model { get; set; }
		public PolicijskaStanicaView Stanica { get; set; }
		public PatrolaView Patrola { get; set; }

		public SluzbenoVoziloView()
		{
		}

		public SluzbenoVoziloView(SluzbenoVozilo s)
		{
			VoziloId = s.VoziloId;
			RegistarskaOznaka = s.RegistarskaOznaka;
			Proizvodjac = s.Proizvodjac;
			Boja = s.Boja;
			Tip = s.Tip;
			Model = s.Model;
		}
	}
}