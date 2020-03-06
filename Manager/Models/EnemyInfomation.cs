using Manager.DB;
using Manager.Util;
using System.Collections.Generic;
using System.Data;

namespace Manager.Models
{
	class EnemyInfomation
	{
		public int WorldId { set; get; }
		public int MapNo { set; get; }
		public int NodeId { set; get; }
		public string NodeName { set; get; }
		public string NodeRemarks { set; get; }
		public string LevelName { set; get; }
		public string TypeName { set; get; }
		public string FormationName { set; get; }
		public string EnemyName { set; get; }
		public int DetailId { set; get; }
		public string AirPower { set; get; }

		/// <summary>
		/// 検索
		/// </summary>
		/// <returns></returns>
		public static List<EnemyInfomation> Select()
		{
			var sql = $@"
SELECT
	world_id
	, map_no
	, node_id
	, node_name
	, node_remarks
	, level_name
	, node_type
	, formation
	, enemy_name
	, node_detail_id
	, air_power
	, land_base_air_power
FROM
	node_information
";
			using (var db = new DBManager())
			{
				var dt = db.Select(sql);
				var list = new List<EnemyInfomation>();
				foreach (DataRow dr in dt.Rows)
				{
					var ins = new EnemyInfomation()
					{
						WorldId = ConvertUtil.ToInt(dr["world_id"]),
						MapNo = ConvertUtil.ToInt(dr["map_no"]),
						NodeId = ConvertUtil.ToInt(dr["node_id"]),
						NodeName = ConvertUtil.ToString(dr["node_name"]),
						NodeRemarks = ConvertUtil.ToString(dr["node_remarks"]),
						LevelName = ConvertUtil.ToString(dr["level_name"]),
						TypeName = ConvertUtil.ToString(dr["node_type"]),
						FormationName = ConvertUtil.ToString(dr["formation"]),
						EnemyName = ConvertUtil.ToString(dr["enemy_name"]),
						DetailId = ConvertUtil.ToInt(dr["node_detail_id"]),
						AirPower = ConvertUtil.ToInt(dr["air_power"]) + "\r\n(" + ConvertUtil.ToInt(dr["land_base_air_power"]) + ")",
					};
					if (ins.NodeRemarks == "") ins.NodeRemarks = "(未指定)";

					list.Add(ins);
				}

				return list;
			}
		}
	}
}
