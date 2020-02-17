using Manager.DB;
using Manager.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Models
{
	class Map : ModelBase
	{
		public int WorldId { set; get; }
		public int MapNo { set; get; }

		public Map()
		{
			TableName = "maps";
		}

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
			var sql = $@"
INSERT 
INTO maps(id, world_id, map_no, name) 
VALUES({ID}, {WorldId}, {MapNo}, @name)
";
			var param = new Dictionary<string, object>() { { "@name", Name } };

			db.ExecuteNonQuery(sql, param);
		}
	}
}
