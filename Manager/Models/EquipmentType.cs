using Manager.DB;
using Manager.Util;
using System.Collections.Generic;
using System.Data;

namespace Manager.Models
{
	class EquipmentType : ModelBase
	{

		public static List<EquipmentType> Select()
		{
			var list = new List<EquipmentType>();
			using (var db = new DBManager())
			{
				var dt = db.Select("SELECT id, name FROM equipment_types");

				foreach (DataRow dr in dt.Rows)
				{
					var shipType = new EquipmentType()
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
