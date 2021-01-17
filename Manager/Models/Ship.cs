using Manager.DB;
using Manager.Util;
using System;
using System.Collections.Generic;
using System.Data;

namespace Manager.Models
{
	class Ship : ModelBase
	{
		public int TypeID { set; get; }
		public string TypeName { set; get; }
		public int SlotCount { set; get; }
		public int? Slot1 { set; get; }
		public int? Slot2 { set; get; }
		public int? Slot3 { set; get; }
		public int? Slot4 { set; get; }
		public int? Slot5 { set; get; }
		public bool IsFinal { set; get; }
		public int Version { set; get; }
		public string IsFinalString { set; get; }
		public int OriginalID { set; get; }
		public string OriginalName { set; get; }
		public int AlbumID { set; get; }
		public bool Enabled { set; get; }
		public Ship()
		{
			TableName = "ships";
		}

		/// <summary>
		/// 指定したIDの敵艦インスタンス生成
		/// </summary>
		/// <param name="shipId"></param>
		public Ship(int shipId)
		{
			TableName = "ships";
			var ships = Select(shipId);
			if (ships.Count == 1)
			{
				ID = ships[0].ID;
				Name = ships[0].Name;
				TypeID = ships[0].TypeID;
				TypeName = ships[0].TypeName;
				SlotCount = ships[0].SlotCount;
				Slot1 = ships[0].Slot1;
				Slot2 = ships[0].Slot2;
				Slot3 = ships[0].Slot3;
				Slot4 = ships[0].Slot4;
				Slot5 = ships[0].Slot5;
				Version = ships[0].Version;
				IsFinal = ships[0].IsFinal;
				IsFinalString = ships[0].IsFinalString;
				OriginalID = ships[0].OriginalID;
				AlbumID = ships[0].AlbumID;
				Enabled = ships[0].Enabled;
			}
		}

		/// <summary>
		/// 艦全体取得
		/// </summary>
		/// <returns></returns>
		public static List<Ship> Select()
		{
			return Select(0);
		}

		/// <summary>
		/// 敵艦指定取得
		/// </summary>
		/// <param name="shipId">ID</param>
		/// <returns></returns>
		public static List<Ship> Select(int shipId)
		{
			var list = new List<Ship>();
			using (var db = new DBManager())
			{
				var dt = db.Select($@"
SELECT
    main.id AS ship_id
    , main.name AS ship_name
    , main.ship_type_id
    , main.ship_type_name
	, main.slot_count
    , main.slot_1
    , main.slot_2
    , main.slot_3
    , main.slot_4
    , main.slot_5
	, main.version
    , IFNULL(main.is_final, 0) AS is_final
    , IFNULL(main.original_id, -1) AS original_id
    , main.album_id
    , IFNULL(origin.name, '') AS original_name
	, IFNULL(main.enabled, 0) AS enabled
FROM
    ships_view AS main 
    LEFT JOIN ships_view AS origin 
        ON main.original_id = origin.album_id 
WHERE
    main.id < 1500
	{(shipId != 0 ? "AND main.id = " + shipId : "")}
;");
				foreach (DataRow dr in dt.Rows)
				{
					var ship = new Ship()
					{
						ID = ConvertUtil.ToInt(dr["ship_id"]),
						Name = ConvertUtil.ToString(dr["ship_name"]),
						TypeID = ConvertUtil.ToInt(dr["ship_type_id"]),
						TypeName = ConvertUtil.ToString(dr["ship_type_name"]),
						SlotCount = ConvertUtil.ToInt(dr["slot_count"], 0),
						Slot1 = ConvertUtil.ToInt(dr["slot_1"], -1),
						Slot2 = ConvertUtil.ToInt(dr["slot_2"], -1),
						Slot3 = ConvertUtil.ToInt(dr["slot_3"], -1),
						Slot4 = ConvertUtil.ToInt(dr["slot_4"], -1),
						Slot5 = ConvertUtil.ToInt(dr["slot_5"], -1),
						Version = ConvertUtil.ToInt(dr["version"], -1),
						IsFinal = ConvertUtil.ToBool(dr["is_final"]),
						IsFinalString = ConvertUtil.ToBool(dr["is_final"]) ? "最終" : "",
						OriginalID = ConvertUtil.ToInt(dr["original_id"]),
						OriginalName = ConvertUtil.ToString(dr["original_name"]),
						AlbumID = ConvertUtil.ToInt(dr["album_id"]),
						Enabled = ConvertUtil.ToBool(dr["enabled"])
					};
					ship.Slot1 = ship.SlotCount < 1 || ship.Slot1 < 0 ? null : ship.Slot1;
					ship.Slot2 = ship.SlotCount < 2 || ship.Slot2 < 0 ? null : ship.Slot2;
					ship.Slot3 = ship.SlotCount < 3 || ship.Slot3 < 0 ? null : ship.Slot3;
					ship.Slot4 = ship.SlotCount < 4 || ship.Slot4 < 0 ? null : ship.Slot4;
					ship.Slot5 = ship.SlotCount < 5 || ship.Slot5 < 0 ? null : ship.Slot5;
					list.Add(ship);
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
INTO ships( 
	id
	, album_id
	, is_final
	, original_id
	, enabled
) 
VALUES ( 
	{ID}
	, {AlbumID}
	, {(IsFinal ? 1 : 0)}
	, {OriginalID}
	, {Enabled}
) ";
			var param = new Dictionary<string, object>() { { "@name", Name }, };
			db.ExecuteNonQuery(sql, param);
		}

		/// <summary>
		/// 削除
		/// </summary>
		/// <param name="db"></param>
		/// <param name="nodeDetailId"></param>
		internal static int Delete(DBManager db, int enemyId)
		{
			var sql = $@"DELETE FROM ships WHERE ID = " + enemyId;
			return db.ExecuteNonQuery(sql);
		}

		/// <summary>
		/// (js側 SHIP_DATA)出力
		/// </summary>
		/// <returns></returns>
		public static string OutputShip()
		{
			var output = "";
			var sql = @"
SELECT
    '  { id: ' || album_id || ', api: ' || id || ', type: ' || ship_type_id || ', name: ""' || name || '""'
     || ', slot: [' || CASE 
        WHEN slot_1 >= 0 AND slot_count >= 1 
            THEN slot_1 || ', ' 
        ELSE '' 
        END || CASE 
        WHEN slot_2 >= 0 AND slot_count >= 2 
            THEN slot_2 || ', ' 
        ELSE '' 
        END || CASE 
        WHEN slot_3 >= 0 AND slot_count >= 3
            THEN slot_3 || ', ' 
        ELSE '' 
        END || CASE 
        WHEN slot_4 >= 0 AND slot_count >= 4
            THEN slot_4 || ', ' 
        ELSE '' 
        END || CASE 
        WHEN slot_5 >= 0 AND slot_count >= 5
            THEN slot_5 || ', ' 
        ELSE '' 
        END || ']' || ', final: ' || is_final || ', orig: ' || original_id || ', valid: ' || enabled || ', range: ' || range || ', sort1: ' || sort_1 || ', sort2: ' || sort_2 || 
    ' },' AS json 
FROM
    ships_view 
WHERE
    id < 1500 
    and ( 
        slot_1 > 0 
        OR slot_2 > 0 
        OR slot_3 > 0 
        OR slot_4 > 0 
        OR slot_5 > 0
    ) 
ORDER BY
    enabled DESC
    , album_id;

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
