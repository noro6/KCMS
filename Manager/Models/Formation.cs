using Manager.DB;
using Manager.Util;
using System.Collections.Generic;
using System.Data;

namespace Manager.Models
{
	class Formation : ModelBase
	{
		public static List<Formation> Select()
		{
			var list = new List<Formation>();
			using (var db = new DBManager())
			{
				var dt = db.Select("SELECT id, name FROM formations");

				foreach (DataRow dr in dt.Rows)
				{
					var formation = new Formation()
					{
						ID = ConvertUtil.ToInt(dr["id"]),
						Name = ConvertUtil.ToString(dr["name"])
					};
					list.Add(formation);
				}
			}
			return list;
		}
	}
}
