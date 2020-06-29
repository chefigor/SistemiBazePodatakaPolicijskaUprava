using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FluentNHibernate;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using Uprava.Entiteti;

namespace Uprava
{
	public partial class PolicijskaUprava : Form
	{
		public PolicijskaUprava()
		{
			InitializeComponent();
		}

		private void btnLoadPolicijskaStanica_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				PolicijskaStanica p = s.Load<PolicijskaStanica>(1);

				MessageBox.Show(p.Sef.Ime + " " + p.Zamenik.Ime);

				s.Close();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
				Console.WriteLine(exception);
				throw;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();
				IList<Policajac> listaPolicajca = s.QueryOver<Policajac>().List<Policajac>();

				foreach (Policajac pol in listaPolicajca)
				{
					if (pol.GetType() == typeof(PozornikPolicajac))
					{
						PozornikPolicajac pozornik = (PozornikPolicajac)pol;
						
						MessageBox.Show(pozornik.ToString());
					}

					else if (pol.GetType() == typeof(VanredniPolicajac))
					{
						VanredniPolicajac vanredni = (VanredniPolicajac)pol;
						MessageBox.Show(vanredni.ToString());
					}
					else if (pol.GetType() == typeof(SkolskiPolicajac))
					{
						SkolskiPolicajac skolski = (SkolskiPolicajac)pol;
						MessageBox.Show(skolski.ToString());
					}
					else
					{
						MessageBox.Show(pol.ToString());
					}
				}
				s.Close();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
				Console.WriteLine(exception);
				throw;
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				Uprava.Entiteti.PolicijskaStanica p = s.Load<Uprava.Entiteti.PolicijskaStanica>(1);

				foreach (Policajac pol in p.Policajci)
				{
					MessageBox.Show(pol.Ime + " " + pol.Kurs);
				}

				s.Close();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);

				Console.WriteLine(exception);
				throw;
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				PolicijskaStanica p = s.Load<PolicijskaStanica>(1);
				MessageBox.Show(p.StanicaId+" "+p.Naziv+" "+p.Adresa);

				s.Close();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
				Console.WriteLine(exception);
				throw;
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();
				AlarmniSistem a = s.Load<AlarmniSistem>("K1271");

				MessageBox.Show(a.GodinaProizvodnje);
				MessageBox.Show(a.Model);
				MessageBox.Show((a.DatumInstalacije).ToString());

