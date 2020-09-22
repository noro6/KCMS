using Manager.DB;
using Manager.Util;
using System;
using System.Collections.Generic;
using System.Data;

namespace Manager.Models
{
	class Enemy : ModelBase
	{
		public string TypeIds { set; get; }
		public string TypeNames { set; get; }
		public int? Slot1 { set; get; }
		public int? Equipment1ID { set; get; }
		public string Equipment1 { set; get; }
		public int? Slot2 { set; get; }
		public int? Equipment2ID { set; get; }
		public string Equipment2 { set; get; }
		public int? Slot3 { set; get; }
		public int? Equipment3ID { set; get; }
		public string Equipment3 { set; get; }
		public int? Slot4 { set; get; }
		public int? Equipment4ID { set; get; }
		public string Equipment4 { set; get; }
		public int? Slot5 { set; get; }
		public int? Equipment5ID { set; get; }
		public string Equipment5 { set; get; }
		public int OriginalID { set; get; }
		public int AntiAirWeight { set; get; }
		public int AntiAirBonus { set; get; }
		public int AirPower { set; get; }
		public int LandBaseAirPower { set; get; }

		public Enemy()
		{
			TableName = "enemies";
		}

		/// <summary>
		/// 指定したIDの敵艦インスタンス生成
		/// </summary>
		/// <param name="enemyId"></param>
		public Enemy(int enemyId)
		{
			TableName = "enemies";
			var enemies = Select(enemyId);
			if (enemies.Count == 1)
			{
				ID = enemies[0].ID;
				Name = enemies[0].Name;
				TypeIds = enemies[0].TypeIds;
				TypeNames = enemies[0].TypeNames;
				Slot1 = enemies[0].Slot1;
				Equipment1ID = enemies[0].Equipment1ID;
				Equipment1 = enemies[0].Equipment1;
				Slot2 = enemies[0].Slot2;
				Equipment2ID = enemies[0].Equipment2ID;
				Equipment2 = enemies[0].Equipment2;
				Slot3 = enemies[0].Slot3;
				Equipment3ID = enemies[0].Equipment3ID;
				Equipment3 = enemies[0].Equipment3;
				Slot4 = enemies[0].Slot4;
				Equipment4ID = enemies[0].Equipment4ID;
				Equipment4 = enemies[0].Equipment4;
				Slot5 = enemies[0].Slot5;
				Equipment5ID = enemies[0].Equipment5ID;
				Equipment5 = enemies[0].Equipment5;
				OriginalID = enemies[0].OriginalID;
				AntiAirWeight = enemies[0].AntiAirWeight;
				AntiAirBonus = enemies[0].AntiAirBonus;

				var equipments = EnemyEquipment.Select();

				AirPower += GetAirPower(equipments, ConvertUtil.ToInt(Equipment1ID), ConvertUtil.ToInt(Slot1));
				AirPower += GetAirPower(equipments, ConvertUtil.ToInt(Equipment2ID), ConvertUtil.ToInt(Slot2));
				AirPower += GetAirPower(equipments, ConvertUtil.ToInt(Equipment3ID), ConvertUtil.ToInt(Slot3));
				AirPower += GetAirPower(equipments, ConvertUtil.ToInt(Equipment4ID), ConvertUtil.ToInt(Slot4));
				AirPower += GetAirPower(equipments, ConvertUtil.ToInt(Equipment5ID), ConvertUtil.ToInt(Slot5));

				LandBaseAirPower += GetAirPower(equipments, ConvertUtil.ToInt(Equipment1ID), ConvertUtil.ToInt(Slot1), true);
				LandBaseAirPower += GetAirPower(equipments, ConvertUtil.ToInt(Equipment2ID), ConvertUtil.ToInt(Slot2), true);
				LandBaseAirPower += GetAirPower(equipments, ConvertUtil.ToInt(Equipment3ID), ConvertUtil.ToInt(Slot3), true);
				LandBaseAirPower += GetAirPower(equipments, ConvertUtil.ToInt(Equipment4ID), ConvertUtil.ToInt(Slot4), true);
				LandBaseAirPower += GetAirPower(equipments, ConvertUtil.ToInt(Equipment5ID), ConvertUtil.ToInt(Slot5), true);
			}
		}

