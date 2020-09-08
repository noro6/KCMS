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
		public bool CopyMode { set; get; } = false;

		private int worldId = 0;

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

				var fleetData = NodeDetailsEnemies.Select(NodeDetailId);
				fleet = fleetData.Enemies;
				dgvFleet.DataSource = fleet;

				btnDelete.Visible = true;

				var sumAirPower = 0;
				var sumLandBaseAirPower = 0;
				foreach (var enm in fleet)
				{
					sumAirPower += enm.AirPower;
					sumLandBaseAirPower += enm.LandBaseAirPower;
				}
				lblSumAirPower.Text = sumAirPower.ToString();
				lblSumAirPower_LB.Text = "（ " + sumLandBaseAirPower + " ）";
			}
			// 新規パターン
			else
			{
				PatternNo = NodeDetail.GetNextPatternNo(NodeId) + 1;
				btnDelete.Visible = false;
			}

			// 複製新規モード
			if (CopyMode)
			{
				// NodeDetailId を破棄して新規登録モードにする
				NodeDetailId = 0;
				PatternNo = NodeDetail.GetNextPatternNo(NodeId) + 1;
				btnDelete.Visible = false;
			}

			// 基本情報
			var node = new Node(NodeId);
			lblNodeId.Text = node.WorldId + "-" + node.MapNo + " " + node.Name;
			worldId = node.WorldId;
			lblPatternNo.Text = PatternNo.ToString();
		}

		/// <summary>
		/// 艦種変更時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CmbEnemyType_SelectedIndexChanged(object sender, EventArgs e)
		{
			Search();
		}

		/// <summary>
		/// 挿入クリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnInsert_Click(object sender, EventArgs e)
		{
			if (dgvEnemies.CurrentCell is null) return;
			var rowIndex = dgvEnemies.CurrentCell.RowIndex;
			if (rowIndex == -1 || rowIndex >= enemies.Count) return;
			var enemy = enemies[rowIndex];

			dgvFleet.DataSource = null;
			fleet.Add(enemy);
			dgvFleet.DataSource = fleet;

			int sumAirPower = 0;
			int sumLandBaseAirPower = 0;
			foreach (var enm in fleet)
			{
				sumAirPower += enm.AirPower;
				sumLandBaseAirPower += enm.LandBaseAirPower;
			}
			lblSumAirPower.Text = sumAirPower.ToString();
			lblSumAirPower_LB.Text = "（ " + sumLandBaseAirPower + " ）";
		}

		/// <summary>
		/// 削除ボタン
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DgvFleet_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if(e.RowIndex > -1 && e.ColumnIndex == 0 && e.RowIndex < fleet.Count)
			{
				dgvFleet.DataSource = null;
				fleet.RemoveAt(e.RowIndex);
				dgvFleet.DataSource = fleet;

				int sumAirPower = 0;
				int sumLandBaseAirPower = 0;
				foreach (var enm in fleet)
				{
					sumAirPower += enm.AirPower;
					sumLandBaseAirPower += enm.LandBaseAirPower;
				}
				lblSumAirPower.Text = sumAirPower.ToString();
				lblSumAirPower_LB.Text = "（ " + sumLandBaseAirPower + " ）";
			}
		}

		/// <summary>
		/// 検索部変更
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TxtSearch_TextChanged(object sender, EventArgs e)
		{
			Search();
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

		private void BtnSave_Click(object sender, EventArgs e)
		{
			// 設定敵艦総数
			var enemyCount = fleet.Count;
			// 戦闘形式
			var nodeType = ConvertUtil.ToInt(cmbNodeType.SelectedValue);
			// 陣形
			var formation = ConvertUtil.ToInt(cmbFormation.SelectedValue);
			// 難易度
			var level = ConvertUtil.ToInt(cmbLevel.SelectedValue);


			// エラー
			if (enemyCount < 1)
			{
				MessageBox.Show("敵艦未選択", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (formation < 10 && nodeType == 2)
			{
				MessageBox.Show("連合艦隊ですが陣形が連合艦隊仕様ではありません。", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				ActiveControl = cmbFormation;
				cmbFormation.DroppedDown = true;
				return;
			}
			if (formation > 10 && nodeType != 2)
			{
				MessageBox.Show("通常艦隊ですが陣形が通常艦隊仕様ではありません。", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				ActiveControl = cmbFormation;
				cmbFormation.DroppedDown = true;
				return;
			}

			// 警告
			if (nodeType != 2 && enemyCount > 6)
			{
				var dr = MessageBox.Show("敵艦数が6隻を超えています。\r\nこのまま登録しますか？", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
				if (dr == DialogResult.Cancel) return;
			}
			if (nodeType == 2 && enemyCount != 12)
			{
				var dr = MessageBox.Show("連合艦隊ですが12隻ではありません。(" + enemyCount + "隻)\r\nこのまま登録しますか？", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
				if (dr == DialogResult.Cancel) return;
			}
			if ((nodeType == 3 || nodeType == 5) && formation != 3)
			{
				var dr = MessageBox.Show("空襲系ですが輪形陣ではありません。\r\nこのまま登録しますか？", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
				if (dr == DialogResult.Cancel)
				{
					ActiveControl = cmbFormation;
					cmbFormation.DroppedDown = true;
					return;
				}
			}
			if (worldId > 20 && level <= 0)
			{
				var dr = MessageBox.Show("イベント海域ですが難易度が選択されていません。\r\nこのまま登録しますか？", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
				if (dr == DialogResult.Cancel)
				{
					ActiveControl = cmbLevel;
					cmbLevel.DroppedDown = true;
					return;
				}
			}
			if (worldId < 20 && level > 0)
			{
				var dr = MessageBox.Show("通常海域ですが難易度が選択されています。\r\nこのまま登録しますか？", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
				if (dr == DialogResult.Cancel)
				{
					ActiveControl = cmbLevel;
					cmbLevel.DroppedDown = true;
					return;
				}

			}
			if (MessageBox.Show("セル情報を登録 / 更新します。\r\nよろしいですか？", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
			{
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
		/// 右側検索
		/// </summary>
		private void Search()
		{
			dgvEnemies.DataSource = null;

			// テキスト検索が最優先
			var text = txtSearch.Text.Trim();

			// テキストがなければカテゴリ検索
			var type = ConvertUtil.ToString(cmbEnemyType.SelectedValue);
			cmbEnemyType.Enabled = text == "";

			enemies = enemiesAll.FindAll(v =>
			{
				if (text != "")
				{
					if (v.Name.Contains(text)) return true;
					if (v.ID.ToString().Contains(text)) return true;
				}
				else if (v.TypeIds.Contains(" " + type + ","))
				{
					return true;
				}
				return false;
			});
			dgvEnemies.DataSource = enemies;
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

		/// <summary>
		/// 戦闘形式変更時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CmbNodeType_SelectedIndexChanged(object sender, EventArgs e)
		{
			// 空襲系なら輪形にする
			if(ConvertUtil.ToInt(cmbNodeType.SelectedValue) == 3 || ConvertUtil.ToInt(cmbNodeType.SelectedValue) == 5)
			{
				cmbFormation.SelectedValue = 3;
			}
		}

		/// <summary>
		/// セルダブルクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DgvEnemies_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0) return;
			if (enemies[e.RowIndex] == null) return;
			var enemyId = enemies[e.RowIndex].ID;
			if (enemyId == 0) return;
			
			using (var frm = new FrmEnemyEdit())
			{
				frm.EditEnemyID = enemyId;
				frm.ShowDialog();
			}

			enemiesAll = Enemy.Select();
			Search();
		}
	}
}
