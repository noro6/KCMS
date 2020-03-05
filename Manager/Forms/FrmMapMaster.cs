using Manager.DB;
using Manager.Models;
using Manager.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Windows.Forms;

namespace Manager.Forms
{
	public partial class FrmMapMaster : Form
	{
		private List<World> worlds = null;
		private List<Map> maps = null;
		private List<Node> nodes = null;

		private List<World> worldAll = null;
		private List<Map> mapAll = null;
		private List<Node> nodeAll = null;

		private List<EnemyInfomation> patternAll = null;
		private List<EnemyInfomation> patterns = null;

		public FrmMapMaster()
		{
			InitializeComponent();
		}

		/// <summary>
		/// ロード時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FrmMapMaster_Load(object sender, EventArgs e)
		{

			dgvPatterns.AutoGenerateColumns = false;
			typeof(DataGridView).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(dgvPatterns, true, null);
			dgvPatterns.RowTemplate.Height = 36;

			// 海域データ取得
			InitializeComboBoxDataSource();
			CmbWorld_SelectedIndexChanged(null, null);
			ChangeAddButtonEnabled();
			Search();
		}

		/// <summary>
		/// 海域選択値変更
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CmbWorld_SelectedIndexChanged(object sender, EventArgs e)
		{
			var worldId = ConvertUtil.ToInt(cmbWorld.SelectedValue);
			maps = mapAll.FindAll(v => v.WorldId == worldId);
			cmbNode.Enabled = false;
			cmbMap.DataSource = maps;

			ChangeAddButtonEnabled();
		}

		/// <summary>
		/// マップ選択値変更
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CmbMap_SelectedIndexChanged(object sender, EventArgs e)
		{
			var worldId = ConvertUtil.ToInt(cmbWorld.SelectedValue);
			var mapNo = ConvertUtil.ToInt(cmbMap.SelectedValue);
			nodes = nodeAll.FindAll(v => v.WorldId == worldId && v.MapNo == mapNo);
			cmbNode.DataSource = nodes;
			cmbNode.Enabled = true;

			ChangeAddButtonEnabled();
		}

		/// <summary>
		/// セル選択値変更
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CmbNode_SelectedIndexChanged(object sender, EventArgs e)
		{
			ChangeAddButtonEnabled();

			if(ConvertUtil.ToString(cmbNode.Text) != "")
			{
				Search();
			}
		}

