using Manager.DB;
using Manager.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Models
{
	class Avoid : ModelBase
	{
		public static List<Avoid> Select()
		{
			var list = new List<Avoid>();
			using (var db = new DBManager())
			{
				var dt = db.Select("SELECT id, name FROM avoids");

				foreach (DataRow dr in dt.Rows)
				{
					var enemy = new Avoid()
					{
						ID = ConvertUtil.ToInt(dr["id"]),
						Name = ConvertUtil.ToString(dr["name"])
					};
					list.Add(enemy);
				}
			}
			return list;
		}
	}
}
