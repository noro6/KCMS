using Manager.DB;
using Manager.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Models
{
	class Node : ModelBase
	{
		public int WorldId { set; get; }
		public int MapNo { set; get; }
		public int Radius { set; get; }
		public string Coords { set; get; }

		public Node()
		{
			TableName = "nodes";
		}

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
		/// 削除処理
		/// </summary>
		/// <param name="db"></param>
		public static void Delete(DBManager db, int deleteID)
		{
			var sql = "DELETE FROM nodes WHERE ID = " + deleteID;
			db.ExecuteNonQuery(sql);
		}
	}
}
