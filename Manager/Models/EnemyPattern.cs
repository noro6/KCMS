using Manager.DB;
using Manager.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Manager.Models
{
	/// <summary>
	/// 敵編成情報 インスタンス
	/// </summary>
	class EnemyPattern : ModelBase
	{
		public int MapID { set; get; }
		public string NodeName { set; get; }
		public string NodeRemarks { set; get; }
		public int LevelID { set; get; }
		public int TypeID { set; get; }
		public int FormationID { set; get; }
		public int Radius { set; get; }
		public string Enemies { set; get; }
		public string Coords { set; get; }
		public int Count { set; get; }
		public int LandBaseAirPower { set; get; }
		public int AirPower { set; get; }
		public int SortValue { set; get; }

		/// <summary>
		/// poidb_node_info 全件取得
		/// </summary>
		/// <returns></returns>
		public static List<EnemyPattern> SelectPoi()
		{
			var list = new List<EnemyPattern>();
			using (var db = new DBManager())
			{
				var dt = db.Select(@"
SELECT
    * 
FROM
    poidb_node_info 
WHERE
    EXISTS ( 
        SELECT
            worlds.status 
        FROM
            maps 
            LEFT JOIN worlds 
                ON maps.world_id = worlds.id 
        WHERE
            poidb_node_info.map_id = (worlds.id || maps.map_no) 
            AND worlds.status = 1
    )
");
				foreach (DataRow dr in dt.Rows)
				{
					var poi = new EnemyPattern()
					{
						MapID = ConvertUtil.ToInt(dr["map_id"]),
						NodeName = ConvertUtil.ToString(dr["node_name"]),
						NodeRemarks = ConvertUtil.ToString(dr["node_remarks"]),
						LevelID = ConvertUtil.ToInt(dr["level_id"]),
						TypeID = ConvertUtil.ToInt(dr["node_type_id"]),
						Radius = ConvertUtil.ToInt(dr["radius"]),
						FormationID = ConvertUtil.ToInt(dr["formation_id"]),
						Enemies = ConvertUtil.ToString(dr["enemy_id"]),
						Coords = ConvertUtil.ToString(dr["coords"]),
						Count = ConvertUtil.ToInt(dr["count"]),
						AirPower = ConvertUtil.ToInt(dr["airPower"]),
						LandBaseAirPower = ConvertUtil.ToInt(dr["airPowerSub"]),
					};
					list.Add(poi);
				}
			}
			return list;
		}


		/// <summary>
		/// node_information 全件取得
		/// </summary>
		/// <returns></returns>
		public static List<EnemyPattern> SelectManual()
		{
			var list = new List<EnemyPattern>();
			using (var db = new DBManager())
			{
				var dt = db.Select(@"
SELECT
    * 
FROM
    node_information 
WHERE
    EXISTS ( 
        SELECT
            worlds.status 
        FROM
            worlds 
        WHERE
            node_information.world_id = worlds.id 
            AND worlds.status = 1
    )
");
				foreach (DataRow dr in dt.Rows)
				{
					var p = new EnemyPattern()
					{
						MapID = ConvertUtil.ToInt(ConvertUtil.ToString(dr["world_id"]) + ConvertUtil.ToString(dr["map_no"])),
						NodeName = ConvertUtil.ToString(dr["node_name"]),
						NodeRemarks = ConvertUtil.ToString(dr["node_remarks"]),
						LevelID = ConvertUtil.ToInt(dr["level_id"]),
						TypeID = ConvertUtil.ToInt(dr["node_type_id"]),
						Radius = ConvertUtil.ToInt(dr["radius"]),
						FormationID = ConvertUtil.ToInt(dr["formation_id"]),
						Enemies = ConvertUtil.ToString(dr["enemy_id"]),
						Coords = ConvertUtil.ToString(dr["coords"]),
						Count = 1,
						AirPower = ConvertUtil.ToInt(dr["air_power"]),
						LandBaseAirPower = ConvertUtil.ToInt(dr["land_base_air_power"]),
					};
					list.Add(p);
				}
			}
			return list;
		}

		/// <summary>
		/// List<EnemyPattern>から、「マップ　マス 難易度　敵編成」が同じものの中で陣形を最適化
		/// </summary>
		/// <returns></returns>
		public static List<EnemyPattern> FormatEnemyPattern(List<EnemyPattern> list)
		{
			var outputList = new List<EnemyPattern>();

			// 敵一覧(マスタから)
			var enemyList = Enemy.Select();
			var formations = Formation.Select();

			foreach (var poi in list)
			{
				// 「マップ　マス 難易度　敵編成」が同じものを検索
				var data = outputList.Find(v =>
				{
					return v.MapID == poi.MapID &&
					v.LevelID == poi.LevelID &&
					v.NodeName == poi.NodeName &&
					v.Enemies == poi.Enemies;
				});

				if (data == null)
				{
					outputList.Add(poi);
				}
				else
				{
					// 同じ「マップ　マス 難易度　敵編成」が存在している場合、陣形を防空性能が高いものにする
					var com = poi.FormationID;
					var prev = data.FormationID;

					if (com < 10)
					{
						// 3 2 6 1 4 5の順
						if (com == 3)
						{
							data.FormationID = com;
						}
						else if ((com == 3 || com == 2) && prev != 3)
						{
							data.FormationID = com;
						}
						else if ((com == 3 || com == 2 || com == 6) && prev != 3 && prev != 2)
						{
							data.FormationID = com;
						}
						else if ((com == 3 || com == 2 || com == 6 || com == 1) && prev != 3 && prev != 2 && prev != 6)
						{
							data.FormationID = com;
						}
						else if (com != 5 && prev != 3 && prev != 2 && prev != 6 && prev != 1)
						{
							data.FormationID = com;
						}
					}
				}
			}

			// 敵ID簡略化 1500引く
			var enemyIDs = new List<int>();
			foreach (var poi in outputList)
			{
				var sumWeight = 0;
				var sumBonus = 0;
				enemyIDs.Clear();
				foreach (var s in poi.Enemies.Split(','))
				{
					var id = ConvertUtil.ToInt(s);
					enemyIDs.Add(id > 1500 ? id - 1500 : id);

					var enemy = enemyList.Find(v => v.ID == id);
					if (enemy != null)
					{
						sumWeight += enemy.AntiAirWeight;
						sumBonus += enemy.AntiAirBonus;
					}
				}
				poi.Enemies = string.Join(",", enemyIDs);

				// 対空砲火具合の計算
				var correct = formations.Find(v => v.ID == poi.FormationID).AntiAirCorrect;
				poi.SortValue = (int)Math.Floor(2 * Math.Floor(correct * sumBonus) + sumWeight);

				// 敵IDの合算値をソート順に使う (値が大きいほど強い傾向にあるので)
				// poi.SortValue = enemyIDs.Sum();

				// 敵IDから対空性能を取得し、加算
			}

			// ソート 
			outputList = outputList
				// 海域 昇順
				.OrderBy(v => v.MapID)
				// マス名 昇順
				.ThenBy(v => v.NodeName)
				// 難易度 昇順
				.ThenBy(v => v.LevelID)
				// 制空値 降順
				.ThenByDescending(v => v.AirPower)
				.ThenByDescending(v => v.LandBaseAirPower)
				// 敵編成 降順
				.ThenByDescending(v => v.SortValue).ToList();
			return outputList;
		}

		/// <summary>
		/// 敵出現海域(ENEMY_PATTERN)出力 poidb & node_information ハイブリッド
		/// </summary>
		/// <returns></returns>
		public static string OutputEnemyPatterns()
		{
			// 手打ち側のデータ取得
			var listManual = SelectManual();
			// poiをベースに取得
			var outputList = SelectPoi();

			// poiに対して手打ちから補完されたデータ群
			var addList = new List<EnemyPattern>();

			// 手打ちの重複チェック
			foreach (var data in listManual)
			{
				// 陣形は考慮せず、敵編成が全く同じものを検索
				var pois = outputList.FindAll(v =>
				{
					return v.MapID == data.MapID &&
					v.LevelID == data.LevelID &&
					v.NodeName == data.NodeName &&
					v.Enemies == data.Enemies;
				});

				// poi側にデータがない編成データ
				if (pois.Count == 0)
				{
					var index = outputList.FindIndex(v => v.MapID == data.MapID && v.LevelID == data.LevelID && v.NodeName == data.NodeName);
					if (index == -1)
					{
						index = outputList.FindIndex(v => v.MapID == data.MapID);
					}
					if (index > -1)
					{
						outputList.Insert(index - 1, data);
						addList.Add(data);
					}
					else
					{
						outputList.Add(data);
					}
				}
				else
				{
					// poi側に存在していた場合、node_remarksを解決
					foreach (var poi in pois)
					{
						poi.NodeRemarks = data.NodeRemarks;
					}
				}
			}

			// 陣形を最適化
			outputList = FormatEnemyPattern(outputList);

			var output = "";
			foreach (var poiView in outputList)
			{
				output += "  { a: " + poiView.MapID + ", " +
					"n: \"" + poiView.NodeName + "\", " +
					"d: \"" + poiView.NodeRemarks + "\", " +
					"l: " + poiView.LevelID + ", " +
					"t: " + poiView.TypeID + ", " +
					"f: " + poiView.FormationID + ", " +
					"r: " + poiView.Radius + ", " +
					"e: [" + poiView.Enemies + "], " +
					"c: \"" + poiView.Coords + "\" },\r\n";
			}
			return output;
		}
	}
}
