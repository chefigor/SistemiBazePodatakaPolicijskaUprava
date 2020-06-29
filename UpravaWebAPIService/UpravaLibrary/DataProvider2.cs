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
		#region SluzbenoVozilo

		public static SluzbenoVoziloView VratiVozilo(int id)
		{
			try
			{
				ISession s = DataLayer.GetSession();
				var v = s.Get<SluzbenoVozilo>(id);
				var vozilo= new SluzbenoVoziloView(v);
				vozilo.Patrola=new PatrolaView(v.Patrola);
				vozilo.Stanica=new PolicijskaStanicaView(v.Stanica);
				return vozilo;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		#endregion
				
		#region TehnickoLice

	public static TehnickoLiceView VratiTehnickoLice(int id)
	{
			try
			{
				ISession s = DataLayer.GetSession();
				var t = s.Get<TehnickoLice>(id);

				var tehnicko = new TehnickoLiceView(t);
				tehnicko.ZaduzenZa =t.ZaduzenZa.Select(i=> new ZaduzenView(i)).ToList();
				return tehnicko;
			
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw;
		}
	}


	public static void DodajTehnickoLice(TehnickoLiceView t)
	{
		try
		{
			ISession s = DataLayer.GetSession();
				

				 var tehnicko = new TehnickoLice();

				tehnicko.Ime = t.Ime;
				tehnicko.Prezime = t.Prezime;
				tehnicko.KontaktBr = t.KontaktBr;



			s.Save(tehnicko);
			s.Flush();
			s.Close();

		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw;
		}
	}

	public static void ObrisiTehnickoLice(int id)
	{
		try
		{
			ISession s = DataLayer.GetSession();

			var tehnicko = s.Get<TehnickoLice>(id);

			   
			if (tehnicko == null)
			return;

			
			s.Delete(tehnicko);
			s.Flush();
			s.Close();
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw;
		}
	}

		#endregion TehnickoLice
/*
		#region Ulica

		public static List<UlicaView> VratiUlice(int id)
		{
			var ulice = new List<UlicaView>();
			try
			{
				ISession s = DataLayer.GetSession();
				IEnumerable<Ulica> sveulice = from c in s.Query<Ulica>()
											 where c.PozornikPolicajac.PolicajacId == id
											 select c;

				foreach (var ulica in sveulice)
				{
					var tmp = new UlicaView(ulica);
					tmp.Policajac = new PolicajacView(ulica.Policajac);
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

		public static void DodajUlicu(UlicaView u)
		{
			try
			{
				ISession s = DataLayer.GetSession();
				var ulica = new Ulica();
				var policajac = s.Get<PozornikPolicajac>(u.Policajac.PolicajacId);
				if (policajac == null)
					return;

				ulica.Naziv = u.Naziv;
				ulica.Policajac = policajac;
				ulica.UlicaId = u.UlicaId;


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

		public static void IzmeniUlicu(UlicaView u)
		{
			try
			{
				ISession s = DataLayer.GetSession();
				var ulica = s.Get<Ulica>(u.UlicaId);

				ulica.Naziv = !string.IsNullOrEmpty(u.Naziv) ? u.Naziv : ulica.Naziv;

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
*/
		#region Vestina

		public static List<VestinaView> VratiVestine(int id)
		{
			var vestine = new List<VestinaView>();
			try
			{
				ISession s = DataLayer.GetSession();
				IEnumerable<Vestina> svevestine = from c in s.Query<Vestina>()
											 where c.Policajac.PolicajacId == id
											 select c;

				foreach (var vestina in svevestine)
				{
					var tmp = new VestinaView(vestina);
					tmp.Policajac = new VanredniPolicajacView(vestina.Policajac);
					vestine.Add(tmp);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}

			return vestine;
		}

		public static void DodajVestinu(VestinaView v)
		{
			try
			{
				ISession s = DataLayer.GetSession();
				var vestina = new Vestina();

				var policajac = s.Get<VanredniPolicajac>(v.Policajac.PolicajacId);
				if (policajac == null)
					return;

				vestina.Naziv = v.Naziv;
				vestina.Policajac = policajac;

				s.Save(vestina);
				s.Flush();
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static void IzmeniVestinu(VestinaView v)
		{
			try
			{
				ISession s = DataLayer.GetSession();
				var vestina = s.Get<Vestina>(v.VestinaId);

				vestina.Naziv = !string.IsNullOrEmpty(v.Naziv) ? v.Naziv : vestina.Naziv;

				s.SaveOrUpdate(vestina);
				s.Flush();
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static void ObrisiVestinu(int id)
		{
			try
			{
				ISession s = DataLayer.GetSession();

				var vestina = s.Get<Vestina>(id);
				s.Delete(vestina);
				s.Flush();
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		#endregion Vestina

		#region Zaduzen


		public static List<ZaduzenView> VratiSveZaduzene()
		{
			var zaduzeni = new List<ZaduzenView>();
			try
			{
				ISession s = DataLayer.GetSession();
				var sviZaduzeni = from i in s.Query<Zaduzen>() select i;

				foreach (var zaduzen in sviZaduzeni)
				{
					ZaduzenView tmp = new ZaduzenView(zaduzen);
					tmp.Alarm = new AlarmniSistemView(zaduzen.Alarm);
					tmp.Tehnicar = new TehnickoLiceView(zaduzen.Tehnicar);
					zaduzeni.Add(tmp);
				}
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}

			return zaduzeni;
		}

		public static List<ZaduzenView> VratiSveZaduzeneAlarm(string serijskibr)
		{
			var zaduzeni = new List<ZaduzenView>();
			try
			{
				ISession s = DataLayer.GetSession();
				var sviZaduzeni = from i in s.Query<Zaduzen>() where i.Alarm.SerijskiBr == serijskibr select i;

				foreach (var zaduzen in sviZaduzeni)
				{
					ZaduzenView tmp = new ZaduzenView(zaduzen);
					tmp.Alarm = new AlarmniSistemView(zaduzen.Alarm);
					tmp.Tehnicar = new TehnickoLiceView(zaduzen.Tehnicar);
					zaduzeni.Add(tmp);
				}

				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}

			return zaduzeni;
		}

		public static List<ZaduzenView> VratiSveZaduzeneTehnicar(int id)
		{
			var zaduzeni = new List<ZaduzenView>();
			try
			{
				ISession s = DataLayer.GetSession();
				var sviZaduzeni = from i in s.Query<Zaduzen>() where i.Tehnicar.TehnicarId == id select i;

				foreach (var zaduzen in sviZaduzeni)
				{
					ZaduzenView tmp = new ZaduzenView(zaduzen);
					tmp.Alarm = new AlarmniSistemView(zaduzen.Alarm);
					tmp.Tehnicar = new TehnickoLiceView(zaduzen.Tehnicar);
					zaduzeni.Add(tmp);
				}

				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}

			return zaduzeni;
		}

		public static ZaduzenView VratiZaduzenog(int id)
		{
			var zaduzen = new ZaduzenView();
			try
			{
				ISession s = DataLayer.GetSession();
				var z = s.Get<Zaduzen>(id);
				if (z == null)
					return null;
				zaduzen = new ZaduzenView(z);
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}

			return zaduzen;
		}

		public static void IzmeniZaduzenog(ZaduzenView z)
		{
			try
			{
				ISession s = DataLayer.GetSession();
				var zaduzen = s.Get<Zaduzen>(z.ZaduzenId);

				zaduzen.DatumOd = z.DatumOd != DateTime.MinValue ? z.DatumOd : zaduzen.DatumOd;
				zaduzen.DatumDo = z.DatumDo != DateTime.MinValue ? z.DatumDo : zaduzen.DatumDo;


				s.Save(zaduzen);
				s.Flush();
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static void DodajZaduzenog(ZaduzenView z)
		{
			try
			{
				ISession s = DataLayer.GetSession();
				var alarm = s.Get<AlarmniSistem>(z.Alarm.SerijskiBr);
				var tehnicar = s.Get<TehnickoLice>(z.Tehnicar.TehnicarId);
				if (alarm == null || tehnicar == null)
					return;

				var zaduzen = new Zaduzen();
				zaduzen.Alarm = alarm;
				zaduzen.Tehnicar = tehnicar;
				zaduzen.DatumOd = z.DatumOd;
				zaduzen.DatumDo = z.DatumDo;


				s.Save(zaduzen);
				s.Flush();
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static void ObrisiZaduzenog(int id)
		{
			try
			{
				ISession s = DataLayer.GetSession();
				var zaduzen = s.Get<Zaduzen>(id);
				if (zaduzen == null)
					return;
				s.Delete(zaduzen);
				s.Flush();
				s.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}
		#endregion Zaduzen
	}
}