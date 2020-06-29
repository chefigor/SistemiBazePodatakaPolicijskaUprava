using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uprava.Entiteti
{
	public class TehnickoLice
	{
		public virtual int TehnicarId { get; set; }
		public virtual string Ime { get; set; }
		public virtual string Prezime { get; set; }
		public virtual string KontaktBr { get; set; }
		public virtual IList<Zaduzen> ZaduzenZa { get; set; }

		public TehnickoLice()
		{
			ZaduzenZa = new List<Zaduzen>();
		}
	}
}
