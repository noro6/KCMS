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
	class Level : ModelBase
	{
		public static List<Level> Select()
		{
			var list = new List<Level>();
			using (var db = new DBManager())
			{
				var dt = db.Select("SELECT id, name FROM levels");

				foreach (DataRow dr in dt.Rows)
				{
					var level = new Level()
					{
						ID = ConvertUtil.ToInt(dr["id"]),
						Name = ConvertUtil.ToString(dr["name"])
					};
					list.Add(level);
				}
			}
			return list;
		}

		/// <summary>
		/// JSON出力
		/// </summary>
		/// <returns></returns>
		internal static string OutputJson()
		{
			var output = "";
			var sql = @"
SELECT
	  '  { id: ' || id || ', name: ""' || name || '"" },' AS json 
FROM
	levels
";
			using (var db = new DBManager())
			{
				var dt = db.Select(sql);
				foreach (DataRow dr in dt.Rows)
				{
					output += ConvertUtil.ToString(dr["json"]) + "\r\n";
				}
			}
			return output;
		}
	}
}
