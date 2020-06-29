using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using UpravaLibrary.Mapiranja;

namespace UpravaLibrary
{
	internal class DataLayer
	{
		private static ISessionFactory _factory = null;
		private static object objLock = new object();

		public static ISession GetSession()
		{
			if (_factory == null)
			{
				lock (objLock)
				{
					if (_factory == null)
						_factory = CreateSessionFactory();
				}
			}

			return _factory.OpenSession();
		}

		private static ISessionFactory CreateSessionFactory()
		{
			try
			{
				var cfg = OracleManagedDataClientConfiguration.Oracle10
					.ConnectionString(c =>
						c.Is(
							"DATA SOURCE=gislab-oracle.elfak.ni.ac.rs:1521/SBP_PDB;PERSIST SECURITY INFO=True; USER ID=S16630;PASSWORD=igor98"));
				return Fluently.Configure()
					.Database(cfg.ShowSql())
					.Mappings(m => m.FluentMappings.AddFromAssemblyOf<PolicijskaStanicaMapiranja>())
					//.ExposeConfiguration(BuildSchema) // kako ovo treba da radi?
					.BuildSessionFactory();
			}
			catch (Exception ec)
			{
				Console.Write(ec.StackTrace);
				return null;
			}
		}
	}
}