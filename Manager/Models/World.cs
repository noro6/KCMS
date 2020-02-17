using Manager.DB;
using Manager.Util;
using System.Collections.Generic;

namespace Manager.Models
{
	class World : ModelBase
	{
		public World()
		{
			TableName = "worlds";
		}

		public  World(int id)
		{
			TableName = "worlds";
			using(var db = new DBManager())
			{
				var dt = db.Select("SELECT * FROM " + TableName + " WHERE id = " + id);
				if(dt.Rows.Count == 1)
				{
					ID = ConvertUtil.ToInt(dt.Rows[0]["id"]);
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
INTO worlds(id, name, status) 
VALUES(@id, @name, true)
";
			var param = new Dictionary<string, object>()
			{
				{ "@id", ID },
				{ "@name", Name }
			};

			db.ExecuteNonQuery(sql, param);
		}
	}
}
