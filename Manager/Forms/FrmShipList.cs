using Manager.Models;
using Manager.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Manager.Forms
{
	public partial class FrmShipList : Form
	{
		private List<Ship> shipAll = null;
		private List<Ship> ships = null;

		public bool isLoaded = false;

		public FrmShipList()
		{
			InitializeComponent();
		}

		private void FrmEnemyMaster_Load(object sender, EventArgs e)
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
			dgvShip.AutoGenerateColumns = false;
			typeof(DataGridView).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(dgvShip, true, null);

			shipAll = Ship.Select();
			ships = Ship.Select();
			dgvShip.DataSource = ships;

			cmbShipType.DataSource = ShipType.Select();
			cmbShipType.DisplayMember = "name";
			cmbShipType.ValueMember = "id";
		}

		/// <summary>
		/// 検索部変更
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TxtSearch_TextChanged(object sender, EventArgs e)
		{
			var text = txtSearch.Text.Trim();

			dgvShip.DataSource = null;
			ships = shipAll.FindAll(v =>
			{
				if (v.Name.Contains(text)) return true;
				if (v.ID.ToString().Contains(text)) return true;
				return false;
			});
			dgvShip.DataSource = ships;
		}

		/// <summary>
		/// 艦種変更時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CmbEnemyType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!isLoaded) return;
			var selectedType = ConvertUtil.ToInt(cmbShipType.SelectedValue);
			dgvShip.DataSource = null;
			ships = shipAll.FindAll(v => v.TypeID == selectedType).ToList();
			dgvShip.DataSource = ships;
		}

		/// <summary>
		/// 新規追加クリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnAdd_Click(object sender, EventArgs e)
		{
			//using (var frm = new FrmShipEdit())
			//{
			//	frm.ShowDialog();
			//}

			// 編集終了後再検索
			dgvShip.DataSource = null;
			ships = Ship.Select();
			dgvShip.DataSource = ships;
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
				frm.EditEnemyID = ConvertUtil.ToInt(dgvShip[0, rowIndex].Value);
				frm.ShowDialog();
			}

			// 編集終了後再検索
			dgvShip.DataSource = null;
			ships = Ship.Select();
			dgvShip.DataSource = ships;

			dgvShip.FirstDisplayedScrollingRowIndex = ships.Count - 1 < rowIndex ? ships.Count - 1 : rowIndex;
			dgvShip[0, rowIndex].Selected = true;
		}
	}
}
