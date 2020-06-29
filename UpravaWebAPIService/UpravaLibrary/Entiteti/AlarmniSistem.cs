using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpravaLibrary.Entiteti
{
	public abstract class AlarmniSistem
	{
		//serijskibr treba da bude int
		public virtual string SerijskiBr { get; set; }

		public virtual string Proizvodjac { get; set; }
		public virtual string Model { get; set; }
		public virtual string GodinaProizvodnje { get; set; }
		public virtual DateTime DatumInstalacije { get; set; }
		public virtual string Tip { get; set; }

		public virtual Objekat Objekat { get; set; }
		public virtual DateTime DatumPoslednjegTesta { get; set; }
		public virtual DateTime DatumPoslednjegServisiranja { get; set; }
		public virtual string OtklonjenKvar { get; set; }
		public virtual IList<Zaduzen> Zaduzeni { get; set; } //this

		public AlarmniSistem()
		{
			Zaduzeni = new List<Zaduzen>();
		}

		#region ToStringFunc

		public override string ToString()
		{
			StringBuilder displayStringBuilder = new StringBuilder();
			displayStringBuilder.AppendFormat("Serijski broj:{0},Proizvodjac{1},model:{2},Godina proizvodnje:{3}",
				SerijskiBr, Proizvodjac, Model, GodinaProizvodnje);
			displayStringBuilder.AppendLine();
			displayStringBuilder.AppendFormat("Datum instalacije:{0},Tip:{1},Objekat id:{2},", DatumInstalacije, Tip,
				Objekat.ObjekatId);
			displayStringBuilder.AppendLine();
			displayStringBuilder.AppendFormat(
				"Datum poslednjeg testa:{0},Datum poslednjeg servisiranja:{1},Otklonjen kvar:{2}", DatumPoslednjegTesta,
				DatumPoslednjegServisiranja, OtklonjenKvar);
			displayStringBuilder.AppendLine();
			if (Zaduzeni.Count != 0)
			{
				displayStringBuilder.AppendFormat("Lista zaduzenih:");
				displayStringBuilder.AppendLine();
				foreach (var zaduzen in Zaduzeni)
				{
					displayStringBuilder.AppendFormat("Id zaduzenog:{0},Ime :{1}", zaduzen.Tehnicar.TehnicarId,
						zaduzen.Tehnicar.Ime);
					displayStringBuilder.AppendLine();
				}
			}
			return displayStringBuilder.ToString();
		}

		#endregion ToStringFunc
	}

	public class ToplotniAlarmniSistem : AlarmniSistem
	{
		public virtual string HorizontalnaRezolucija { get; set; }
		public virtual string VertikalnaRezolucija { get; set; }

		public override string Tip
		{
			get
			{
				return "Tolpotni";
			}
		}

		#region toStringFunc

		public override string ToString()
		{
			StringBuilder displayStringBuilder = new StringBuilder();
			displayStringBuilder.AppendLine();
			displayStringBuilder.AppendFormat("Horiznotalna rezolucija:{0},Vertikalna rezolucija:{1}",
				HorizontalnaRezolucija, VertikalnaRezolucija);
			return base.ToString() + displayStringBuilder.ToString();
		}

		#endregion toStringFunc
	}

	public class UltrazvucniAlarmniSistem : AlarmniSistem
	{
		public virtual string Frekvencija { get; set; }

		public override string Tip
		{
			get
			{
				return "Ultrazvucni";
			}
		}

		#region toStringFunc

		public override string ToString()
		{
			StringBuilder displayStringBuilder = new StringBuilder();
			displayStringBuilder.AppendLine();
			displayStringBuilder.AppendFormat("Frekvencija:{0}", Frekvencija);
			return base.ToString() + displayStringBuilder.ToString();
		}

		#endregion toStringFunc
	}

	public class DetekcijaPokretaAlarmniSistem : AlarmniSistem
	{
		public virtual string Osetljivost { get; set; }

		public override string Tip
		{
			get
			{
				return "Detekcija_Pokreta";
			}
		}

		#region toStringFunc

		public override string ToString()
		{
			StringBuilder displayStringBuilder = new StringBuilder();
			displayStringBuilder.AppendLine();
			displayStringBuilder.AppendFormat("Osetljivost:{0}", Osetljivost);
			return base.ToString() + displayStringBuilder.ToString();
		}

		#endregion toStringFunc
	}
}