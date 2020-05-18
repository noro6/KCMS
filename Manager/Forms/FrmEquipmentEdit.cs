using Manager.DB;
using Manager.Models;
using Manager.Util;
using System;
using System.Windows.Forms;

namespace Manager.Forms
{
	public partial class FrmEquipmentEdit : Form
	{
		/// <summary>
		/// 編集対象敵艦ID
		/// </summary>
		public int EditEquipmentId { set; get; }

		public FrmEquipmentEdit()
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

			var equipment = new Equipment(EditEquipmentId);
			if(equipment.ID > 0)
			{
				// データセット
				txtID.Text = ConvertUtil.ToString(equipment.ID);
				txtID.ReadOnly = true;
				txtName.Text = ConvertUtil.ToString(equipment.Name);
				txtAbbr.Text = ConvertUtil.ToString(equipment.Abbr);
				cmbType.SelectedValue = equipment.TypeID;
				chkCanRemodel.Checked = equipment.CanRemodel;

				numAntiAir.Value = equipment.AntiAir;
				numTorpedo.Value = equipment.Torpedo;
				numBomber.Value = equipment.Bomber;
				numInterception.Value = equipment.Interception;
				numAntiBomber.Value = equipment.AntiBomber;
				numScout.Value = equipment.Scout;
				numRadius.Value = equipment.Radius;
				numCost.Value = equipment.Cost;

				cmbAvoid.SelectedValue = equipment.AvoidID;
			}
		}

		/// <summary>
		/// コントロール初期化
		/// </summary>
		private void InitializeControl()
		{
			// コンボボックス初期化
			cmbType.DataSource = EquipmentType.Select();
			cmbAvoid.DataSource = Avoid.Select();
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
			var equipment = new Equipment
			{
				ID = ConvertUtil.ToInt(txtID.Text),
				Name = ConvertUtil.ToString(txtName.Text).Trim(),
				TypeID = ConvertUtil.ToInt(cmbType.SelectedValue),
				Abbr = ConvertUtil.ToString(txtAbbr.Text).Trim(),
				CanRemodel = chkCanRemodel.Checked,
				AntiAir = ConvertUtil.ToInt(numAntiAir.Value),
				Torpedo = ConvertUtil.ToInt(numTorpedo.Value),
				Bomber = ConvertUtil.ToInt(numBomber.Value),
				Interception = ConvertUtil.ToInt(numInterception.Value),
				AntiBomber = ConvertUtil.ToInt(numAntiBomber.Value),
				Scout = ConvertUtil.ToInt(numScout.Value),
				Radius = ConvertUtil.ToInt(numRadius.Value),
				Cost = ConvertUtil.ToInt(numCost.Value),
				AvoidID = ConvertUtil.ToInt(cmbAvoid.SelectedValue),
			};

			if (HasError(equipment)) return;
			if (MessageBox.Show("登録を行います。", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK) return;

			using (var db = new DBManager())
			{
				try
				{
					db.CreateConnection();
					db.BeginTran();

					// 新規追加
					if (EditEquipmentId == 0)
					{
						// equipments 登録
						equipment.Insert(db);

					}
					// 編集
					else
					{
						// equipments 更新
						Equipment.Delete(db, equipment.ID);
						equipment.Insert(db);
					}

					db.Commit();

					MessageBox.Show("登録完了", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
					Close();
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
		/// <param name="equipment">チェック対象インスタンス</param>
		/// <returns></returns>
		private bool HasError(Equipment equipment)
		{
			if (equipment.ID == 0)
			{
				MessageBox.Show("ID未入力エラー", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtID.SelectAll();
				ActiveControl = txtID;
				return true;
			}
			if (EditEquipmentId == 0 && new Equipment(equipment.ID).ID > 0)
			{
				MessageBox.Show("ID重複エラー", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtID.SelectAll();
				ActiveControl = txtID;
				return true;
			}
			if (equipment.Name == "")
			{
				MessageBox.Show("名前未入力エラー", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				ActiveControl = txtID;
				return true;
			}
			if (equipment.TypeID == 0)
			{
				MessageBox.Show("種別未選択エラー", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return true;
			}

			return false;
		}
	}
}
