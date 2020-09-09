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

		public bool CopyMode { set; get; } = false;

		private List<EnemyEquipment> equipmentsAll = null;
		private List<EnemyEquipment> equipments1 = null;
		private List<EnemyEquipment> equipments2 = null;
		private List<EnemyEquipment> equipments3 = null;
		private List<EnemyEquipment> equipments4 = null;
		private List<EnemyEquipment> equipments5 = null;

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
			var enemy = new Enemy(EditEnemyID);
			InitializeControl();

			if(enemy.ID > 0)
			{
				// データセット
				txtID.Text = ConvertUtil.ToString(enemy.ID);
				txtID.ReadOnly = true;
				txtName.Text = ConvertUtil.ToString(enemy.Name);
				numAntiAirWeight.Value = enemy.AntiAirWeight;
				numAntiAirBonus.Value = enemy.AntiAirBonus;

				chkType0.Checked = enemy.TypeIds.Contains(" 0,");
				chkType1.Checked = enemy.TypeIds.Contains(" 1,");
				chkType2.Checked = enemy.TypeIds.Contains(" 2,");
				chkType11.Checked = enemy.TypeIds.Contains(" 11,");
				chkType12.Checked = enemy.TypeIds.Contains(" 12,");
				chkType13.Checked = enemy.TypeIds.Contains(" 13,");
				chkType14.Checked = enemy.TypeIds.Contains(" 14,");
				chkType15.Checked = enemy.TypeIds.Contains(" 15,");
				chkType16.Checked = enemy.TypeIds.Contains(" 16,");
				chkType17.Checked = enemy.TypeIds.Contains(" 17,");
				chkType18.Checked = enemy.TypeIds.Contains(" 18,");
				chkType19.Checked = enemy.TypeIds.Contains(" 19,");
				chkType20.Checked = enemy.TypeIds.Contains(" 20,");
				chkType21.Checked = enemy.TypeIds.Contains(" 21,");

				numSlot1.Value = ConvertUtil.ToInt(enemy.Slot1);
				numSlot2.Value = ConvertUtil.ToInt(enemy.Slot2);
				numSlot3.Value = ConvertUtil.ToInt(enemy.Slot3);
				numSlot4.Value = ConvertUtil.ToInt(enemy.Slot4);
				numSlot5.Value = ConvertUtil.ToInt(enemy.Slot5);

				cmbEquipment1.SelectedValue = enemy.Equipment1ID;
				cmbEquipment2.SelectedValue = enemy.Equipment2ID;
				cmbEquipment3.SelectedValue = enemy.Equipment3ID;
				cmbEquipment4.SelectedValue = enemy.Equipment4ID;
				cmbEquipment5.SelectedValue = enemy.Equipment5ID;

				// 鬼姫じゃないなら元選択
				if (!chkType1.Checked)
				{
					cmbOriginalEnemy.SelectedValue = enemy.OriginalID;
					cmbOriginalEnemy.Enabled = true;
				}

				if (CopyMode)
				{
					EditEnemyID = 0;
					txtID.Text = "";
					txtID.ReadOnly = false;
					txtName.Text = "";
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
			var originals = Enemy.Select().FindAll(v => v.Name.Length == 4 && !v.TypeIds.Contains(" 1,") && !v.TypeIds.Contains(" 2,"));
			originals.Insert(0, new Enemy() { ID = 0, Name = "" });
			cmbOriginalEnemy.DataSource = originals;

			var planeType = EquipmentType.Select();
			var enabledTypes = new List<int>() { 1, 2, 3, 5, 6, 101, 1001, 1002, 1003, 1004, 1005 };
			cmbType1.DataSource = planeType.FindAll(v => enabledTypes.Contains(Math.Abs(v.ID)));
			cmbType2.DataSource = planeType.FindAll(v => enabledTypes.Contains(Math.Abs(v.ID)));
			cmbType3.DataSource = planeType.FindAll(v => enabledTypes.Contains(Math.Abs(v.ID)));
			cmbType4.DataSource = planeType.FindAll(v => enabledTypes.Contains(Math.Abs(v.ID)));
			cmbType5.DataSource = planeType.FindAll(v => enabledTypes.Contains(Math.Abs(v.ID)));

			var allEquipments = EnemyEquipment.Select();
			// 空データ挿入
			allEquipments.Insert(0, new EnemyEquipment() { ID = -1, Name = "" });
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
			cmbOriginalEnemy.Enabled = !chkType1.Checked;
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
			enemy.Equipment1ID = ConvertUtil.ToInt(cmbEquipment1.SelectedValue);
			enemy.Equipment2ID = ConvertUtil.ToInt(cmbEquipment2.SelectedValue);
			enemy.Equipment3ID = ConvertUtil.ToInt(cmbEquipment3.SelectedValue);
			enemy.Equipment4ID = ConvertUtil.ToInt(cmbEquipment4.SelectedValue);
			enemy.Equipment5ID = ConvertUtil.ToInt(cmbEquipment5.SelectedValue);
			enemy.AntiAirWeight = ConvertUtil.ToInt(numAntiAirWeight.Value);
			enemy.AntiAirBonus = ConvertUtil.ToInt(numAntiAirBonus.Value);
			enemy.OriginalID = cmbOriginalEnemy.Enabled ? ConvertUtil.ToInt(cmbOriginalEnemy.SelectedValue) : enemy.ID;
			enemy.AirPower = ConvertUtil.ToInt(lblAirPower.Text);
			enemy.LandBaseAirPower = ConvertUtil.ToInt(lblLandBaseAirPower.Text);

			// 艦種
			var types = new List<int>();
			if (chkType0.Checked) types.Add(0);
			if (chkType1.Checked) types.Add(1);
			if (chkType2.Checked) types.Add(2);
			if (chkType11.Checked) types.Add(11);
			if (chkType12.Checked) types.Add(12);
			if (chkType13.Checked) types.Add(13);
			if (chkType14.Checked) types.Add(14);
			if (chkType15.Checked) types.Add(15);
			if (chkType16.Checked) types.Add(16);
			if (chkType17.Checked) types.Add(17);
			if (chkType18.Checked) types.Add(18);
			if (chkType19.Checked) types.Add(19);
			if (chkType20.Checked) types.Add(20);
			if (chkType21.Checked) types.Add(21);

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
					MessageBox.Show("登録失敗\r\n" + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

		/// <summary>
		/// 装備変更時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void EquipmentStatus_Changed(object sender, EventArgs e)
		{
			var equipment1 = equipments1.Find(v => v.ID == ConvertUtil.ToInt(cmbEquipment1.SelectedValue));
			var equipment2 = equipments2.Find(v => v.ID == ConvertUtil.ToInt(cmbEquipment2.SelectedValue));
			var equipment3 = equipments3.Find(v => v.ID == ConvertUtil.ToInt(cmbEquipment3.SelectedValue));
			var equipment4 = equipments4.Find(v => v.ID == ConvertUtil.ToInt(cmbEquipment4.SelectedValue));
			var equipment5 = equipments5.Find(v => v.ID == ConvertUtil.ToInt(cmbEquipment5.SelectedValue));

			// 通常制空値
			var ap1 = Enemy.GetAirPower(equipment1, ConvertUtil.ToInt(numSlot1.Value));
			var ap2 = Enemy.GetAirPower(equipment2, ConvertUtil.ToInt(numSlot2.Value));
			var ap3 = Enemy.GetAirPower(equipment3, ConvertUtil.ToInt(numSlot3.Value));
			var ap4 = Enemy.GetAirPower(equipment4, ConvertUtil.ToInt(numSlot4.Value));
			var ap5 = Enemy.GetAirPower(equipment5, ConvertUtil.ToInt(numSlot5.Value));
			var sum = ap1 + ap2 + ap3 + ap4 + ap5;

			lblAirPower1.Text = ap1.ToString();
			lblAirPower2.Text = ap2.ToString();
			lblAirPower3.Text = ap3.ToString();
			lblAirPower4.Text = ap4.ToString();
			lblAirPower5.Text = ap5.ToString();

			// 基地制空値
			var ap1_ = Enemy.GetAirPower(equipment1, ConvertUtil.ToInt(numSlot1.Value), true);
			var ap2_ = Enemy.GetAirPower(equipment2, ConvertUtil.ToInt(numSlot2.Value), true);
			var ap3_ = Enemy.GetAirPower(equipment3, ConvertUtil.ToInt(numSlot3.Value), true);
			var ap4_ = Enemy.GetAirPower(equipment4, ConvertUtil.ToInt(numSlot4.Value), true);
			var ap5_ = Enemy.GetAirPower(equipment5, ConvertUtil.ToInt(numSlot5.Value), true);
			var sum_ = ap1_ + ap2_ + ap3_ + ap4_ + ap5_;

			lblAirPower.Text = sum.ToString();
			lblLandBaseAirPower.Text = sum_.ToString();

			// 装備対空値
			var antiAirWeight1 = Enemy.GetAntiAirWeight(equipment1);
			var antiAirWeight2 = Enemy.GetAntiAirWeight(equipment2);
			var antiAirWeight3 = Enemy.GetAntiAirWeight(equipment3);
			var antiAirWeight4 = Enemy.GetAntiAirWeight(equipment4);
			var antiAirWeight5 = Enemy.GetAntiAirWeight(equipment5);
			var sumAntiAirWeight = antiAirWeight1 + antiAirWeight2 + antiAirWeight3 + antiAirWeight4 + antiAirWeight5;

			var sumEquipmentAntiAir =
				ConvertUtil.ToInt(equipment1 == null ? "0" : equipment1.AntiAir)
				+ ConvertUtil.ToInt(equipment2 == null ? "0" : equipment2.AntiAir)
				+ ConvertUtil.ToInt(equipment3 == null ? "0" : equipment3.AntiAir)
				+ ConvertUtil.ToInt(equipment4 == null ? "0" : equipment4.AntiAir)
				+ ConvertUtil.ToInt(equipment5 == null ? "0" : equipment5.AntiAir);

			var antiAirWeight = 2 * Math.Floor(Math.Sqrt(ConvertUtil.ToInt(numAntiAir.Value) + sumEquipmentAntiAir)) + sumAntiAirWeight;
			lblAntiAirWeight.Text = antiAirWeight.ToString();

			// 防空ボーナス
			var antiAirBonus1 = Enemy.GetAntiAirBonus(equipment1);
			var antiAirBonus2 = Enemy.GetAntiAirBonus(equipment2);
			var antiAirBonus3 = Enemy.GetAntiAirBonus(equipment3);
			var antiAirBonus4 = Enemy.GetAntiAirBonus(equipment4);
			var antiAirBonus5 = Enemy.GetAntiAirBonus(equipment5);
			var sumantiAirBonus = antiAirBonus1 + antiAirBonus2 + antiAirBonus3 + antiAirBonus4 + antiAirBonus5;
			lblAntiAirBonus.Text = Math.Floor(sumantiAirBonus).ToString();
		}
	}
}
