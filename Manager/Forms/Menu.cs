using Manager.Forms;
using Manager.Models;
using System;
using System.Windows.Forms;

namespace Manager
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void BtnEnd_Click(object sender, EventArgs e)
		{
			Close();
		}
		/// <summary>
		/// 装備編集
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnEquipmentEdit_Click(object sender, EventArgs e)
		{
			using (var form = new FrmEquipmentList())
			{
				Hide();
				form.ShowDialog();
				Show();
			}
		}
		/// <summary>
		/// 艦娘編集
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnShipEdit_Click(object sender, EventArgs e)
		{
			using (var form = new FrmShipList())
			{
				Hide();
				form.ShowDialog();
				Show();
			}
		}
		/// <summary>
		/// 海域編集
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnMapEdit(object sender, EventArgs e)
		{
			using (var form = new FrmMapMaster())
			{
				Hide();
				form.ShowDialog();
				Show();
			}
		}

		/// <summary>
		/// 敵艦編集
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnEnemyEdit_Click(object sender, EventArgs e)
		{
			using (var form = new FrmEnemyList())
			{
				Hide();
				form.ShowDialog();
				Show();
			}
		}

		/// <summary>
		/// ENEMY_PATTERN出力
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnOutputEnemyPatterns_Click(object sender, EventArgs e)
		{
			txtOutput.Text = Enemy.OutputEnemyPatterns();
			MessageBox.Show("出力しました", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		/// <summary>
		/// ENEMY_DATA出力
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnOutputEnemies_Click(object sender, EventArgs e)
		{
			txtOutput.Text = Enemy.OutputEnemies();
			MessageBox.Show("出力しました", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		/// <summary>
		/// SHIP_DATA出力
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnOutputShips_Click(object sender, EventArgs e)
		{
			txtOutput.Text = Ship.OutputShip();
			MessageBox.Show("出力しました", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		/// <summary>
		/// PLANE_DATA出力
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnOutputEquipments_Click(object sender, EventArgs e)
		{
			txtOutput.Text = Equipment.OutputEquipment();
			MessageBox.Show("出力しました", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}
