using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using NHibernate;
using NHibernate.Dialect.Schema;
using NHibernate.Hql.Ast.ANTLR.Tree;
using UpravaLibrary.DTOs;
using UpravaLibrary.Entiteti;

namespace UpravaLibrary
{
	public partial class DataProvider
	{
		#region AlarmniSistemi

		public static List<AlarmniSistemView> VratiSveAlarmneSisteme()
		{
			List<AlarmniSistemView> alarmi = new List<AlarmniSistemView>();
			try
			{
				ISession s = DataLayer.GetSession();

				IEnumerable<AlarmniSistem> sviAlarmi = from a in s.Query<AlarmniSistem>()
													   select a;
				foreach (AlarmniSistem a in sviAlarmi)
				{
					AlarmniSistemView tmp = new AlarmniSistemView(a);
					tmp.Objekat = new ObjekatView(a.Objekat);
					tmp.Zaduzen = a.Zaduzeni.Select(z => new ZaduzenView(z)).ToList();

					alarmi.Add(tmp);
				}

				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}

			return alarmi;
		}

		public static List<AlarmniSistemView> VratiSveALarmneSistemeObjekat(int id)
		{
			var alarmi = new List<AlarmniSistemView>();
			try
			{
				ISession s = DataLayer.GetSession();
				var sviAlarmi = from o in s.Query<AlarmniSistem>()
								where o.Objekat.ObjekatId == id
								select o;
				foreach (AlarmniSistem a in sviAlarmi)
				{
					AlarmniSistemView a1 = new AlarmniSistemView(a);
					a1.Zaduzen = a.Zaduzeni.Select(a => new ZaduzenView(a)).ToList();
					a1.Objekat = new ObjekatView(a.Objekat);
					alarmi.Add(a1);
				}

				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}

			return alarmi;
		}

		//public static void DodajAlarmniSistem(AlarmniSistemView a)
		//{
		//	try
		//	{
		//		ISession s = DataLayer.GetSession();
		//		var alarm = new AlarmniSistemView();
		//		if (a.Tip == "Toplotni")
		//		{
		//			ToplotniAlarmniSistemView t = ()
		//			DodajToplotniAlarmniSistem((ToplotniAlarmniSistemView)a);
		//		}
		//		else if (a.Tip == "Ultrazvucni")
		//		{
		//			DodajUltrazvucniAlarmniSistem((UltrazvucniAlarmniSistemView)a);
		//		}
		//		else if(a.Tip=="Detekcija_pokreta")
		//		{
		//			DodajDetekcijaAlarmniSistem((DetekcijaPokretaAlarmniSistemView)a);
		//		}
		//		else
		//		{
		//			s.Close();
		//			return;
		//		}

		//		s.Close();
		//	}
		//	catch (Exception e)
		//	{
		//		Console.WriteLine(e);
		//		throw;
		//	}
		//}
		public static void ObrisiAlarmniSistem(string serijskibr)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				AlarmniSistem a = s.Get<AlarmniSistem>(serijskibr);
				s.Delete(a);
				s.Flush();
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static AlarmniSistemView VratiAlarmniSistem(string serijskibr)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				AlarmniSistem a = s.Get<AlarmniSistem>(serijskibr);

				if (a == null)
				{
					return null;
				}

