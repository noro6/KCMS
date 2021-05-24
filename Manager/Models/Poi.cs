using Manager.DB;
using Manager.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Manager.Models
{
	class Poi : ModelBase
	{
		public int MapID { set; get; }
		public string EnemyName { set; get; }
		public int MapLv { set; get; }
		public int CellID { set; get; }
		public int FormationID { set; get; }
		public string Enemies1 { set; get; }
		public string Enemies2 { set; get; }
		public List<Enemy> EnemyList1 { set; get; }
		public List<Enemy> EnemyList2 { set; get; }
		public int Count { set; get; }
		public int AirPower { set; get; }
		public int LandBaseAirPower { set; get; }

		/// <summary>
		/// 無印コンストラクタ
		/// </summary>
		public Poi() { }

		/// <summary>
		/// poidb用CSV取り込時コンストラクタ
		/// </summary>
		/// <param name="csv"></param>
		public Poi(List<string> csv)
		{

		}
		/// <summary>
		/// poidbテーブルからリスト取得
		/// </summary>
		/// <returns></returns>
		public static List<Poi> Select()
		{
			// 返却用
			var list = new List<Poi>();
			// 敵一覧を取得しておく
			var enemyList = Enemy.Select();

			using (var db = new DBManager())
			{
				var dt = db.Select(@"SELECT * FROM poidb");

				foreach (DataRow dr in dt.Rows)
				{
					var poi = new Poi()
					{
						MapID = ConvertUtil.ToInt(dr["mapId"]),
						EnemyName = ConvertUtil.ToString(dr["enemy"]),
						MapLv = ConvertUtil.ToInt(dr["mapLv"]),
						CellID = ConvertUtil.ToInt(dr["cellId"]),
						FormationID = ConvertUtil.ToInt(dr["formation"]),
						Enemies1 = ConvertUtil.ToString(dr["enemies1"]).Trim('[').Trim(']'),
						Enemies2 = ConvertUtil.ToString(dr["enemies2"]).Trim('[').Trim(']'),
						EnemyList1 = new List<Enemy>(),
						EnemyList2 = new List<Enemy>(),
						Count = ConvertUtil.ToInt(dr["count"])
					};

					// 敵艦隊詳細インスタンス格納
					foreach (var id in poi.Enemies1.Split(','))
					{
						var enemy = enemyList.Find(v => v.ID == ConvertUtil.ToInt(id));
						if (enemy == null)
						{
							continue;
						}
						poi.EnemyList1.Add(enemy);
						poi.AirPower += enemy.AirPower;
						poi.LandBaseAirPower += enemy.LandBaseAirPower;
					}
					foreach (var id in poi.Enemies2.Split(','))
					{
						var enemy = enemyList.Find(v => v.ID == ConvertUtil.ToInt(id));
						if (enemy == null)
						{
							continue;
						}
						poi.EnemyList2.Add(enemy);
						poi.AirPower += enemy.AirPower;
						poi.LandBaseAirPower += enemy.LandBaseAirPower;
					}

					list.Add(poi);
				}
			}
			return list;
		}

		/// <summary>
		/// csvからPoiリストインスタンス化
		/// </summary>
		/// <param name="csv"></param>
		/// <returns></returns>
		public static List<Poi> NewPois(List<List<string>> csv)
		{
			// 返却用
			var list = new List<Poi>();
			// 敵一覧を取得しておく
			var enemyList = Enemy.Select();
			foreach (var row in csv)
			{
				var poi = new Poi
				{
					MapID = ConvertUtil.ToInt(row[0]),
					EnemyName = ConvertUtil.ToString(row[1]),
					MapLv = ConvertUtil.ToInt(row[2]),
					CellID = ConvertUtil.ToInt(row[3]),
					FormationID = ConvertUtil.ToInt(row[4]),
					Enemies1 = ConvertUtil.ToString(row[5]).Trim('[').Trim(']'),
					Enemies2 = ConvertUtil.ToString(row[6]).Trim('[').Trim(']'),
					EnemyList1 = new List<Enemy>(),
					EnemyList2 = new List<Enemy>(),
					Count = ConvertUtil.ToInt(row[7])
				};

				// 敵艦隊詳細インスタンス格納
				foreach (var id in poi.Enemies1.Split(','))
				{
					var enemy = enemyList.Find(v => v.ID == ConvertUtil.ToInt(id));
					if (enemy == null)
					{
						continue;
					}
					poi.EnemyList1.Add(enemy);
					poi.AirPower += enemy.AirPower;
					poi.LandBaseAirPower += enemy.LandBaseAirPower;
				}
				// 敵id配列を格納しなおす
				poi.Enemies1 = string.Join(",", poi.EnemyList1.Select(v => v.ID).ToList());

				foreach (var id in poi.Enemies2.Split(','))
				{
					var enemy = enemyList.Find(v => v.ID == ConvertUtil.ToInt(id));
					if (enemy == null)
					{
						continue;
					}
					poi.EnemyList2.Add(enemy);
					poi.AirPower += enemy.AirPower;
					poi.LandBaseAirPower += enemy.LandBaseAirPower;
				}
				// 敵id配列を格納しなおす
				poi.Enemies2 = string.Join(",", poi.EnemyList2.Select(v => v.ID).ToList());

				list.Add(poi);
			}

			return list;
		}

		/// <summary>
		/// poidbCSV読み込んだうえで、データを整理してpoidbに登録
		/// </summary>
		public static void ReadCSVAndRegist()
		{
			var csv = ConvertUtil.ReadCSV();
			if (csv == null || csv.Count == 0)
			{
				return;
			}

			// 読み込んだcsvをPoiインスタンス化
			var csvList = Poi.NewPois(csv);

			// 現在DBからPoiインスタンス取得
			var currentList = Poi.Select();

			// 取込に失敗した者たち記録用
			var errorList = new List<Poi>();
			var updateCount = 0;
			var insertCount = 0;
			var ignoreCount = 0;

			// コネクション作成
			using (var db = new DBManager())
			{
				try
				{
					db.CreateConnection();
					db.BeginTran();

					foreach (var poi in csvList)
					{
						// 敵データがない or イベント海域(mapID > 400)なのにmapLvが1未満 or 通常海域なのにmapLvが1以上
						if (string.IsNullOrEmpty(poi.Enemies1) || poi.EnemyList1.Count == 0 ||
							((poi.MapID > 400) && poi.MapLv < 1) || ((poi.MapID < 400) && poi.MapLv > 0))
						{
							ignoreCount++;
							continue;
						}

						// 現DB内に同じ「マップ、難易度、セルID、陣形、編成」があるかチェック
						var data = currentList.Find(v =>
						{
							return v.MapID == poi.MapID &&
							v.MapLv == poi.MapLv &&
							v.CellID == poi.CellID &&
							v.FormationID == poi.FormationID &&
							v.Enemies1 == poi.Enemies1 &&
							v.Enemies2 == poi.Enemies2;
						});

						if (data != null)
						{
							// データが見つかればそれのカウントを加算するUPDATE発行
							data.Count += poi.Count;
							// ついでに制空値も最新に
							data.AirPower = poi.AirPower;
							data.LandBaseAirPower = poi.LandBaseAirPower;
							data.Update(db);
							updateCount++;
						}
						else
						{
							// データが見つからなければInsert試行 制約違反があっても続行する
							try
							{
								poi.Insert(db);
								insertCount++;
							}
							catch (Exception)
							{
								// 記録して握り潰し
								errorList.Add(poi);
							}
						}
					}
					db.Commit();

					MessageBox.Show("poidbへのCSV取り込みが正常に完了しました。" +
						Environment.NewLine + "全件数: " + csvList.Count +
						Environment.NewLine + "登録件数: " + insertCount +
						Environment.NewLine + "更新件数: " + updateCount +
						Environment.NewLine + "無視件数: " + ignoreCount +
						Environment.NewLine + "重複件数: " + errorList.Count,
						"poidb更新完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch (Exception ex)
				{
					db.RollBack();
					MessageBox.Show("失敗しました。" + Environment.NewLine + ex.Message, "poidb更新失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		/// <summary>
		/// poidb登録
		/// </summary>
		/// <param name="db"></param>
		public void Insert(DBManager db)
		{
			var sql = $@"
INSERT 
INTO poidb( 
    mapId
    , enemy
    , mapLv
    , cellId
    , formation
    , enemies1
    , enemies2
    , count
	, airPower
	, airPowerSub
) 
VALUES ( 
    {MapID}
    , @enemyName
    , {MapLv}
    , {CellID}
    , {FormationID}
    , @enemies1
    , @enemies2
    , {Count}
	, {AirPower}
	, {LandBaseAirPower}
)
";
			var param = new Dictionary<string, object>()
			{
				{ "@enemyName", EnemyName },
				{ "@enemies1", Enemies1 },
				{ "@enemies2", Enemies2 },
			};
			db.ExecuteNonQuery(sql, param);
		}

		/// <summary>
		/// 更新処理
		/// </summary>
		/// <param name="db"></param>
		public void Update(DBManager db)
		{
			var sql = $@"
UPDATE poidb 
SET
    count = {Count}
	, airPower = {AirPower}
	, airPowerSub = {LandBaseAirPower}
WHERE
    mapId = {MapID} 
    and mapLv = {MapLv}
    and cellId = {CellID} 
    and formation = {FormationID} 
    and enemies1 = @enemies1
    and enemies2 = @enemies2
";
			var param = new Dictionary<string, object>()
			{
				{ "@enemies1", Enemies1 },
				{ "@enemies2", Enemies2 },
			};
			db.ExecuteNonQuery(sql, param);
		}

		/// <summary>
		/// <see cref="EnemyInfomation"/>データを条件としてpoidbからデータ削除
		/// </summary>
		/// <param name="db"></param>
		/// <param name="e"></param>
		/// <returns>削除件数</returns>
		public static int DeletePoi(DBManager db, EnemyInfomation e)
		{
			var sql = $@"
DELETE FROM poidb 
WHERE
    mapID = {e.MapId} 
    and mapLv = {e.LevelId} 
    and formation = {(e.FormationId == 11 ? 14 : e.FormationId == 14 ? 11 : e.FormationId)} 
    and enemies1 = @enemies1
	and enemies2 = @enemies2
    and exists ( 
        SELECT
            cell_id 
        FROM
            cells 
        WHERE
            map_id = {e.MapId} 
            and cell_id = poidb.cellId 
            and next_node = @node
    )
";
			var list = e.Enemies;
			var cnt = e.Enemies.Count;
			var enemies1 = list.GetRange(0, cnt >= 6 ? 6 : cnt).Select(v => v.ID).ToList();
			var enemies2 = cnt > 6 ? list.GetRange(6, cnt - 6).Select(v => v.ID).ToList() : new List<int>();

			var param = new Dictionary<string, object>()
			{
				{ "@enemies1", string.Join(",", enemies1) },
				{ "@enemies2", string.Join(",", enemies2) },
				{ "@node", e.NodeName },
			};
			return db.ExecuteNonQuery(sql, param);
		}

		/// <summary>
		/// 敵出現海域(ENEMY_PATTERN)出力 poidbから
		/// </summary>
		/// <returns></returns>
		public static string OutputEnemyPatterns()
		{
			var list = EnemyPattern.FormatEnemyPattern(EnemyPattern.SelectPoi());

			var output = "";
			foreach (var poiView in list)
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
