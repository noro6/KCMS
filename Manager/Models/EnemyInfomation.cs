using Manager.DB;
using Manager.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Manager.Models
{
	class EnemyInfomation
	{
		public int MapId { set; get; }
		public int NodeId { set; get; }
		public string NodeName { set; get; }
		public string NodeRemarks { set; get; }
		public int LevelId { set; get; }
		public string LevelName { set; get; }
		public int TypeId { set; get; }
		public string TypeName { set; get; }
		public int FormationId { set; get; }
		public string FormationName { set; get; }
		public string EnemyID { set; get; }
		public string EnemyName { set; get; }
		public int DetailId { set; get; }
		public string AirPower { set; get; }
		public List<Enemy> Enemies { set; get; }
		public int Count { set; get; }
		public double Rate {
			set
			{
				rate = value;
			}
			get {
				var ret = Math.Floor(rate * 1000.0) / 10.0;
				var ret2 = Math.Floor(rate * 10000.0) / 100.0;
				var ret3 = Math.Floor(rate * 100000.0) / 1000.0;
				return ret > 0 ? ret : ret2 > 0 ? ret2 : ret3;
			} 
		}
		public double rate = 0;

		/// <summary>
		/// 検索
		/// </summary>
		/// <returns></returns>
		public static List<EnemyInfomation> Select()
		{
			var sql = $@"
SELECT
	world_id
	, map_no
	, node_id
	, node_name
	, node_remarks
	, level_id
	, level_name
	, node_type_id
	, node_type
	, formation_id
	, formation
	, enemy_id
	, enemy_name
	, node_detail_id
	, air_power
	, land_base_air_power
FROM
	node_information
";
			using (var db = new DBManager())
			{
				var dt = db.Select(sql);
				var list = new List<EnemyInfomation>();
				foreach (DataRow dr in dt.Rows)
				{
					var ins = new EnemyInfomation()
					{
						MapId = ConvertUtil.ToInt(ConvertUtil.ToString(dr["world_id"]) + ConvertUtil.ToString(dr["map_no"])),
						NodeId = ConvertUtil.ToInt(dr["node_id"]),
						NodeName = ConvertUtil.ToString(dr["node_name"]),
						NodeRemarks = ConvertUtil.ToString(dr["node_remarks"]),
						LevelId = ConvertUtil.ToInt(dr["level_id"]),
						LevelName = ConvertUtil.ToString(dr["level_name"]),
						TypeId = ConvertUtil.ToInt(dr["node_type_id"]),
						TypeName = ConvertUtil.ToString(dr["node_type"]),
						FormationId = ConvertUtil.ToInt(dr["formation_id"]),
						FormationName = ConvertUtil.ToString(dr["formation"]),
						EnemyID = ConvertUtil.ToString(dr["enemy_id"]),
						EnemyName = ConvertUtil.ToString(dr["enemy_name"]),
						DetailId = ConvertUtil.ToInt(dr["node_detail_id"]),
						AirPower = ConvertUtil.ToInt(dr["air_power"]) + "\r\n(" + ConvertUtil.ToInt(dr["land_base_air_power"]) + ")",
						Count = 1,
						Rate = 0,
					};

					if (ins.NodeRemarks == "") ins.NodeRemarks = "-";

					list.Add(ins);
				}
				return list;
			}
		}

		/// <summary>
		/// 検索(poidbベースに)
		/// </summary>
		/// <returns></returns>
		public static List<EnemyInfomation> SelectFromPoi()
		{
			// 敵一覧を取得しておく
			var enemyList = Enemy.Select();

			var sql = $@"
SELECT
	map_id
	, node_name
	, node_remarks
	, level_id
	, level_name
	, node_type_id
	, node_type
	, formation_id
	, formation
	, radius
	, enemy_id
	, airPower
	, airPowerSub
	, count
FROM
	poidb_node_info
";
			using (var db = new DBManager())
			{
				var dt = db.Select(sql);
				var list = new List<EnemyInfomation>();
				foreach (DataRow dr in dt.Rows)
				{
					var poi = new EnemyInfomation()
					{
						MapId = ConvertUtil.ToInt(dr["map_id"]),
						NodeName = ConvertUtil.ToString(dr["node_name"]),
						NodeRemarks = ConvertUtil.ToString(dr["node_remarks"]),
						LevelId = ConvertUtil.ToInt(dr["level_id"]),
						LevelName = ConvertUtil.ToString(dr["level_name"]),
						TypeId = ConvertUtil.ToInt(dr["node_type_id"]),
						TypeName = ConvertUtil.ToString(dr["node_type"]),
						FormationId = ConvertUtil.ToInt(dr["formation_id"]),
						FormationName = ConvertUtil.ToString(dr["formation"]),
						AirPower = ConvertUtil.ToInt(dr["airPower"]) + "\r\n(" + ConvertUtil.ToInt(dr["airPowerSub"]) + ")",
						EnemyID = ConvertUtil.ToString(dr["enemy_id"]),
						Enemies = new List<Enemy>(),
						Count = ConvertUtil.ToInt(dr["count"]),
					};

					// 敵艦隊詳細インスタンス格納
					if (poi.EnemyID != "")
					{
						var ap = 0;
						var lb = 0;
						var enemyNames = "";
						foreach (var id in poi.EnemyID.Split(','))
						{
							var enemy = enemyList.Find(v => v.ID == ConvertUtil.ToInt(id));
							if (enemy == null)
							{
								continue;
							}
							poi.Enemies.Add(enemy);
							enemyNames += enemy.Name + ",";
							ap += enemy.AirPower;
							lb += enemy.LandBaseAirPower;
						}

						poi.AirPower = ap + "\r\n(" + lb + ")";
						poi.EnemyName = enemyNames.Trim(',');
					}

					list.Add(poi);
				}

				// 同一クラスタ内での編成選択率を算出
				foreach (var poi in list)
				{
					var data = list.FindAll(v => v.MapId == poi.MapId && v.LevelId == poi.LevelId && v.NodeName == poi.NodeName);
					poi.Rate = poi.Count / (double)data.Sum(v => v.Count);
				}
				return list;
			}
		}
	}
}
