using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Uprava.Entiteti;

namespace Uprava.Mapiranja
{
    public class SkolskiPolicajacMapiranja : SubclassMap<SkolskiPolicajac>
    {
        public SkolskiPolicajacMapiranja()
        {
            //Table("SKOLSKI_POLICAJAC");

            //KeyColumn("POLICAJACID");
            DiscriminatorValue("SKOLSKI");

            Join("SKOLSKI_POLICAJAC", j =>
            {
                j.KeyColumn("POLICAJACID");
                //j.Map(x => x.NazivSkole, "NAZIV_SKOLE");
                //j.Map(x => x.AdresaSkole, "ADRESA");
                //j.Map(x => x.BrojTelefonaSkole, "BR_TELEFONA_SKOLE");
                //j.Map(x => x.OsobaZaKontakt, "OSOBA_ZA_KONTAKT");
                //j.Map(x => x.SrednjaIliOsnovna, "SREDNJA_ILI_OSNOVNA");
                j.Map(x => x.NazivSkole).Column("NAZIV_SKOLE");
                j.Map(x => x.AdresaSkole).Column("ADRESA");
                j.Map(x => x.BrojTelefonaSkole).Column("BR_TELEFONA_SKOLE");
                j.Map(x => x.OsobaZaKontakt).Column("OSOBA_ZA_KONTAKT");
                j.Map(x => x.SrednjaIliOsnovna).Column("SREDNJA_ILI_OSNOVNA");
            });



        }
    }
}
