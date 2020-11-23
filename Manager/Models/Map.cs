using Manager.DB;
using Manager.Util;
using System.Collections.Generic;
using System.Data;

namespace Manager.Models
{
	/// <summary>
	/// マップモデル
	/// </summary>
	class Map : ModelBase
	{
		/// <summary>
		/// 海域id
		/// </summary>
		public int WorldId { set; get; }
		/// <summary>
		/// マップ番号
		/// </summary>
		public int MapNo { set; get; }

		/// <summary>
		/// 空の<see cref="Map"/>インスタンス生成
		/// </summary>
		public Map()
		{
			TableName = "maps";
		}

		/// <summary>
		/// DBから指定id(PK)を持つ<see	cref="Map"/>インスタンス生成
		/// </summary>
		/// <param name="id"></param>
		public Map(int id)
		{
			TableName = "maps";
			using (var db = new DBManager())
			{
				var dt = db.Select("SELECT * FROM " + TableName + " WHERE id = " + id);
				if (dt.Rows.Count == 1)
				{
					ID = ConvertUtil.ToInt(dt.Rows[0]["id"]);
					WorldId = ConvertUtil.ToInt(dt.Rows[0]["world_id"]);
					MapNo = ConvertUtil.ToInt(dt.Rows[0]["map_no"]);
					Name = ConvertUtil.ToString(dt.Rows[0]["name"]);
				}
			}
		}
		/// <summary>
		/// DBから指定海域、指定マップ番号を持つ<see	cref="Map"/>インスタンス生成
		/// </summary>
		/// <param name="worldId">海域id</param>
		/// <param name="mapNo">マップ番号</param>
		public Map(int worldId, int mapNo)
		{
			TableName = "maps";
			using (var db = new DBManager())
			{
				var dt = db.Select("SELECT * FROM " + TableName + " WHERE world_id = " + worldId + " AND map_no = " + mapNo);
				if (dt.Rows.Count == 1)
				{
					ID = ConvertUtil.ToInt(dt.Rows[0]["id"]);
					WorldId = ConvertUtil.ToInt(dt.Rows[0]["world_id"]);
					MapNo = ConvertUtil.ToInt(dt.Rows[0]["map_no"]);
					Name = ConvertUtil.ToString(dt.Rows[0]["name"]);
				}
			}
		}

		/// <summary>
		/// 新規登録処理
		/// </summary>
		/// <param name="db"></param>
		public void Insert(DBManager db)
		{
			ID = SelectMaxId(db) + 1;
			var sql = $@"
INSERT 
INTO maps(id, world_id, map_no, name) 
VALUES({ID}, {WorldId}, {MapNo}, @name)
";
			var param = new Dictionary<string, object>() { { "@name", Name } };

			db.ExecuteNonQuery(sql, param);
		}

		/// <summary>
		/// JSON出力
		/// </summary>
		/// <returns></returns>
		internal static string OutputJson()
		{
			var output = "";
			var sql = @"
SELECT
	  '  { area: ' || world_id || map_no || ', name: ""' || maps.name || '"" },' AS json 
FROM
	maps
LEFT JOIN worlds
	ON maps.world_id = worlds.id
WHERE
	worlds.status = 1
ORDER BY 
	world_id
	, map_no
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

		/// <summary>
		/// マップ削除処理
		/// </summary>
		/// <param name="db"></param>
		/// <param name="worldId">削除対象海域id</param>
		/// <param name="mapNo">削除対象マップ番号</param>
		public static void Delete(DBManager db, int worldId, int mapNo)
		{
			var sql = "DELETE FROM maps WHERE world_id = " + worldId + " AND map_no = " + mapNo;
			db.ExecuteNonQuery(sql);
		}

		/// <summary>
		/// 更新処理
		/// </summary>
		/// <param name="db"></param>
		internal void Update(DBManager db)
		{
			var sql = $@"
UPDATE maps 
SET
	name = @name
WHERE
	world_id = {WorldId}
	AND map_no = {MapNo}
";
			var param = new Dictionary<string, object>()
			{
				{ "@name", Name },
			};
			db.ExecuteNonQuery(sql, param);
		}
	}
}
