using Manager.DB;
using Manager.Util;
using System.Collections.Generic;
using System.Data;

namespace Manager.Models
{
	class PlaneType : ModelBase
	{
		/// <summary>
		/// 装備カテゴリ取得
		/// </summary>
		/// <returns></returns>
		public static List<PlaneType> Select()
		{
			var list = new List<PlaneType>();
			using (var db = new DBManager())
			{
				var dt = db.Select($@"SELECT id, name FROM plane_types");
				foreach (DataRow dr in dt.Rows)
				{
					var type = new PlaneType()
					{
						ID = ConvertUtil.ToInt(dr["id"]),
						Name = ConvertUtil.ToString(dr["name"]),
					};
					list.Add(type);
				}
			}
			return list;
		}
	}
}
