using Manager.Models;
using Manager.Util;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace Manager.Forms
{
	public partial class FrmEquipmentList : Form
	{
		private List<Equipment> equipmentAll = null;
		private List<Equipment> equipments = null;

		public bool isLoaded = false;

		public FrmEquipmentList()
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
			dgvEquipments.AutoGenerateColumns = false;
			typeof(DataGridView).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(dgvEquipments, true, null);

			RefreshData();

			var types = EquipmentType.Select();
			types.Insert(0, new EquipmentType() { ID = -99, Name = "全て" });
			cmbType.DataSource = types;
			cmbType.DisplayMember = "name";
			cmbType.ValueMember = "id";
		}

		/// <summary>
		/// データ関連初期化再読み込み
		/// </summary>
		private void RefreshData()
		{
			dgvEquipments.DataSource = null;
			equipmentAll = Equipment.Select();
			equipments = Equipment.Select();
			dgvEquipments.DataSource = equipments;
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
		/// 表示物のフィルタ　もとい検索処理
		/// </summary>
		private void Filter()
		{
			var keyword = txtSearch.Text.Trim();
			dgvEquipments.DataSource = null;
			if(keyword != "")
			{
				// キーワード検索
				equipments = equipmentAll.FindAll(v =>
				{
					if (v.Name.Contains(keyword)) return true;
					if (v.ID.ToString().Contains(keyword)) return true;
					return false;
				});
				dgvEquipments.DataSource = equipments;
			}
			else
			{
				// カテゴリ検索
				var type = ConvertUtil.ToInt(cmbType.SelectedValue);
				if (type != -99)
				{
					equipments = equipmentAll.FindAll(v => v.TypeID == type);
				}
				else
				{
					// 全件取得
					equipments = equipmentAll.FindAll(v => true);
				}
				dgvEquipments.DataSource = equipments;
			}
		}

		/// <summary>
		/// 新規追加クリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnAdd_Click(object sender, EventArgs e)
		{
			using (var frm = new FrmEquipmentEdit())
			{
				frm.ShowDialog();
			}

			var scrollIndex = dgvEquipments.FirstDisplayedScrollingRowIndex;
			// 新規追加終了後再検索
			RefreshData();
			Filter();
			// スクロール位置復帰
			if (scrollIndex > 0 && scrollIndex < dgvEquipments.Rows.Count)
			{
				dgvEquipments.FirstDisplayedScrollingRowIndex = scrollIndex;
			}
		}

		/// <summary>
		/// セルダブルクリック(編集開始)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DgvEquipments_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			var rowIndex = e.RowIndex;
			if (rowIndex < 0) return;
			using (var frm = new FrmEquipmentEdit())
			{
				frm.EditEquipmentId = ConvertUtil.ToInt(dgvEquipments[0, rowIndex].Value);
				frm.ShowDialog();
			}

			var scrollIndex = dgvEquipments.FirstDisplayedScrollingRowIndex;
			// 編集終了後再検索
			RefreshData();
			// フィルタ適用
			Filter();
			// スクロール位置復帰
			if (scrollIndex > 0 && scrollIndex < dgvEquipments.Rows.Count)
			{
				dgvEquipments.FirstDisplayedScrollingRowIndex = scrollIndex;
			}
			if(rowIndex < dgvEquipments.Rows.Count)
			{
				dgvEquipments[0, rowIndex].Selected = true;
			}
		}
	}
}
