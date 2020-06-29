using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate;
using NHibernate;
using UpravaLibrary.DTOs;
using UpravaLibrary.Entiteti;

namespace UpravaLibrary
{
	public partial class DataProvider
	{
		#region Cin

		public static List<CinView> VratiCinovePolicajac(int id)
		{
			var cinovi = new List<CinView>();
			try
			{
				ISession s = DataLayer.GetSession();
				IEnumerable<Cin> svicinovi = from c in s.Query<Cin>()
											 where c.Policajac.PolicajacId == id
											 select c;

				foreach (var cin in svicinovi)
				{
					var tmp = new CinView(cin);
					tmp.Policajac = new PolicajacView(cin.Policajac);
					cinovi.Add(tmp);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}

			return cinovi;
		}

		public static void DodajCin(CinView c)
		{
			try
			{
				ISession s = DataLayer.GetSession();
				var cin = new Cin();
				var policajac = s.Get<Policajac>(c.Policajac.PolicajacId);
				if (policajac == null)
					return;
				cin.Policajac = policajac;
				cin.DatumSticanja = c.DatumSticanja;
				cin.Naziv = c.Naziv;

				s.Save(cin);
				s.Flush();
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static void IzmeniCin(CinView c)
		{
			try
			{
				ISession s = DataLayer.GetSession();
				var cin = s.Get<Cin>(c.CinId);

				cin.Naziv = !string.IsNullOrEmpty(c.Naziv) ? c.Naziv : cin.Naziv;
				cin.DatumSticanja = c.DatumSticanja != DateTime.MinValue ? c.DatumSticanja : cin.DatumSticanja;

				s.SaveOrUpdate(cin);
				s.Flush();
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static void ObrisiCin(int id)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				var cin = s.Get<Cin>(id);
				s.Delete(cin);
				s.Flush();
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		#endregion Cin

		#region Intervencija

		public static List<IntervencijaView> VratiSveIntervencije()
		{
			var intervencije = new List<IntervencijaView>();
			try
			{
				ISession s = DataLayer.GetSession();

				var sveIntervencije = from i in s.Query<Intervencija>() select i;

				foreach (var intervencija in sveIntervencije)
				{
					IntervencijaView tmp = new IntervencijaView(intervencija);
					tmp.Objekat = new ObjekatView(intervencija.Objekat);
					tmp.Patrola = new PatrolaView(intervencija.Patrola);
					intervencije.Add(tmp);
				}

				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}

			return intervencije;
		}

		public static List<IntervencijaView> VratisveIntervencijeObjekat(int id)
		{
			var intervencije = new List<IntervencijaView>();
			try
			{
				ISession s = DataLayer.GetSession();

				var sveIntervencije = from i in s.Query<Intervencija>() where i.Objekat.ObjekatId == id select i;

				foreach (var intervencija in sveIntervencije)
				{
					IntervencijaView tmp = new IntervencijaView(intervencija);
					tmp.Objekat = new ObjekatView(intervencija.Objekat);
					tmp.Patrola = new PatrolaView(intervencija.Patrola);
					intervencije.Add(tmp);
				}

				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}

			return intervencije;
		}

		public static List<IntervencijaView> VratiSveIntervencijePatrola(int id)
		{
			var intervencije = new List<IntervencijaView>();
			try
			{
				ISession s = DataLayer.GetSession();

				var sveIntervencije = from i in s.Query<Intervencija>() where i.Patrola.PatrolaId == id select i;

				foreach (var intervencija in sveIntervencije)
				{
					IntervencijaView tmp = new IntervencijaView(intervencija);
					tmp.Objekat = new ObjekatView(intervencija.Objekat);
					tmp.Patrola = new PatrolaView(intervencija.Patrola);
					intervencije.Add(tmp);
				}

				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}

			return intervencije;
		}

		public static IntervencijaView VratiIntervenciju(int id)
		{
			var intervencija = new IntervencijaView();
			try
			{
				ISession s = DataLayer.GetSession();
				var i = s.Get<Intervencija>(id);
				if (i == null)
					return null;
				intervencija = new IntervencijaView(i);
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}

			return intervencija;
		}

		public static void IzmeniIntervenciju(IntervencijaView i)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				var intervencija = s.Get<Intervencija>(i.IntervencijaId);

				intervencija.Datum = i.Datum != DateTime.MinValue ? i.Datum : intervencija.Datum;
				intervencija.Opis = !string.IsNullOrEmpty(i.Opis) ? i.Opis : intervencija.Opis;
				intervencija.Vreme = !string.IsNullOrEmpty(i.Vreme) ? i.Vreme : intervencija.Vreme;

				s.Save(intervencija);
				s.Flush();
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static void DodajIntervenciju(IntervencijaView i)
		{
			try
			{
				ISession s = DataLayer.GetSession();
				var patrola = s.Get<Patrola>(i.Patrola.PatrolaId);
				var objekat = s.Get<Objekat>(i.Objekat.ObjekatId);
				if (patrola == null || objekat == null)
					return;

				var intervencija = new Intervencija();
				intervencija.Datum = i.Datum;
				intervencija.Opis = i.Opis;
				intervencija.Vreme = i.Vreme;
				intervencija.Patrola = patrola;
				intervencija.Objekat = objekat;

				s.Save(intervencija);
				s.Flush();
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static void ObrisiIntervenciju(int id)
		{
			try
			{
				ISession s = DataLayer.GetSession();
				var intervencija = s.Get<Intervencija>(id);
				if (intervencija == null)
					return;
				s.Delete(intervencija);
				s.Flush();
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		#endregion Intervencija

		#region Kurs

		public static List<KursView> VratiKurseveVanredniPolicajac(int id)
		{
			var kursevi = new List<KursView>();
			try
			{
				ISession s = DataLayer.GetSession();

				var svikursevi = from k in s.Query<Kurs>() where k.Policajac.PolicajacId == id select k;

				foreach (var kurs in svikursevi)
				{
					var tmp = new KursView(kurs);
					tmp.Policajac = new VanredniPolicajacView(kurs.Policajac);
					kursevi.Add(tmp);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}

			return kursevi;
		}

		public static void DodajKurs(KursView k)
		{
			try
			{
				ISession s = DataLayer.GetSession();
				var policajac = s.Get<VanredniPolicajac>(k.Policajac.PolicajacId);
				if (policajac == null)
					return;
				var kurs = new Kurs();
				kurs.Naziv = k.Naziv;
				kurs.DatumZavrsetka = k.DatumZavrsetka;
				kurs.Policajac = policajac;

				s.Save(kurs);
				s.Flush();
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static void IzmeniKurs(KursView k)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				var kurs = s.Get<Kurs>(k.KursId);

				kurs.Naziv = !string.IsNullOrEmpty(k.Naziv) ? k.Naziv : kurs.Naziv;
				kurs.DatumZavrsetka = k.DatumZavrsetka != DateTime.MinValue ? k.DatumZavrsetka : kurs.DatumZavrsetka;

				s.SaveOrUpdate(kurs);
				s.Flush();
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static void ObrisiKurs(int id)
		{
			try
			{
				ISession s = DataLayer.GetSession();
				var kurs = s.Get<Kurs>(id);
				s.Delete(kurs);
				s.Flush();
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		#endregion Kurs

		#region Patrola

		public static PatrolaView VratiPatrolu(int id)
		{
			try
			{
				ISession s = DataLayer.GetSession();
				var p = s.Get<Patrola>(id);
				var patrola = new PatrolaView(p);
				patrola.Vozilo = new SluzbenoVoziloView(p.Vozilo);
				patrola.Vodja = new ObicanPolicajacView(p.Vodja);
				patrola.Partner = new ObicanPolicajacView(p.Partner);
				patrola.Intervencije = p.Intervencije.Select(i => new IntervencijaView(i)).ToList();
				return patrola;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static List<PatrolaView> VratiSvePatrole()
		{
			var patrole = new List<PatrolaView>();
			try
			{
				ISession s = DataLayer.GetSession();
				var svepatrole = from p in s.Query<Patrola>() select p;

				foreach (var patrola in svepatrole)
				{
					var tmp = new PatrolaView(patrola);
					tmp.Vodja = new ObicanPolicajacView(patrola.Vodja);
					tmp.Partner = new ObicanPolicajacView(patrola.Partner);
					tmp.Vozilo = new SluzbenoVoziloView(patrola.Vozilo);
					tmp.Intervencije = patrola.Intervencije.Select(i => new IntervencijaView(i)).ToList();
					patrole.Add(tmp);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}

			return patrole;
		}

		public static void DodajPatrolu(PatrolaView p)
		{
			try
			{
				ISession s = DataLayer.GetSession();
				var vodja = s.Get<ObicanPolicajac>(p.Vodja.PolicajacId);
				var partner = s.Get<ObicanPolicajac>(p.Partner.PolicajacId);
				var vozilo = s.Get<SluzbenoVozilo>(p.Vozilo.VoziloId);

				var patrola = new Patrola();

				patrola.Partner = partner;
				patrola.Vozilo = vozilo;
				patrola.Vodja = vodja;

				s.Save(patrola);
				s.Flush();
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static void ObrisiPatrolu(int id)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				var patrola = s.Get<Patrola>(id);

				foreach (var intervencija in patrola.Intervencije)
				{
					ObrisiIntervenciju(intervencija.IntervencijaId);
				}
				s.Delete(patrola);
				s.Flush();
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		#endregion Patrola

		#region Objekat

		public static ObjekatView VratiObjekat(int objekatId)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				Objekat o = s.Get<Objekat>(objekatId);

				if (o == null)
				{
					return null;
				}

				var objekat = new ObjekatView(o);
				objekat.Alarmi = o.Alarmi.Select(a => new AlarmniSistemView(a)).ToList();
				objekat.Intervencije = o.Intervencije.Select(i => new IntervencijaView(i)).ToList();
				objekat.PolicijskaStanica = new PolicijskaStanicaView(o.PolicijskaStanica);

				return objekat;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static List<ObjekatView> VratiSveObjektePolicijskaStanica(int id)
		{
			var objekti = new List<ObjekatView>();
			try
			{
				ISession s = DataLayer.GetSession();
				var sviObjekti = from o in s.Query<Objekat>() where o.PolicijskaStanica.StanicaId == id select o;

				foreach (var objekat in sviObjekti)
				{
					var tmp = new ObjekatView(objekat);
					tmp.Alarmi = objekat.Alarmi.Select(a => new AlarmniSistemView(a)).ToList();
					tmp.Intervencije = objekat.Intervencije.Select(i => new IntervencijaView(i)).ToList();
					tmp.PolicijskaStanica = new PolicijskaStanicaView(objekat.PolicijskaStanica);
					objekti.Add(tmp);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}

			return objekti;
		}

		public static List<ObjekatView> VratiSveObjekte()
		{
			var objekti = new List<ObjekatView>();
			try
			{
				ISession s = DataLayer.GetSession();
				var sviObjekti = s.Query<Objekat>();

				foreach (var objekat in sviObjekti)
				{
					var tmp = new ObjekatView(objekat);
					tmp.Alarmi = objekat.Alarmi.Select(a => new AlarmniSistemView(a)).ToList();
					tmp.Intervencije = objekat.Intervencije.Select(i => new IntervencijaView(i)).ToList();
					tmp.PolicijskaStanica = new PolicijskaStanicaView(objekat.PolicijskaStanica);
					objekti.Add(tmp);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}

			return objekti;
		}

		public static void ObrisiObjekat(int id)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				var objekat = s.Get<Objekat>(id);

				s.Delete(objekat);
				s.Flush();
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static void DodajObjekat(ObjekatView o)
		{
			try
			{
				ISession s = DataLayer.GetSession();
				var objekat = new Objekat();
				var policijskastanica = s.Get<PolicijskaStanica>(o.PolicijskaStanica.StanicaId);
				objekat.PolicijskaStanica = policijskastanica;
				objekat.Adresa = o.Adresa;
				objekat.Broj = o.Broj;
				objekat.Ime = o.Ime;
				objekat.Prezime = o.Prezime;
				objekat.Povrsina = o.Povrsina;
				objekat.TipObjekta = o.TipObjekta;

				s.Save(objekat);
				s.Flush();
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static void IzmeniObjekat(ObjekatView o)
		{
			try
			{
				ISession s = DataLayer.GetSession();
				var objekat = s.Get<Objekat>(o.ObjekatId);

				objekat.Adresa = !string.IsNullOrEmpty(o.Adresa) ? o.Adresa : objekat.Adresa;
				objekat.Broj = !string.IsNullOrEmpty(o.Broj) ? o.Broj : objekat.Broj;
				objekat.Ime = !string.IsNullOrEmpty(o.Ime) ? o.Ime : objekat.Ime;
				objekat.Prezime = !string.IsNullOrEmpty(o.Prezime) ? o.Prezime : objekat.Prezime;
				objekat.Povrsina = !double.IsNaN(o.Povrsina) ? o.Povrsina : objekat.Povrsina;
				objekat.TipObjekta = !string.IsNullOrEmpty(o.TipObjekta) ? o.TipObjekta : objekat.TipObjekta;
				s.SaveOrUpdate(objekat);
				s.Flush();
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		#endregion Objekat
	}
}