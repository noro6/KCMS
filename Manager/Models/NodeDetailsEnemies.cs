using Manager.DB;
using Manager.Util;
using System;
using System.Collections.Generic;
using System.Data;

namespace Manager.Models
{
	class NodeDetailsEnemies : ModelBase
	{
		public int NodeDetailId { set; get; }
		public List<Enemy> Enemies { set; get; }

		public NodeDetailsEnemies()
		{
			TableName = "node_details_enemies";
		}

		public static NodeDetailsEnemies Select(int nodeDetailId)
		{
			var list = new List<NodeDetail>();
			using (var db = new DBManager())
			{
				var dt = db.Select(@"
SELECT
	  node_details_enemies.id
	, node_detail_id
	, enemy_id
	, enemies.name AS enemy_name 
FROM
	node_details_enemies 
	LEFT JOIN enemies 
		ON enemy_id = enemies.id
WHERE 
	node_detail_id = " + nodeDetailId);

				if (dt.Rows.Count == 0) return new NodeDetailsEnemies();

				var retValue = new NodeDetailsEnemies();
				retValue.ID = ConvertUtil.ToInt(dt.Rows[0]["id"]);
				retValue.NodeDetailId = nodeDetailId;
				retValue.Enemies = new List<Enemy>();

				foreach (DataRow dr in dt.Rows)
				{
					var enemy = new Enemy()
					{
						ID = ConvertUtil.ToInt(dr["enemy_id"]),
						Name = ConvertUtil.ToString(dr["enemy_name"]),
					};
					retValue.Enemies.Add(enemy);
				}

				return retValue;
			}
		}

		/// <summary>
		/// 登録
		/// </summary>
		/// <param name="db"></param>
		internal void Insert(DBManager db)
		{
			for (int i = 0; i < Enemies.Count; i++)
			{
				var sql = $@"
INSERT 
INTO node_details_enemies (
	id
	, node_detail_id
	, enemy_id
	, sort
) 
VALUES (
	{ID++}
	, {NodeDetailId}
	, {Enemies[i].ID}
	, {i + 1}
);";
				db.ExecuteNonQuery(sql);
			}

		}

		/// <summary>
		/// 削除
		/// </summary>
		/// <param name="db"></param>
		/// <param name="nodeDetailId"></param>
		internal static void Delete(DBManager db, int nodeDetailId)
		{
			var sql = $@"DELETE FROM node_details_enemies WHERE node_detail_id = " + nodeDetailId;
			db.ExecuteNonQuery(sql);
		}
	}
}
