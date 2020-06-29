using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpravaLibrary.Entiteti
{
	public class Kurs
	{
		public virtual int KursId { get; set; }
		public virtual VanredniPolicajac Policajac { get; set; } //VAnredni policajac
		public virtual string Naziv { get; set; }
		public virtual DateTime DatumZavrsetka { get; set; }
	}
}