		/// <summary>
		/// 制空値を返却する　
		/// </summary>
		/// <param name="equipments">装備リスト</param>
		/// <param name="equipmentId">装備ID</param>
		/// <param name="slot">搭載数</param>
		/// <param name="isLandBase">対基地の制空値を返すかどうか</param>
		public static int GetAirPower(List<EnemyEquipment> equipments, int equipmentId, int slot, bool isLandBase = false)
		{
			if (equipments == null || equipments.Count == 0) return 0;

			var equipment = equipments.Find(v => v.ID == equipmentId);
			if (equipment == null) return 0;
			if (!isLandBase && (equipment.TypeID == 4 || equipment.TypeID == 5))
			{
				return 0;
			}

			return (int)(ConvertUtil.ToInt(equipment.AntiAir) * Math.Sqrt(slot));
		}

		/// <summary>
		/// 制空値を返却する　
		/// </summary>
		/// <param name="equipments">装備リスト</param>
		/// <param name="equipmentId">装備ID</param>
		/// <param name="slot">搭載数</param>
		/// <param name="isLandBase">対基地の制空値を返すかどうか</param>
		public static int GetAirPower(EnemyEquipment equipment, int slot, bool isLandBase = false)
		{
			if (equipment == null) return 0;
			if (!isLandBase && (equipment.TypeID == 4 || equipment.TypeID == 5))
			{
				return 0;
			}

			return (int)(ConvertUtil.ToInt(equipment.AntiAir) * Math.Sqrt(slot));
		}

		/// <summary>
		/// 加重対空（装備倍率分）を取得
		/// </summary>
		/// <param name="equipments"></param>
		/// <param name="equipmentId"></param>
		/// <returns></returns>
		public static int GetAntiAirWeight(EnemyEquipment equipment)
		{
			if (equipment == null) return 0;

			var aa = ConvertUtil.ToInt(equipment.AntiAir);

			// 機銃
			if (equipment.TypeID == 1005) return 6 * aa;
			// 高角砲
			if (equipment.TypeID == 1002) return 4 * aa;
			// 電探
			if (equipment.TypeID == 1004) return 3 * aa;

			return 0;
		}

		/// <summary>
		/// 防空ボーナスを取得
		/// </summary>
		/// <param name="equipments"></param>
		/// <param name="equipmentId"></param>
		/// <returns></returns>
		public static double GetAntiAirBonus(EnemyEquipment equipment)
		{
			if (equipment == null) return 0;

			var aa = ConvertUtil.ToInt(equipment.AntiAir);
			// 三式弾
			//if (equipment.TypeID == 2000) return 0.6 * aa;
			// 電探
			if (equipment.TypeID == 1004) return 0.4 * aa;
			// 高角砲
			if (equipment.TypeID == 1002) return 0.35 * aa;
			// 主砲（赤）副砲　機銃　艦戦　艦爆　水偵
			if (equipment.TypeID == 1001
				|| equipment.TypeID == 1003
				|| equipment.TypeID == 1005
				|| equipment.TypeID == 1
				|| equipment.TypeID == -1
				|| equipment.TypeID == 2
				|| equipment.TypeID == -2
				|| equipment.TypeID == 3
				|| equipment.TypeID == 5) return 0.2 * aa;

			return 0;
		}

		/// <summary>
		/// 敵艦全体取得
		/// </summary>
		/// <returns></returns>
		public static List<Enemy> Select()
		{
			return Select(0);
		}

