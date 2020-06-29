using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uprava.Entiteti
{
	public class Cin
	{
		public virtual int CinId { get; set; }
		public virtual Policajac PripadaPolicajcu { get; set; }
		public virtual string Naziv { get; set; }
		public virtual DateTime DatumSticanja { get; set; }

	}
}
