using System;
using System.Collections.Generic;
using System.Text;
using UpravaLibrary.Entiteti;

namespace UpravaLibrary.DTOs
{
	public class VestinaView
	{
		public int VestinaId { get; protected set; }
		public VanredniPolicajacView Policajac { get; set; } //vanredni

		public string Naziv { get; set; }

		public VestinaView()
		{
		}

		public VestinaView(Vestina v)
		{
			VestinaId = v.VestinaId;
			Naziv = v.Naziv;
		}
	}
}