		/// <summary>
		/// 敵艦指定取得
		/// </summary>
		/// <param name="enemyId">敵艦ID</param>
		/// <returns></returns>
		public static List<Enemy> Select(int enemyId)
		{
			var list = new List<Enemy>();
			using (var db = new DBManager())
			{
				var dt = db.Select($@"
SELECT
	  enemies.id                                                     AS enemy_id
	, enemies.name                                                   AS enemy_name
	, ' ' || GROUP_CONCAT(enemies_types.enemy_type_id, ', ') || ', ' AS type_ids
	, GROUP_CONCAT(enemy_types.name, ', ')                           AS type_names
	, IFNULL(slot_1, '')                                             AS slot_1
	, IFNULL(enemy_plane1.id, '')                                    AS equipment1_id
	, enemy_plane1.name                                              AS equipment1
	, IFNULL(slot_2, '')                                             AS slot_2
	, IFNULL(enemy_plane2.id, '')                                    AS equipment2_id
	, enemy_plane2.name                                              AS equipment2
	, IFNULL(slot_3, '')                                             AS slot_3
	, IFNULL(enemy_plane3.id, '')                                    AS equipment3_id
	, enemy_plane3.name                                              AS equipment3
	, IFNULL(slot_4, '')                                             AS slot_4
	, IFNULL(enemy_plane4.id, '')                                    AS equipment4_id
	, enemy_plane4.name                                              AS equipment4
	, IFNULL(slot_5, '')                                             AS slot_5
	, IFNULL(enemy_plane5.id, '')                                    AS equipment5_id
	, enemy_plane5.name                                              AS equipment5
	, original_id
	, anti_air_weight
	, anti_air_bonus 
FROM
	enemies
	LEFT JOIN enemies_types 
		ON enemies.id = enemies_types.enemy_id 
	LEFT JOIN enemy_types 
		ON enemies_types.enemy_type_id = enemy_types.id 
	LEFT JOIN equipments_view AS enemy_plane1 
		ON enemies.equipment_1 = enemy_plane1.id 
	LEFT JOIN equipments_view AS enemy_plane2 
		ON enemies.equipment_2 = enemy_plane2.id 
	LEFT JOIN equipments_view AS enemy_plane3 
		ON enemies.equipment_3 = enemy_plane3.id 
	LEFT JOIN equipments_view AS enemy_plane4 
		ON enemies.equipment_4 = enemy_plane4.id 
	LEFT JOIN equipments_view AS enemy_plane5 
		ON enemies.equipment_5 = enemy_plane5.id
WHERE
	enemies.id <> - 1 
	{(enemyId != 0 ? "AND enemies.id = " + enemyId : "")}
GROUP BY
	enemies.id
");

				var equipments = EnemyEquipment.Select();

				foreach (DataRow dr in dt.Rows)
				{
					var enemy = new Enemy();
					enemy.ID = ConvertUtil.ToInt(dr["enemy_id"]);
					enemy.Name = ConvertUtil.ToString(dr["enemy_name"]);
					enemy.TypeIds = ConvertUtil.ToString(dr["type_ids"]);
					enemy.TypeNames = ConvertUtil.ToString(dr["type_names"]);
					enemy.Slot1 = ConvertUtil.ToInt(dr["slot_1"]);
					enemy.Equipment1ID = ConvertUtil.ToInt(dr["equipment1_id"]);
					enemy.Equipment1 = "[" + enemy.Slot1 + "] " + ConvertUtil.ToString(dr["equipment1"]);
					enemy.Slot2 = ConvertUtil.ToInt(dr["slot_2"]);
					enemy.Equipment2ID = ConvertUtil.ToInt(dr["equipment2_id"]);
					enemy.Equipment2 = "[" + enemy.Slot2 + "] " + ConvertUtil.ToString(dr["equipment2"]);
					enemy.Slot3 = ConvertUtil.ToInt(dr["slot_3"]);
					enemy.Equipment3ID = ConvertUtil.ToInt(dr["equipment3_id"]);
					enemy.Equipment3 = "[" + enemy.Slot3 + "] " + ConvertUtil.ToString(dr["equipment3"]);
					enemy.Slot4 = ConvertUtil.ToInt(dr["slot_4"]);
					enemy.Equipment4ID = ConvertUtil.ToInt(dr["equipment4_id"]);
					enemy.Equipment4 = "[" + enemy.Slot4 + "] " + ConvertUtil.ToString(dr["equipment4"]);
					enemy.Slot5 = ConvertUtil.ToInt(dr["slot_5"]);
					enemy.Equipment5ID = ConvertUtil.ToInt(dr["equipment5_id"]);
					enemy.Equipment5 = "[" + enemy.Slot5 + "] " + ConvertUtil.ToString(dr["equipment5"]);
					enemy.OriginalID = ConvertUtil.ToInt(dr["original_id"]);
					enemy.AntiAirWeight = ConvertUtil.ToInt(dr["anti_air_weight"]);
					enemy.AntiAirBonus = ConvertUtil.ToInt(dr["anti_air_bonus"]);

					enemy.AirPower += GetAirPower(equipments, ConvertUtil.ToInt(enemy.Equipment1ID), ConvertUtil.ToInt(enemy.Slot1));
					enemy.AirPower += GetAirPower(equipments, ConvertUtil.ToInt(enemy.Equipment2ID), ConvertUtil.ToInt(enemy.Slot2));
					enemy.AirPower += GetAirPower(equipments, ConvertUtil.ToInt(enemy.Equipment3ID), ConvertUtil.ToInt(enemy.Slot3));
					enemy.AirPower += GetAirPower(equipments, ConvertUtil.ToInt(enemy.Equipment4ID), ConvertUtil.ToInt(enemy.Slot4));
					enemy.AirPower += GetAirPower(equipments, ConvertUtil.ToInt(enemy.Equipment5ID), ConvertUtil.ToInt(enemy.Slot5));

					enemy.LandBaseAirPower += GetAirPower(equipments, ConvertUtil.ToInt(enemy.Equipment1ID), ConvertUtil.ToInt(enemy.Slot1), true);
					enemy.LandBaseAirPower += GetAirPower(equipments, ConvertUtil.ToInt(enemy.Equipment2ID), ConvertUtil.ToInt(enemy.Slot2), true);
					enemy.LandBaseAirPower += GetAirPower(equipments, ConvertUtil.ToInt(enemy.Equipment3ID), ConvertUtil.ToInt(enemy.Slot3), true);
					enemy.LandBaseAirPower += GetAirPower(equipments, ConvertUtil.ToInt(enemy.Equipment4ID), ConvertUtil.ToInt(enemy.Slot4), true);
					enemy.LandBaseAirPower += GetAirPower(equipments, ConvertUtil.ToInt(enemy.Equipment5ID), ConvertUtil.ToInt(enemy.Slot5), true);

					list.Add(enemy);
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
INTO enemies( 
	id
	, name
	, slot_1
	, slot_2
	, slot_3
	, slot_4
	, slot_5
	, equipment_1
	, equipment_2
	, equipment_3
	, equipment_4
	, equipment_5
	, original_id
	, anti_air_weight
	, anti_air_bonus
	, air_power
	, land_base_air_power
) 
VALUES ( 
	{ID}
	, @name
	, @slot_1
	, @slot_2
	, @slot_3
	, @slot_4
	, @slot_5
	, @equipment_1
	, @equipment_2
	, @equipment_3
	, @equipment_4
	, @equipment_5
	, {OriginalID}
	, {AntiAirWeight}
	, {AntiAirBonus}
	, {AirPower}
	, {LandBaseAirPower}
) ";
			var param = new Dictionary<string, object>()
			{
				{ "@name", Name },
				{ "@slot_1", Slot1 == null ? (object)DBNull.Value : Slot1 },
				{ "@slot_2", Slot2 == null ? (object)DBNull.Value : Slot2 },
				{ "@slot_3", Slot3 == null ? (object)DBNull.Value : Slot3 },
				{ "@slot_4", Slot4 == null ? (object)DBNull.Value : Slot4 },
				{ "@slot_5", Slot5 == null ? (object)DBNull.Value : Slot5 },
				{ "@equipment_1", Equipment1ID == null ? (object)DBNull.Value : Equipment1ID },
				{ "@equipment_2", Equipment2ID == null ? (object)DBNull.Value : Equipment2ID },
				{ "@equipment_3", Equipment3ID == null ? (object)DBNull.Value : Equipment3ID },
				{ "@equipment_4", Equipment4ID == null ? (object)DBNull.Value : Equipment4ID },
				{ "@equipment_5", Equipment5ID == null ? (object)DBNull.Value : Equipment5ID }
			};
			db.ExecuteNonQuery(sql, param);
		}

		/// <summary>
		/// 削除
		/// </summary>
		/// <param name="db"></param>
		/// <param name="nodeDetailId"></param>
		internal static void Delete(DBManager db, int enemyId)
		{
			var sql = $@"DELETE FROM enemies WHERE ID = " + enemyId;
			db.ExecuteNonQuery(sql);
		}

		/// <summary>
		/// 艦種登録
		/// </summary>
		/// <param name="db"></param>
		public static void InsertTypes(DBManager db, int enemyId, int typeId)
		{
			var sql = $@"
INSERT 
INTO enemies_types (
	enemy_id
	, enemy_type_id
) 
VALUES (
	{enemyId}
	, {typeId}
)";
			db.ExecuteNonQuery(sql);
		}

		/// <summary>
		/// 削除
		/// </summary>
		/// <param name="db"></param>
		/// <param name="nodeDetailId"></param>
		internal static void DeleteEnemyTypes(DBManager db, int enemyId)
		{
			var sql = $@"DELETE FROM enemies_types WHERE enemy_id = " + enemyId;
			db.ExecuteNonQuery(sql);
		}

		/// <summary>
		/// 敵出現海域( ENEMY_PATTERN)出力
		/// </summary>
		/// <returns></returns>
		public static string OutputEnemyPatterns()
		{
			var outputList = EnemyPattern.SelectManual();
			var output = "";
			foreach (var p in outputList)
			{
				output += "  { a: " + p.MapID + ", " +
					"n: \"" + p.NodeName + "\", " +
					"d: \"" + p.NodeRemarks + "\", " +
					"l: " + p.LevelID + ", " +
					"t: " + p.TypeID + ", " +
					"f: " + p.FormationID + ", " +
					"r: " + p.Radius + ", " +
					"e: [" + p.Enemies + "], " +
					"c: \"" + p.Coords + "\" },\r\n";
			}
			return output;
		}

		/// <summary>
		/// Json出力
		/// </summary>
		/// <returns></returns>
		public static string OutputJson()
		{
			var output = "";
			var sql = @"
SELECT
    '  { id: ' || (id - 1500) || ', type: [' || GROUP_CONCAT(enemies_types.enemy_type_id, ', ') || ']' || ', name: ""' || name || '""' || ', slot: [' || CASE 
        WHEN slot_1 > 0 
            THEN slot_1 || ', ' 
        ELSE '' 
        END || CASE 
        WHEN slot_2 > 0 
            THEN slot_2 || ', ' 
        ELSE '' 
        END || CASE 
        WHEN slot_3 > 0 
            THEN slot_3 || ', ' 
        ELSE '' 
        END || CASE 
        WHEN slot_4 > 0 
            THEN slot_4 || ', ' 
        ELSE '' 
        END || CASE 
        WHEN slot_5 > 0 
            THEN slot_5 || ', ' 
        ELSE '' 
        END || ']' || ', eqp: [' || CASE 
        WHEN slot_1 > 0 AND equipment_1 > 0 
            THEN equipment_1 || ', ' 
        ELSE '' 
        END || CASE 
        WHEN slot_2 > 0 AND equipment_2 > 0 
            THEN equipment_2 || ', ' 
        ELSE '' 
        END || CASE 
        WHEN slot_3 > 0 AND equipment_3 > 0 
            THEN equipment_3 || ', ' 
        ELSE '' 
        END || CASE 
        WHEN slot_4 > 0 AND equipment_4 > 0 
            THEN equipment_4 || ', ' 
        ELSE '' 
        END || CASE 
        WHEN slot_5 > 0 AND equipment_5 > 0 
            THEN equipment_5 || ', ' 
        ELSE '' 
        END || ']' || ', orig: ' || original_id || ', aaw: ' || anti_air_weight || ', aabo: ' || anti_air_bonus || ' },' AS json 
FROM
    enemies 
    LEFT JOIN enemies_types 
        ON enemies.id = enemies_types.enemy_id 
GROUP BY
    enemies.id
";
			using (var db = new DBManager())
			{
				var dt = db.Select(sql);

				foreach (DataRow dr in dt.Rows)
				{
					output += ConvertUtil.ToString(dr["json"]) + "\r\n";
				}
			}

			output = output.Replace(", ]", "]");
			return output;
		}
	}
}
