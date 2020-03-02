using Manager.DB;
using Manager.Util;
using System.Collections.Generic;
using System.Data;

namespace Manager.Models
{
	class Equipment : ModelBase
	{
		public int TypeID { set; get; }
		public string TypeName { set; get; }
		public string Abbr { set; get; }
		public int AntiAir { set; get; }
		public int Torpedo { set; get; }
		public int Bomber { set; get; }
		public int Interception { set; get; }
		public int AntiBomber { set; get; }
		public int Scout { set; get; }
		public bool CanRemodel { set; get; }
		public string CanRemodelString { set; get; }
		public int Radius { set; get; }
		public int Cost { set; get; }
		public int AvoidID { set; get; }
		public string AvoidName { set; get; }
		public Equipment()
		{
			TableName = "equipments";
		}

		/// <summary>
		/// 指定したIDのインスタンス生成
		/// </summary>
		/// <param name="equipmentID"></param>
		public Equipment(int equipmentID)
		{
			TableName = "equipments";
			var ships = Select(equipmentID);
			if (ships.Count == 1)
			{
				ID = ships[0].ID;
				Name = ships[0].Name;
				Abbr = ships[0].Abbr;
				TypeID = ships[0].TypeID;
				TypeName = ships[0].TypeName;
				AntiAir = ships[0].AntiAir;
				Torpedo = ships[0].Torpedo;
				Bomber = ships[0].Bomber;
				Interception = ships[0].Interception;
				AntiBomber = ships[0].AntiBomber;
				Scout = ships[0].Scout;
				CanRemodel = ships[0].CanRemodel;
				CanRemodelString = ships[0].CanRemodelString;
				Radius = ships[0].Radius;
				Cost = ships[0].Cost;
				AvoidID = ships[0].AvoidID;
				AvoidName = ships[0].AvoidName;
			}
		}

		/// <summary>
		/// 敵艦全体取得
		/// </summary>
		/// <returns></returns>
		public static List<Equipment> Select()
		{
			return Select(0);
		}

		/// <summary>
		/// 指定取得
		/// </summary>
		/// <param name="equipmentId">ID</param>
		/// <returns></returns>
		public static List<Equipment> Select(int equipmentId)
		{
			var list = new List<Equipment>();
			using (var db = new DBManager())
			{
				var dt = db.Select($@"
SELECT
	  equipments.id        AS id
	, equipment_types.id   AS type_id
	, equipment_types.name AS type_name
	, equipments.name
	, equipments.abbr
	, equipments.anti_air
	, equipments.torpedo
	, equipments.bomber
	, equipments.interception
	, equipments.anti_bomer
	, equipments.scout
	, equipments.can_remodel
	, equipments.radius
	, equipments.cost
	, equipments.avoid_id 
	, avoids.name          AS avoid_name 
FROM
	equipments 
	LEFT JOIN equipment_types 
		ON equipments.equipment_type_id = equipment_types.id
	LEFT JOIN avoids 
		ON equipments.avoid_id = avoids.id
WHERE
	1 = 1
	{(equipmentId != 0 ? "AND equipments.id = " + equipmentId : "")}
");
				foreach (DataRow dr in dt.Rows)
				{
					var equipment = new Equipment()
					{
						ID = ConvertUtil.ToInt(dr["id"]),
						Name = ConvertUtil.ToString(dr["name"]),
						Abbr = ConvertUtil.ToString(dr["abbr"]),
						TypeID = ConvertUtil.ToInt(dr["type_id"]),
						TypeName = ConvertUtil.ToString(dr["type_name"]),
						AntiAir = ConvertUtil.ToInt(dr["anti_air"], -99),
						Torpedo = ConvertUtil.ToInt(dr["torpedo"], -99),
						Bomber = ConvertUtil.ToInt(dr["bomber"], -99),
						Interception = ConvertUtil.ToInt(dr["interception"], -99),
						AntiBomber = ConvertUtil.ToInt(dr["anti_bomer"], -99),
						Scout = ConvertUtil.ToInt(dr["scout"], -99),
						CanRemodel = ConvertUtil.ToBool(dr["can_remodel"]),
						CanRemodelString = ConvertUtil.ToBool(dr["can_remodel"]) ? "可" : "",
						Radius = ConvertUtil.ToInt(dr["radius"], -99),
						Cost = ConvertUtil.ToInt(dr["cost"], -99),
						AvoidID = ConvertUtil.ToInt(dr["avoid_id"]),
						AvoidName = ConvertUtil.ToString(dr["avoid_name"])
					};
					list.Add(equipment);
				}
			}
			return list;
		}

		/// <summary>
		/// 登録
		/// </summary>
		/// <param name="db"></param>
		public void Insert(DBManager db)
		{
			var sql = $@"
INSERT 
INTO equipments( 
	id
	, equipment_type_id
	, name
	, abbr
	, anti_air
	, anti_bomer
	, interception
	, torpedo
	, bomber
	, scout
	, can_remodel
	, radius
	, cost
	, avoid_id
) 
VALUES ( 
	{ID}
	, {TypeID}
	, @name
	, @abbr
	, {AntiAir}
	, {AntiBomber}
	, {Interception}
	, {Torpedo}
	, {Bomber}
	, {Scout}
	, {CanRemodel}
	, {Radius}
	, {Cost}
	, {AvoidID}
) ";
			var param = new Dictionary<string, object>()
			{
				{ "@name", Name },
				{ "@abbr", Abbr },
			};
			db.ExecuteNonQuery(sql, param);
		}

		/// <summary>
		/// 削除
		/// </summary>
		/// <param name="db"></param>
		/// <param name="enemyId"></param>
		internal static void Delete(DBManager db, int enemyId)
		{
			var sql = $@"DELETE FROM equipments WHERE ID = " + enemyId;
			db.ExecuteNonQuery(sql);
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
	'  { id: ' || id || 
	', type: ' || equipment_type_id || 
	', name: ""' || name || '""' || 
	', abbr: ""' || IFNULL(abbr, '') || '""' || 
	', antiAir: ' || anti_air || 
	', torpedo: ' || torpedo || 
	', bomber: ' || bomber || 
	', antiBomber: ' || anti_bomer || 
	', interception: ' || interception || 
	', scout: ' || scout || 
	', canRemodel: ' || can_remodel || 
	', radius: ' || radius || 
	', cost: ' || cost || 
	', avoid: ' || avoid_id || 
	' },' AS JSON 
FROM
	equipments
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
