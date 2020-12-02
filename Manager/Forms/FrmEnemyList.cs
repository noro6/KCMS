using Manager.Models;
using Manager.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Manager.Forms
{
	public partial class FrmEnemyList : Form
	{
		private List<Enemy> enemiesAll = null;
		private List<Enemy> enemies = null;

		public bool isLoaded = false;

		public FrmEnemyList()
		{
			InitializeComponent();
		}

		private void FrmEnemyList_Load(object sender, EventArgs e)
		{
			// コントロール初期化
			InitializeControl();
			isLoaded = true;
		}

		private void BtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		/// <summary>
		/// コントロール初期化
		/// </summary>
		private void InitializeControl()
		{
			dgvEnemies.AutoGenerateColumns = false;
			typeof(DataGridView).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(dgvEnemies, true, null);
			dgvEnemies.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

			cmbEnemyType.DataSource = EnemyType.Select();
			cmbEnemyType.DisplayMember = "name";
			cmbEnemyType.ValueMember = "id";

			RefreshData();
			Filter();
		}

		/// <summary>
		/// データ関連初期化再読み込み
		/// </summary>
		private void RefreshData()
		{
			try
			{
				dgvEnemies.DataSource = null;
				enemiesAll = Enemy.Select();
				dgvEnemies.DataSource = enemies;
			}
			catch (Exception ex)
			{
				MessageBox.Show("検索に失敗しました。" + Environment.NewLine + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		/// <summary>
		/// 検索部変更
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TxtSearch_TextChanged(object sender, EventArgs e)
		{
			Filter();
		}

		/// <summary>
		/// 艦種変更時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CmbEnemyType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!isLoaded) return;
			var selectedType = ConvertUtil.ToString(cmbEnemyType.SelectedValue);
			dgvEnemies.DataSource = null;
			enemies = enemiesAll.FindAll(v => v.TypeIds.Contains(" " + selectedType + ",")).ToList();
			dgvEnemies.DataSource = enemies;
		}

		/// <summary>
		/// 新規追加クリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnAdd_Click(object sender, EventArgs e)
		{
			using (var frm = new FrmEnemyEdit())
			{
				frm.ShowDialog();
			}

			// 新規追加終了後再読み込み再検索
			var firstIndex = dgvEnemies.FirstDisplayedScrollingRowIndex;

			RefreshData();
			Filter();

			if (firstIndex > 0 && firstIndex < dgvEnemies.Rows.Count)
			{
				dgvEnemies.FirstDisplayedScrollingRowIndex = firstIndex;
			}
		}

		/// <summary>
		/// セルダブルクリック(編集開始)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DgvEnemies_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			var rowIndex = e.RowIndex;
			if (rowIndex < 0) return;
			using (var frm = new FrmEnemyEdit())
			{
				frm.EditEnemyID = ConvertUtil.ToInt(dgvEnemies[0, rowIndex].Value);
				frm.ShowDialog();
			}

			var firstIndex = dgvEnemies.FirstDisplayedScrollingRowIndex;

			// 編集終了後再読み込み再検索
			RefreshData();
			Filter();

			if (firstIndex > 0 && firstIndex < dgvEnemies.Rows.Count)
			{
				dgvEnemies.FirstDisplayedScrollingRowIndex = firstIndex;
			}
			if (rowIndex < dgvEnemies.Rows.Count)
			{
				dgvEnemies[0, rowIndex].Selected = true;
			}
		}

		/// <summary>
		/// 複製追加
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnCopy_Click(object sender, EventArgs e)
		{
			if (dgvEnemies.CurrentCell == null)
			{
				MessageBox.Show("複製対象を選択してください。", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			var rowIndex = dgvEnemies.CurrentCell.RowIndex;
			if (rowIndex < 0)
			{
				MessageBox.Show("複製対象を選択してください。", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			using (var frm = new FrmEnemyEdit())
			{
				frm.EditEnemyID = ConvertUtil.ToInt(dgvEnemies[0, rowIndex].Value);
				frm.CopyMode = true;
				frm.ShowDialog();
			}

			// 新規追加終了後再読み込み再検索
			var firstIndex = dgvEnemies.FirstDisplayedScrollingRowIndex;

			RefreshData();
			Filter();

			if (firstIndex > 0 && firstIndex < dgvEnemies.Rows.Count)
			{
				dgvEnemies.FirstDisplayedScrollingRowIndex = firstIndex;
			}
		}

		/// <summary>
		/// 検索処理
		/// </summary>
		private void Filter()
		{
			var text = txtSearch.Text.Trim();

			dgvEnemies.DataSource = null;

			if (enemiesAll is null)
			{
				Close();
				return;
			}
			enemies = enemiesAll.FindAll(v =>
			{
				if (v.Name.Contains(text)) return true;
				if (v.ID.ToString().Contains(text)) return true;
				return false;
			});

			dgvEnemies.DataSource = enemies;
		}
	}
}
