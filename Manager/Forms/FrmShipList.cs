using Manager.Models;
using Manager.Util;
using System;
using System.Collections.Generic;
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

		private void FrmShipList_Load(object sender, EventArgs e)
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

			RefreshData();

			var types = ShipType.Select();
			types.Insert(0, new ShipType() { ID = -99, Name = "全て" });
			cmbShipType.DataSource = types;
			cmbShipType.DisplayMember = "name";
			cmbShipType.ValueMember = "id";
		}

		/// <summary>
		/// データ関連初期化再読み込み
		/// </summary>
		private void RefreshData()
		{
			dgvShip.DataSource = null;
			shipAll = Ship.Select();
			ships = Ship.Select();
			dgvShip.DataSource = ships;
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
		private void CmbShipType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!isLoaded) return;
			Filter();
		}

		/// <summary>
		/// 有効チェックボックス変更
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void chkEnabled_CheckedChanged(object sender, EventArgs e)
		{
			Filter();
		}

		/// <summary>
		/// 表示物のフィルタ　もとい検索処理
		/// </summary>
		private void Filter()
		{
			var keyword = txtSearch.Text.Trim();
			dgvShip.DataSource = null;

			if (keyword != "")
			{
				// キーワード検索
				ships = shipAll.FindAll(v =>
				{
					if (v.Name.Contains(keyword)) return true;
					if (v.ID.ToString().Contains(keyword)) return true;
					return false;
				});
			}
			else
			{
				// カテゴリ検索
				var type = ConvertUtil.ToInt(cmbShipType.SelectedValue);
				if (type != -99)
				{
					ships = shipAll.FindAll(v => v.TypeID == type);
				}
				else
				{
					// 全件取得
					ships = shipAll.FindAll(v => true);
				}
			}

			if (chkEnabled.Checked) ships = ships.FindAll(v => v.Enabled == true);

			dgvShip.DataSource = ships;
		}

		/// <summary>
		/// 新規追加クリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnAdd_Click(object sender, EventArgs e)
		{
			using (var frm = new FrmShipEdit())
			{
				frm.ShowDialog();
			}

			var firstIndex = dgvShip.FirstDisplayedScrollingRowIndex;

			// 新規追加終了後再読み込み再検索
			RefreshData();
			Filter();

			if (firstIndex > 0 && firstIndex < dgvShip.Rows.Count)
			{
				dgvShip.FirstDisplayedScrollingRowIndex = firstIndex;
			}
		}

		/// <summary>
		/// セルダブルクリック(編集開始)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DgvShips_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			var rowIndex = e.RowIndex;
			if (rowIndex < 0) return;
			using (var frm = new FrmShipEdit())
			{
				frm.EditShipID = ConvertUtil.ToInt(dgvShip[0, rowIndex].Value);
				frm.ShowDialog();
			}

			var firstIndex = dgvShip.FirstDisplayedScrollingRowIndex;

			// 編集終了後再読み込み再検索
			RefreshData();
			Filter();

			if (firstIndex > 0 && firstIndex < dgvShip.Rows.Count)
			{
				dgvShip.FirstDisplayedScrollingRowIndex = firstIndex;
			}
			if (rowIndex < dgvShip.Rows.Count)
			{
				dgvShip[0, rowIndex].Selected = true;
			}
		}
	}
}
