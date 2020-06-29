using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpravaLibrary.Entiteti
{
	public class Cin
	{
		public virtual int CinId { get; set; }
		public virtual Policajac Policajac { get; set; }
		public virtual string Naziv { get; set; }
		public virtual DateTime DatumSticanja { get; set; }
	}
}