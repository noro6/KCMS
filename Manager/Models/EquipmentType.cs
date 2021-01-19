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
				var dt = db.Select("SELECT * FROM api_item_types");

				foreach (DataRow dr in dt.Rows)
				{
					var shipType = new EquipmentType()
					{
						ID = ConvertUtil.ToInt(dr["api_id"]),
						Name = ConvertUtil.ToString(dr["api_name"])
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
    '  { id: ' || api_id || ', name: ""' || api_name || '"", sort: ""' || IFNULL(sort, 99) || '"" },' AS json
FROM
    api_item_types
WHERE
	api_name <> ''
ORDER BY
	IFNULL(sort, 999)
	, api_id
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

		/// <summary>
		/// JSON出力
		/// </summary>
		/// <returns></returns>
		internal static string OutputJson2()
		{
			var output = "";
			var sql = @"
SELECT
    '  { id: ' || api_id || ', name: ""' || name || '"", css: ""' || IFNULL(css, '') || '"" },' AS json
FROM
    icon_item_types
WHERE
	name <> ''
ORDER BY
    api_id
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
