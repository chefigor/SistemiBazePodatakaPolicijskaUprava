using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uprava.Entiteti
{
	public class Patrola
	{
		public virtual int PatrolaId { get; set; }
		public virtual Policajac Vodja { get; set; }
		public virtual Policajac Partner { get; set; }
		public virtual SluzbenoVozilo Vozilo { get; set; }
		public virtual IList<Intervencija> ImalaIntervencije { get; set; }
	
	  public Patrola()
		{ 
			ImalaIntervencije = new List<Intervencija>();
		}
	}
}