				s.Close();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
				Console.WriteLine(exception);
				throw;
			}
		}

		private void button10_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();
				Sertifikat se = s.Load<Sertifikat>(4);

				MessageBox.Show(se.Naziv);
				MessageBox.Show((se.Policajac.Ime).ToString());
				MessageBox.Show((se.DatumSticanja).ToString());

				s.Close();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
				Console.WriteLine(exception);
				throw;
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();
				Cin c = s.Load<Cin>(2);

				MessageBox.Show(c.Naziv);
				MessageBox.Show((c.DatumSticanja).ToString());
				MessageBox.Show(c.PripadaPolicajcu.Ime);

				s.Close();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
				Console.WriteLine(exception);
				throw;
			}
		}

		private void button6_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();
				Intervencija i = s.Load<Intervencija>(2);

				MessageBox.Show((i.Patrola.PatrolaId).ToString());
				MessageBox.Show((i.Objekat.Ime).ToString());
				MessageBox.Show((i.Objekat.Povrsina).ToString());
				MessageBox.Show(i.Vreme);
				MessageBox.Show(i.Opis);


				s.Close();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
				Console.WriteLine(exception);
				throw;
			}
		}

		private void button7_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();
				Kurs k = s.Load<Kurs>(2);

				MessageBox.Show((k.Policajac.Ime).ToString());
				MessageBox.Show((k.DatumZavrsetka).ToString());



				s.Close();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
				Console.WriteLine(exception);
				throw;
			}
		}

		private void button8_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();
				Objekat o = s.Load<Objekat>(2);

				MessageBox.Show((o.Ime).ToString());
				MessageBox.Show((o.Povrsina).ToString());
				MessageBox.Show((o.PripadaPolicjkojStanica.StanicaId).ToString());
				MessageBox.Show((o.PripadaPolicjkojStanica.Opstina).ToString());

				s.Close();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
				Console.WriteLine(exception);
				throw;
			}
		}

		private void button9_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();
				Patrola p = s.Load<Patrola>(3);

				MessageBox.Show((p.PatrolaId).ToString());
				MessageBox.Show((p.Vozilo.Model));
				MessageBox.Show((p.Vodja.DatumSticanjaDiplome).ToString());
				MessageBox.Show((p.Partner.Jmbg).ToString());

				s.Close();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
				Console.WriteLine(exception);
				throw;
			}
		}

		private void button11_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();
				SluzbenoVozilo sv = s.Load<SluzbenoVozilo>(3);

				MessageBox.Show((sv.RegistarskaOznaka).ToString());
				MessageBox.Show((sv.Tip).ToString());
				MessageBox.Show((sv.pripadaStanici.Naziv).ToString());


				s.Close();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
				Console.WriteLine(exception);
				throw;
			}
		}

		private void button12_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();
				Zaduzen z = s.Load<Zaduzen>(3);

				MessageBox.Show((z.Tehnicar.Ime).ToString());
				MessageBox.Show((z.DatumOd).ToString());
				MessageBox.Show((z.DatumDo).ToString());
				MessageBox.Show((z.AlarmSerijskiBr.SerijskiBr).ToString());

				s.Close();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
				Console.WriteLine(exception);
				throw;
			}
		}

		private void button13_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();
				TehnickoLice t = s.Load<TehnickoLice>(3);

				MessageBox.Show((t.Ime).ToString());
				MessageBox.Show((t.Prezime).ToString());
				MessageBox.Show((t.KontaktBr).ToString());


				s.Close();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
				Console.WriteLine(exception);
				throw;
			}
		}

		private void button14_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();
				Ulica ul = s.Load<Ulica>(3);

				MessageBox.Show(ul.Naziv);
				MessageBox.Show	((ul.UlicaId).ToString());
				MessageBox.Show(ul.PripadaPolicajcu.Ime);


				s.Close();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
				Console.WriteLine(exception);
				throw;
			}
		}

		private void button15_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();
				Vestina ve = s.Load<Vestina>(3);

				MessageBox.Show(ve.Naziv);
				MessageBox.Show((ve.VestinaId).ToString());
				MessageBox.Show(ve.PripadaPolicajcu.Ime);
				MessageBox.Show((ve.PripadaPolicajcu.PolicajacId).ToString());

				s.Close();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
				Console.WriteLine(exception);
				throw;
			}
		}

		private void button16_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();
				SkolskiPolicajac sp = s.Load<SkolskiPolicajac>(5);

				MessageBox.Show((sp.PolicajacId).ToString());
				MessageBox.Show((sp.NazivSkole));
				MessageBox.Show(sp.OsobaZaKontakt);
				

				s.Close();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
				Console.WriteLine(exception);
				throw;
			}
		}

        private void btnOnetoManyObjekti_Click(object sender, EventArgs e)
        {
            
                try
                {
                    ISession s = DataLayer.GetSession();
                    Uprava.Entiteti.PolicijskaStanica ps = s.Load<Uprava.Entiteti.PolicijskaStanica>(1);
                
                    foreach(Objekat o in ps.DrziObjekte)
                {
                    MessageBox.Show(o.Adresa + " " + o.TipObjekta);
                }
                   
                    s.Close();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                    Console.WriteLine(exception);
                    throw;
                }
            
        }

        private void btnOnetoManyAlarmi_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Uprava.Entiteti.Objekat o = s.Load<Uprava.Entiteti.Objekat>(2);

                foreach (AlarmniSistem a in o.ImaAlarme)
                {
                    MessageBox.Show(a.Tip + " " + a.Proizvodjac+ " " + a.DatumInstalacije);
                }

                s.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                Console.WriteLine(exception);
                throw;
            }
        }
        //ovo ne prikazuje nista, kod je dobar, ali mislim da je to zato sto je cin visevrednosni 
        private void btnOnetoManyCinovi_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Uprava.Entiteti.Policajac p = s.Load<Uprava.Entiteti.Policajac>(7);

                foreach (Cin c in p.Cinovi)
                {
                    MessageBox.Show(c.Naziv);
                   
                }

                s.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                Console.WriteLine(exception);
                throw;
            }
        }
        
        private void btnOnetoManyVozila_Click(object sender, EventArgs e)
        {

            try
            {
                ISession s = DataLayer.GetSession();
                Uprava.Entiteti.PolicijskaStanica p = s.Load<Uprava.Entiteti.PolicijskaStanica>(1);

                foreach (SluzbenoVozilo sv in p.SluzbenaVozila)
                {
                    MessageBox.Show(sv.RegistarskaOznaka + " " + sv.Tip + " " + sv.Model);
                }

                s.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                Console.WriteLine(exception);
                throw;
            }
        }

        private void btnManytoOneStanice_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Uprava.Entiteti.Objekat o = s.Load<Uprava.Entiteti.Objekat>(10);

                
                MessageBox.Show(o.TipObjekta);
                MessageBox.Show(o.PripadaPolicjkojStanica.Naziv);


                s.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                Console.WriteLine(exception);
                throw;
            }
        }

        private void btnManytoOnePolStanice_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Uprava.Entiteti.Policajac p = s.Load<Uprava.Entiteti.Policajac>(9);


                MessageBox.Show(p.Ime + " " + p.Jmbg);
                MessageBox.Show(p.PripadaPolicijskaStanica.Naziv);


                s.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                Console.WriteLine(exception);
                throw;
            }
        }

        private void btnManytoOnealObjekti_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Uprava.Entiteti.AlarmniSistem a = s.QueryOver<AlarmniSistem>()
	                .Where(a=>a.SerijskiBr=="K1271").SingleOrDefault();
                if (a.GetType() == typeof(ToplotniAlarmniSistem))
                {
	                ToplotniAlarmniSistem t = (ToplotniAlarmniSistem) a;
	                MessageBox.Show(t.Tip);
	                MessageBox.Show(t.PripadaObjektu.TipObjekta);
                }
                else if(a.GetType() == typeof(UltrazvucniAlarmniSistem))
                {
					UltrazvucniAlarmniSistem t = (UltrazvucniAlarmniSistem)a;
					MessageBox.Show(t.Tip);
					MessageBox.Show(t.PripadaObjektu.TipObjekta);
				}

				else if (a.GetType() == typeof(DetekcijaPokretaAlarmniSistem))
                {
	                DetekcijaPokretaAlarmniSistem t = (DetekcijaPokretaAlarmniSistem)a;
	                MessageBox.Show(t.Tip);
	                MessageBox.Show(t.PripadaObjektu.TipObjekta);
				}

                s.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                Console.WriteLine(exception);
                throw;
            }
        }

        private void btnManytoOnevozStan_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Uprava.Entiteti.SluzbenoVozilo sv = s.Load<Uprava.Entiteti.SluzbenoVozilo>(9);


                MessageBox.Show(sv.Tip + " " + sv.RegistarskaOznaka);
                MessageBox.Show(sv.pripadaStanici.Naziv);


                s.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                Console.WriteLine(exception);
                throw;
            }
        }

		private void button17_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();




				Policajac pol = s.Load<Policajac>(11);

				Cin c = new Cin();


				c.DatumSticanja = DateTime.Now;
				c.Naziv = "TEST ZA IGORAAAAAAA";
				c.PripadaPolicajcu= pol;

				pol.Cinovi.Add(c);



				
				s.Save(c);
				s.Flush();

				s.Close();
			
			}


			catch (Exception ec)
			{
				MessageBox.Show(ec.Message);
			}
		}

		private void button19_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				Patrola p = s.Load<Patrola>(1);
				Objekat o = s.Load<Objekat>(1);
				Intervencija i = new Intervencija();

				i.Datum = DateTime.Now;
				i.Objekat = o;
				i.Patrola = p;
				i.Vreme = "20:35H";
				i.Opis = "Lagana prica";
				o.ImaoIntervencije.Add(i);
				p.ImalaIntervencije.Add(i);

				s.Save(i);
				s.Flush();

				s.Close();

			}


			catch (Exception ec)
			{
				MessageBox.Show(ec.Message);
			}
		}

		private void button18_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				ObicanPolicajac p = new ObicanPolicajac();
				PolicijskaStanica ps = s.Load<PolicijskaStanica>(1);

				p.Adresa = "Neznanog junaka";
				p.DatumPrijema = DateTime.Now;
				p.DatumRodjenja = new DateTime(1976, 10, 20);
				p.DatumSticanjaDiplome = new DateTime(2006, 2, 11);
				p.Ime = "Slobodan";
				p.ImeRoditelja = "Branislav";
				p.Jmbg = "1452145214521";
				p.Kurs = "No info";
				p.NazivObrazovanja = "Obuceni policajac";
				p.Pol = 'M';
				p.Pozicija = "Snajperista";
				p.Skola = "Policijska akademija";
				p.TipPosla = "Skolski Policajac";
				p.Prezime = "Stamenkovic";

				p.PripadaPolicijskaStanica = ps;
				ps.Policajci.Add(p);

				s.Save(p);
				s.Flush();

				s.Close();

			}


			catch (Exception ec)
			{
				MessageBox.Show(ec.Message);
			}
		}

		private void button20_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				Vestina v = new Vestina();
				IList<VanredniPolicajac> listaVanrednihPolicajaca = s.QueryOver<VanredniPolicajac>().List();

				VanredniPolicajac pol = listaVanrednihPolicajaca[0];

				v.Naziv = "Borilacke vestine";
				v.PripadaPolicajcu = pol;

				pol.Vestine.Add(v);
				

				s.Save(v);
				s.Flush();

				s.Close();

			}
			
				catch (Exception ec)
				{
					MessageBox.Show(ec.Message);
				}
			}

		private void button22_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();
				IList<AlarmniSistem> listaAlarmnihSistema = s.QueryOver<AlarmniSistem>().List<AlarmniSistem>();

				foreach (AlarmniSistem alarm in listaAlarmnihSistema)
				{
					if (alarm.GetType() == typeof(ToplotniAlarmniSistem))
					{
						ToplotniAlarmniSistem toplotni = (ToplotniAlarmniSistem) alarm;
						MessageBox.Show(toplotni.ToString());
					}

					else if (alarm.GetType() == typeof(UltrazvucniAlarmniSistem))
					{
						UltrazvucniAlarmniSistem ultrazvucni = (UltrazvucniAlarmniSistem) alarm;
						MessageBox.Show(ultrazvucni.ToString());
					}
					else if (alarm.GetType() == typeof(DetekcijaPokretaAlarmniSistem))
					{
						DetekcijaPokretaAlarmniSistem detekcijaPokretaAlarmniSistem =
							(DetekcijaPokretaAlarmniSistem) alarm;
						MessageBox.Show(detekcijaPokretaAlarmniSistem.ToString());
					}
				}

				s.Close();

			}
			catch (Exception exception)
			{
				Console.WriteLine(exception);
				throw;
			}
		}

		private void button21_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();
				IList<Policajac> policajci = s.QueryOver<Policajac>().Where(p => p.PolicajacId == 5).List<Policajac>();

				SkolskiPolicajac skolski = (SkolskiPolicajac) policajci[0];
				MessageBox.Show(skolski.ToString());
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception);
				throw;
			}
		}

		private void button23_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();
				IList<SkolskiPolicajac> policajci = s.QueryOver<SkolskiPolicajac>().List<SkolskiPolicajac>();

				foreach (var pol in policajci)
				{
					MessageBox.Show(pol.ToString());
				}
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception);
				throw;
			}
		}

		private void button23_Click_1(object sender, EventArgs e)
		{
			
				try
				{
					ISession s = DataLayer.GetSession();

					Policajac pol = s.Get<Policajac>(11);

					//obrada podataka o odeljenju

					s.Refresh(pol);

					s.Close();

				}
				catch (Exception ec)
				{
					MessageBox.Show(ec.Message);
				}
			}

		private void button24_Click(object sender, EventArgs e)
		{

			try
			{
				ISession s = DataLayer.GetSession();

				Vestina v = s.Get<Vestina>(2);

				//obrada podataka o odeljenju

				s.Refresh(v);

				s.Close();

			}
			catch (Exception ec)
			{
				MessageBox.Show(ec.Message);
			}
		}

		private void button25_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				AlarmniSistem a = s.Get<AlarmniSistem>("K1271");

				//obrada podataka o odeljenju

				s.Refresh(a);

				s.Close();

			}
			catch (Exception ec)
			{
				MessageBox.Show(ec.Message);
			}
		}

		private void button27_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				IQuery q = s.CreateQuery("from Cin");

				IList<Cin> cinovi = q.List<Cin>();

				foreach (Cin o in cinovi)
				{
					MessageBox.Show(o.Naziv);
					//MessageBox.Show(o.pripadaPolicajcu.Ime);
				}

				s.Close();

			}
			catch (Exception ec)
			{
				MessageBox.Show(ec.Message);
			}
		}

		private void button28_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				IQuery q = s.CreateQuery("from AlarmniSistem");

				IList<AlarmniSistem> sistemi = q.List<AlarmniSistem>();

				foreach (AlarmniSistem z in sistemi)
				{
				
					MessageBox.Show(z.GodinaProizvodnje+" "+z.SerijskiBr+" "+z.Tip);
				}

				s.Close();

			}
			catch (Exception ec)
			{
				MessageBox.Show(ec.Message);
			}
		}

		private void button29_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				IQuery q = s.CreateQuery("from Intervencija");

				IList<Intervencija> intervencije = q.List<Intervencija>();

				foreach (Intervencija z in intervencije)
				{

					MessageBox.Show(z.Vreme);
					MessageBox.Show(z.Opis);
					MessageBox.Show((z.IntervencijaId).ToString());
					MessageBox.Show((z.Objekat.ObjekatId).ToString());
				}

				s.Close();

			}
			catch (Exception ec)
			{
				MessageBox.Show(ec.Message);
			}
		}

		private void button30_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				//Odeljenja koja nemaju info pult
				IQuery q = s.CreateQuery("from ToplotniAlarmniSistem as o where o.Proizvodjac='PARADOX'");

				IList<ToplotniAlarmniSistem> sistemi = q.List<ToplotniAlarmniSistem>();

				foreach (ToplotniAlarmniSistem o in sistemi)
				{
					MessageBox.Show(o.SerijskiBr + " " + (o.DatumInstalacije.ToString()));
				}

				s.Close();

			}
			catch (Exception ec)
			{
				MessageBox.Show(ec.Message);
			}
		}

		private void button31_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				//Odeljenja koja nemaju info pult
				IQuery q = s.CreateQuery("from Cin as o where o.Naziv='INSPEKTOR'");

				IList<Cin> cinovi = q.List<Cin>();

				foreach (Cin o in cinovi)
				{
					MessageBox.Show(o.Naziv + " " + "Cin  id: " + (o.CinId.ToString()));
				}

				s.Close();

			}
			catch (Exception ec)
			{
				MessageBox.Show(ec.Message);
			}
		}

		private void button32_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				//Odeljenja koja nemaju info pult
				IQuery q = s.CreateQuery("from Policajac as o where o.Ime='VLADIMIR'");

				IList<Policajac> policajci = q.List<Policajac>();

				foreach (Policajac o in policajci)
				{
					MessageBox.Show(o.Ime + " " + "," + "Policajac id: " + (o.PolicajacId.ToString()) + " , " + "Ime roditelja:" + o.ImeRoditelja);
				}

				s.Close();

			}
			catch (Exception ec)
			{
				MessageBox.Show(ec.Message);
			}
		}

		private void button33_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				//Odeljenja koja nemaju info pult
				IQuery q = s.CreateQuery("from PolicijskaStanica as o where o.Naziv='POLICIJSKA STANICA NIS'");

				IList<PolicijskaStanica> stanice = q.List<PolicijskaStanica>();

				foreach (PolicijskaStanica o in stanice)
				{
					MessageBox.Show(o.Naziv + " " + "," + "Stanica id: " + (o.StanicaId.ToString()) + " Opstina" + ":" + o.Opstina);
				}

				s.Close();

			}
			catch (Exception ec)
			{
				MessageBox.Show(ec.Message);
			}
		}

		private void button34_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				Policajac o = s.Get<Policajac>(100);

				if (o != null)
				{
					MessageBox.Show(o.Prezime);
					MessageBox.Show(o.Ime);
					MessageBox.Show(o.ImeRoditelja);
				}
				else
				{
					MessageBox.Show("Ne postoji policajac sa zadatim identifikatorom");
				}


				s.Close();

			}
			catch (Exception ec)
			{
				MessageBox.Show(ec.Message);
			}
		}

		private void button35_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				Cin o = s.Get<Cin>(2);

				if (o != null)
				{
					MessageBox.Show(o.Naziv);
					MessageBox.Show(o.PripadaPolicajcu.Ime);
				}
				else
				{
					MessageBox.Show("Ne postoji cin sa zadatim identifikatorom");
				}


				s.Close();

			}
			catch (Exception ec)
			{
				MessageBox.Show(ec.Message);
			}
		}

		private void button36_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				AlarmniSistem o = s.Get<AlarmniSistem>("K333");

				if (o != null)
				{
					MessageBox.Show(o.Model);
				}
				else
				{
					MessageBox.Show("Ne postoji alarmni sistem sa zadatim serijskim brojem");
				}


				s.Close();

			}
			catch (Exception ec)
			{
				MessageBox.Show(ec.Message);
			}
		}

		private void button37_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				//Paramterizovani upit
				IQuery q = s.CreateQuery("from Policajac as o where o.Ime = ? and o.Pol >= ?");
				q.SetParameter(0, "IGOR");
				q.SetParameter(1, 'M');

				IList<Policajac> policajci = q.List<Policajac>();

				foreach (Policajac o in policajci)
				{
					MessageBox.Show("Id="+ o.PolicajacId + "," + "Pol=" + o.Pol + "Ime:" + o.Ime);
				}

				s.Close();

			}
			catch (Exception ec)
			{
				MessageBox.Show(ec.Message);
			}
		}

		private void button38_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				//Paramterizovani upit
				IQuery q = s.CreateQuery("from AlarmniSistem as o where o.Model = ? and o.GodinaProizvodnje >= ?");
				q.SetParameter(0, "1510");
				q.SetParameter(1, "2018");

				IList<AlarmniSistem> sistemi = q.List<AlarmniSistem>();

				foreach (AlarmniSistem o in sistemi)
				{
					MessageBox.Show("Id=" + o.SerijskiBr);
				}

				s.Close();

			}
			catch (Exception ec)
			{
				MessageBox.Show(ec.Message);
			}
		}

		private void button39_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				//Paramterizovani upit
				IQuery q = s.CreateQuery("from Cin as o where o.Naziv = ?");
				q.SetParameter(0, "INSPEKTOR");
				

				IList<Cin> cinovi = q.List<Cin>();

				foreach (Cin o in cinovi)
				{
					MessageBox.Show("Id=" + o.PripadaPolicajcu.PolicajacId + "Naziv=" + o.Naziv);
				}

				s.Close();

			}
			catch (Exception ec)
			{
				MessageBox.Show(ec.Message);
			}
		}

		private void button42_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				//Paramterizovani upit
				IQuery q = s.CreateQuery("select o.Naziv from Vestina as o "
										+ "where o.VestinaId = :vestinaa "
										+ "and o.PripadaPolicajcu.PolicajacId = :policajacc");

				q.SetInt32("vestinaa", 21);
				q.SetInt32("policajacc", 24);
				

				IList<String> vestine = q.List<String>();

				foreach (String  o in vestine)
				{
					MessageBox.Show("Naziv:" + o);
				}

				s.Close();

			}
			catch (Exception ec)
			{
				MessageBox.Show(ec.Message);
			}
		}

		private void button41_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				//Paramterizovani upit
				IQuery q = s.CreateQuery("select o.Ime from Policajac as o "
										+ "where o.PolicajacId = :id "
										+ "and o.Prezime = :prezime");

				q.SetInt32("id", 24);
				q.SetString("prezime", "Stamenkovic");


				IList<String> policajac = q.List<String>();

				foreach (String o in policajac)
				{
					MessageBox.Show("Ime:" + o);
				}

				s.Close();

			}
			catch (Exception ec)
			{
				MessageBox.Show(ec.Message);
			}
		}

		private void button40_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				//Paramterizovani upit
				IQuery q = s.CreateQuery("select o from Cin as o "
										+ "where o.CinId = :id "
										);

				q.SetInt32("id", 3);
				


				IList<Entiteti.Cin> cinovi = q.List<Entiteti.Cin>();

				foreach (Entiteti.Cin o in cinovi)
				{
					MessageBox.Show("Naziv:" + o.Naziv);
				}

				s.Close();

			}
			catch (Exception ec)
			{
				MessageBox.Show(ec.Message);
			}
		}

		private void button43_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				IQuery q = s.CreateQuery("select o from AlarmniSistem o where o.SerijskiBr = 'K1271'");

				//za slucaj da upit vraca samo jednu vrednost
				AlarmniSistem o = q.UniqueResult<AlarmniSistem>();

				MessageBox.Show(o.GodinaProizvodnje);
				MessageBox.Show((o.DatumInstalacije).ToString());

				s.Close();

			}
			catch (Exception ec)
			{
				MessageBox.Show(ec.Message);
			}
		}

		private void button44_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				IQuery q = s.CreateQuery("from Vestina");
				q.SetFirstResult(3);
				q.SetMaxResults(2);

				IList<Vestina> vestine = q.List<Vestina>();

				foreach (Vestina o in vestine)
				{
					MessageBox.Show(o.VestinaId.ToString());
				}

				s.Close();

			}
			catch (Exception ec)
			{
				MessageBox.Show(ec.Message);
			}
		}

		private void button45_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				IQuery q = s.CreateQuery("from Policajac");
				q.SetFirstResult(3);
				q.SetMaxResults(5);

				IList<Policajac> policajci = q.List<Policajac>();

				foreach (Policajac o in policajci)
				{
					MessageBox.Show(o.Ime.ToString());
				}

				s.Close();

			}
			catch (Exception ec)
			{
				MessageBox.Show(ec.Message);
			}
		}

		private void button46_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				IQuery q = s.CreateQuery("from Objekat");
				q.SetFirstResult(1);
				q.SetMaxResults(4);

				IList<Objekat> objekti = q.List<Objekat>();

				foreach (Objekat o in objekti)
				{
					MessageBox.Show(o.Povrsina.ToString());
				}

				s.Close();

			}
			catch (Exception ec)
			{
				MessageBox.Show(ec.Message);
			}
		}

		private void button47_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				ISQLQuery q = s.CreateSQLQuery("SELECT O.* FROM CIN O");
				q.AddEntity(typeof(Cin));


				IList<Cin> cinovi = q.List<Cin>();

				foreach (Cin o in cinovi)
				{
					MessageBox.Show(o.Naziv.ToString());
				}

				s.Close();

			}
			catch (Exception ec)
			{
				MessageBox.Show(ec.Message);
			}
		}

		private void button48_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				ISQLQuery q = s.CreateSQLQuery("SELECT O.* FROM Vestina O");
				q.AddEntity(typeof(Vestina));


				IList<Vestina> vestine = q.List<Vestina>();

				foreach (Vestina o in vestine)
				{
					MessageBox.Show(o.Naziv.ToString());
				}

				s.Close();

			}
			catch (Exception ec)
			{
				MessageBox.Show(ec.Message);
			}
		}

		private void button49_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				ISQLQuery q = s.CreateSQLQuery("SELECT O.* FROM Objekat O");
				q.AddEntity(typeof(Objekat));


				IList<Objekat> objekti = q.List<Objekat>();

				foreach (Objekat o in objekti)
				{
					MessageBox.Show(o.TipObjekta.ToString());
				}

				s.Close();

			}
			catch (Exception ec)
			{
				MessageBox.Show(ec.Message);
			}
		}

		private void button50_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				IList<Policajac> policajci = s.QueryOver<Policajac>()
												.Where(x => x.Pol == 'M')
												.Where(x => x.PolicajacId >= 5)
												.List<Policajac>();

				foreach (Policajac o in policajci)
				{
					MessageBox.Show(o.Pol.ToString() + " , " + o.PolicajacId);
				}

				s.Close();

			}
			catch (Exception ec)
			{
				MessageBox.Show(ec.Message);
			}
		}

		private void button51_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				Policajac p = s.Load<Policajac>(2);

				//originalna sesija se zatvara i raskida se veza izmedju objekta i sesije
			

				//objekat se modifikuje potpuno nezavisno od sesije
				
				p.Ime="Petar";

				//otvara se nova sesija
	

			

				//poziva se Update i objekat se povezuje sa novom sesijom
				s.Update(p);

				s.Flush();
				s.Close();

			}
			catch (Exception ec)
			{
				MessageBox.Show(ec.Message);
			}
		}

		private void button52_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				Objekat o = s.Load<Objekat>(2);

				//originalna sesija se zatvara i raskida se veza izmedju objekta i sesije


				//objekat se modifikuje potpuno nezavisno od sesije

				o.Povrsina = 300.55;

				//otvara se nova sesija




				//poziva se Update i objekat se povezuje sa novom sesijom
				s.Update(o);

				s.Flush();
				s.Close();

			}
			catch (Exception ec)
			{
				MessageBox.Show(ec.Message);
			}
		}

		private void button53_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				Cin c = s.Load<Cin>(2);

				//originalna sesija se zatvara i raskida se veza izmedju objekta i sesije


				//objekat se modifikuje potpuno nezavisno od sesije

				c.Naziv = "Snajperista";

				//otvara se nova sesija




				//poziva se Update i objekat se povezuje sa novom sesijom
				s.Update(c);

				s.Flush();
				s.Close();

			}
			catch (Exception ec)
			{
				MessageBox.Show(ec.Message);
			}
		}

		private void button54_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				Policajac o = s.Load<Policajac>(19);

				//brise se objekat iz baze ali ne i instanca objekta u memroiji
				s.Delete(o);
				//s.Delete("from Odeljenje");

				s.Flush();
				s.Close();

			}
			catch (Exception ec)
			{
				MessageBox.Show(ec.Message);
			}
		}

		private void button55_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				Objekat o = s.Load<Objekat>(9);

				//brise se objekat iz baze ali ne i instanca objekta u memroiji
				s.Delete(o);
				//s.Delete("from Odeljenje");

				s.Flush();
				s.Close();

			}
			catch (Exception ec)
			{
				MessageBox.Show(ec.Message);
			}
		}

		private void button56_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				Cin o = s.Load<Cin>(3);

				//brise se objekat iz baze ali ne i instanca objekta u memroiji
				s.Delete(o);
				//s.Delete("from Odeljenje");

				s.Flush();
				s.Close();

			}
			catch (Exception ec)
			{
				MessageBox.Show(ec.Message);
			}
		}

		private void button57_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				IEnumerable<Objekat> objekti = from p in s.Query<Objekat>()
											   where (p.PripadaPolicjkojStanica.StanicaId == 2 || p.Povrsina >= 110)
											   orderby p.PripadaPolicjkojStanica.StanicaId, p.Povrsina
												  select p;

				foreach (Objekat p in objekti)
				{
					MessageBox.Show(p.ObjekatId.ToString());
				}

				s.Close();

			}
			catch (Exception ec)
			{
				MessageBox.Show(ec.Message);
			}
		}

		private void button58_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				IEnumerable<Policajac> policajci = from p in s.Query<Policajac>()
												   where (p.Pol == 'M')
												   orderby p.Pol
											   select p;

				foreach (Policajac p in policajci)
				{
					MessageBox.Show(p.Ime.ToString());
				}

				s.Close();

			}
			catch (Exception ec)
			{
				MessageBox.Show(ec.Message);
			}
		}

		private void button59_Click(object sender, EventArgs e)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				IEnumerable<Vestina> vestine = from p in s.Query<Vestina>()
												   where (p.PripadaPolicajcu.PolicajacId == 13)
												   orderby p.PripadaPolicajcu.PolicajacId
												   select p;

				foreach (Vestina p in vestine)
				{
					MessageBox.Show(p.Naziv.ToString());
				}

				s.Close();

			}
			catch (Exception ec)
			{
				MessageBox.Show(ec.Message);
			}
		}
	}
	}
	
	


