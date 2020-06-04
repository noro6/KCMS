using Manager.DB;
using Manager.Util;
using System.Collections.Generic;
using System.Data;

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

		/// <summary>
		/// JSON出力
		/// </summary>
		/// <returns></returns>
		internal static string OutputJson()
		{
			var output = "";
			var sql = @"
SELECT
	  '  { world: ' || id || ', name: ""' || name || '"" },' AS json 
FROM
	worlds 
WHERE
	status = 1 
ORDER BY
	sort
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
		/// 更新処理
		/// </summary>
		/// <param name="db"></param>
		internal void Update(DBManager db)
		{
			var sql = $@"
UPDATE worlds 
SET
	name = @name
WHERE
	id = {ID}
";
			var param = new Dictionary<string, object>()
			{
				{ "@name", Name },
			};
			db.ExecuteNonQuery(sql, param);
		}
	}
}
