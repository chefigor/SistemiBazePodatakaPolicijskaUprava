using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uprava.Entiteti
{
	public class SluzbenoVozilo
	{
		public virtual int VoziloId { get; protected set; }
		public virtual string RegistarskaOznaka { get; set; }
		public virtual string Proizvodjac { get; set; }
		public virtual string Boja { get; set; }
		public virtual string Tip { get; set; }
		public virtual string Model { get; set; }
		public virtual PolicijskaStanica pripadaStanici { get; set; }
		public virtual Patrola pripadaPatroli { get; set; }


		public SluzbenoVozilo()
		{
		}
	}
}
