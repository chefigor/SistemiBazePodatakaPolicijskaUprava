using System;
using System.Collections.Generic;
using System.Text;
using UpravaLibrary.Entiteti;

namespace UpravaLibrary.DTOs
{
	public class UlicaView
	{
		public int UlicaId { get; protected set; }

		public PozornikPolicajacView Policajac { get; set; } //pozornik

		public string Naziv { get; set; }

		public UlicaView()
		{
		}

		public UlicaView(Ulica u)
		{
			UlicaId = u.UlicaId;
			Naziv = u.Naziv;
		}
	}
}