using Manager.DB;
using Manager.Models;
using Manager.Util;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace Manager.Forms
{
	public partial class FrmEnemyFleetEdit : Form
	{
		public int NodeId { set; get; }
		public int PatternNo { set; get; }
		public int NodeDetailId { set; get; }

		private List<Enemy> enemiesAll = null;
		private List<Enemy> enemies = null;

		private List<Enemy> fleet = new List<Enemy>();

		public FrmEnemyFleetEdit()
		{
			InitializeComponent();
		}

		private void FrmEnemyFleetEdit_Load(object sender, EventArgs e)
		{
			// コントロール初期化
			InitializeControl();

			// パターン編集モード
			if(NodeDetailId > 0)
			{
				var detailData = NodeDetail.Select(NodeDetailId);
				cmbNodeType.SelectedValue = detailData.NodeTypeId;
				cmbFormation.SelectedValue = detailData.FormationId;
				cmbLevel.SelectedValue = detailData.LevelId;
				txtRemarks.Text = detailData.Name;
				NodeId = detailData.NodeId;
				PatternNo = detailData.PatternNo;
				var node = new Node(NodeId);
				lblNodeId.Text = node.WorldId + "-" + node.MapNo + " " + node.Name;
				lblPatternNo.Text = PatternNo.ToString();

				var fleetData = NodeDetailsEnemies.Select(NodeDetailId);
				fleet = fleetData.Enemies;
				dgvFleet.DataSource = fleet;

				btnDelete.Visible = true;
			}
			// 新規パターン
			else
			{
				var node = new Node(NodeId);
				lblNodeId.Text = node.WorldId + "-" + node.MapNo + " " + node.Name;
				PatternNo = NodeDetail.GetNextPatternNo(NodeId) + 1;
				lblPatternNo.Text = PatternNo.ToString();

				btnDelete.Visible = false;
			}
		}

		/// <summary>
		/// 艦種変更時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CmbEnemyType_SelectedIndexChanged(object sender, EventArgs e)
		{
			var selectedType = ConvertUtil.ToString(cmbEnemyType.SelectedValue);
			dgvEnemies.DataSource = null;
			enemies = enemiesAll.FindAll(v => v.TypeIds.Contains(selectedType));
			dgvEnemies.DataSource = enemies;
		}

		private void BtnInsert_Click(object sender, EventArgs e)
		{
			if (dgvEnemies.CurrentCell is null) return;
			var rowIndex = dgvEnemies.CurrentCell.RowIndex;
			if (rowIndex == -1 || rowIndex >= enemies.Count) return;
			var enemy = enemies[rowIndex];

			dgvFleet.DataSource = null;
			fleet.Add(enemy);
			dgvFleet.DataSource = fleet;
		}

		private void DgvFleet_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if(e.RowIndex > -1 && e.ColumnIndex == 0 && e.RowIndex < fleet.Count)
			{
				dgvFleet.DataSource = null;
				fleet.RemoveAt(e.RowIndex);
				dgvFleet.DataSource = fleet;
			}
		}

		/// <summary>
		/// 検索部変更
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TxtSearch_TextChanged(object sender, EventArgs e)
		{
			var text = txtSearch.Text.Trim();

			dgvEnemies.DataSource = null;
			enemies = enemiesAll.FindAll(v =>
			{
				if (v.Name.Contains(text)) return true;
				if (v.ID.ToString().Contains(text)) return true;
				return false;
			});
			dgvEnemies.DataSource = enemies;
		}

		private void BtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void BtnSave_Click(object sender, EventArgs e)
		{
			if (fleet.Count < 1)
			{
				MessageBox.Show("敵艦未選択", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (ConvertUtil.ToInt(cmbNodeType.SelectedValue) == 0)
			{
				MessageBox.Show("戦闘形式未選択", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (ConvertUtil.ToInt(cmbFormation.SelectedValue) == 0)
			{
				MessageBox.Show("陣形未選択", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (ConvertUtil.ToInt(cmbNodeType.SelectedValue) == 0)
			{
				MessageBox.Show("難易度未選択", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			var nodeDetail = new NodeDetail()
			{
				NodeId = NodeId,
				Name = txtRemarks.Text.Trim(),
				PatternNo = PatternNo,
				FormationId = ConvertUtil.ToInt(cmbFormation.SelectedValue),
				LevelId = ConvertUtil.ToInt(cmbLevel.SelectedValue),
				NodeTypeId = ConvertUtil.ToInt(cmbNodeType.SelectedValue),
			};

			var info = "セル情報を登録 / 更新します。";

			if (MessageBox.Show(info, Text, MessageBoxButtons.OKCancel) != DialogResult.OK)
			{
				return;
			}

			using (var db = new DBManager())
			{
				try
				{
					db.CreateConnection();
					db.BeginTran();

					// 新規登録
					if (NodeDetailId <= 0)
					{
						var nodeDetailId = nodeDetail.SelectMaxId(db) + 1;
						nodeDetail.ID = nodeDetailId;
						nodeDetail.Insert(db);

						var startId = new NodeDetailsEnemies().SelectMaxId(db) + 1;
						var detailsEnemies = new NodeDetailsEnemies
						{
							ID = startId,
							NodeDetailId = nodeDetailId,
							Enemies = fleet
						};

						detailsEnemies.Insert(db);
					}
					// 更新処理 デリイン実装
					else
					{
						nodeDetail.ID = NodeDetailId;
						NodeDetail.Delete(db, NodeDetailId);
						nodeDetail.Insert(db);

						var startId = new NodeDetailsEnemies().SelectMaxId(db) + 1;
						var detailsEnemies = new NodeDetailsEnemies
						{
							ID = startId,
							NodeDetailId = NodeDetailId,
							Enemies = fleet
						};
						NodeDetailsEnemies.Delete(db, NodeDetailId);
						detailsEnemies.Insert(db);
					}

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

		/// <summary>
		/// コントロール初期化
		/// </summary>
		private void InitializeControl()
		{
			dgvEnemies.AutoGenerateColumns = false;
			typeof(DataGridView).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(dgvEnemies, true, null);

			dgvFleet.AutoGenerateColumns = false;
			typeof(DataGridView).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(dgvFleet, true, null);

			enemiesAll = Enemy.Select();
			enemies = Enemy.Select();
			dgvEnemies.DataSource = enemies;

			cmbEnemyType.DataSource = EnemyType.Select();
			cmbEnemyType.DisplayMember = "name";
			cmbEnemyType.ValueMember = "id";

			cmbNodeType.DataSource = NodeType.Select();
			cmbNodeType.DisplayMember = "name";
			cmbNodeType.ValueMember = "id";

			cmbFormation.DataSource = Formation.Select();
			cmbFormation.DisplayMember = "name";
			cmbFormation.ValueMember = "id";

			cmbLevel.DataSource = Level.Select();
			cmbLevel.DisplayMember = "name";
			cmbLevel.ValueMember = "id";

			CmbEnemyType_SelectedIndexChanged(null, null);

			lblNodeId.Text = "更新対象セルID：" + NodeId;
			lblPatternNo.Text = "";
		}

		/// <summary>
		/// 上へボタン
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnUp_Click(object sender, EventArgs e)
		{
			if (dgvFleet.CurrentCell is null) return;
			var rowIndex = dgvFleet.CurrentCell.RowIndex;
			if (rowIndex < 1) return;

			dgvFleet.DataSource = null;

			var tmp = fleet[rowIndex];
			fleet[rowIndex] = fleet[rowIndex - 1];
			fleet[rowIndex - 1] = tmp;

			dgvFleet.DataSource = fleet;

			dgvFleet.CurrentCell = dgvFleet[0, rowIndex - 1];
		}

		/// <summary>
		/// 下へボタン
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnDown_Click(object sender, EventArgs e)
		{
			if (dgvFleet.CurrentCell is null) return;
			var rowIndex = dgvFleet.CurrentCell.RowIndex;
			if (rowIndex >= fleet.Count - 1) return;

			dgvFleet.DataSource = null;

			var tmp = fleet[rowIndex];
			fleet[rowIndex] = fleet[rowIndex + 1];
			fleet[rowIndex + 1] = tmp;

			dgvFleet.DataSource = fleet;

			dgvFleet.CurrentCell = dgvFleet[0, rowIndex + 1];
		}

		/// <summary>
		/// 削除ボタン
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnDelete_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("本当に？", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
			{
				return;
			}

			using (var db = new DBManager())
			{
				try
				{
					db.CreateConnection();
					db.BeginTran();

					NodeDetail.Delete(db, NodeDetailId);
					NodeDetailsEnemies.Delete(db, NodeDetailId);

					db.Commit();
					MessageBox.Show("削除完了", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch (Exception ex)
				{
					db.RollBack();
					MessageBox.Show("削除失敗\r\n" + ex.Message + "\r\n" + ex.StackTrace, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

			Close();
		}
	}
}
