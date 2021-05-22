using Manager.DB;
using Manager.Util;
using System;
using System.Collections.Generic;
using System.Data;

namespace Manager.Models
{
	class ShipType : ModelBase
	{

		public static List<ShipType> Select()
		{
			var list = new List<ShipType>();
			using (var db = new DBManager())
			{
				var dt = db.Select("SELECT id, name FROM ship_types ORDER BY sort");

				foreach (DataRow dr in dt.Rows)
				{
					var shipType = new ShipType()
					{
						ID = ConvertUtil.ToInt(dr["id"]),
						Name = ConvertUtil.ToString(dr["name"])
					};
					list.Add(shipType);
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
	ship_types
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
