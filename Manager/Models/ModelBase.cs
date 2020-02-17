using Manager.DB;
using Manager.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Models
{
	abstract class ModelBase
	{
		public int ID { set; get; }

		public string Name { set; get; }

		protected string TableName { set;  get; }


		/// <summary>
		/// 現在登録されているIDの最大値を取得
		/// </summary>
		/// <returns></returns>
		public int SelectMaxId()
		{
			using (var db = new DBManager())
			{
				return SelectMaxId(db);
			}
		}

		/// <summary>
		/// 現在登録されているIDの最大値を取得
		/// </summary>
		/// <param name="db">コネクション使いまわす場合</param>
		/// <returns></returns>
		public int SelectMaxId(DBManager db)
		{
			var dt = db.Select("SELECT MAX(id) FROM " + TableName);
			if (dt.Rows.Count > 0) return ConvertUtil.ToInt(dt.Rows[0][0]);
			else return 0;
		}
	}
}
