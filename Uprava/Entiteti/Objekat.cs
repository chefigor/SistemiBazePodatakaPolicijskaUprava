using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uprava.Entiteti
{
	public class Objekat
	{
		public virtual int ObjekatId { get; set; }
		public virtual string Adresa { get; set; }
		public virtual double Povrsina { get; set; }
		public virtual string TipObjekta { get; set; }
		public virtual PolicijskaStanica PripadaPolicjkojStanica { get; set; }
		public virtual string Ime { get; set; }
		public virtual string Prezime { get; set; }
		public virtual string Broj { get; set; }
		public virtual IList<Intervencija> ImaoIntervencije { get; set; }
		public virtual IList<AlarmniSistem> ImaAlarme { get; set; }

		public Objekat()
		{
			ImaoIntervencije = new List<Intervencija>();
			ImaAlarme = new List<AlarmniSistem>();
		}
	}
}
