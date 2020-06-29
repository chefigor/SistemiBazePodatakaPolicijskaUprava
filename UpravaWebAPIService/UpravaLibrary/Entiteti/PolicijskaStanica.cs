using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpravaLibrary.Entiteti
{
	public class PolicijskaStanica
	{
		public virtual int StanicaId { get; set; }
		public virtual string Naziv { get; set; }
		public virtual string Adresa { get; set; }
		public virtual string Opstina { get; set; }
		public virtual DateTime DatumOsnivanja { get; set; }
		public virtual Policajac Sef { get; set; }
		public virtual Policajac Zamenik { get; set; }
		public virtual int BrojSluzbenihVozila { get; protected set; }

		public virtual IList<Policajac> Policajci { get; set; }
		public virtual IList<Objekat> Objekti { get; set; }
		public virtual IList<SluzbenoVozilo> SluzbenaVozila { get; set; }

		public PolicijskaStanica()
		{
			Policajci = new List<Policajac>();
			SluzbenaVozila = new List<SluzbenoVozilo>();
			Objekti = new List<Objekat>();
		}
	}
}