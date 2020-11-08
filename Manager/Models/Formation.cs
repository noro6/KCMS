using Manager.DB;
using Manager.Util;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace Manager.Models
{
	class Formation : ModelBase
	{
		public double AntiAirCorrect { set; get; }

		public static List<Formation> Select()
		{
			var list = new List<Formation>();
			using (var db = new DBManager())
			{
				var dt = db.Select("SELECT * FROM formations");

				foreach (DataRow dr in dt.Rows)
				{
					var formation = new Formation()
					{
						ID = ConvertUtil.ToInt(dr["id"]),
						Name = ConvertUtil.ToString(dr["name"]),
						AntiAirCorrect = ConvertUtil.ToDouble(dr["anti_air_correct"])
					};
					list.Add(formation);
				}
			}
			return list;
		}
	}
}
