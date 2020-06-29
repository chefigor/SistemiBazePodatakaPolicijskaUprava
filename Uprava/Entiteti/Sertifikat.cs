using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uprava.Entiteti
{
	public class Sertifikat
	{
		public virtual int SertifikatId { get; set; }
		public virtual VanredniPolicajac Policajac { get; set; } //vanredni policajca
		public virtual string Naziv { get; set; }
		public virtual DateTime DatumSticanja { get; set; }

	}
}