				if (a.GetType() == typeof(ToplotniAlarmniSistem))
				{
					return new ToplotniAlarmniSistemView((ToplotniAlarmniSistem)a);
				}
				else if (a.GetType() == typeof(DetekcijaPokretaAlarmniSistem))
				{
					return new DetekcijaPokretaAlarmniSistemView((DetekcijaPokretaAlarmniSistem)a);
				}
				else
				{
					return new UltrazvucniAlarmniSistemView((UltrazvucniAlarmniSistem)a);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		#region ToplotniAlarmniSistemi

		public static void DodajToplotniAlarmniSistem(ToplotniAlarmniSistemView t)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				var alarm = new ToplotniAlarmniSistem();
				var objekat = s.Get<Objekat>(t.Objekat.ObjekatId);
				if (objekat == null)
				{
					s.Close();
					return;
				}

				alarm.HorizontalnaRezolucija = t.HorizontalnaRezolucija;
				alarm.VertikalnaRezolucija = t.VertikalnaRezolucija;

				alarm.Objekat = objekat;
				alarm.DatumInstalacije = t.DatumInstalacije;
				alarm.DatumPoslednjegServisiranja = t.DatumPoslednjegServisiranja;
				alarm.DatumPoslednjegTesta = t.DatumPoslednjegTesta;
				alarm.GodinaProizvodnje = t.GodinaProizvodnje;
				alarm.OtklonjenKvar = t.OtklonjenKvar;
				alarm.Model = t.Model;
				alarm.SerijskiBr = t.SerijskiBr;
				alarm.Proizvodjac = t.Proizvodjac;

				s.Save(alarm);
				s.Flush();
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static void IzmeniToplotniAlarmniSistem(ToplotniAlarmniSistemView t)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				var alarm = s.Get<ToplotniAlarmniSistem>(t.SerijskiBr);

				alarm.HorizontalnaRezolucija = t.HorizontalnaRezolucija != string.Empty
					? t.HorizontalnaRezolucija
					: alarm.HorizontalnaRezolucija;
				alarm.VertikalnaRezolucija = t.VertikalnaRezolucija != string.Empty
					? t.VertikalnaRezolucija
					: alarm.VertikalnaRezolucija;

				alarm.DatumInstalacije = t.DatumInstalacije.ToString() != string.Empty
					? t.DatumInstalacije
					: alarm.DatumInstalacije;
				alarm.DatumPoslednjegServisiranja = t.DatumPoslednjegServisiranja.ToString() != string.Empty
					? t.DatumPoslednjegServisiranja
					: alarm.DatumPoslednjegServisiranja;
				alarm.DatumPoslednjegTesta = t.DatumPoslednjegTesta.ToString() != string.Empty
					? t.DatumPoslednjegTesta
					: alarm.DatumPoslednjegTesta;
				alarm.GodinaProizvodnje =
					t.GodinaProizvodnje != string.Empty ? t.GodinaProizvodnje : alarm.GodinaProizvodnje;
				alarm.OtklonjenKvar = t.OtklonjenKvar != string.Empty ? t.OtklonjenKvar : alarm.OtklonjenKvar;
				alarm.Model = t.Model != string.Empty ? t.Model : alarm.Model;
				alarm.Proizvodjac = t.Proizvodjac != string.Empty ? t.Proizvodjac : alarm.Proizvodjac;

				s.SaveOrUpdate(alarm);
				s.Flush();
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		#endregion ToplotniAlarmniSistemi

		#region UltrazvucniAlarmniSistem

		public static void DodajUltrazvucniAlarmniSistem(UltrazvucniAlarmniSistemView t)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				var alarm = new UltrazvucniAlarmniSistem();
				var objekat = s.Get<Objekat>(t.Objekat.ObjekatId);
				if (objekat == null)
				{
					s.Close();

					return;
				}

				alarm.Frekvencija = t.Frekvencija;

				alarm.Objekat = objekat;
				alarm.DatumInstalacije = t.DatumInstalacije;
				alarm.DatumPoslednjegServisiranja = t.DatumPoslednjegServisiranja;
				alarm.DatumPoslednjegTesta = t.DatumPoslednjegTesta;
				alarm.GodinaProizvodnje = t.GodinaProizvodnje;
				alarm.OtklonjenKvar = t.OtklonjenKvar;
				alarm.Model = t.Model;
				alarm.SerijskiBr = t.SerijskiBr;
				alarm.Proizvodjac = t.Proizvodjac;

				s.Save(alarm);
				s.Flush();
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static void IzmeniUltrazvucniAlarmniSistem(UltrazvucniAlarmniSistemView t)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				var alarm = s.Get<UltrazvucniAlarmniSistem>(t.SerijskiBr);

				alarm.Frekvencija = t.Frekvencija != String.Empty ? t.Frekvencija : alarm.Frekvencija;
				alarm.DatumInstalacije = t.DatumInstalacije.ToString() != string.Empty
					? t.DatumInstalacije
					: alarm.DatumInstalacije;
				alarm.DatumPoslednjegServisiranja = t.DatumPoslednjegServisiranja.ToString() != String.Empty
					? t.DatumPoslednjegServisiranja
					: alarm.DatumPoslednjegServisiranja;
				alarm.DatumPoslednjegTesta = t.DatumPoslednjegTesta.ToString() != String.Empty
					? t.DatumPoslednjegTesta
					: alarm.DatumPoslednjegTesta;
				alarm.GodinaProizvodnje =
					t.GodinaProizvodnje != String.Empty ? t.GodinaProizvodnje : alarm.GodinaProizvodnje;
				alarm.OtklonjenKvar = t.OtklonjenKvar != String.Empty ? t.OtklonjenKvar : alarm.OtklonjenKvar;
				alarm.Model = t.Model != String.Empty ? t.Model : alarm.Model;
				alarm.Proizvodjac = t.Proizvodjac != String.Empty ? t.Proizvodjac : alarm.Proizvodjac;

				s.SaveOrUpdate(alarm);
				s.Flush();
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		#endregion UltrazvucniAlarmniSistem

		#region DetekicijaAlarmniSistem

		public static void DodajDetekcijaAlarmniSistem(DetekcijaPokretaAlarmniSistemView t)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				var alarm = new DetekcijaPokretaAlarmniSistem();
				var objekat = s.Get<Objekat>(t.Objekat.ObjekatId);
				if (objekat == null)
				{
					s.Close();

					return;
				}

				alarm.Osetljivost = t.Osetljivost;
				alarm.Objekat = objekat;
				alarm.DatumInstalacije = t.DatumInstalacije;
				alarm.DatumPoslednjegServisiranja = t.DatumPoslednjegServisiranja;
				alarm.DatumPoslednjegTesta = t.DatumPoslednjegTesta;
				alarm.GodinaProizvodnje = t.GodinaProizvodnje;
				alarm.OtklonjenKvar = t.OtklonjenKvar;
				alarm.Model = t.Model;
				alarm.SerijskiBr = t.SerijskiBr;
				alarm.Proizvodjac = t.Proizvodjac;

				s.Save(alarm);
				s.Flush();
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static void IzmeniDetekcijaAlarmniSistem(DetekcijaPokretaAlarmniSistemView t)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				var alarm = s.Get<DetekcijaPokretaAlarmniSistem>(t.SerijskiBr);

				alarm.Osetljivost = t.Osetljivost != String.Empty ? t.Osetljivost : alarm.Osetljivost;
				alarm.DatumInstalacije = t.DatumInstalacije.ToString() != string.Empty
					? t.DatumInstalacije
					: alarm.DatumInstalacije;
				alarm.DatumPoslednjegServisiranja = t.DatumPoslednjegServisiranja.ToString() != String.Empty
					? t.DatumPoslednjegServisiranja
					: alarm.DatumPoslednjegServisiranja;
				alarm.DatumPoslednjegTesta = t.DatumPoslednjegTesta.ToString() != String.Empty
					? t.DatumPoslednjegTesta
					: alarm.DatumPoslednjegTesta;
				alarm.GodinaProizvodnje =
					t.GodinaProizvodnje != String.Empty ? t.GodinaProizvodnje : alarm.GodinaProizvodnje;
				alarm.OtklonjenKvar = t.OtklonjenKvar != String.Empty ? t.OtklonjenKvar : alarm.OtklonjenKvar;
				alarm.Model = t.Model != String.Empty ? t.Model : alarm.Model;
				alarm.Proizvodjac = t.Proizvodjac != String.Empty ? t.Proizvodjac : alarm.Proizvodjac;

				s.SaveOrUpdate(alarm);
				s.Flush();
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		#endregion DetekicijaAlarmniSistem

		#endregion AlarmniSistemi

		#region Policajac

		public static List<PolicajacView> Vratisvepolicajce()
		{
			List<PolicajacView> policajci = new List<PolicajacView>();

			try
			{
				ISession s = DataLayer.GetSession();

				IEnumerable<Policajac> sviPolicajci = from a in s.Query<Policajac>()
													  select a;
				foreach (Policajac a in sviPolicajci)
				{
					PolicajacView tmp = new PolicajacView(a);
					tmp.Cinovi = a.Cinovi.Select(c => new CinView(c)).ToList();
					tmp.PolicijskaStanica = new PolicijskaStanicaView(a.PolicijskaStanica);

					policajci.Add(tmp);
				}

				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}

			return policajci;
		}

		public static List<PolicajacView> VratiSvePolicajce(int id)
		{
			var policajci = new List<PolicajacView>();
			try
			{
				ISession s = DataLayer.GetSession();
				var sviPolicajci = from o in s.Query<Policajac>()
								   where o.PolicijskaStanica.StanicaId == id
								   select o;
				foreach (Policajac a in sviPolicajci)
				{
					PolicajacView a1 = new PolicajacView(a);
					a1.Cinovi = a.Cinovi.Select(a => new CinView(a)).ToList();
					a1.PolicijskaStanica = new PolicijskaStanicaView(a.PolicijskaStanica);
					policajci.Add(a1);
				}

				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}

			return policajci;
		}

		public static void ObrisiPolicajca(int id)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				Policajac a = s.Get<Policajac>(id);
				s.Delete(a);
				s.Flush();
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static PolicajacView VratiPolicajca(int id)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				var policajac = s.Get<Policajac>(id);
				var p = new PolicajacView(policajac);
				p.Cinovi = policajac.Cinovi.Select(c => new CinView(c)).ToList();
				p.PolicijskaStanica = new PolicijskaStanicaView(policajac.PolicijskaStanica);

				return p;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		#endregion Policajac

		#region PozornikPolicajac

		public static void DodajPolicajcaPozornika(PozornikPolicajacView t)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				var policajac = new PozornikPolicajac();
				var stanica = s.Get<PolicijskaStanica>(t.PolicijskaStanica.StanicaId);
				if (stanica == null)
				{
					return;
				}

				policajac.PolicijskaStanica = stanica;
				policajac.Adresa = t.Adresa;
				policajac.DatumPrijema = t.DatumPrijema;
				policajac.DatumRodjenja = t.DatumRodjenja;
				policajac.DatumSticanjaDiplome = t.DatumSticanjaDiplome;
				policajac.Ime = t.Ime;
				policajac.ImeRoditelja = t.ImeRoditelja;
				policajac.Jmbg = t.Jmbg;
				policajac.Kurs = t.Kurs;
				policajac.Pol = t.Pol;
				policajac.NazivObrazovanja = t.NazivObrazovanja;
				policajac.Pozicija = t.Pozicija;
				policajac.Skola = t.Skola;
				policajac.TipPosla = t.TipPosla;

				s.Save(policajac);
				s.Flush();
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static void IzmeniPozornikPolicajca(PozornikPolicajacView t)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				var pozornik = s.Get<PozornikPolicajac>(t.PolicajacId);

				pozornik.Adresa = !string.IsNullOrEmpty(t.Adresa) ? t.Adresa : pozornik.Adresa;
				pozornik.DatumPrijema = t.DatumPrijema != DateTime.MinValue ? t.DatumPrijema : pozornik.DatumPrijema;

				pozornik.DatumRodjenja = t.DatumRodjenja != DateTime.MinValue ? t.DatumRodjenja : pozornik.DatumRodjenja;
				pozornik.DatumSticanjaDiplome = t.DatumSticanjaDiplome != DateTime.MinValue ? t.DatumSticanjaDiplome : pozornik.DatumSticanjaDiplome;
				pozornik.Ime = !string.IsNullOrEmpty(t.Ime) ? t.Ime : pozornik.Ime;
				pozornik.ImeRoditelja = !string.IsNullOrEmpty(t.ImeRoditelja) ? t.ImeRoditelja : pozornik.ImeRoditelja;
				pozornik.Jmbg = !string.IsNullOrEmpty(t.Jmbg) ? t.Jmbg : pozornik.Jmbg;
				pozornik.Kurs = !string.IsNullOrEmpty(t.Kurs) ? t.Kurs : pozornik.Kurs;
				pozornik.NazivObrazovanja = !string.IsNullOrEmpty(t.NazivObrazovanja) ? t.NazivObrazovanja : pozornik.NazivObrazovanja;
				pozornik.Pol = t.Pol;
				//za karakter ne znam, ako brzo zavrsim vraticu se na ovo da sve zavrsim do 09h
				pozornik.Pozicija = !string.IsNullOrEmpty(t.Pozicija) ? t.Pozicija : pozornik.Pozicija;
				pozornik.TipPosla = !string.IsNullOrEmpty(t.TipPosla) ? t.TipPosla : pozornik.TipPosla;

				s.SaveOrUpdate(pozornik);
				s.Flush();
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static PozornikPolicajacView VratiPozornika(int id)
		{
			try
			{
				ISession s = DataLayer.GetSession();
				var pozornik = s.Get<PozornikPolicajac>(id);
				if (pozornik == null)
					return null;

				var p = new PozornikPolicajacView(pozornik);
				p.Ulice = pozornik.Ulice.Select(u => new UlicaView(u)).ToList();

				return p;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		#endregion PozornikPolicajac

		//dodaj pozornika, prikazi listu, izzbrisi (izmeni nisam uradio)

		#region SkolskiPolicajac

		public static void DodajSkolskogPolicajca(SkolskiPolicajacView t)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				var policajac = new SkolskiPolicajac();
				var stanica = s.Get<PolicijskaStanica>(t.PolicijskaStanica.StanicaId);
				if (stanica == null)
				{
					return;
				}

				policajac.PolicijskaStanica = stanica;
				policajac.NazivSkole = t.NazivSkole;
				policajac.OsobaZaKontakt = t.OsobaZaKontakt;
				policajac.BrojTelefonaSkole = t.BrojTelefonaSkole;
				policajac.SrednjaIliOsnovna = t.SrednjaIliOsnovna;
				policajac.Adresa = t.Adresa;
				policajac.AdresaSkole = t.AdresaSkole;
				policajac.DatumPrijema = t.DatumPrijema;
				policajac.DatumSticanjaDiplome = t.DatumSticanjaDiplome;
				policajac.Ime = t.Ime;
				policajac.ImeRoditelja = t.ImeRoditelja;
				policajac.Jmbg = t.Jmbg;
				policajac.Kurs = t.Kurs;
				policajac.NazivObrazovanja = t.NazivObrazovanja;
				policajac.Pol = t.Pol;
				policajac.Pozicija = t.Pozicija;
				policajac.Skola = t.Skola;
				policajac.TipPosla = t.TipPosla;

				s.Save(policajac);
				s.Flush();
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static void IzmeniSkolskogPolicajca(SkolskiPolicajacView t)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				var skolski = s.Get<SkolskiPolicajac>(t.PolicajacId);

				skolski.Adresa = !string.IsNullOrEmpty(t.Adresa) ? t.Adresa : skolski.Adresa;
				skolski.DatumPrijema = t.DatumPrijema != DateTime.MinValue ? t.DatumPrijema : skolski.DatumPrijema;
				skolski.AdresaSkole = !string.IsNullOrEmpty(t.AdresaSkole) ? t.AdresaSkole : skolski.AdresaSkole;
				skolski.BrojTelefonaSkole = !string.IsNullOrEmpty(t.BrojTelefonaSkole) ? t.BrojTelefonaSkole : skolski.BrojTelefonaSkole;
				skolski.DatumRodjenja = t.DatumRodjenja != DateTime.MinValue ? t.DatumRodjenja : skolski.DatumRodjenja;
				skolski.DatumSticanjaDiplome = t.DatumSticanjaDiplome != DateTime.MinValue ? t.DatumSticanjaDiplome : skolski.DatumSticanjaDiplome;
				skolski.Ime = !string.IsNullOrEmpty(t.Ime) ? t.Ime : skolski.Ime;
				skolski.ImeRoditelja = !string.IsNullOrEmpty(t.ImeRoditelja) ? t.ImeRoditelja : skolski.ImeRoditelja;
				skolski.Jmbg = !string.IsNullOrEmpty(t.Jmbg) ? t.Jmbg : skolski.Jmbg;
				skolski.Kurs = !string.IsNullOrEmpty(t.Kurs) ? t.Kurs : skolski.Kurs;
				skolski.NazivObrazovanja = !string.IsNullOrEmpty(t.NazivObrazovanja) ? t.NazivObrazovanja : skolski.NazivObrazovanja;
				skolski.NazivSkole = !string.IsNullOrEmpty(t.NazivSkole) ? t.NazivSkole : skolski.NazivSkole;
				skolski.OsobaZaKontakt = !string.IsNullOrEmpty(t.OsobaZaKontakt) ? t.OsobaZaKontakt : skolski.OsobaZaKontakt;
				//za karakter ne znam, ako brzo zavrsim vraticu se na ovo da sve zavrsim do 09h
				skolski.Pozicija = !string.IsNullOrEmpty(t.Pozicija) ? t.Pozicija : skolski.Pozicija;
				skolski.SrednjaIliOsnovna = !string.IsNullOrEmpty(t.SrednjaIliOsnovna) ? t.SrednjaIliOsnovna : skolski.SrednjaIliOsnovna;
				skolski.TipPosla = !string.IsNullOrEmpty(t.TipPosla) ? t.TipPosla : skolski.TipPosla;

				s.SaveOrUpdate(skolski);
				s.Flush();
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		#endregion SkolskiPolicajac

		////dodaj skolskog, prikazi listu, izzbrisi (izmeni nisam uradio)

		#region ObicanPolicajac

		public static ObicanPolicajacView VratiObicnogPolicajca(int id)
		{
			try
			{
				ISession s = DataLayer.GetSession();
				var policajac = s.Get<ObicanPolicajac>(id);
				var p = new ObicanPolicajacView(policajac);
				p.Cinovi = policajac.Cinovi.Select(c => new CinView(c)).ToList();
				p.PolicijskaStanica = new PolicijskaStanicaView(policajac.PolicijskaStanica);
				p.PartnerUPatroli = new PatrolaView(policajac.PartnerUPatroli);
				p.VodjaPatrole = new PatrolaView(policajac.VodjaPatrole);
				return p;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static void DodajObicnogPolicajca(ObicanPolicajacView t)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				var policajac = new ObicanPolicajac();
				var stanica = s.Get<PolicijskaStanica>(t.PolicijskaStanica.StanicaId);
				if (stanica == null)
				{
					return;
				}

				policajac.PolicijskaStanica = stanica;
				policajac.Adresa = t.Adresa;
				policajac.DatumPrijema = t.DatumPrijema;
				policajac.DatumRodjenja = t.DatumRodjenja;
				policajac.DatumSticanjaDiplome = t.DatumSticanjaDiplome;
				policajac.Ime = t.Ime;
				policajac.ImeRoditelja = t.ImeRoditelja;
				policajac.Jmbg = t.Jmbg;
				policajac.Kurs = t.Kurs;
				policajac.Pol = t.Pol;
				policajac.NazivObrazovanja = t.NazivObrazovanja;
				policajac.Pozicija = t.Pozicija;
				policajac.Skola = t.Skola;
				policajac.TipPosla = t.TipPosla;

				s.Save(policajac);
				s.Flush();
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static void IzmeniObicnogPolicajca(ObicanPolicajacView t)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				var obican = s.Get<ObicanPolicajac>(t.PolicajacId);

				obican.Adresa = !string.IsNullOrEmpty(t.Adresa) ? t.Adresa : obican.Adresa;
				obican.DatumPrijema = t.DatumPrijema != DateTime.MinValue ? t.DatumPrijema : obican.DatumPrijema;

				obican.DatumRodjenja = t.DatumRodjenja != DateTime.MinValue ? t.DatumRodjenja : obican.DatumRodjenja;
				obican.DatumSticanjaDiplome = t.DatumSticanjaDiplome != DateTime.MinValue ? t.DatumSticanjaDiplome : obican.DatumSticanjaDiplome;
				obican.Ime = !string.IsNullOrEmpty(t.Ime) ? t.Ime : obican.Ime;
				obican.ImeRoditelja = !string.IsNullOrEmpty(t.ImeRoditelja) ? t.ImeRoditelja : obican.ImeRoditelja;
				obican.Jmbg = !string.IsNullOrEmpty(t.Jmbg) ? t.Jmbg : obican.Jmbg;
				obican.Kurs = !string.IsNullOrEmpty(t.Kurs) ? t.Kurs : obican.Kurs;
				obican.NazivObrazovanja = !string.IsNullOrEmpty(t.NazivObrazovanja) ? t.NazivObrazovanja : obican.NazivObrazovanja;

				//za karakter ne znam, ako brzo zavrsim vraticu se na ovo da sve zavrsim do 09h
				obican.Pozicija = !string.IsNullOrEmpty(t.Pozicija) ? t.Pozicija : obican.Pozicija;
				obican.TipPosla = !string.IsNullOrEmpty(t.TipPosla) ? t.TipPosla : obican.TipPosla;

				s.SaveOrUpdate(obican);
				s.Flush();
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		#endregion ObicanPolicajac

		//dodaj obicnog, prikazi listu, izzbrisi (izmeni nisam uradio)

		#region VanredniPolicajac

		public static void DodajVanrednogPolicajaca(VanredniPolicajacView t)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				var policajac = new VanredniPolicajac();
				var stanica = s.Get<PolicijskaStanica>(t.PolicijskaStanica.StanicaId);
				if (stanica == null)
				{
					return;
				}

				policajac.PolicijskaStanica = stanica;
				policajac.DatumPrijema = t.DatumPrijema;
				policajac.DatumRodjenja = t.DatumRodjenja;
				policajac.DatumSticanjaDiplome = t.DatumSticanjaDiplome;
				policajac.Ime = t.Ime;
				policajac.ImeRoditelja = t.ImeRoditelja;
				policajac.Jmbg = t.Jmbg;
				policajac.Kurs = t.Kurs;
				policajac.Pol = t.Pol;
				policajac.NazivObrazovanja = t.NazivObrazovanja;
				policajac.Pozicija = t.Pozicija;
				policajac.Skola = t.Skola;
				policajac.TipPosla = t.TipPosla;

				s.Save(policajac);
				s.Flush();
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static void IzmeniVanrednogPolicajca(VanredniPolicajacView t)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				var vanredni = s.Get<VanredniPolicajac>(t.PolicajacId);

				vanredni.Adresa = !string.IsNullOrEmpty(t.Adresa) ? t.Adresa : vanredni.Adresa;
				vanredni.DatumPrijema = t.DatumPrijema != DateTime.MinValue ? t.DatumPrijema : vanredni.DatumPrijema;

				vanredni.DatumRodjenja = t.DatumRodjenja != DateTime.MinValue ? t.DatumRodjenja : vanredni.DatumRodjenja;
				vanredni.DatumSticanjaDiplome = t.DatumSticanjaDiplome != DateTime.MinValue ? t.DatumSticanjaDiplome : vanredni.DatumSticanjaDiplome;
				vanredni.Ime = !string.IsNullOrEmpty(t.Ime) ? t.Ime : vanredni.Ime;
				vanredni.ImeRoditelja = !string.IsNullOrEmpty(t.ImeRoditelja) ? t.ImeRoditelja : vanredni.ImeRoditelja;
				vanredni.Jmbg = !string.IsNullOrEmpty(t.Jmbg) ? t.Jmbg : vanredni.Jmbg;
				vanredni.Kurs = !string.IsNullOrEmpty(t.Kurs) ? t.Kurs : vanredni.Kurs;
				vanredni.NazivObrazovanja = !string.IsNullOrEmpty(t.NazivObrazovanja) ? t.NazivObrazovanja : vanredni.NazivObrazovanja;

				//za karakter ne znam, ako brzo zavrsim vraticu se na ovo da sve zavrsim do 09h
				vanredni.Pozicija = !string.IsNullOrEmpty(t.Pozicija) ? t.Pozicija : vanredni.Pozicija;
				vanredni.TipPosla = !string.IsNullOrEmpty(t.TipPosla) ? t.TipPosla : vanredni.TipPosla;

				s.SaveOrUpdate(vanredni);
				s.Flush();
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static VanredniPolicajacView VratiVanrednogPolicajca(int id)
		{
			try
			{
				ISession s = DataLayer.GetSession();
				var vanredni = s.Get<VanredniPolicajac>(id);
				var v = new VanredniPolicajacView(vanredni);
				v.Cinovi = vanredni.Cinovi.Select(c => new CinView(c)).ToList();
				v.PolicijskaStanica = new PolicijskaStanicaView(vanredni.PolicijskaStanica);
				v.Kursevi = vanredni.Kursevi.Select(c => new KursView(c)).ToList();
				v.Sertifikati = vanredni.Sertifikati.Select(c => new SertifikatView(c)).ToList();
				v.Vestine = vanredni.Vestine.Select(c => new VestinaView(c)).ToList();

				return v;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		#endregion VanredniPolicajac

		#region Sertifikat

		public static List<SertifikatView> VratiSveSertifikate()
		{
			List<SertifikatView> sertifikati = new List<SertifikatView>();
			try
			{
				ISession s = DataLayer.GetSession();

				IEnumerable<Sertifikat> sviSertifikati = from a in s.Query<Sertifikat>()
														 select a;
				foreach (Sertifikat a in sviSertifikati)
				{
					SertifikatView tmp = new SertifikatView(a);
					tmp.Policajac = new VanredniPolicajacView(a.Policajac);

					sertifikati.Add(tmp);
				}

				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}

			return sertifikati;
		}

		public static List<SertifikatView> VratiSertifikate(int id)
		{
			var sertifikati = new List<SertifikatView>();
			try
			{
				ISession s = DataLayer.GetSession();
				IEnumerable<Sertifikat> sviSertifikati = from c in s.Query<Sertifikat>()
														 where c.Policajac.PolicajacId == id
														 select c;

				foreach (var sertifikat in sviSertifikati)
				{
					var tmp = new SertifikatView(sertifikat);
					tmp.Policajac = new VanredniPolicajacView(sertifikat.Policajac);
					sertifikati.Add(tmp);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}

			return sertifikati;
		}

		public static void DodajSertifikat(SertifikatView c)
		{
			try
			{
				ISession s = DataLayer.GetSession();
				var sertifikat = new Sertifikat();
				var Vanrednipolicajac = s.Get<VanredniPolicajac>(c.Policajac.PolicajacId);
				if (Vanrednipolicajac == null)
					return;
				sertifikat.Policajac = Vanrednipolicajac;
				sertifikat.DatumSticanja = c.DatumSticanja;
				sertifikat.Naziv = c.Naziv;

				s.Save(sertifikat);
				s.Flush();
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static void IzmeniSertifikat(SertifikatView c)
		{
			try
			{
				ISession s = DataLayer.GetSession();
				var sertifikat = s.Get<Sertifikat>(c.SertifikatId);

				sertifikat.Naziv = !string.IsNullOrEmpty(c.Naziv) ? c.Naziv : sertifikat.Naziv;
				sertifikat.DatumSticanja = c.DatumSticanja != DateTime.MinValue ? c.DatumSticanja : sertifikat.DatumSticanja;

				s.SaveOrUpdate(sertifikat);
				s.Flush();
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static void ObrisiSertifikat(int id)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				var sertifikat = s.Get<Sertifikat>(id);
				s.Delete(sertifikat);
				s.Flush();
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		#endregion Sertifikat

		#region PolicijskaStanica

		public static List<PolicijskaStanicaView> VratiPolicijskeStanice()
		{
			List<PolicijskaStanicaView> stanice = new List<PolicijskaStanicaView>();
			try
			{
				ISession s = DataLayer.GetSession();

				IEnumerable<PolicijskaStanica> sveStanice = from a in s.Query<PolicijskaStanica>()
															select a;
				foreach (PolicijskaStanica a in sveStanice)
				{
					PolicijskaStanicaView tmp = new PolicijskaStanicaView(a);
					tmp.Sef = new PolicajacView(a.Sef);
					tmp.Zamenik = new PolicajacView(a.Zamenik);
					tmp.Objekti = a.Objekti.Select(c => new ObjekatView(c)).ToList();
					tmp.SluzbenaVozila = a.SluzbenaVozila.Select(c => new SluzbenoVoziloView(c)).ToList();
					tmp.Policajci = a.Policajci.Select(c => new PolicajacView(c)).ToList();

					stanice.Add(tmp);
				}

				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}

			return stanice;
		}

		public static PolicijskaStanicaView VratiPolicijskuStanicu(int id)
		{
			try
			{
				ISession s = DataLayer.GetSession();
				var stanica = s.Get<PolicijskaStanica>(id);

				var st = new PolicijskaStanicaView(stanica);
				st.Objekti = stanica.Objekti.Select(o => new ObjekatView(o)).ToList();
				st.Policajci = stanica.Policajci.Select(p => new PolicajacView(p)).ToList();
				st.SluzbenaVozila = stanica.SluzbenaVozila.Select(v => new SluzbenoVoziloView(v)).ToList();
				st.Zamenik = new PolicajacView(stanica.Zamenik);
				st.Sef = new PolicajacView(stanica.Sef);

				return st;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static List<PolicijskaStanicaView> VratiStanice(int id)
		{
			var stanice = new List<PolicijskaStanicaView>();
			try
			{
				ISession s = DataLayer.GetSession();
				IEnumerable<PolicijskaStanica> sveStanice = from c in s.Query<PolicijskaStanica>()
															where c.Sef.PolicajacId == id || c.Zamenik.PolicajacId == id
															select c;

				foreach (var stanica in sveStanice)
				{
					var tmp = new PolicijskaStanicaView(stanica);
					tmp.Sef = new PolicajacView(stanica.Sef);
					tmp.Zamenik = new PolicajacView(stanica.Zamenik);
					stanice.Add(tmp);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}

			return stanice;
		}

		public static void DodajStanice(PolicijskaStanicaView c)
		{
			try
			{
				ISession s = DataLayer.GetSession();
				var stanica = new PolicijskaStanica();

				stanica.Naziv = c.Naziv;
				stanica.Adresa = c.Adresa;
				stanica.DatumOsnivanja = c.DatumOsnivanja;
				stanica.Opstina = c.Opstina;

				s.Save(stanica);
				s.Flush();
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static void IzmeniStanicu(PolicijskaStanicaView c)
		{
			try
			{
				ISession s = DataLayer.GetSession();
				var stanica = s.Get<PolicijskaStanica>(c.StanicaId);

				stanica.Naziv = !string.IsNullOrEmpty(c.Naziv) ? c.Naziv : stanica.Naziv;
				stanica.DatumOsnivanja = c.DatumOsnivanja != DateTime.MinValue ? c.DatumOsnivanja : stanica.DatumOsnivanja;
				stanica.Adresa = !string.IsNullOrEmpty(c.Adresa) ? c.Adresa : stanica.Adresa;
				stanica.Opstina = !string.IsNullOrEmpty(c.Opstina) ? c.Opstina : stanica.Opstina;

				s.SaveOrUpdate(stanica);
				s.Flush();
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static void ObrisiStanicu(int id)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				var stanica = s.Get<PolicijskaStanica>(id);
				s.Delete(stanica);
				s.Flush();
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		#endregion PolicijskaStanica

		#region Ulica

		public static List<UlicaView> VratiSveUlice()
		{
			List<UlicaView> ulice = new List<UlicaView>();
			try
			{
				ISession s = DataLayer.GetSession();

				IEnumerable<Ulica> sveUlice = from a in s.Query<Ulica>()
											  select a;
				foreach (Ulica a in sveUlice)
				{
					UlicaView tmp = new UlicaView(a);
					tmp.Policajac = new PozornikPolicajacView(a.Policajac);

					ulice.Add(tmp);
				}

				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}

			return ulice;
		}

		public static List<UlicaView> VratiSveUlice(int id)
		{
			var ulice = new List<UlicaView>();
			try
			{
				ISession s = DataLayer.GetSession();
				IEnumerable<Ulica> sveUlice = from c in s.Query<Ulica>()
											  where c.Policajac.PolicajacId == id
											  select c;

				foreach (var ulica in sveUlice)
				{
					var tmp = new UlicaView(ulica);
					tmp.Policajac = new PozornikPolicajacView(ulica.Policajac);
					ulice.Add(tmp);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}

			return ulice;
		}

		public static void DodajUlicu(UlicaView c)
		{
			try
			{
				ISession s = DataLayer.GetSession();
				var ulica = new Ulica();
				var Pozornik = s.Get<PozornikPolicajac>(c.Policajac.PolicajacId);
				if (Pozornik == null)
					return;
				ulica.Policajac = Pozornik;

				ulica.Naziv = c.Naziv;

				s.Save(ulica);
				s.Flush();
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static void IzmeniUlicu(UlicaView c)
		{
			try
			{
				ISession s = DataLayer.GetSession();
				var ulica = s.Get<Ulica>(c.UlicaId);

				ulica.Naziv = !string.IsNullOrEmpty(c.Naziv) ? c.Naziv : ulica.Naziv;

				s.SaveOrUpdate(ulica);
				s.Flush();
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static void ObrisiUlicu(int id)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				var ulica = s.Get<Ulica>(id);
				s.Delete(ulica);
				s.Flush();
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		#endregion Ulica
	}
}