using Manager.DB;
using Manager.Util;
using System.Collections.Generic;
using System.Data;

namespace Manager.Models
{
	/// <summary>
	/// セルモデル
	/// </summary>
	class Node : ModelBase
	{
		/// <summary>
		/// 海域id
		/// </summary>
		public int WorldId { set; get; }
		/// <summary>
		/// マップno
		/// </summary>
		public int MapNo { set; get; }
		/// <summary>
		/// 半径
		/// </summary>
		public int Radius { set; get; }
		/// <summary>
		/// マップ画像座標
		/// </summary>
		public string Coords { set; get; }
		/// <summary>
		/// 空の<see cref="Node"/>インスタンス生成
		/// </summary>
		public Node()
		{
			TableName = "nodes";
		}
		/// <summary>
		/// DBから指定id(PK)を持つ<see	cref="Node"/>インスタンス生成
		/// </summary>
		/// <param name="id"></param>
		public Node(int id)
		{
			TableName = "nodes";
			using (var db = new DBManager())
			{
				var dt = db.Select("SELECT * FROM " + TableName + " WHERE id = " + id);
				if (dt.Rows.Count == 1)
				{
					ID = ConvertUtil.ToInt(dt.Rows[0]["id"]);
					WorldId = ConvertUtil.ToInt(dt.Rows[0]["world_id"]);
					MapNo = ConvertUtil.ToInt(dt.Rows[0]["map_no"]);
					Name = ConvertUtil.ToString(dt.Rows[0]["name"]);
					Radius = ConvertUtil.ToInt(dt.Rows[0]["radius"]);
					Coords = ConvertUtil.ToString(dt.Rows[0]["coords"]);
				}
			}
		}
		/// <summary>
		/// DBから指定海域、指定マップ番号、セル名を持つ<see	cref="Node"/>インスタンス生成
		/// </summary>
		/// <param name="worldId">海域id</param>
		/// <param name="mapNo">マップ番号</param>
		/// <param name="nodeName">セル名</param>
		public Node(int worldId, int mapNo, string nodeName)
		{
			TableName = "nodes";
			using (var db = new DBManager())
			{
				var dt = db.Select($@"
SELECT * FROM {TableName}
WHERE 
	world_id = {worldId}
	AND map_no = {mapNo}
	AND name = '{nodeName}'
");
				if (dt.Rows.Count == 1)
				{
					ID = ConvertUtil.ToInt(dt.Rows[0]["id"]);
					WorldId = ConvertUtil.ToInt(dt.Rows[0]["world_id"]);
					MapNo = ConvertUtil.ToInt(dt.Rows[0]["map_no"]);
					Name = ConvertUtil.ToString(dt.Rows[0]["name"]);
					Radius = ConvertUtil.ToInt(dt.Rows[0]["radius"]);
					Coords = ConvertUtil.ToString(dt.Rows[0]["coords"]);
				}
			}
		}

		/// <summary>
		/// マス情報を海域id マップNoから検索
		/// </summary>
		/// <param name="worldId">海域id</param>
		/// <param name="mapNo">マップno</param>
		/// <returns></returns>
		public static List<Node> SelectAll(int worldId, int mapNo)
		{
			using (var db = new DBManager())
			{
				return SelectAll(db, worldId, mapNo);
			}
		}

		/// <summary>
		/// マス情報を海域id マップNoから検索
		/// </summary>
		/// <param name="db">同一トラン内で検索する場合</param>
		/// <param name="worldId">海域id</param>
		/// <param name="mapNo">マップno</param>
		/// <returns></returns>
		public static List<Node> SelectAll(DBManager db,int worldId, int mapNo)
		{
			var dt = db.Select("SELECT * FROM nodes WHERE world_id = " + worldId + " AND map_no = " + mapNo);

			var nodes = new List<Node>();
			foreach (DataRow dr in dt.Rows)
			{
				var node = new Node()
				{
					ID = ConvertUtil.ToInt(dr["id"]),
					Name = ConvertUtil.ToString(dr["name"]),
					WorldId = ConvertUtil.ToInt(dr["world_id"]),
					MapNo = ConvertUtil.ToInt(dr["map_no"]),
				};
				nodes.Add(node);
			}
			return nodes;
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
INTO nodes(id, world_id, map_no, name, radius, coords) 
VALUES({ID}, {WorldId}, {MapNo}, @name, {Radius}, @coords)
";
			var param = new Dictionary<string, object>()
			{
				{ "@name", Name },
				{ "@coords", Coords }
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
UPDATE nodes 
SET
	name = @name
	, radius = {Radius}
	, coords = @coords
WHERE
	id = {ID}
";
			var param = new Dictionary<string, object>()
			{
				{ "@name", Name },
				{ "@coords", Coords }
			};
			db.ExecuteNonQuery(sql, param);
		}


		/// <summary>
		/// 削除処理
		/// </summary>
		/// <param name="db"></param>
		/// <param name="deleteID">削除対象ID</param>
		public static void Delete(DBManager db, int deleteID)
		{
			var sql = "DELETE FROM nodes WHERE ID = " + deleteID;
			db.ExecuteNonQuery(sql);
		}

		/// <summary>
		/// 複数削除処理
		/// </summary>
		/// <param name="db"></param>
		/// <param name="deleteID">削除対象ID</param>
		public static List<Node> DeleteNodes(DBManager db,int worldId, int deleteMapNo)
		{
			var deleteList = SelectAll(db, worldId, deleteMapNo);
			var sql = $@"
DELETE FROM 
	nodes 
WHERE 
	world_id = {worldId}
	AND map_no = {deleteMapNo}
";
			db.ExecuteNonQuery(sql);

			return deleteList;
		}
	}
}
