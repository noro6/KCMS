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
		public int Slot1 { set; get; }
		public int Slot2 { set; get; }
		public int Slot3 { set; get; }
		public int Slot4 { set; get; }
		public int Slot5 { set; get; }
		public bool IsFinal { set; get; }
		public string IsFinalString { set; get; }
		public int OriginalID { set; get; }
		public string OriginalName { set; get; }
		public int DeckID { set; get; }
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
				Slot1 = ships[0].Slot1;
				Slot2 = ships[0].Slot2;
				Slot3 = ships[0].Slot3;
				Slot4 = ships[0].Slot4;
				Slot5 = ships[0].Slot5;
				IsFinal = ships[0].IsFinal;
				IsFinalString = ships[0].IsFinalString;
				OriginalID = ships[0].OriginalID;
				DeckID = ships[0].DeckID;
			} 
		}

		/// <summary>
		/// 敵艦全体取得
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
			using(var db = new DBManager())
			{
				var dt = db.Select($@"
SELECT
	  ships.id            AS ship_id
	, ships.name          AS ship_name
	, ship_types.id       AS type_id
	, ship_types.name     AS type_name
	, ships.slot_1
	, ships.slot_2
	, ships.slot_3
	, ships.slot_4
	, ships.slot_5
	, ships.is_final
	, ships.original_id
	, ships.deck_id
	, original_ships.name AS original_name 
FROM
	ships 
	LEFT JOIN ship_types 
		ON ships.ship_type_id = ship_types.id 
	LEFT JOIN ships AS original_ships 
		ON ships.original_id = original_ships.id

");
				foreach (DataRow dr in dt.Rows)
				{
					var ship = new Ship()
					{
						ID = ConvertUtil.ToInt(dr["ship_id"]),
						Name = ConvertUtil.ToString(dr["ship_name"]),
						TypeID = ConvertUtil.ToInt(dr["type_id"]),
						TypeName = ConvertUtil.ToString(dr["type_name"]),
						Slot1 = ConvertUtil.ToInt(dr["slot_1"]),
						Slot2 = ConvertUtil.ToInt(dr["slot_2"]),
						Slot3 = ConvertUtil.ToInt(dr["slot_3"]),
						Slot4 = ConvertUtil.ToInt(dr["slot_4"]),
						Slot5 = ConvertUtil.ToInt(dr["slot_5"]),
						IsFinal = ConvertUtil.ToBool(dr["is_final"]),
						IsFinalString = ConvertUtil.ToBool(dr["is_final"]) ? "最終" : "",
						OriginalID = ConvertUtil.ToInt(dr["original_id"]),
						OriginalName = ConvertUtil.ToString(dr["original_name"]),
						DeckID = ConvertUtil.ToInt(dr["deck_id"])
					};
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
	, ship_type_id
	, name
	, slot_1
	, slot_2
	, slot_3
	, slot_4
	, slot_5
	, is_final
	, original_id
	, deck_id
) 
VALUES ( 
	{ID}
	, {TypeID}
	, @name
	, {Slot1}
	, {Slot2}
	, {Slot3}
	, {Slot4}
	, {Slot5}
	, {(IsFinal ? 1 : 0)}
	, {OriginalID}
	, {DeckID}
) ";
			var param = new Dictionary<string, object>()
			{
				{ "@name", Name },
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
			var sql = $@"DELETE FROM ships WHERE ID = " + enemyId;
			db.ExecuteNonQuery(sql);
		}
	}
}
