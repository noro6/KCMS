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
	class EnemyType : ModelBase
	{

		public static List<EnemyType> Select()
		{
			var list = new List<EnemyType>();
			using (var db = new DBManager())
			{
				var dt = db.Select("SELECT id, name FROM enemy_types ORDER BY sort");

				foreach (DataRow dr in dt.Rows)
				{
					var enemy = new EnemyType()
					{
						ID = ConvertUtil.ToInt(dr["id"]),
						Name = ConvertUtil.ToString(dr["name"])
					};
					list.Add(enemy);
				}
			}
			return list;
		}

		/// <summary>
		/// JSON出力
		/// </summary>
		/// <returns></returns>
		public static string OutputJson()
		{
			var output = "";
			var sql = @"
SELECT
	  '  { id: ' || id || ', name: ""' || name || '"" },' AS json 
FROM
	enemy_types
ORDER BY 
	sort
";
			using (var db = new DBManager())
			{
				var dt = db.Select(sql);

				foreach (DataRow dr in dt.Rows)
				{
					output += ConvertUtil.ToString(dr["json"]) + "\r\n";
				}
			}

			output = output.Replace(",]", "]");
			return output;
		}
	}
}
