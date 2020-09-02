namespace Manager.Forms
{
	partial class FrmShipEdit
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
			this.txtAlbumID = new System.Windows.Forms.TextBox();
			this.txtName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.numSlot1 = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.numSlot2 = new System.Windows.Forms.NumericUpDown();
			this.label9 = new System.Windows.Forms.Label();
			this.numSlot3 = new System.Windows.Forms.NumericUpDown();
			this.label12 = new System.Windows.Forms.Label();
			this.numSlot5 = new System.Windows.Forms.NumericUpDown();
			this.label15 = new System.Windows.Forms.Label();
			this.numSlot4 = new System.Windows.Forms.NumericUpDown();
			this.label18 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.cmbOriginalShip = new System.Windows.Forms.ComboBox();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.cmbType = new System.Windows.Forms.ComboBox();
			this.txtID = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.chkIsFinal = new System.Windows.Forms.CheckBox();
			this.chkEnabledSlot1 = new System.Windows.Forms.CheckBox();
			this.chkEnabledSlot2 = new System.Windows.Forms.CheckBox();
			this.chkEnabledSlot4 = new System.Windows.Forms.CheckBox();
			this.chkEnabledSlot3 = new System.Windows.Forms.CheckBox();
			this.chkEnabledSlot5 = new System.Windows.Forms.CheckBox();
			this.label7 = new System.Windows.Forms.Label();
			this.chkEnabled = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.numSlot1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numSlot2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numSlot3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numSlot5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numSlot4)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 98);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(54, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "図鑑ID：";
			// 
			// txtAlbumID
			// 
			this.txtAlbumID.Location = new System.Drawing.Point(72, 95);
			this.txtAlbumID.Name = "txtAlbumID";
			this.txtAlbumID.Size = new System.Drawing.Size(50, 23);
			this.txtAlbumID.TabIndex = 0;
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(72, 124);
			this.txtName.MaxLength = 60;
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(138, 23);
			this.txtName.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(23, 127);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(43, 15);
			this.label2.TabIndex = 2;
			this.label2.Text = "艦名：";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(23, 185);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(43, 15);
			this.label3.TabIndex = 5;
			this.label3.Text = "艦種：";
			// 
			// numSlot1
			// 
			this.numSlot1.Location = new System.Drawing.Point(343, 67);
			this.numSlot1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numSlot1.Name = "numSlot1";
			this.numSlot1.Size = new System.Drawing.Size(50, 23);
			this.numSlot1.TabIndex = 8;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(232, 69);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(49, 15);
			this.label4.TabIndex = 19;
			this.label4.Text = "搭載1：";
			// 
			// numSlot2
			// 
			this.numSlot2.Location = new System.Drawing.Point(343, 96);
			this.numSlot2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numSlot2.Name = "numSlot2";
			this.numSlot2.Size = new System.Drawing.Size(50, 23);
			this.numSlot2.TabIndex = 10;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(232, 98);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(49, 15);
			this.label9.TabIndex = 19;
			this.label9.Text = "搭載2：";
			// 
			// numSlot3
			// 
			this.numSlot3.Location = new System.Drawing.Point(343, 125);
			this.numSlot3.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numSlot3.Name = "numSlot3";
			this.numSlot3.Size = new System.Drawing.Size(50, 23);
			this.numSlot3.TabIndex = 12;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(232, 127);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(49, 15);
			this.label12.TabIndex = 19;
			this.label12.Text = "搭載3：";
			// 
			// numSlot5
			// 
			this.numSlot5.Location = new System.Drawing.Point(343, 183);
			this.numSlot5.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numSlot5.Name = "numSlot5";
			this.numSlot5.Size = new System.Drawing.Size(50, 23);
			this.numSlot5.TabIndex = 16;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(232, 185);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(49, 15);
			this.label15.TabIndex = 19;
			this.label15.Text = "搭載5：";
			// 
			// numSlot4
			// 
			this.numSlot4.Location = new System.Drawing.Point(343, 154);
			this.numSlot4.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numSlot4.Name = "numSlot4";
			this.numSlot4.Size = new System.Drawing.Size(50, 23);
			this.numSlot4.TabIndex = 14;
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(232, 156);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(49, 15);
			this.label18.TabIndex = 19;
			this.label18.Text = "搭載4：";
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(23, 156);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(43, 15);
			this.label21.TabIndex = 31;
			this.label21.Text = "無印：";
			// 
			// cmbOriginalShip
			// 
			this.cmbOriginalShip.DisplayMember = "Name";
			this.cmbOriginalShip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbOriginalShip.FormattingEnabled = true;
			this.cmbOriginalShip.Location = new System.Drawing.Point(72, 153);
			this.cmbOriginalShip.Name = "cmbOriginalShip";
			this.cmbOriginalShip.Size = new System.Drawing.Size(138, 23);
			this.cmbOriginalShip.TabIndex = 3;
			this.cmbOriginalShip.ValueMember = "ID";
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(297, 12);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(88, 35);
			this.btnClose.TabIndex = 18;
			this.btnClose.Text = "閉じる";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(203, 12);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(88, 35);
			this.btnSave.TabIndex = 17;
			this.btnSave.Text = "保存";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
			// 
			// cmbType
			// 
			this.cmbType.DisplayMember = "Name";
			this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbType.FormattingEnabled = true;
			this.cmbType.Location = new System.Drawing.Point(72, 182);
			this.cmbType.Name = "cmbType";
			this.cmbType.Size = new System.Drawing.Size(138, 23);
			this.cmbType.TabIndex = 4;
			this.cmbType.ValueMember = "ID";
			// 
			// txtID
			// 
			this.txtID.Location = new System.Drawing.Point(72, 66);
			this.txtID.Name = "txtID";
			this.txtID.Size = new System.Drawing.Size(50, 23);
			this.txtID.TabIndex = 6;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(36, 70);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(30, 15);
			this.label5.TabIndex = 36;
			this.label5.Text = "ID：";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(23, 213);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(43, 15);
			this.label6.TabIndex = 38;
			this.label6.Text = "状態：";
			// 
			// chkIsFinal
			// 
			this.chkIsFinal.AutoSize = true;
			this.chkIsFinal.Location = new System.Drawing.Point(72, 212);
			this.chkIsFinal.Name = "chkIsFinal";
			this.chkIsFinal.Size = new System.Drawing.Size(98, 19);
			this.chkIsFinal.TabIndex = 5;
			this.chkIsFinal.Text = "最終改造状態";
			this.chkIsFinal.UseVisualStyleBackColor = true;
			// 
			// chkEnabledSlot1
			// 
			this.chkEnabledSlot1.AutoSize = true;
			this.chkEnabledSlot1.Location = new System.Drawing.Point(287, 69);
			this.chkEnabledSlot1.Name = "chkEnabledSlot1";
			this.chkEnabledSlot1.Size = new System.Drawing.Size(50, 19);
			this.chkEnabledSlot1.TabIndex = 7;
			this.chkEnabledSlot1.Text = "有効";
			this.chkEnabledSlot1.UseVisualStyleBackColor = true;
			this.chkEnabledSlot1.CheckedChanged += new System.EventHandler(this.ChkEnabledSlot1_CheckedChanged);
			// 
			// chkEnabledSlot2
			// 
			this.chkEnabledSlot2.AutoSize = true;
			this.chkEnabledSlot2.Location = new System.Drawing.Point(287, 97);
			this.chkEnabledSlot2.Name = "chkEnabledSlot2";
			this.chkEnabledSlot2.Size = new System.Drawing.Size(50, 19);
			this.chkEnabledSlot2.TabIndex = 9;
			this.chkEnabledSlot2.Text = "有効";
			this.chkEnabledSlot2.UseVisualStyleBackColor = true;
			this.chkEnabledSlot2.CheckedChanged += new System.EventHandler(this.ChkEnabledSlot2_CheckedChanged);
			// 
			// chkEnabledSlot4
			// 
			this.chkEnabledSlot4.AutoSize = true;
			this.chkEnabledSlot4.Location = new System.Drawing.Point(287, 154);
			this.chkEnabledSlot4.Name = "chkEnabledSlot4";
			this.chkEnabledSlot4.Size = new System.Drawing.Size(50, 19);
			this.chkEnabledSlot4.TabIndex = 13;
			this.chkEnabledSlot4.Text = "有効";
			this.chkEnabledSlot4.UseVisualStyleBackColor = true;
			this.chkEnabledSlot4.CheckedChanged += new System.EventHandler(this.ChkEnabledSlot4_CheckedChanged);
			// 
			// chkEnabledSlot3
			// 
			this.chkEnabledSlot3.AutoSize = true;
			this.chkEnabledSlot3.Location = new System.Drawing.Point(287, 126);
			this.chkEnabledSlot3.Name = "chkEnabledSlot3";
			this.chkEnabledSlot3.Size = new System.Drawing.Size(50, 19);
			this.chkEnabledSlot3.TabIndex = 11;
			this.chkEnabledSlot3.Text = "有効";
			this.chkEnabledSlot3.UseVisualStyleBackColor = true;
			this.chkEnabledSlot3.CheckedChanged += new System.EventHandler(this.ChkEnabledSlot3_CheckedChanged);
			// 
			// chkEnabledSlot5
			// 
			this.chkEnabledSlot5.AutoSize = true;
			this.chkEnabledSlot5.Location = new System.Drawing.Point(287, 184);
			this.chkEnabledSlot5.Name = "chkEnabledSlot5";
			this.chkEnabledSlot5.Size = new System.Drawing.Size(50, 19);
			this.chkEnabledSlot5.TabIndex = 15;
			this.chkEnabledSlot5.Text = "有効";
			this.chkEnabledSlot5.UseVisualStyleBackColor = true;
			this.chkEnabledSlot5.CheckedChanged += new System.EventHandler(this.ChkEnabledSlot5_CheckedChanged);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(238, 212);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(43, 15);
			this.label7.TabIndex = 39;
			this.label7.Text = "状態：";
			// 
			// chkEnabled
			// 
			this.chkEnabled.AutoSize = true;
			this.chkEnabled.Location = new System.Drawing.Point(287, 213);
			this.chkEnabled.Name = "chkEnabled";
			this.chkEnabled.Size = new System.Drawing.Size(50, 19);
			this.chkEnabled.TabIndex = 40;
			this.chkEnabled.Text = "有効";
			this.chkEnabled.UseVisualStyleBackColor = true;
			// 
			// FrmShipEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(405, 244);
			this.Controls.Add(this.chkEnabled);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.chkEnabledSlot5);
			this.Controls.Add(this.chkEnabledSlot4);
			this.Controls.Add(this.chkEnabledSlot3);
			this.Controls.Add(this.chkEnabledSlot2);
			this.Controls.Add(this.chkEnabledSlot1);
			this.Controls.Add(this.chkIsFinal);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtID);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.cmbType);
			this.Controls.Add(this.numSlot5);
			this.Controls.Add(this.numSlot4);
			this.Controls.Add(this.numSlot3);
			this.Controls.Add(this.numSlot2);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.numSlot1);
			this.Controls.Add(this.label18);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.cmbOriginalShip);
			this.Controls.Add(this.label21);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtAlbumID);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "FrmShipEdit";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "敵艦編集";
			this.Load += new System.EventHandler(this.FrmEnemyEdit_Load);
			((System.ComponentModel.ISupportInitialize)(this.numSlot1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numSlot2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numSlot3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numSlot5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numSlot4)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtAlbumID;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.ComboBox cmbOriginalShip;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.NumericUpDown numSlot1;
		private System.Windows.Forms.NumericUpDown numSlot2;
		private System.Windows.Forms.NumericUpDown numSlot3;
		private System.Windows.Forms.NumericUpDown numSlot5;
		private System.Windows.Forms.NumericUpDown numSlot4;
		private System.Windows.Forms.ComboBox cmbType;
		private System.Windows.Forms.TextBox txtID;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckBox chkIsFinal;
		private System.Windows.Forms.CheckBox chkEnabledSlot1;
		private System.Windows.Forms.CheckBox chkEnabledSlot2;
		private System.Windows.Forms.CheckBox chkEnabledSlot4;
		private System.Windows.Forms.CheckBox chkEnabledSlot3;
		private System.Windows.Forms.CheckBox chkEnabledSlot5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.CheckBox chkEnabled;
	}
}