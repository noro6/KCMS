using Manager.DB;
using Manager.Util;
using System.Collections.Generic;
using System.Data;

namespace Manager.Models
{
	class NodeType : ModelBase
	{
		public static List<NodeType> Select()
		{
			var list = new List<NodeType>();
			using (var db = new DBManager())
			{
				var dt = db.Select("SELECT id, name FROM node_types");

				foreach (DataRow dr in dt.Rows)
				{
					var nodeType = new NodeType()
					{
						ID = ConvertUtil.ToInt(dr["id"]),
						Name = ConvertUtil.ToString(dr["name"])
					};
					list.Add(nodeType);
				}
			}
			return list;
		}
	}
}
