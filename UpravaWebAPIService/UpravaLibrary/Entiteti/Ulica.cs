using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpravaLibrary.Entiteti
{
	public class Ulica
	{
		public virtual int UlicaId { get; protected set; }

		public virtual PozornikPolicajac Policajac { get; set; } //pozornik

		public virtual string Naziv { get; set; }
	}
}