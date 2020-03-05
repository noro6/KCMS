using Manager.DB;
using Manager.Util;
using System;
using System.Collections.Generic;
using System.Data;

namespace Manager.Models
{
	class NodeDetail : ModelBase
	{
		public int NodeId { set; get; }
		public int PatternNo { set; get; }
		public int LevelId { set; get; }
		public int FormationId { set; get; }
		public int NodeTypeId { set; get; }

		public NodeDetail(){ TableName = "node_details"; }

		public NodeDetail(int detailId)
		{
			TableName = "node_details";
			var detail = Select(detailId);
			ID = detail.ID;
			NodeId = detail.NodeId;
			Name = detail.Name;
			PatternNo = detail.PatternNo;
			LevelId = detail.LevelId;
			NodeTypeId = detail.NodeTypeId;
			FormationId = detail.FormationId;
		}

		public static List<NodeDetail> Select()
		{
			var list = new List<NodeDetail>();
			using (var db = new DBManager())
			{
				var dt = db.Select("SELECT id, name FROM node_types");

				foreach (DataRow dr in dt.Rows)
				{
					var nodeDetail = new NodeDetail()
					{
						ID = ConvertUtil.ToInt(dr["id"]),
						NodeId = ConvertUtil.ToInt(dr["node_id"]),
						Name = ConvertUtil.ToString(dr["name"]),
						PatternNo = ConvertUtil.ToInt(dr["pattern_no"]),
						LevelId = ConvertUtil.ToInt(dr["level_no"]),
						NodeTypeId = ConvertUtil.ToInt(dr["node_type_id"]),
						FormationId = ConvertUtil.ToInt(dr["formation_id"]),
					};
					list.Add(nodeDetail);
				}
			}
			return list;
		}

		/// <summary>
		/// 一件のみ返す
		/// </summary>
		/// <param name="detailId"></param>
		/// <returns></returns>
		public static NodeDetail Select(int detailId)
		{
			using (var db = new DBManager())
			{
				var dt = db.Select("SELECT * FROM node_details WHERE id = " + detailId);

				var nodeDetail = new NodeDetail()
				{
					ID = ConvertUtil.ToInt(dt.Rows[0]["id"]),
					NodeId = ConvertUtil.ToInt(dt.Rows[0]["node_id"]),
					Name = ConvertUtil.ToString(dt.Rows[0]["name"]),
					PatternNo = ConvertUtil.ToInt(dt.Rows[0]["pattern_no"]),
					LevelId = ConvertUtil.ToInt(dt.Rows[0]["level_id"]),
					NodeTypeId = ConvertUtil.ToInt(dt.Rows[0]["node_type_id"]),
					FormationId = ConvertUtil.ToInt(dt.Rows[0]["formation_id"]),
				};
				return nodeDetail;
			}
		}

		/// <summary>
		/// 複数件返す
		/// </summary>
		/// <param name="detailId"></param>
		/// <returns></returns>
		public static List<NodeDetail> SelectAll(DBManager db, int nodeId)
		{
			var dt = db.Select("SELECT * FROM node_details WHERE node_id = " + nodeId);

			var details = new List<NodeDetail>();
			foreach (DataRow dr in dt.Rows)
			{
				var nodeDetail = new NodeDetail()
				{
					ID = ConvertUtil.ToInt(dr["id"]),
					NodeId = ConvertUtil.ToInt(dr["node_id"]),
					Name = ConvertUtil.ToString(dr["name"]),
					PatternNo = ConvertUtil.ToInt(dr["pattern_no"]),
					LevelId = ConvertUtil.ToInt(dr["level_id"]),
					NodeTypeId = ConvertUtil.ToInt(dr["node_type_id"]),
					FormationId = ConvertUtil.ToInt(dr["formation_id"]),
				};
				details.Add(nodeDetail);
			}
			return details;
		}

		/// <summary>
		/// 指定したセルのパターン数の最大値を返却
		/// </summary>
		/// <param name="nodeId">nodes.id</param>
		/// <returns></returns>
		internal static int GetNextPatternNo(int nodeId)
		{
			using (var db = new DBManager())
			{
				var dt = db.Select("SELECT MAX(pattern_no) FROM node_details WHERE node_id = " + nodeId);
				if (dt.Rows.Count == 0) return 0;
				return ConvertUtil.ToInt(dt.Rows[0][0]);
			}
		}

		/// <summary>
		/// 登録
		/// </summary>
		/// <param name="db"></param>
		public void Insert(DBManager db)
		{
			var sql = $@"
INSERT 
INTO node_details ( 
  id
  , node_id
  , pattern_no
  , name
  , level_id
  , node_type_id
  , formation_id
) 
VALUES( 
  {ID}
  , {NodeId}
  , {PatternNo}
  , @name
  , {LevelId}
  , {NodeTypeId}
  , {FormationId}
)
";
			var param = new Dictionary<string, object>()
			{
				{ "@name", Name }
			};
			db.ExecuteNonQuery(sql, param);
		}

		/// <summary>
		/// 一意キーで削除処理
		/// </summary>
		/// <param name="db"></param>
		/// <param name="nodeDetailId">主キー</param>
		public static void Delete(DBManager db, int nodeDetailId)
		{
			var sql = $@"DELETE FROM node_details WHERE id = " + nodeDetailId ;
			db.ExecuteNonQuery(sql);
		}

		/// <summary>
		/// 削除処理 セルID指定で削除するので複数削除される可能性がある
		/// </summary>
		/// <param name="db"></param>
		/// <param name="deleteNodeId">紐づいているセルID</param>
		/// <returns>削除された node_details レコードインスタンス</returns>
		public static List<NodeDetail> DeleteNode(DBManager db, int deleteNodeId)
		{
			var list = SelectAll(db, deleteNodeId);
			var sql = "DELETE FROM node_details WHERE node_id = " + deleteNodeId;
			db.ExecuteNonQuery(sql);

			return list;
		}
	}
}
