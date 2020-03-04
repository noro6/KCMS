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
			} 
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
			using(var db = new DBManager())
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
	LEFT JOIN enemy_equipments AS enemy_plane1 
		ON enemies.equipment_1 = enemy_plane1.id 
	LEFT JOIN enemy_equipments AS enemy_plane2 
		ON enemies.equipment_2 = enemy_plane2.id 
	LEFT JOIN enemy_equipments AS enemy_plane3 
		ON enemies.equipment_3 = enemy_plane3.id 
	LEFT JOIN enemy_equipments AS enemy_plane4 
		ON enemies.equipment_4 = enemy_plane4.id 
	LEFT JOIN enemy_equipments AS enemy_plane5 
		ON enemies.equipment_5 = enemy_plane5.id
WHERE
	enemies.id <> - 1 
	{(enemyId != 0 ? "AND enemies.id = " + enemyId : "")}
GROUP BY
	enemies.id
");
				foreach (DataRow dr in dt.Rows)
				{
					var enemy = new Enemy()
					{
						ID = ConvertUtil.ToInt(dr["enemy_id"]),
						Name = ConvertUtil.ToString(dr["enemy_name"]),
						TypeIds = ConvertUtil.ToString(dr["type_ids"]),
						TypeNames = ConvertUtil.ToString(dr["type_names"]),
						Slot1 = ConvertUtil.ToInt(dr["slot_1"]),
						Equipment1ID = ConvertUtil.ToInt(dr["equipment1_id"]),
						Equipment1 = ConvertUtil.ToString(dr["equipment1"]),
						Slot2 = ConvertUtil.ToInt(dr["slot_2"]),
						Equipment2ID = ConvertUtil.ToInt(dr["equipment2_id"]),
						Equipment2 = ConvertUtil.ToString(dr["equipment2"]),
						Slot3 = ConvertUtil.ToInt(dr["slot_3"]),
						Equipment3ID = ConvertUtil.ToInt(dr["equipment3_id"]),
						Equipment3 = ConvertUtil.ToString(dr["equipment3"]),
						Slot4 = ConvertUtil.ToInt(dr["slot_4"]),
						Equipment4ID = ConvertUtil.ToInt(dr["equipment4_id"]),
						Equipment4 = ConvertUtil.ToString(dr["equipment4"]),
						Slot5 = ConvertUtil.ToInt(dr["slot_5"]),
						Equipment5ID = ConvertUtil.ToInt(dr["equipment5_id"]),
						Equipment5 = ConvertUtil.ToString(dr["equipment5"]),
						OriginalID = ConvertUtil.ToInt(dr["original_id"]),
						AntiAirWeight = ConvertUtil.ToInt(dr["anti_air_weight"]),
						AntiAirBonus = ConvertUtil.ToInt(dr["anti_air_bonus"]),
					};
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
			var output = "";
			var sql = @"
SELECT
  '  { area: ' || world_id || map_no ||
  ', node: ""' || nodes.name || 
  '"", remarks: ""' || node_details.name ||
  '"", pattern: ' || IFNULL(node_details.pattern_no, '') ||
  ', lv: ' || levels.id ||
  ', type: ' || node_types.id ||
  ', form: ' || formations.id ||
  ', radius: ' || nodes.radius ||
  ', enemies: [' || pattern.enemy_id || ']' ||
  ', coords: ""' || IFNULL(nodes.coords, '') || '"" },' AS json
FROM
  worlds 
  LEFT JOIN nodes 
    ON worlds.id = nodes.world_id 
  LEFT JOIN node_details 
    ON nodes.id = node_details.node_id 
  LEFT JOIN ( 
    SELECT
      node_detail_id
      , GROUP_CONCAT(enemy_id, ', ') AS enemy_id
      , GROUP_CONCAT(enemies.name) AS enemy_name 
    FROM
      node_details_enemies
	  LEFT JOIN enemies
		ON node_details_enemies.enemy_id = enemies.id
	GROUP BY
	  node_detail_id
  ) AS pattern
	ON pattern.node_detail_id = node_details.id
  LEFT JOIN levels
	ON node_details.level_id = levels.id
  LEFT JOIN node_types
	ON node_details.node_type_id = node_types.id
  LEFT JOIN formations
	ON node_details.formation_id = formations.id
WHERE
  worlds.status = 1
  AND node_details.id is not null
GROUP BY
  world_id
  , map_no
  , nodes.name
  , pattern_no
ORDER BY
  world_id ASC
  , map_no ASC
  , nodes.name ASC
  , levels.id DESC
  , node_details.pattern_no ASC
";

			using(var db = new DBManager())
			{
				var dt = db.Select(sql);

				foreach (DataRow dr in dt.Rows)
				{
					output += ConvertUtil.ToString(dr["json"]) + "\r\n";
				}
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
	  '  { id: ' || id || ', type: [' || GROUP_CONCAT(enemies_types.enemy_type_id, ', ') || ']' || ', name: ""' || name || '""' || ', slot: [' || 
	  	CASE 
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
		WHEN equipment_1 > 0 
			THEN equipment_1 || ', ' 
		ELSE '' 
		END || CASE 
		WHEN equipment_2 > 0 
			THEN equipment_2 || ', ' 
		ELSE '' 
		END || CASE 
		WHEN equipment_3 > 0 
			THEN equipment_3 || ', ' 
		ELSE '' 
		END || CASE 
		WHEN equipment_4 > 0 
			THEN equipment_4 || ', ' 
		ELSE '' 
		END || CASE 
		WHEN equipment_5 > 0 
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
