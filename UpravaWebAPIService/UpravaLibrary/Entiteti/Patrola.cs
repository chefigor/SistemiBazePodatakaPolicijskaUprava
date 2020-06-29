using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpravaLibrary.Entiteti
{
	public class Patrola
	{
		public virtual int PatrolaId { get; set; }
		public virtual ObicanPolicajac Vodja { get; set; }
		public virtual ObicanPolicajac Partner { get; set; }
		public virtual SluzbenoVozilo Vozilo { get; set; }
		public virtual IList<Intervencija> Intervencije { get; set; }

		public Patrola()
		{
			Intervencije = new List<Intervencija>();
		}
	}
}