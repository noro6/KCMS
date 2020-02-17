using Manager.DB;
using Manager.Util;
using System.Collections.Generic;
using System.Data;

namespace Manager.Models
{
	class ShipType : ModelBase
	{

		public static List<ShipType> Select()
		{
			var list = new List<ShipType>();
			using (var db = new DBManager())
			{
				var dt = db.Select("SELECT id, name FROM ship_types");

				foreach (DataRow dr in dt.Rows)
				{
					var shipType = new ShipType()
					{
						ID = ConvertUtil.ToInt(dr["id"]),
						Name = ConvertUtil.ToString(dr["name"])
					};
					list.Add(shipType);
				}
			}
			return list;
		}
	}
}
