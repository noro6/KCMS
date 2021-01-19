using Manager.Forms;
using Manager.Models;
using Manager.Util;
using System;
using System.Windows.Forms;

namespace Manager
{
	public partial class FormMenu : Form
	{

		public FormMenu()
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
		/// 装備カテゴリ出力
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnOutputEquipmentTypes_Click(object sender, EventArgs e)
		{
			txtOutput.Text = "const ITEM_API_TYPE = [\r\n" + EquipmentType.OutputJson() + "];";
			txtOutput.Text += "\r\nconst ITEM_ICON_TYPE = [\r\n" + EquipmentType.OutputJson2() + "];";
			MessageBox.Show("出力しました", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		/// <summary>
		/// 装備データ出力
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnOutputEquipments_Click(object sender, EventArgs e)
		{
			txtOutput.Text = "const ITEM_DATA = [\r\n" + Equipment.OutputJson() + "];";
			MessageBox.Show("出力しました", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		/// <summary>
		/// 艦娘カテゴリ出力
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnOutputShipTypes_Click(object sender, EventArgs e)
		{
			txtOutput.Text = "const SHIP_TYPE = [\r\n" + ShipType.OutputJson() + "];";
			MessageBox.Show("出力しました", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		/// <summary>
		/// 艦娘データ出力
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnOutputShips_Click(object sender, EventArgs e)
		{
			txtOutput.Text = "const SHIP_DATA = [\r\n" + Ship.OutputShip() + "];";
			MessageBox.Show("出力しました", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		/// <summary>
		/// 敵艦カテゴリ出力
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnOutputEnemyTypes_Click(object sender, EventArgs e)
		{
			txtOutput.Text = "const ENEMY_TYPE = [\r\n" + EnemyType.OutputJson() + "];";
			MessageBox.Show("出力しました", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		/// <summary>
		/// 敵艦データ出力
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnOutputEnemies_Click(object sender, EventArgs e)
		{
			txtOutput.Text = "const ENEMY_DATA = [\r\n" + Enemy.OutputJson() + "];\r\n";
			txtOutput.Text += "const ENEMY_ITEM = [\r\n" + EnemyEquipment.OutputJson() + "];";
			MessageBox.Show("出力しました", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		/// <summary>
		/// 海域マップ出力
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnOutputWorlds_Click(object sender, EventArgs e)
		{
			txtOutput.Text = "const WORLD_DATA = [\r\n" + World.OutputJson() + "];\r\n";
			txtOutput.Text += "const MAP_DATA = [\r\n" + Map.OutputJson() + "];";
			MessageBox.Show("出力しました", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		/// <summary>
		/// 敵編成パターン出力
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnOutputEnemyPatterns_Click(object sender, EventArgs e)
		{
			txtOutput.Text = "\"ENEMY_PATTERN\": [\r\n" + Enemy.OutputEnemyPatterns() + "]";
			MessageBox.Show("出力しました", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		/// <summary>
		/// 敵編成パターン出力 poiから
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnOutputEnemyPatterns2_Click(object sender, EventArgs e)
		{
			txtOutput.Text = "\"ENEMY_PATTERN\": [\r\n" + Poi.OutputEnemyPatterns() + "]";
			MessageBox.Show("出力しました", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		/// <summary>
		/// 全出力
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnOutputAll_Click(object sender, EventArgs e)
		{
			var outputText = "";
			outputText += "const ITEM_API_TYPE = [\r\n" + EquipmentType.OutputJson() + "];\r\n";
			outputText += "const ITEM_ICON_TYPE = [\r\n" + EquipmentType.OutputJson2() + "];\r\n";
			outputText += "const ITEM_DATA = [\r\n" + Equipment.OutputJson() + "];\r\n";
			outputText += "const SHIP_TYPE = [\r\n" + ShipType.OutputJson() + "];\r\n";
			outputText += "const SHIP_DATA = [\r\n" + Ship.OutputShip() + "];\r\n";
			outputText += "const ENEMY_TYPE = [\r\n" + EnemyType.OutputJson() + "];\r\n";
			outputText += "const ENEMY_DATA = [\r\n" + Enemy.OutputJson() + "];\r\n";
			outputText += "const ENEMY_ITEM = [\r\n" + EnemyEquipment.OutputJson() + "];\r\n";
			outputText += "const DIFFICULTY = [\r\n" + Level.OutputJson() + "];\r\n";
			outputText += "const WORLD_DATA = [\r\n" + World.OutputJson() + "];\r\n";
			outputText += "const MAP_DATA = [\r\n" + Map.OutputJson() + "];\r\n";
			outputText += "const ENEMY_PATTERN = [\r\n" + Enemy.OutputEnemyPatterns() + "];";

			txtOutput.Text = outputText.Trim();
			MessageBox.Show("出力しました", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		/// <summary>
		/// POICSV取込
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnImportCSV_Click(object sender, EventArgs e)
		{
			Poi.ReadCSVAndRegist();
		}

		/// <summary>
		/// poidbと手入力からハイブリッド出力
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnOutputEnemy_Click(object sender, EventArgs e)
		{
			txtOutput.Text = "\"ENEMY_PATTERN\": [\r\n" + EnemyPattern.OutputEnemyPatterns() + "]";
			MessageBox.Show("出力しました", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}
