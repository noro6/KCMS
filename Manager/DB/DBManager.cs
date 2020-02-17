using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manager.DB
{
	/// <summary>
	/// データベース接続クラス
	/// </summary>
	public class DBManager : IDisposable
	{
		private SQLiteConnection sqlConnection;
		private SQLiteTransaction sqlTransaction;

		/// <summary>
		/// コネクション生成
		/// </summary>
		public void CreateConnection()
		{
			sqlConnection = new SQLiteConnection("Data Source=kc.db");
			sqlConnection.Open();
		}

		/// <summary>
		/// DB切断
		/// </summary>
		public void Dispose()
		{
			sqlConnection.Close();
			sqlConnection.Dispose();
		}

		/// <summary>
		/// トランザクション開始
		/// </summary>
		public void BeginTran()
		{
			this.sqlTransaction = this.sqlConnection.BeginTransaction();
		}

		/// <summary>
		/// トランザクション　コミット
		/// </summary>
		public void Commit()
		{
			if (this.sqlTransaction.Connection != null)
			{
				this.sqlTransaction.Commit();
				this.sqlTransaction.Dispose();
			}
		}

		/// <summary>
		/// トランザクション　ロールバック
		/// </summary>
		public void RollBack()
		{
			if (this.sqlTransaction.Connection != null)
			{
				this.sqlTransaction.Rollback();
				this.sqlTransaction.Dispose();
			}
		}

		/// <summary>
		/// 指定したSQL文の結果を<see cref="DataTable"/>形式で返却
		/// </summary>
		/// <param name="query">sql文</param>
		/// <returns></returns>
		public DataTable Select(string query)
		{
			return Select(query, new Dictionary<string, object>());
		}

		/// <summary>
		/// 指定したSQL文の結果を<see cref="DataTable"/>形式で返却
		/// </summary>
		/// <param name="query">sql文</param>
		/// <param name="paramDict">SQLパラメータ(key, value)形式</param>
		/// <returns></returns>
		public DataTable Select(string query, Dictionary<string, object> paramDict)
		{
			try
			{
				var dt = new DataTable();
				if (this.sqlConnection == null) CreateConnection();
				dt.Load(ExecuteQuery(query, paramDict));
				return dt;
			}
			catch (Exception e)
			{
				MessageBox.Show(query + "\r\n" + e.Message, "SQLite 実行エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				throw e;
			}
		}

		/// <summary>
		/// クエリー実行(OUTPUT項目なし)
		/// <para name="query">SQL文</para>
		/// <para name="paramDict">SQLパラメータ</para>
		/// </summary>
		public void ExecuteNonQuery(string query)
		{
			ExecuteNonQuery(query, new Dictionary<string, object>());
		}

		/// <summary>
		/// SQL実行(outputあり)
		/// </summary>
		/// <param name="query">sql文</param>
		/// <param name="paramDict">SQLパラメータ(key, value)形式</param>
		/// <returns>SqlDataReader 形式</returns>
		public SQLiteDataReader ExecuteQuery(string query, Dictionary<string, object> paramDict)
		{
			var sqlCom = new SQLiteCommand
			{
				//クエリー送信先、トランザクションの指定
				Connection = this.sqlConnection,
				Transaction = this.sqlTransaction,

				CommandText = query
			};
			foreach (KeyValuePair<string, object> item in paramDict)
			{
				sqlCom.Parameters.Add(new SQLiteParameter(item.Key, item.Value));
			}
			SQLiteDataReader reader = sqlCom.ExecuteReader();
			return reader;
		}

		/// <summary>
		/// クエリー実行(OUTPUT項目なし)
		/// <para name="query">SQL文</para>
		/// <param name="paramDict">SQLパラメータ(key, value)形式</param>
		/// </summary>
		public void ExecuteNonQuery(string query, Dictionary<string, object> paramDict)
		{
			SQLiteCommand sqlCom = new SQLiteCommand
			{
				Connection = this.sqlConnection,
				Transaction = this.sqlTransaction,
				CommandText = query
			};
			foreach (KeyValuePair<string, object> item in paramDict)
			{
				sqlCom.Parameters.Add(new SQLiteParameter(item.Key, item.Value));
			}

			// SQLを実行
			sqlCom.ExecuteNonQuery();
		}
	}
}
