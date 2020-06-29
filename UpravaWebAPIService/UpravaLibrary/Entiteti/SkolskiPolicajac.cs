using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpravaLibrary.Entiteti
{
	public class SkolskiPolicajac : Policajac
	{
		public virtual string SrednjaIliOsnovna { get; set; }
		public virtual string NazivSkole { get; set; }
		public virtual string AdresaSkole { get; set; }
		public virtual string OsobaZaKontakt { get; set; }
		public virtual string BrojTelefonaSkole { get; set; }
	}
}