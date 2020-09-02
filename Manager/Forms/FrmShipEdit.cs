using Manager.DB;
using Manager.Models;
using Manager.Util;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Manager.Forms
{
	public partial class FrmShipEdit : Form
	{
		/// <summary>
		/// 編集対象敵艦ID
		/// </summary>
		public int EditShipID { set; get; }

		public FrmShipEdit()
		{
			InitializeComponent();
		}

		/// <summary>
		/// ロード時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FrmEnemyEdit_Load(object sender, System.EventArgs e)
		{
			// コントロール初期化
			InitializeControl();

			var ship = new Ship(EditShipID);
			if(ship.ID > 0)
			{
				// データセット
				txtID.Text = ConvertUtil.ToString(ship.ID);
				txtName.Text = ConvertUtil.ToString(ship.Name);
				chkIsFinal.Checked = ship.IsFinal;
				cmbOriginalShip.SelectedValue = ship.OriginalID;
				txtAlbumID.Text = ConvertUtil.ToString(ship.AlbumID);
				cmbType.SelectedValue = ship.TypeID;

				chkEnabledSlot1.Checked = !(ship.Slot1 is null);
				chkEnabledSlot2.Checked = !(ship.Slot2 is null);
				chkEnabledSlot3.Checked = !(ship.Slot3 is null);
				chkEnabledSlot4.Checked = !(ship.Slot4 is null);
				chkEnabledSlot5.Checked = !(ship.Slot5 is null);

				numSlot1.Value = ConvertUtil.ToInt(ship.Slot1 is null ? 0 : ship.Slot1);
				numSlot2.Value = ConvertUtil.ToInt(ship.Slot2 is null ? 0 : ship.Slot2);
				numSlot3.Value = ConvertUtil.ToInt(ship.Slot3 is null ? 0 : ship.Slot3);
				numSlot4.Value = ConvertUtil.ToInt(ship.Slot4 is null ? 0 : ship.Slot4);
				numSlot5.Value = ConvertUtil.ToInt(ship.Slot5 is null ? 0 : ship.Slot5);

				numSlot1.Enabled = chkEnabledSlot1.Checked;
				numSlot2.Enabled = chkEnabledSlot2.Checked;
				numSlot3.Enabled = chkEnabledSlot3.Checked;
				numSlot4.Enabled = chkEnabledSlot4.Checked;
				numSlot5.Enabled = chkEnabledSlot5.Checked;

				chkEnabled.Checked = ship.Enabled;
			}
			else
			{
				cmbOriginalShip.Enabled = true;
			}
		}

		/// <summary>
		/// コントロール初期化
		/// </summary>
		private void InitializeControl()
		{
			// コンボボックス初期化
			var originals = Ship.Select();
			originals.Insert(0, new Ship() { ID = 0, Name = "" });
			cmbOriginalShip.DataSource = originals;

			cmbType.DataSource = ShipType.Select();
		}

		private void BtnClose_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		/// <summary>
		/// 登録
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnSave_Click(object sender, System.EventArgs e)
		{
			var ship = new Ship
			{
				ID = ConvertUtil.ToInt(txtID.Text),
				Name = ConvertUtil.ToString(txtName.Text).Trim(),
				TypeID = ConvertUtil.ToInt(cmbType.SelectedValue),
				Slot1 = chkEnabledSlot1.Checked ? ConvertUtil.ToInt(numSlot1.Value) : (int?)null,
				Slot2 = chkEnabledSlot2.Checked ? ConvertUtil.ToInt(numSlot2.Value) : (int?)null,
				Slot3 = chkEnabledSlot3.Checked ? ConvertUtil.ToInt(numSlot3.Value) : (int?)null,
				Slot4 = chkEnabledSlot4.Checked ? ConvertUtil.ToInt(numSlot4.Value) : (int?)null,
				Slot5 = chkEnabledSlot5.Checked ? ConvertUtil.ToInt(numSlot5.Value) : (int?)null,
				IsFinal = chkIsFinal.Checked,
				OriginalID = ConvertUtil.ToInt(cmbOriginalShip.SelectedValue),
				AlbumID = ConvertUtil.ToInt(txtAlbumID.Text),
				Enabled = chkEnabled.Checked
			};
			// 未選択なら自身を無印とする
			ship.OriginalID = ship.OriginalID == 0 ? ship.ID : ship.OriginalID;

			if (HasError(ship)) return;
			if (MessageBox.Show("登録を行います。", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK) return;

			using (var db = new DBManager())
			{
				try
				{
					db.CreateConnection();
					db.BeginTran();

					// 新規追加
					if (EditShipID == 0)
					{
						// ships 登録
						ship.Insert(db);

					}
					// 編集
					else
					{
						// ships 更新
						Ship.Delete(db, ship.ID);
						ship.Insert(db);
					}

					db.Commit();

					MessageBox.Show("登録完了", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch (Exception ex)
				{
					db.RollBack();
					MessageBox.Show("登録失敗\r\n" + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		/// <summary>
		/// エラーがあるかどうかチェック　あれば true
		/// </summary>
		/// <param name="ship">チェック対象 Enemy インスタンス</param>
		/// <returns></returns>
		private bool HasError(Ship ship)
		{
			if (ship.ID == 0)
			{
				MessageBox.Show("ID未入力エラー", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtAlbumID.SelectAll();
				ActiveControl = txtID;
				return true;
			}
			if (ship.AlbumID == 0)
			{
				MessageBox.Show("図鑑ID未入力エラー", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtAlbumID.SelectAll();
				ActiveControl = txtAlbumID;
				return true;
			}
			if (EditShipID == 0 && new Ship(ship.ID).ID > 0)
			{
				MessageBox.Show("ID重複エラー", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtAlbumID.SelectAll();
				ActiveControl = txtID;
				return true;
			}
			if (ship.Name == "")
			{
				MessageBox.Show("名前未入力エラー", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				ActiveControl = txtAlbumID;
				return true;
			}
			if (ship.TypeID < 1)
			{
				MessageBox.Show("艦種未選択エラー", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return true;
			}
			if((ship.IsFinal || ship.ID > 1000) && ship.OriginalID <= 0)
			{
				MessageBox.Show("無印状態未選択エラー", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				ActiveControl = cmbOriginalShip;
				cmbOriginalShip.DroppedDown = true;
				return true;
			}
			if (ship.AlbumID <= 0)
			{
				var dr = MessageBox.Show("デッキビルダーID未入力警告\r\nこのまま続行しますか？", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
				if(dr != DialogResult.OK)
				{
					return true;
				}
			}

			return false;
		}

		private void ChkEnabledSlot1_CheckedChanged(object sender, EventArgs e)
		{
			numSlot1.Enabled = chkEnabledSlot1.Checked;
		}

		private void ChkEnabledSlot2_CheckedChanged(object sender, EventArgs e)
		{
			numSlot2.Enabled = chkEnabledSlot2.Checked;
		}

		private void ChkEnabledSlot3_CheckedChanged(object sender, EventArgs e)
		{
			numSlot3.Enabled = chkEnabledSlot3.Checked;
		}

		private void ChkEnabledSlot4_CheckedChanged(object sender, EventArgs e)
		{
			numSlot4.Enabled = chkEnabledSlot4.Checked;
		}

		private void ChkEnabledSlot5_CheckedChanged(object sender, EventArgs e)
		{
			numSlot5.Enabled = chkEnabledSlot5.Checked;
		}
	}
}
