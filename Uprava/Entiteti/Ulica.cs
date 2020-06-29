using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uprava.Entiteti
{
    public class Ulica
    {
        //metode
        public virtual int UlicaId { get; protected set; }
        public virtual PozornikPolicajac PripadaPolicajcu { get; set; } //pozornik

        public virtual string Naziv { get; set; }
    }
}
