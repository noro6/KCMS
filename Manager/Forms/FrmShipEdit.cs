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
			if (ship.ID > 0)
			{
				// データセット
				txtID.Text = ConvertUtil.ToString(ship.ID);
				txtName.Text = ConvertUtil.ToString(ship.Name);
				chkIsFinal.Checked = ship.IsFinal;
				cmbOriginalShip.SelectedValue = ship.OriginalID;
				txtAlbumID.Text = ConvertUtil.ToString(ship.AlbumID);
				cmbType.SelectedValue = ship.TypeID;

				numSlot1.Value = ConvertUtil.ToInt(ship.Slot1 is null ? 0 : ship.Slot1);
				numSlot2.Value = ConvertUtil.ToInt(ship.Slot2 is null ? 0 : ship.Slot2);
				numSlot3.Value = ConvertUtil.ToInt(ship.Slot3 is null ? 0 : ship.Slot3);
				numSlot4.Value = ConvertUtil.ToInt(ship.Slot4 is null ? 0 : ship.Slot4);
				numSlot5.Value = ConvertUtil.ToInt(ship.Slot5 is null ? 0 : ship.Slot5);

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
			originals.Insert(0, new Ship() { ID = 0, Name = "", Version = 0, AlbumID = 0 });
			originals = originals.FindAll(v => v.Version == 0);
			originals.Sort((a, b) => a.AlbumID - b.AlbumID);
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
				IsFinal = chkIsFinal.Checked,
				OriginalID = ConvertUtil.ToInt(cmbOriginalShip.SelectedValue),
				AlbumID = ConvertUtil.ToInt(txtAlbumID.Text),
				Enabled = chkEnabled.Checked
			};
			// 未選択なら自身を無印とする
			ship.OriginalID = ship.OriginalID == 0 ? ship.AlbumID : ship.OriginalID;

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
						ship.Insert(db);
						EditShipID = ship.ID;
					}
					// 編集
					else
					{
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
			if ((ship.IsFinal || ship.ID > 1000) && ship.OriginalID <= 0)
			{
				MessageBox.Show("無印状態未選択エラー", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				ActiveControl = cmbOriginalShip;
				cmbOriginalShip.DroppedDown = true;
				return true;
			}
			if (ship.AlbumID <= 0)
			{
				var dr = MessageBox.Show("デッキビルダーID未入力警告\r\nこのまま続行しますか？", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
				if (dr != DialogResult.OK)
				{
					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// 削除
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnDelete_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("削除を行います。", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK) return;

			using (var db = new DBManager())
			{
				try
				{
					db.CreateConnection();
					db.BeginTran();

					var deleted = Ship.Delete(db, EditShipID) == 1;

					db.Commit();

					if (deleted)
					{
						MessageBox.Show("削除完了", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
						Close();
					}
					else
					{
						MessageBox.Show("削除対象ではありません。", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
				catch (Exception ex)
				{
					db.RollBack();
					MessageBox.Show("削除失敗\r\n" + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}
	}
}
