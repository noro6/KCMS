using Manager.DB;
using Manager.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Models
{
	class EnemyPlane : ModelBase
	{
		public int TypeID { set; get; }
		public string TypeName { set; get; }
		public string AntiAir { set; get; }

		public EnemyPlane()
		{
			TableName = "enemy_planes";
		}

		public EnemyPlane(int planeId)
		{
			TableName = "enemy_planes";
		}


		/// <summary>
		/// 敵装備全体取得
		/// </summary>
		/// <returns></returns>
		public static List<EnemyPlane> Select()
		{
			return Select(0);
		}

		/// <summary>
		/// 敵装備指定取得
		/// </summary>
		/// <param name="enemyId">敵艦ID</param>
		/// <returns></returns>
		public static List<EnemyPlane> Select(int planeId)
		{
			var list = new List<EnemyPlane>();
			using (var db = new DBManager())
			{
				var dt = db.Select($@"
SELECT
	  enemy_planes.id   AS id
	, enemy_planes.name AS name
	, plane_types.id    AS type_id
	, plane_types.name  AS type_name
	, enemy_planes.anti_air 
FROM
	enemy_planes 
	LEFT JOIN plane_types 
		ON enemy_planes.plane_type_id = plane_types.id 
WHERE
	1 = 1
	{(planeId != 0 ? "AND enemy_planes.id = " + planeId : "")}
");
				foreach (DataRow dr in dt.Rows)
				{
					var plane = new EnemyPlane()
					{
						ID = ConvertUtil.ToInt(dr["id"]),
						Name = "ID:" + ConvertUtil.ToInt(dr["id"]) + " " + ConvertUtil.ToString(dr["name"]),
						TypeID = ConvertUtil.ToInt(dr["type_id"]),
						TypeName = ConvertUtil.ToString(dr["type_name"]),
						AntiAir = ConvertUtil.ToString(dr["anti_air"]),
					};
					list.Add(plane);
				}
			}
			return list;
		}

		/// <summary>
		/// 敵装備カテゴリ指定取得
		/// </summary>
		/// <param name="enemyId">敵艦ID</param>
		/// <returns></returns>
		public static List<EnemyPlane> Filter(int typeId)
		{
			var list = new List<EnemyPlane>();
			using (var db = new DBManager())
			{
				var dt = db.Select($@"
SELECT
	  enemy_planes.id   AS id
	, enemy_planes.name AS name
	, plane_types.id    AS type_id
	, plane_types.name  AS type_name
	, enemy_planes.anti_air 
FROM
	enemy_planes 
	LEFT JOIN plane_types 
		ON enemy_planes.plane_type_id = plane_types.id 
WHERE
	1 = 1
	{(typeId != 0 ? "AND plane_types.id = " + typeId : "")}
");
				foreach (DataRow dr in dt.Rows)
				{
					var plane = new EnemyPlane()
					{
						ID = ConvertUtil.ToInt(dr["id"]),
						Name = ConvertUtil.ToString(dr["name"]),
						TypeID = ConvertUtil.ToInt(dr["type_id"]),
						TypeName = ConvertUtil.ToString(dr["type_name"]),
						AntiAir = ConvertUtil.ToString(dr["anti_air"]),
					};
					list.Add(plane);
				}
			}
			return list;
		}
	}
}
