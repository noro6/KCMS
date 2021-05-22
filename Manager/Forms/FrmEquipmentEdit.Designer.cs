namespace Manager.Forms
{
	partial class FrmEquipmentEdit
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.txtID = new System.Windows.Forms.TextBox();
			this.txtName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.cmbType = new System.Windows.Forms.ComboBox();
			this.txtAbbr = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.chkCanRemodel = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.numAntiAir = new System.Windows.Forms.NumericUpDown();
			this.label15 = new System.Windows.Forms.Label();
			this.numTorpedo = new System.Windows.Forms.NumericUpDown();
			this.numBomber = new System.Windows.Forms.NumericUpDown();
			this.numInterception = new System.Windows.Forms.NumericUpDown();
			this.numAntiBomber = new System.Windows.Forms.NumericUpDown();
			this.numCost = new System.Windows.Forms.NumericUpDown();
			this.numRadius = new System.Windows.Forms.NumericUpDown();
			this.numScout = new System.Windows.Forms.NumericUpDown();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.cmbAvoid = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.numAntiAir)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numTorpedo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numBomber)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numInterception)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numAntiBomber)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numCost)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numRadius)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numScout)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(14, 69);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(54, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "図鑑ID：";
			// 
			// txtID
			// 
			this.txtID.Location = new System.Drawing.Point(74, 66);
			this.txtID.Name = "txtID";
			this.txtID.Size = new System.Drawing.Size(50, 23);
			this.txtID.TabIndex = 0;
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(74, 95);
			this.txtName.MaxLength = 60;
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(152, 23);
			this.txtName.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(25, 98);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(43, 15);
			this.label2.TabIndex = 2;
			this.label2.Text = "名称：";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(25, 156);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(43, 15);
			this.label3.TabIndex = 5;
			this.label3.Text = "種別：";
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(374, 12);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(88, 35);
			this.btnClose.TabIndex = 15;
			this.btnClose.Text = "閉じる";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(280, 12);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(88, 35);
			this.btnSave.TabIndex = 14;
			this.btnSave.Text = "保存";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
			// 
			// cmbType
			// 
			this.cmbType.DisplayMember = "Name";
			this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbType.Enabled = false;
			this.cmbType.FormattingEnabled = true;
			this.cmbType.Location = new System.Drawing.Point(74, 153);
			this.cmbType.Name = "cmbType";
			this.cmbType.Size = new System.Drawing.Size(152, 23);
			this.cmbType.TabIndex = 3;
			this.cmbType.ValueMember = "ID";
			// 
			// txtAbbr
			// 
			this.txtAbbr.Location = new System.Drawing.Point(74, 124);
			this.txtAbbr.Name = "txtAbbr";
			this.txtAbbr.Size = new System.Drawing.Size(152, 23);
			this.txtAbbr.TabIndex = 2;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(25, 127);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(43, 15);
			this.label5.TabIndex = 36;
			this.label5.Text = "略称：";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(25, 184);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(43, 15);
			this.label6.TabIndex = 38;
			this.label6.Text = "改修：";
			// 
			// chkCanRemodel
			// 
			this.chkCanRemodel.AutoSize = true;
			this.chkCanRemodel.Location = new System.Drawing.Point(74, 183);
			this.chkCanRemodel.Name = "chkCanRemodel";
			this.chkCanRemodel.Size = new System.Drawing.Size(38, 19);
			this.chkCanRemodel.TabIndex = 4;
			this.chkCanRemodel.Text = "可";
			this.chkCanRemodel.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(232, 69);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(43, 15);
			this.label4.TabIndex = 19;
			this.label4.Text = "対空：";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(232, 98);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(43, 15);
			this.label9.TabIndex = 19;
			this.label9.Text = "雷装：";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(232, 127);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(43, 15);
			this.label12.TabIndex = 19;
			this.label12.Text = "爆装：";
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(232, 156);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(43, 15);
			this.label18.TabIndex = 19;
			this.label18.Text = "迎撃：";
			// 
			// numAntiAir
			// 
			this.numAntiAir.Enabled = false;
			this.numAntiAir.Location = new System.Drawing.Point(281, 67);
			this.numAntiAir.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numAntiAir.Name = "numAntiAir";
			this.numAntiAir.Size = new System.Drawing.Size(57, 23);
			this.numAntiAir.TabIndex = 5;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(232, 185);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(43, 15);
			this.label15.TabIndex = 19;
			this.label15.Text = "対爆：";
			// 
			// numTorpedo
			// 
			this.numTorpedo.Enabled = false;
			this.numTorpedo.Location = new System.Drawing.Point(281, 96);
			this.numTorpedo.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numTorpedo.Name = "numTorpedo";
			this.numTorpedo.Size = new System.Drawing.Size(57, 23);
			this.numTorpedo.TabIndex = 6;
			// 
			// numBomber
			// 
			this.numBomber.Enabled = false;
			this.numBomber.Location = new System.Drawing.Point(281, 125);
			this.numBomber.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numBomber.Name = "numBomber";
			this.numBomber.Size = new System.Drawing.Size(57, 23);
			this.numBomber.TabIndex = 7;
			// 
			// numInterception
			// 
			this.numInterception.Enabled = false;
			this.numInterception.Location = new System.Drawing.Point(281, 154);
			this.numInterception.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numInterception.Name = "numInterception";
			this.numInterception.Size = new System.Drawing.Size(57, 23);
			this.numInterception.TabIndex = 8;
			// 
			// numAntiBomber
			// 
			this.numAntiBomber.Enabled = false;
			this.numAntiBomber.Location = new System.Drawing.Point(281, 183);
			this.numAntiBomber.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numAntiBomber.Name = "numAntiBomber";
			this.numAntiBomber.Size = new System.Drawing.Size(57, 23);
			this.numAntiBomber.TabIndex = 9;
			// 
			// numCost
			// 
			this.numCost.Enabled = false;
			this.numCost.Location = new System.Drawing.Point(405, 125);
			this.numCost.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numCost.Name = "numCost";
			this.numCost.Size = new System.Drawing.Size(57, 23);
			this.numCost.TabIndex = 12;
			// 
			// numRadius
			// 
			this.numRadius.Enabled = false;
			this.numRadius.Location = new System.Drawing.Point(405, 96);
			this.numRadius.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numRadius.Name = "numRadius";
			this.numRadius.Size = new System.Drawing.Size(57, 23);
			this.numRadius.TabIndex = 11;
			// 
			// numScout
			// 
			this.numScout.Enabled = false;
			this.numScout.Location = new System.Drawing.Point(405, 67);
			this.numScout.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numScout.Name = "numScout";
			this.numScout.Size = new System.Drawing.Size(57, 23);
			this.numScout.TabIndex = 10;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(355, 127);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(44, 15);
			this.label10.TabIndex = 46;
			this.label10.Text = "コスト：";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(356, 98);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(43, 15);
			this.label11.TabIndex = 47;
			this.label11.Text = "半径：";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(356, 69);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(43, 15);
			this.label13.TabIndex = 48;
			this.label13.Text = "索敵：";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(355, 157);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(43, 15);
			this.label7.TabIndex = 49;
			this.label7.Text = "回避：";
			// 
			// cmbAvoid
			// 
			this.cmbAvoid.DisplayMember = "Name";
			this.cmbAvoid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbAvoid.FormattingEnabled = true;
			this.cmbAvoid.Location = new System.Drawing.Point(405, 154);
			this.cmbAvoid.Name = "cmbAvoid";
			this.cmbAvoid.Size = new System.Drawing.Size(57, 23);
			this.cmbAvoid.TabIndex = 13;
			this.cmbAvoid.ValueMember = "ID";
			// 
			// FrmEquipmentEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(474, 222);
			this.Controls.Add(this.cmbAvoid);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.numCost);
			this.Controls.Add(this.numRadius);
			this.Controls.Add(this.numScout);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.chkCanRemodel);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtAbbr);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.cmbType);
			this.Controls.Add(this.numAntiBomber);
			this.Controls.Add(this.numInterception);
			this.Controls.Add(this.numBomber);
			this.Controls.Add(this.numTorpedo);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.numAntiAir);
			this.Controls.Add(this.label18);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtID);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "FrmEquipmentEdit";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "装備編集";
			this.Load += new System.EventHandler(this.FrmEnemyEdit_Load);
			((System.ComponentModel.ISupportInitialize)(this.numAntiAir)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numTorpedo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numBomber)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numInterception)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numAntiBomber)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numCost)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numRadius)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numScout)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtID;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.ComboBox cmbType;
		private System.Windows.Forms.TextBox txtAbbr;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckBox chkCanRemodel;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.NumericUpDown numAntiAir;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.NumericUpDown numTorpedo;
		private System.Windows.Forms.NumericUpDown numBomber;
		private System.Windows.Forms.NumericUpDown numInterception;
		private System.Windows.Forms.NumericUpDown numAntiBomber;
		private System.Windows.Forms.NumericUpDown numCost;
		private System.Windows.Forms.NumericUpDown numRadius;
		private System.Windows.Forms.NumericUpDown numScout;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox cmbAvoid;
	}
}