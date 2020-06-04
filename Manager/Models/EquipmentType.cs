using Manager.DB;
using Manager.Util;
using System;
using System.Collections.Generic;
using System.Data;

namespace Manager.Models
{
	class EquipmentType : ModelBase
	{
		/// <summary>
		/// 装備カテゴリ読み込み
		/// </summary>
		/// <returns></returns>
		public static List<EquipmentType> Select()
		{
			var list = new List<EquipmentType>();
			using (var db = new DBManager())
			{
				var dt = db.Select("SELECT id, name FROM equipment_types ORDER BY ABS(id), id DESC");

				foreach (DataRow dr in dt.Rows)
				{
					var shipType = new EquipmentType()
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
	  '  { id: ' || id || ', name: ""' || name || '"", abbr: ""' || abbr || '"", css: ""' || css || '"" },' AS json 
FROM
	equipment_types 
ORDER BY
	ABS(id)
	, id DESC
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
