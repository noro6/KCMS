using Manager.DB;
using Manager.Models;
using Manager.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
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

		private List<EnemyInfomation> poisAll = null;
		private List<EnemyInfomation> pois = null;

		private bool isLoading = false;

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
			dgvPatterns.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

			dgvPois.AutoGenerateColumns = false;
			typeof(DataGridView).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(dgvPois, true, null);
			dgvPois.RowTemplate.Height = 36;
			dgvPois.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

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
		private void CmbNode_SelectedValueChanged(object sender, EventArgs e)
		{
			if (!isLoading)
			{
				ChangeAddButtonEnabled();
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
				frm.IsNumberOnly = true;
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

			using (var db = new DBManager())
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
		/// 海域編集ボタンクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnEditWorld_Click(object sender, EventArgs e)
		{
			var world = new World(ConvertUtil.ToInt(cmbWorld.SelectedValue));

			using (var frm = new FrmTextInput())
			{
				frm.InfomationText = "変更後の海域名を入力\r\n(現在：" + world.Name + ")";
				frm.ShowDialog();
				if (frm.IsCanceled) return;
				world.Name = frm.InputText;
			}

			using (var db = new DBManager())
			{
				try
				{
					db.CreateConnection();
					db.BeginTran();

					world.Update(db);

					db.Commit();

					MessageBox.Show("海域編集完了", Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
		/// 海域削除ボタンクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnDeleteWorld_Click(object sender, EventArgs e)
		{
			var world = new World(ConvertUtil.ToInt(cmbWorld.SelectedValue));

			using (var frm = new FrmTextInput())
			{
				frm.InfomationText = "変更後の海域名を入力\r\n(現在：" + world.Name + ")";
				frm.ShowDialog();
				if (frm.IsCanceled) return;
				world.Name = frm.InputText;
			}

			using (var db = new DBManager())
			{
				try
				{
					db.CreateConnection();
					db.BeginTran();

					world.Update(db);

					db.Commit();

					MessageBox.Show("海域編集完了", Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					InitializeComboBoxDataSource();

					cmbWorld.SelectedValue = world.ID;
					cmbMap.SelectedValue = ConvertUtil.ToInt(cmbMap.SelectedValue);
					cmbNode.SelectedValue = ConvertUtil.ToInt(cmbNode.SelectedValue);

					ReSearch();
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
				frm.IsNumberOnly = true;
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
		/// マップ編集ボタンクリック時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnEditMap_Click(object sender, EventArgs e)
		{
			var worldId = ConvertUtil.ToInt(cmbWorld.SelectedValue);
			var mapNo = ConvertUtil.ToInt(cmbMap.SelectedValue);
			var map = new Map(worldId, mapNo);

			using (var frm = new FrmTextInput())
			{
				frm.InfomationText = "変更後のマップ名を入力\r\n(現在：" + map.Name + ")";
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

					map.Update(db);

					db.Commit();

					MessageBox.Show("マップ編集完了", Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

					InitializeComboBoxDataSource();

					cmbWorld.SelectedValue = worldId;
					cmbMap.SelectedValue = mapNo;
					cmbNode.SelectedValue = ConvertUtil.ToInt(cmbNode.SelectedValue);

					ReSearch();
				}
				catch (Exception)
				{
					db.RollBack();
					throw;
				}
			}
		}
		/// <summary>
		/// マップ削除ボタンクリック時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnDeleteMap_Click(object sender, EventArgs e)
		{
			var worldId = ConvertUtil.ToInt(cmbWorld.SelectedValue);
			var mapNo = ConvertUtil.ToInt(cmbMap.SelectedValue);
			if (worldId > 0 && mapNo > 0)
			{
				var nodes = Node.SelectAll(worldId, mapNo);
				var nodesString = "";
				foreach (var node in nodes) nodesString += node.Name + " ";

				var dr = MessageBox.Show("マップを削除します。\r\nこのマップに登録されているマス、敵艦隊情報も全て削除されます。\r\nよろしいですか？\r\n削除マス：" + nodesString, Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
				if (dr == DialogResult.Cancel) return;

				using (var db = new DBManager())
				{
					try
					{
						db.CreateConnection();
						db.BeginTran();

						DeleteMap(db, worldId, mapNo);

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
				frm.IsNumberOnly = true;
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
		/// セル編集クリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnEditNode_Click(object sender, EventArgs e)
		{
			var node = new Node(ConvertUtil.ToInt(cmbNode.SelectedValue));
			var prevName = node.Name;
			using (var frm = new FrmTextInput())
			{
				var exist = false;
				frm.InfomationText = "新しいマス名を入力\r\n(現在：" + node.Name + ")";
				do
				{
					frm.ShowDialog();
					if (frm.IsCanceled) return;

					node.Name = ConvertUtil.ToString(frm.InputText);
					exist = prevName != node.Name && !string.IsNullOrEmpty(new Node(node.WorldId, node.MapNo, node.Name).Name);
					if (string.IsNullOrEmpty(node.Name) || exist)
					{
						MessageBox.Show("登録できない値です。", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				} while (exist);

				frm.InfomationText = "半径を入力 (不明または不必要の場合、空欄か0でOKをクリック)\r\n(現在：" + node.Radius + ")";
				frm.InitializeText = node.Radius;
				frm.IsEmptyOK = true;
				frm.IsNumberOnly = true;
				frm.ShowDialog();
				if (frm.IsCanceled) return;
				node.Radius = ConvertUtil.ToInt(frm.InputText);

				frm.InfomationText = "クリック座標を入力 (不明または不必要の場合、空欄でOKをクリック)\r\n(現在：" + node.Coords + ")";
				frm.InitializeText = node.Coords;
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

					node.Update(db);

					db.Commit();

					MessageBox.Show("マス編集完了", Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

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
		private void BtnDeleteNode_Click(object sender, EventArgs e)
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

						DeleteNode(db, node.ID);

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
			var mapId = ConvertUtil.ToInt(ConvertUtil.ToString(cmbWorld.SelectedValue) + ConvertUtil.ToString(cmbMap.SelectedValue));
			var nodeId = ConvertUtil.ToInt(cmbNode.SelectedValue);
			var nodeName = ConvertUtil.ToString(cmbNode.Text);

			var displayLevels = new List<string>() { "-" };
			if (chkKo.Checked) displayLevels.Add("甲");
			if (chkOtsu.Checked) displayLevels.Add("乙");
			if (chkHei.Checked) displayLevels.Add("丙");
			if (chkTei.Checked) displayLevels.Add("丁");

			patterns = patternAll.FindAll(v =>
			{
				return v.MapId == mapId && v.NodeId == nodeId && displayLevels.Contains(v.LevelName);
			});

			pois = poisAll.FindAll(v =>
			{
				return v.MapId == mapId && v.NodeName == nodeName && displayLevels.Contains(v.LevelName);
			});

			// pois 手動入力で設定されている編成名と一致するデータはNodeRemarksを解決させる。
			foreach (var poi in pois)
			{
				var x = patterns.Find(v => v.LevelId == poi.LevelId && v.EnemyID == poi.EnemyID && v.NodeRemarks != "");
				if (x != null)
				{
					poi.NodeRemarks = x.NodeRemarks;
				}
			}

			dgvPatterns.SuspendLayout();
			dgvPatterns.DataSource = patterns;
			dgvPatterns.ResumeLayout();

			dgvPois.SuspendLayout();
			dgvPois.DataSource = pois;
			dgvPois.ResumeLayout();
		}

		/// <summary>
		/// DB再接続して検索
		/// </summary>
		private void ReSearch()
		{
			try
			{
				patternAll = EnemyInfomation.Select();
				poisAll = EnemyInfomation.SelectFromPoi();
				Search();
			}
			catch (Exception ex)
			{
				MessageBox.Show("検索に失敗しました。" + Environment.NewLine + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// コンボ初期化
		/// </summary>
		private void InitializeComboBoxDataSource()
		{
			isLoading = true;

			using (var db = new DBManager())
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

				dt = db.Select("SELECT id, name, world_id, map_no FROM maps ORDER BY map_no");
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

			poisAll = EnemyInfomation.SelectFromPoi();
			pois = EnemyInfomation.SelectFromPoi();

			cmbWorld.DataSource = worlds;
			cmbMap.DataSource = maps;
			cmbNode.DataSource = nodes;

			cmbWorld.DisplayMember = "Name";
			cmbWorld.ValueMember = "ID";
			cmbMap.DisplayMember = "Name";
			cmbMap.ValueMember = "MapNo";
			cmbNode.DisplayMember = "Name";
			cmbNode.ValueMember = "ID";

			isLoading = false;
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
			btnAddPattern.Enabled = (worldId > 0 && mapNo > 0 && nodeName != "") && tabDataBase.SelectedTab == tabManual;

			btnEditNode.Enabled = nodeName != "";
			btnDeleteNode.Enabled = nodeName != "";
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
			using (var frm = new FrmEnemyFleetEdit())
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
			if (dgvPatterns.CurrentCell == null || e.RowIndex < 0)
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
		/// 順序変更ボタンクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnUpdateSort_Click(object sender, EventArgs e)
		{
			var dr = MessageBox.Show("現在表示されている順番に更新します。\r\nよろしいですか？", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
			if (dr != DialogResult.OK) return;

			using (var db = new DBManager())
			{
				try
				{
					db.CreateConnection();
					db.BeginTran();

					for (int i = 0; i < patterns.Count; i++)
					{
						NodeDetail.UpdatePatternNo(db, patterns[i].DetailId, i + 1);
					}

					db.Commit();
				}
				catch (Exception ex)
				{
					db.RollBack();
					throw ex;
				}
			}

			ReSearch();
		}

		/// <summary>
		/// 上へ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnUp_Click(object sender, EventArgs e)
		{
			if (dgvPatterns.CurrentCell == null) return;
			var rowIndex = dgvPatterns.CurrentCell.RowIndex;
			if (rowIndex < 1) return;

			dgvPatterns.DataSource = null;

			var tmp = patterns[rowIndex];
			patterns[rowIndex] = patterns[rowIndex - 1];
			patterns[rowIndex - 1] = tmp;

			dgvPatterns.DataSource = patterns;
			dgvPatterns.CurrentCell = dgvPatterns[0, rowIndex - 1];
		}
		/// <summary>
		/// 下へ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnDown_Click(object sender, EventArgs e)
		{
			if (dgvPatterns.CurrentCell is null) return;
			var rowIndex = dgvPatterns.CurrentCell.RowIndex;
			if (rowIndex >= patterns.Count - 1) return;

			dgvPatterns.DataSource = null;

			var tmp = patterns[rowIndex];
			patterns[rowIndex] = patterns[rowIndex + 1];
			patterns[rowIndex + 1] = tmp;

			dgvPatterns.DataSource = patterns;
			dgvPatterns.CurrentCell = dgvPatterns[0, rowIndex + 1];
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

		/// <summary>
		/// 指定マップ削除
		/// </summary>
		/// <param name="db"></param>
		/// <param name="nodeId"></param>
		private void DeleteMap(DBManager db, int worldId, int mapNo)
		{
			// マップ本体削除
			Map.Delete(db, worldId, mapNo);

			// 関連ノード削除
			var deleteNodes = Node.DeleteNodes(db, worldId, mapNo);
			foreach (var node in deleteNodes)
			{
				DeleteNode(db, node.ID);
			}
		}

		/// <summary>
		/// 指定ノード削除
		/// </summary>
		/// <param name="nodeId">削除ノードid</param>
		private void DeleteNode(DBManager db, int nodeId)
		{
			// ノード本体削除
			Node.Delete(db, nodeId);

			// 関連詳細削除
			var deleteNodeDetails = NodeDetail.DeleteNodeDetails(db, nodeId);
			foreach (var detail in deleteNodeDetails)
			{
				NodeDetailsEnemies.Delete(db, detail.ID);
			}
		}

		/// <summary>
		/// 難易度フィルタチェンジ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ChkLevel_CheckedChanged(object sender, EventArgs e)
		{
			var chk = (CheckBox)sender;
			if (!chk.Checked)
			{
				isLoading = true;
				chkAll.Checked = false;
				isLoading = false;
			}
			Search();
		}

		/// <summary>
		/// 全チェック変更時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ChkAll_CheckedChanged(object sender, EventArgs e)
		{
			if (isLoading) return;
			chkKo.Checked = chkAll.Checked;
			chkOtsu.Checked = chkAll.Checked;
			chkHei.Checked = chkAll.Checked;
			chkTei.Checked = chkAll.Checked;
		}
		/// <summary>
		/// poi側セルダブルクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dgvPois_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			RegistFleetFromPoi();
		}

		/// <summary>
		/// 編成名登録
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnRegistName_Click(object sender, EventArgs e)
		{
			RegistFleetFromPoi();
		}

		/// <summary>
		/// POIベースに、同じ編成をDBに登録する
		/// </summary>
		private void RegistFleetFromPoi()
		{
			if (dgvPois.CurrentCell == null)
			{
				MessageBox.Show("対象を選択してください。", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			var rowIndex = dgvPois.CurrentCell.RowIndex;
			if (rowIndex < 0 || pois[rowIndex] == null)
			{
				MessageBox.Show("対象を選択してください。", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			var poi = pois[rowIndex];
			if (poi == null || poi.EnemyID == "")
			{
				MessageBox.Show("対象を選択してください。", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			// 取得できた敵id羅列と一致する編成がすでに登録されていないかどうかをチェック
			var nodeId = ConvertUtil.ToInt(cmbNode.SelectedValue);
			var data = patternAll.Find(v => v.MapId == poi.MapId && v.LevelId == poi.LevelId && v.NodeId == nodeId && v.EnemyID == poi.EnemyID);
			if (data != null)
			{
				MessageBox.Show("既に登録されている編成です。", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			using (var frm = new FrmTextInput())
			{
				frm.InfomationText = "編成名を入力してください。";
				frm.ShowDialog();
				if (frm.IsCanceled) return;

				var nodeDetail = new NodeDetail()
				{
					NodeId = nodeId,
					Name = frm.InputText,
					PatternNo = NodeDetail.GetNextPatternNo(nodeId) + 1,
					FormationId = poi.FormationId,
					LevelId = poi.LevelId,
					NodeTypeId = poi.TypeId,
				};

				using (var db = new DBManager())
				{
					try
					{
						db.CreateConnection();
						db.BeginTran();

						var nodeDetailId = nodeDetail.SelectMaxId(db) + 1;
						nodeDetail.ID = nodeDetailId;
						nodeDetail.Insert(db);

						var startId = new NodeDetailsEnemies().SelectMaxId(db) + 1;
						var detailsEnemies = new NodeDetailsEnemies
						{
							ID = startId,
							NodeDetailId = nodeDetailId,
							Enemies = poi.Enemies
						};
						detailsEnemies.Insert(db);

						db.Commit();
						MessageBox.Show("登録完了", Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
					catch (Exception ex)
					{
						db.RollBack();
						MessageBox.Show("登録失敗\r\n" + ex.Message + "\r\n" + ex.StackTrace, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}

			ReSearch();
		}

		private void btnDeletePoi_Click(object sender, EventArgs e)
		{
			if (dgvPois.CurrentCell == null)
			{
				MessageBox.Show("対象を選択してください。", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			var rowIndex = dgvPois.CurrentCell.RowIndex;
			if (rowIndex < 0 || pois[rowIndex] == null)
			{
				MessageBox.Show("対象を選択してください。", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			var poi = pois[rowIndex];
			if (poi == null || poi.EnemyID == "")
			{
				MessageBox.Show("対象を選択してください。", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			// 対象のデータ確認
			var data = $@"
難易度: {poi.LevelName}
編成: {poi.EnemyID}
陣形: {poi.FormationName}
総件数: {poi.Count:N0}
割合: {poi.Rate}%
このマスのデータ件数: {poi.Count / (poi.Rate / 100):N0}
";
			var dr = MessageBox.Show("選択されたデータをpoidbから削除します。よろしいですか？\r\n" + data, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if(dr != DialogResult.Yes)
			{
				return;
			}

			// コネクション作成
			using (var db = new DBManager())
			{
				try
				{
					db.CreateConnection();
					db.BeginTran();

					var deletedCount = Poi.DeletePoi(db, poi);

					db.Commit();
					MessageBox.Show(deletedCount + "件のデータをpoidbから削除しました。", "poidb更新完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch (Exception ex)
				{
					db.RollBack();
					MessageBox.Show("失敗しました。" + Environment.NewLine + ex.Message, "poidb更新失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

			ReSearch();
		}

		/// <summary>
		/// タブ切り替え時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			btnUpdateSort.Enabled = tabDataBase.SelectedTab == tabManual;
			btnCopyPattern.Enabled = tabDataBase.SelectedTab == tabManual;
			btnAddPattern.Enabled = tabDataBase.SelectedTab == tabManual;
			btnUp.Enabled = tabDataBase.SelectedTab == tabManual;
			btnDown.Enabled = tabDataBase.SelectedTab == tabManual;
			btnRegistName.Enabled = tabDataBase.SelectedTab == tabPoi;
			btnDeletePoi.Enabled = tabDataBase.SelectedTab == tabPoi;
		}

		private void dgvPatterns_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.ColumnIndex != 0 || e.RowIndex < 0 || e.RowIndex >= patterns.Count)
			{
				return;
			}

			var data = patterns[e.RowIndex];
			var style = dgvPatterns.Rows[e.RowIndex].DefaultCellStyle;
			// poi内に同じ編成データがあるかどうかチェック
			if (pois.FindIndex(v => v.LevelId == data.LevelId && v.EnemyID == data.EnemyID) > -1)
			{
				// 同じ編成データがある OK
				style.BackColor = Color.FromArgb(255, 255, 255);
				style.SelectionBackColor = Color.FromArgb(172, 172, 172);
			}
			else
			{
				// ここ独自のデータだよこれ
				style.BackColor = Color.FromArgb(255, 255, 220);
				style.SelectionBackColor = Color.FromArgb(255, 255, 128);
			}
			style.SelectionForeColor = Color.Black;
		}

		private void dgvPois_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.ColumnIndex != 0 || e.RowIndex < 0 || e.RowIndex >= pois.Count)
			{
				return;
			}

			var poi = pois[e.RowIndex];
			var style = dgvPois.Rows[e.RowIndex].DefaultCellStyle;

			// パターン内に同じ編成データがあるかどうかチェック
			if (patterns.FindIndex(v => v.LevelId == poi.LevelId && v.EnemyID == poi.EnemyID) > -1)
			{
				// 同じ編成データがあるが、全体の1%以下
				if (poi.Rate < 1.0)
				{
					// これいる？？ 赤
					style.BackColor = Color.FromArgb(255, 220, 220);
					style.SelectionBackColor = Color.FromArgb(255, 128, 128);
				}
				else
				{
					// ほぼ問題ないデータ　青
					style.BackColor = Color.FromArgb(220, 240, 255);
					style.SelectionBackColor = Color.FromArgb(128, 172, 255);
				}
			}
			else
			{
				// パターン内に存在しないが、そこそこある
				if (poi.Rate >= 10.0)
				{
					// これ取り込んでもいいかも　緑
					style.BackColor = Color.FromArgb(220, 255, 220);
					style.SelectionBackColor = Color.FromArgb(128, 255, 128);
				}
				else if (poi.Rate > 1.0 || poi.Count >= 1000)
				{
					// 取り込んでもいいか微妙　要チェック 黄
					style.BackColor = Color.FromArgb(255, 255, 220);
					style.SelectionBackColor = Color.FromArgb(255, 255, 128);
				}
				else
				{
					// 取り込む必要なし 灰色
					style.BackColor = Color.FromArgb(150, 150, 150);
					style.SelectionBackColor = Color.FromArgb(128, 128, 128);
				}
			}
			style.SelectionForeColor = Color.Black;
		}
	}
}
