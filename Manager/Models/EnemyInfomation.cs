using Manager.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Models
{
	class EnemyInfomation
	{
		public string MapName { get; }
		public string Name { get; }
		public string Level { get; }
		public string NodeType { get; }
		public string Formation { get; }
		public string NodeDetailId { get; }
		public string PatternNo { get; }
		public string EnemyName { get; }

		public EnemyInfomation(string mapName, string name, string level, string nodeType, string formation, string detailNo, string patternNo, string enemyName)
		{
			MapName = mapName;
			Name = name;
			Level = level;
			NodeType = nodeType;
			Formation = formation;
			NodeDetailId = detailNo;
			PatternNo = patternNo;
			EnemyName = enemyName;
		}

		/// <summary>
		/// 検索
		/// </summary>
		/// <param name="worldId"></param>
		/// <param name="mapNo"></param>
		/// <param name="nodeId"></param>
		/// <returns></returns>
		public static DataTable Select(int worldId, int mapNo, int nodeId)
		{
			var sql = $@"
SELECT
	  world_id || '-' || map_no AS map_name
	, name
	, level
	, node_type
	, formation
	, enemy_name
	, node_detail_id
FROM
	node_information
WHERE
	world_id = {worldId}
	{(mapNo > 0 ? "AND map_no = " + mapNo : "")}
	{(nodeId > 0 ? "AND node_id = " + nodeId : "")}
";
			using(var db = new DBManager())
			{
				return db.Select(sql);
			}
		}
	}
}
