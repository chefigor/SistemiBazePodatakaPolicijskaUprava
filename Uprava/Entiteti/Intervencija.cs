using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uprava.Entiteti
{
	public class Intervencija
	{
		public virtual int IntervencijaId { get; set; }
		public virtual string Vreme { get; set; }
		public virtual DateTime Datum { get; set; }
		public virtual string Opis { get; set; }
        public virtual Patrola Patrola { get; set; }
        public virtual Objekat Objekat { get; set; }

       
	}
}