		/// <summary>
		/// 海域追加クリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnAddWorld_Click(object sender, EventArgs e)
		{
			var world = new World();
			using (var frm = new FrmTextInput())
			{
				var exist = false;
				frm.InfomationText = "海域番号を入力";
				do
				{
					frm.ShowDialog();
					if (frm.IsCanceled) return;

					world.ID = ConvertUtil.ToInt(frm.InputText);
					exist = !string.IsNullOrEmpty(new World(world.ID).Name);
					if (world.ID == 0 || exist)
						MessageBox.Show("登録できない値です", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

				} while (exist);

				frm.InfomationText = "海域名を入力";
				frm.ShowDialog();
				if (frm.IsCanceled) return;
				world.Name = frm.InputText;
			}

			using(var db = new DBManager())
			{
				try
				{
					db.CreateConnection();
					db.BeginTran();

					world.Insert(db);

					db.Commit();

					MessageBox.Show("海域登録完了", Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					InitializeComboBoxDataSource();
				}
				catch (Exception)
				{
					db.RollBack();
					throw;
				}
			}
		}

		/// <summary>
		/// マップ追加クリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnAddMap_Click(object sender, EventArgs e)
		{
			var map = new Map
			{
				WorldId = ConvertUtil.ToInt(cmbWorld.SelectedValue)
			};
			using (var frm = new FrmTextInput())
			{
				var exist = false;
				frm.InfomationText = "第何海域か入力\n(" + cmbWorld.Text + "の何枚目のマップ？)";
				do
				{
					frm.ShowDialog();
					if (frm.IsCanceled) return;

					map.MapNo = ConvertUtil.ToInt(frm.InputText);
					exist = !string.IsNullOrEmpty(new Map(map.WorldId, map.MapNo).Name);
					if (map.MapNo == 0 || exist)
						MessageBox.Show("登録できない値です", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

				} while (exist);

				frm.InfomationText = "マップ名を入力";
				frm.ShowDialog();
				if (frm.IsCanceled) return;
				map.Name = frm.InputText;
			}

			using (var db = new DBManager())
			{
				try
				{
					db.CreateConnection();
					db.BeginTran();

					map.Insert(db);

					db.Commit();

					MessageBox.Show("マップ登録完了", Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					InitializeComboBoxDataSource();
				}
				catch (Exception)
				{
					db.RollBack();
					throw;
				}
			}
		}

		/// <summary>
		/// マス追加クリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnAddNode_Click(object sender, EventArgs e)
		{
			var node = new Node
			{
				WorldId = ConvertUtil.ToInt(cmbWorld.SelectedValue),
				MapNo = ConvertUtil.ToInt(cmbMap.SelectedValue)
			};
			using (var frm = new FrmTextInput())
			{
				var exist = false;
				frm.InfomationText = "マス名を入力\n(追加対象海域：" + node.WorldId + " - " + node.MapNo + ")";
				do
				{
					frm.ShowDialog();
					if (frm.IsCanceled) return;

					node.Name = ConvertUtil.ToString(frm.InputText);
					exist = !string.IsNullOrEmpty(new Node(node.WorldId, node.MapNo, node.Name).Name);
					if (string.IsNullOrEmpty(node.Name) || exist)
						MessageBox.Show("登録できない値です", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				} while (exist);

				frm.InfomationText = "半径を入力 (不明または不必要の場合、0かそのままOKをクリック)";
				frm.IsEmptyOK = true;
				frm.ShowDialog();
				if (frm.IsCanceled) return;
				node.Radius = ConvertUtil.ToInt(frm.InputText);

				frm.InfomationText = "クリック座標を入力 (不明または不必要の場合、空欄かそのままOKをクリック)";
				frm.IsEmptyOK = true;
				frm.ShowDialog();
				if (frm.IsCanceled) return;
				node.Coords = frm.InputText;
			}

			using (var db = new DBManager())
			{
				try
				{
					db.CreateConnection();
					db.BeginTran();

					node.Insert(db);

					db.Commit();

					MessageBox.Show("マス登録完了", Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

					var world = ConvertUtil.ToInt(cmbWorld.SelectedValue);
					var map = ConvertUtil.ToInt(cmbMap.SelectedValue);
					var nodeId = ConvertUtil.ToInt(node.ID);
					InitializeComboBoxDataSource();

					cmbWorld.SelectedValue = world;
					cmbMap.SelectedValue = map;
					cmbNode.SelectedValue = nodeId;

					Search();
				}
				catch (Exception)
				{
					db.RollBack();
					throw;
				}
			}
		}

		/// <summary>
		/// セル削除ボタンクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDeleteNode_Click(object sender, EventArgs e)
		{
			var node = new Node(ConvertUtil.ToInt(cmbNode.SelectedValue));

			if (node.ID > 0)
			{
				var dr = MessageBox.Show("セルを削除します。このセルに登録されている敵編成パターンも全て削除されます。\r\nよろしいですか?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
				if (dr == DialogResult.Cancel) return;

				using (var db = new DBManager())
				{
					try
					{
						db.CreateConnection();
						db.BeginTran();

						Node.Delete(db, node.ID);
						var deleteRecords = NodeDetail.DeleteNode(db, node.ID);
						foreach (var detail in deleteRecords)
						{
							NodeDetailsEnemies.Delete(db, detail.ID);
						}

						db.Commit();
						MessageBox.Show("削除が完了しました。", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					catch (Exception)
					{
						db.RollBack();
						throw;
					}
				}

				InitializeComboBoxDataSource();
				ReSearch();
			}
		}

		/// <summary>
		/// 検索
		/// </summary>
		private void Search()
		{
			var worldId = ConvertUtil.ToInt(cmbWorld.SelectedValue);
			var mapNo = ConvertUtil.ToInt(cmbMap.SelectedValue);
			var nodeId = ConvertUtil.ToInt(cmbNode.SelectedValue);

			patterns = patternAll.FindAll(v => v.WorldId == worldId && v.MapNo == mapNo && v.NodeId == nodeId);

			dgvPatterns.SuspendLayout();
			dgvPatterns.DataSource = patterns;
			dgvPatterns.ResumeLayout();
		}

		/// <summary>
		/// DB再接続して検索
		/// </summary>
		private void ReSearch()
		{
			patternAll = EnemyInfomation.Select();
			Search();
		}

		/// <summary>
		/// コンボ初期化
		/// </summary>
		private void InitializeComboBoxDataSource()
		{
			using(var db = new DBManager())
			{
				var dt = db.Select("SELECT id, name FROM worlds WHERE status = 1 ORDER BY sort");
				worldAll = new List<World>();
				foreach (DataRow row in dt.Rows)
				{
					var world = new World()
					{
						ID = ConvertUtil.ToInt(row["id"]),
						Name = ConvertUtil.ToString(row["name"])
					};
					worldAll.Add(world);
				}

				dt = db.Select("SELECT id, name, world_id, map_no FROM maps");
				mapAll = new List<Map>() { new Map() { ID = 0, Name = "", MapNo = 0, WorldId = 0 } };
				foreach (DataRow row in dt.Rows)
				{
					var map = new Map()
					{
						ID = ConvertUtil.ToInt(row["id"]),
						Name = ConvertUtil.ToString(row["name"]),
						WorldId = ConvertUtil.ToInt(row["world_id"]),
						MapNo = ConvertUtil.ToInt(row["map_no"])
					};
					mapAll.Add(map);
				}

				dt = db.Select("SELECT id, name, world_id, map_no FROM nodes ORDER BY name");
				nodeAll = new List<Node>() { new Node() { ID = 0, Name = "", MapNo = 0, WorldId = 0 } };
				foreach (DataRow row in dt.Rows)
				{
					var node = new Node()
					{
						ID = ConvertUtil.ToInt(row["id"]),
						Name = ConvertUtil.ToString(row["name"]),
						WorldId = ConvertUtil.ToInt(row["world_id"]),
						MapNo = ConvertUtil.ToInt(row["map_no"])
					};
					nodeAll.Add(node);
				}
			}

			worlds = worldAll.FindAll(v => true);
			maps = mapAll.FindAll(v => v.WorldId == 0);
			nodes = nodeAll.FindAll(v => v.WorldId == 0 && v.MapNo == 0);

			patternAll = EnemyInfomation.Select();
			patterns = EnemyInfomation.Select();

			cmbWorld.DataSource = worlds;
			cmbMap.DataSource = maps;
			cmbNode.DataSource = nodes;

			cmbWorld.DisplayMember = "Name";
			cmbWorld.ValueMember = "ID";
			cmbMap.DisplayMember = "Name";
			cmbMap.ValueMember = "MapNo";
			cmbNode.DisplayMember = "Name";
			cmbNode.ValueMember = "ID";
		}

		/// <summary>
		/// ボタン活性化状態制御
		/// </summary>
		private void ChangeAddButtonEnabled()
		{
			var worldId = ConvertUtil.ToInt(cmbWorld.SelectedValue);
			var mapNo = ConvertUtil.ToInt(cmbMap.SelectedValue);
			var nodeName = ConvertUtil.ToString(cmbNode.Enabled ? cmbNode.Text : "");

			btnAddMap.Enabled = worldId > 0;
			btnAddNode.Enabled = worldId > 0 && mapNo > 0;
			btnAddPattern.Enabled = worldId > 0 && mapNo > 0 && nodeName != "";
		}

		/// <summary>
		/// 新パターン追加ボタン
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnAddPattern_Click(object sender, EventArgs e)
		{
			var nodeId = ConvertUtil.ToInt(cmbNode.SelectedValue);
			if (nodeId < 1) return;
			using(var frm = new FrmEnemyFleetEdit())
			{
				frm.NodeId = nodeId;
				frm.ShowDialog();
			}

			ReSearch();
		}

		/// <summary>
		/// 複製して新規ボタン
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnCopyPattern_Click(object sender, EventArgs e)
		{
			if (dgvPatterns.CurrentCell == null)
			{
				MessageBox.Show("複製対象を選択してください。", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			var rowIndex = dgvPatterns.CurrentCell.RowIndex;
			if (rowIndex < 0 || patterns[rowIndex] == null)
			{
				MessageBox.Show("複製対象を選択してください。", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			var detailId = patterns[rowIndex].DetailId;
			if (detailId < 1)
			{
				MessageBox.Show("複製対象を選択してください。", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			using (var frm = new FrmEnemyFleetEdit())
			{
				frm.NodeDetailId = detailId;
				frm.CopyMode = true;
				frm.ShowDialog();
			}

			ReSearch();
		}

		/// <summary>
		/// セルダブルクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DgvPatterns_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (dgvPatterns.CurrentCell == null)
			{
				return;
			}

			var rowIndex = dgvPatterns.CurrentCell.RowIndex;
			if (rowIndex < 0 || patterns[rowIndex] == null)
			{
				return;
			}

			var detailId = patterns[rowIndex].DetailId;
			if (detailId < 1)
			{
				return;
			}

			using (var frm = new FrmEnemyFleetEdit())
			{
				frm.NodeDetailId = detailId;
				frm.ShowDialog();
			}

			ReSearch();
		}

		/// <summary>
		/// 閉じる
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
