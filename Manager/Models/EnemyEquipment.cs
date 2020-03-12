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
		public string TypeName { set; get; }
		public string AntiAir { set; get; }

		public EnemyEquipment()
		{
			TableName = "enemy_equipments";
		}

		public EnemyEquipment(int planeId)
		{
			TableName = "enemy_equipments";
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
	  enemy_equipments.id   AS id
	, enemy_equipments.name AS name
	, equipment_types.id    AS type_id
	, equipment_types.name  AS type_name
	, enemy_equipments.anti_air 
FROM
	enemy_equipments 
	LEFT JOIN equipment_types 
		ON enemy_equipments.equipment_type_id = equipment_types.id 
WHERE
	1 = 1
	{(planeId != 0 ? "AND enemy_equipments.id = " + planeId : "")}
");
				foreach (DataRow dr in dt.Rows)
				{
					var plane = new EnemyEquipment()
					{
						ID = ConvertUtil.ToInt(dr["id"]),
						Name = "ID:" + ConvertUtil.ToInt(dr["id"]) + " " + ConvertUtil.ToString(dr["name"]),
						TypeID = ConvertUtil.ToInt(dr["type_id"]),
						TypeName = ConvertUtil.ToString(dr["type_name"]),
						AntiAir = ConvertUtil.ToString(dr["anti_air"]),
					};
					list.Add(plane);
				}
			}
			return list;
		}

		/// <summary>
		/// 敵装備カテゴリ指定取得
		/// </summary>
		/// <param name="enemyId">敵艦ID</param>
		/// <returns></returns>
		public static List<EnemyEquipment> Filter(int typeId)
		{
			var list = new List<EnemyEquipment>();
			using (var db = new DBManager())
			{
				var dt = db.Select($@"
SELECT
	  enemy_equipments.id   AS id
	, enemy_equipments.name AS name
	, equipment_types.id    AS type_id
	, equipment_types.name  AS type_name
	, enemy_equipments.anti_air 
FROM
	enemy_equipments 
	LEFT JOIN equipment_types 
		ON enemy_equipments.equipment_type_id = equipment_types.id 
WHERE
	1 = 1
	{(typeId != 0 ? "AND equipment_types.id = " + typeId : "")}
");
				foreach (DataRow dr in dt.Rows)
				{
					var plane = new EnemyEquipment()
					{
						ID = ConvertUtil.ToInt(dr["id"]),
						Name = ConvertUtil.ToString(dr["name"]),
						TypeID = ConvertUtil.ToInt(dr["type_id"]),
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
	'  { id: ' || id || ', type: ' || equipment_type_id || ', name: ""' || name || '""' || ', antiAir: ' || anti_air || ' },' AS JSON 
FROM
	enemy_equipments
WHERE
	equipment_type_id < 1000
ORDER BY
	ABS(equipment_type_id)
	, equipment_type_id DESC
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
