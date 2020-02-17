using Manager.DB;
using Manager.Models;
using Manager.Util;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Manager.Forms
{
	public partial class FrmEnemyEdit : Form
	{
		/// <summary>
		/// 編集対象敵艦ID
		/// </summary>
		public int EditEnemyID { set; get; }

		/// <summary>
		/// 編集対象敵艦クラス
		/// </summary>
		private Enemy Enemy { set; get; }

		private List<EnemyPlane> equipmentsAll = null;
		private List<EnemyPlane> equipments1 = null;
		private List<EnemyPlane> equipments2 = null;
		private List<EnemyPlane> equipments3 = null;
		private List<EnemyPlane> equipments4 = null;
		private List<EnemyPlane> equipments5 = null;

		private bool isLoaded = false;

		public FrmEnemyEdit()
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
			Enemy = new Enemy(EditEnemyID);
			InitializeControl();

			if(Enemy.ID > 0)
			{
				// データセット
				txtID.Text = ConvertUtil.ToString(Enemy.ID);
				txtID.ReadOnly = true;
				txtName.Text = ConvertUtil.ToString(Enemy.Name);
				numAntiAirWeight.Value = Enemy.AntiAirWeight;
				numAntiAirBonus.Value = Enemy.AntiAirBonus;

				chkType1.Checked = Enemy.TypeIds.Contains(" 1,");
				chkType2.Checked = Enemy.TypeIds.Contains(" 2,");
				chkType3.Checked = Enemy.TypeIds.Contains(" 3,");
				chkType4.Checked = Enemy.TypeIds.Contains(" 4,");
				chkType5.Checked = Enemy.TypeIds.Contains(" 5,");
				chkType6.Checked = Enemy.TypeIds.Contains(" 6,");
				chkType7.Checked = Enemy.TypeIds.Contains(" 7,");
				chkType8.Checked = Enemy.TypeIds.Contains(" 8,");
				chkType9.Checked = Enemy.TypeIds.Contains(" 9,");
				chkType10.Checked = Enemy.TypeIds.Contains(" 10,");
				chkType20.Checked = Enemy.TypeIds.Contains(" 20,");
				chkType100.Checked = Enemy.TypeIds.Contains(" 100,");
				chkType110.Checked = Enemy.TypeIds.Contains(" 110,");

				numSlot1.Value = ConvertUtil.ToInt(Enemy.Slot1);
				numSlot2.Value = ConvertUtil.ToInt(Enemy.Slot2);
				numSlot3.Value = ConvertUtil.ToInt(Enemy.Slot3);
				numSlot4.Value = ConvertUtil.ToInt(Enemy.Slot4);
				numSlot5.Value = ConvertUtil.ToInt(Enemy.Slot5);

				cmbEquipment1.SelectedValue = Enemy.Equipment1ID;
				cmbEquipment2.SelectedValue = Enemy.Equipment2ID;
				cmbEquipment3.SelectedValue = Enemy.Equipment3ID;
				cmbEquipment4.SelectedValue = Enemy.Equipment4ID;
				cmbEquipment5.SelectedValue = Enemy.Equipment5ID;

				if (!chkType110.Checked)
				{
					cmbOriginalEnemy.SelectedValue = Enemy.OriginalID;
					cmbOriginalEnemy.Enabled = true;
				}
			}
			else
			{
				cmbOriginalEnemy.Enabled = true;
			}

			isLoaded = true;
		}

		/// <summary>
		/// コントロール初期化
		/// </summary>
		private void InitializeControl()
		{
			// コンボボックス初期化
			var originals = Enemy.Select().FindAll(v => v.Name.Length == 4 && !v.TypeIds.Contains(" 100,") && !v.TypeIds.Contains(" 110,"));
			originals.Insert(0, new Enemy() { ID = 0, Name = "" });
			cmbOriginalEnemy.DataSource = originals;

			var planeType = PlaneType.Select();
			var enabledTypes = new List<int>() { 1, 2, 3, 5, 6, 101 };
			cmbType1.DataSource = planeType.FindAll(v => enabledTypes.Contains(v.ID));
			cmbType2.DataSource = planeType.FindAll(v => enabledTypes.Contains(v.ID));
			cmbType3.DataSource = planeType.FindAll(v => enabledTypes.Contains(v.ID));
			cmbType4.DataSource = planeType.FindAll(v => enabledTypes.Contains(v.ID));
			cmbType5.DataSource = planeType.FindAll(v => enabledTypes.Contains(v.ID));

			var allEquipments = EnemyPlane.Select();
			// 空データ挿入
			allEquipments.Insert(0, new EnemyPlane() { ID = -1, Name = "" });
			equipmentsAll = allEquipments;
			equipments1 = allEquipments.FindAll(v => true);
			equipments2 = allEquipments.FindAll(v => true);
			equipments3 = allEquipments.FindAll(v => true);
			equipments4 = allEquipments.FindAll(v => true);
			equipments5 = allEquipments.FindAll(v => true);

			cmbEquipment1.DisplayMember = "Name";
			cmbEquipment1.ValueMember = "ID";
			cmbEquipment2.DisplayMember = "Name";
			cmbEquipment2.ValueMember = "ID";
			cmbEquipment3.DisplayMember = "Name";
			cmbEquipment3.ValueMember = "ID";
			cmbEquipment4.DisplayMember = "Name";
			cmbEquipment4.ValueMember = "ID";
			cmbEquipment5.DisplayMember = "Name";
			cmbEquipment5.ValueMember = "ID";

			cmbEquipment1.DataSource = equipments1;
			cmbEquipment2.DataSource = equipments2;
			cmbEquipment3.DataSource = equipments3;
			cmbEquipment4.DataSource = equipments4;
			cmbEquipment5.DataSource = equipments5;

			cmbType1.SelectedIndex = -1;
			cmbType2.SelectedIndex = -1;
			cmbType3.SelectedIndex = -1;
			cmbType4.SelectedIndex = -1;
			cmbType5.SelectedIndex = -1;
		}

		/// <summary>
		/// 鬼 / 姫チェックが変更
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ChkType110_CheckedChanged(object sender, System.EventArgs e)
		{
			cmbOriginalEnemy.Enabled = !chkType110.Checked;
		}

		private void CmbType1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (isLoaded)
			{
				var selectedType = ConvertUtil.ToInt(cmbType1.SelectedValue);
				cmbEquipment1.DataSource = null;
				equipments1 = equipmentsAll.FindAll(v => v.TypeID == selectedType || v.ID == -1);
				cmbEquipment1.DisplayMember = "Name";
				cmbEquipment1.ValueMember = "ID";
				cmbEquipment1.DataSource = equipments1;
			}
		}

		private void CmbType2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (isLoaded)
			{
				var selectedType = ConvertUtil.ToInt(cmbType2.SelectedValue);
				cmbEquipment2.DataSource = null;
				equipments2 = equipmentsAll.FindAll(v => v.TypeID == selectedType || v.ID == -1);
				cmbEquipment2.DisplayMember = "Name";
				cmbEquipment2.ValueMember = "ID";
				cmbEquipment2.DataSource = equipments2;
			}
		}

		private void CmbType3_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (isLoaded)
			{
				var selectedType = ConvertUtil.ToInt(cmbType3.SelectedValue);
				cmbEquipment3.DataSource = null;
				equipments3 = equipmentsAll.FindAll(v => v.TypeID == selectedType || v.ID == -1);
				cmbEquipment3.DisplayMember = "Name";
				cmbEquipment3.ValueMember = "ID";
				cmbEquipment3.DataSource = equipments3;
			}
		}

		private void CmbType4_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (isLoaded)
			{
				var selectedType = ConvertUtil.ToInt(cmbType4.SelectedValue);
				cmbEquipment4.DataSource = null;
				equipments4 = equipmentsAll.FindAll(v => v.TypeID == selectedType || v.ID == -1);
				cmbEquipment4.DisplayMember = "Name";
				cmbEquipment4.ValueMember = "ID";
				cmbEquipment4.DataSource = equipments4;
			}
		}

		private void CmbType5_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (isLoaded)
			{
				var selectedType = ConvertUtil.ToInt(cmbType5.SelectedValue);
				cmbEquipment5.DataSource = null;
				equipments5 = equipmentsAll.FindAll(v => v.TypeID == selectedType || v.ID == -1);
				cmbEquipment5.DisplayMember = "Name";
				cmbEquipment5.ValueMember = "ID";
				cmbEquipment5.DataSource = equipments5;
			}
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
			var enemy = new Enemy
			{
				ID = ConvertUtil.ToInt(txtID.Text),
				Name = ConvertUtil.ToString(txtName.Text).Trim(),
				Slot1 = ConvertUtil.ToInt(numSlot1.Value),
				Slot2 = ConvertUtil.ToInt(numSlot2.Value),
				Slot3 = ConvertUtil.ToInt(numSlot3.Value),
				Slot4 = ConvertUtil.ToInt(numSlot4.Value),
				Slot5 = ConvertUtil.ToInt(numSlot5.Value),
			};
			enemy.Slot1 = enemy.Slot1 > 0 ? enemy.Slot1 : null;
			enemy.Slot2 = enemy.Slot2 > 0 ? enemy.Slot2 : null;
			enemy.Slot3 = enemy.Slot3 > 0 ? enemy.Slot3 : null;
			enemy.Slot4 = enemy.Slot4 > 0 ? enemy.Slot4 : null;
			enemy.Slot5 = enemy.Slot5 > 0 ? enemy.Slot5 : null;
			enemy.Equipment1ID = enemy.Slot1 > 0 ? ConvertUtil.ToInt(cmbEquipment1.SelectedValue) : (int?)null;
			enemy.Equipment2ID = enemy.Slot2 > 0 ? ConvertUtil.ToInt(cmbEquipment2.SelectedValue) : (int?)null;
			enemy.Equipment3ID = enemy.Slot3 > 0 ? ConvertUtil.ToInt(cmbEquipment3.SelectedValue) : (int?)null;
			enemy.Equipment4ID = enemy.Slot4 > 0 ? ConvertUtil.ToInt(cmbEquipment4.SelectedValue) : (int?)null;
			enemy.Equipment5ID = enemy.Slot5 > 0 ? ConvertUtil.ToInt(cmbEquipment5.SelectedValue) : (int?)null;
			enemy.AntiAirWeight = ConvertUtil.ToInt(numAntiAirWeight.Value);
			enemy.AntiAirBonus = ConvertUtil.ToInt(numAntiAirBonus.Value);
			enemy.OriginalID = cmbOriginalEnemy.Enabled ? ConvertUtil.ToInt(cmbOriginalEnemy.SelectedValue) : enemy.ID;

			// 艦種
			var types = new List<int>();
			if (chkType1.Checked) types.Add(1);
			if (chkType2.Checked) types.Add(2);
			if (chkType3.Checked) types.Add(3);
			if (chkType4.Checked) types.Add(4);
			if (chkType5.Checked) types.Add(5);
			if (chkType6.Checked) types.Add(6);
			if (chkType7.Checked) types.Add(7);
			if (chkType8.Checked) types.Add(8);
			if (chkType9.Checked) types.Add(9);
			if (chkType10.Checked) types.Add(10);
			if (chkType20.Checked) types.Add(20);
			if (chkType100.Checked) types.Add(100);
			if (chkType110.Checked) types.Add(110);

			enemy.TypeIds = string.Join(",", types);

			if (HasError(enemy)) return;
			if (MessageBox.Show("登録を行います。", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK) return;

			using (var db = new DBManager())
			{
				try
				{
					db.CreateConnection();
					db.BeginTran();

					// 新規追加
					if (EditEnemyID == 0)
					{
						// enemies 登録
						enemy.Insert(db);

						// enemies_types　登録
						foreach (var typeId in types)
						{
							Enemy.InsertTypes(db, enemy.ID, typeId);
						}
					}
					// 編集
					else
					{
						// enemies 更新
						Enemy.Delete(db, enemy.ID);
						enemy.Insert(db);

						// enemies_types　更新
						Enemy.DeleteEnemyTypes(db, enemy.ID);
						foreach (var typeId in types)
						{
							Enemy.InsertTypes(db, enemy.ID, typeId);
						}
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
		/// <param name="enemy">チェック対象 Enemy インスタンス</param>
		/// <returns></returns>
		private bool HasError(Enemy enemy)
		{
			if (enemy.ID == 0)
			{
				MessageBox.Show("無効なID", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtID.SelectAll();
				ActiveControl = txtID;
				return true;
			}
			if (EditEnemyID == 0 && new Enemy(enemy.ID).ID > 0)
			{
				MessageBox.Show("ID重複エラー", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtID.SelectAll();
				ActiveControl = txtID;
				return true;
			}
			if (enemy.Name == "")
			{
				MessageBox.Show("名前未入力エラー", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				ActiveControl = txtID;
				return true;
			}
			if (string.IsNullOrEmpty(enemy.TypeIds))
			{
				MessageBox.Show("艦種未選択エラー", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return true;
			}
			if (enemy.Slot1 > 0 && enemy.Equipment1ID < 1)
			{
				MessageBox.Show("装備未入力エラー", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				ActiveControl = cmbEquipment1;
				cmbEquipment1.DroppedDown = true;
				return true;
			}
			if (enemy.Slot2 > 0 && enemy.Equipment2ID < 1)
			{
				MessageBox.Show("装備未入力エラー", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				ActiveControl = cmbEquipment2;
				cmbEquipment2.DroppedDown = true;
				return true;
			}
			if (enemy.Slot3 > 0 && enemy.Equipment3ID < 1)
			{
				MessageBox.Show("装備未入力エラー", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				ActiveControl = cmbEquipment3;
				cmbEquipment3.DroppedDown = true;
				return true;
			}
			if (enemy.Slot4 > 0 && enemy.Equipment4ID < 1)
			{
				MessageBox.Show("装備未入力エラー", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				ActiveControl = cmbEquipment4;
				cmbEquipment4.DroppedDown = true;
				return true;
			}
			if (enemy.Slot5 > 0 && enemy.Equipment5ID < 1)
			{
				MessageBox.Show("装備未入力エラー", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				ActiveControl = cmbEquipment5;
				cmbEquipment5.DroppedDown = true;
				return true;
			}

			return false;
		}
	}
}
