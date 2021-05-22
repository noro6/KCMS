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
	/// <summary>
	/// 敵艦載機データ
	/// </summary>
	class EnemyEquipment : ModelBase
	{
		public int TypeID { set; get; }
		public int IconTypeID { set; get; }
		public string TypeName { set; get; }
		public string AntiAir { set; get; }

		public EnemyEquipment()
		{
			TableName = "equipments_view";
		}

		public EnemyEquipment(int planeId)
		{
			TableName = "equipments_view";
		}


		/// <summary>
		/// 敵装備全体取得
		/// </summary>
		/// <returns></returns>
		public static List<EnemyEquipment> Select()
		{
			return Select(0);
		}

		/// <summary>
		/// 敵装備指定取得
		/// </summary>
		/// <param name="enemyId">敵艦ID</param>
		/// <returns></returns>
		public static List<EnemyEquipment> Select(int planeId)
		{
			var list = new List<EnemyEquipment>();
			using (var db = new DBManager())
			{
				var dt = db.Select($@"
SELECT
	  equipments_view.id			AS id
	, equipments_view.name			AS name
	, equipments_view.api_type_id	AS type_id
	, equipments_view.icon_type_id	AS icon_type_id
	, api_item_types.api_name		AS type_name
	, equipments_view.anti_air 
FROM
	equipments_view 
	LEFT JOIN api_item_types 
		ON equipments_view.api_type_id = api_item_types.api_id 
WHERE
	equipments_view.id >= 500
	{(planeId != 0 ? "AND equipments_view.id = " + planeId : "")}
");
				foreach (DataRow dr in dt.Rows)
				{
					var plane = new EnemyEquipment()
					{
						ID = ConvertUtil.ToInt(dr["id"]),
						Name = "ID:" + ConvertUtil.ToInt(dr["id"]) + " " + ConvertUtil.ToString(dr["name"]),
						TypeID = ConvertUtil.ToInt(dr["type_id"]),
						IconTypeID = ConvertUtil.ToInt(dr["icon_type_id"]),
						TypeName = ConvertUtil.ToString(dr["type_name"]),
						AntiAir = ConvertUtil.ToString(dr["anti_air"]),
					};
					list.Add(plane);
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
	'  { id: ' || id || ', type: ' || api_type_id || ', itype: ' || icon_type_id || ', name: ""' || name || '""' || ', antiAir: ' || anti_air || ', torpedo: ' || torpedo || ', bomber: ' || bomber || ', armor: ' || armor || ' },' AS JSON 
FROM
	equipments_view
WHERE
	id >= 500
ORDER BY
	api_type_id
	, id
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
