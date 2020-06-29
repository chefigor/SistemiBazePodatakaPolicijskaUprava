using System;
using System.Collections.Generic;
using System.Text;
using UpravaLibrary.Entiteti;

namespace UpravaLibrary.DTOs
{
	public class SertifikatView
	{
		public int SertifikatId { get; set; }
		public VanredniPolicajacView Policajac { get; set; } //vanredni policajca
		public string Naziv { get; set; }
		public DateTime DatumSticanja { get; set; }

		public SertifikatView()
		{
		}

		public SertifikatView(Sertifikat s)
		{
			SertifikatId = s.SertifikatId;
			Naziv = s.Naziv;
			DatumSticanja = s.DatumSticanja;
		}
	}
}