namespace Manager.Forms
{
	partial class FrmEnemyFleetEdit
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
			this.lblNodeId = new System.Windows.Forms.Label();
			this.dgvFleet = new System.Windows.Forms.DataGridView();
			this.btnInsert = new System.Windows.Forms.Button();
			this.dgvEnemies = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cmbEnemyType = new System.Windows.Forms.ComboBox();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.lblPatternNo = new System.Windows.Forms.Label();
			this.cmbFormation = new System.Windows.Forms.ComboBox();
			this.cmbNodeType = new System.Windows.Forms.ComboBox();
			this.cmbLevel = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.btnUp = new System.Windows.Forms.Button();
			this.btnDown = new System.Windows.Forms.Button();
			this.txtRemarks = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnDelete = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.lblSumAirPower = new System.Windows.Forms.Label();
			this.lblSumAirPower_LB = new System.Windows.Forms.Label();
			this.Column3 = new System.Windows.Forms.DataGridViewButtonColumn();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dgvFleet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvEnemies)).BeginInit();
			this.SuspendLayout();
			// 
			// lblNodeId
			// 
			this.lblNodeId.AutoSize = true;
			this.lblNodeId.Location = new System.Drawing.Point(167, 9);
			this.lblNodeId.Name = "lblNodeId";
			this.lblNodeId.Size = new System.Drawing.Size(13, 15);
			this.lblNodeId.TabIndex = 0;
			this.lblNodeId.Text = "0";
			// 
			// dgvFleet
			// 
			this.dgvFleet.AllowUserToAddRows = false;
			this.dgvFleet.AllowUserToDeleteRows = false;
			this.dgvFleet.AllowUserToResizeColumns = false;
			this.dgvFleet.AllowUserToResizeRows = false;
			this.dgvFleet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvFleet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvFleet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column1,
            this.Column2,
            this.Column5,
            this.Column7});
			this.dgvFleet.Location = new System.Drawing.Point(12, 127);
			this.dgvFleet.MultiSelect = false;
			this.dgvFleet.Name = "dgvFleet";
			this.dgvFleet.RowHeadersVisible = false;
			this.dgvFleet.RowTemplate.Height = 21;
			this.dgvFleet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvFleet.Size = new System.Drawing.Size(380, 277);
			this.dgvFleet.TabIndex = 3;
			this.dgvFleet.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvFleet_CellClick);
			// 
			// btnInsert
			// 
			this.btnInsert.Location = new System.Drawing.Point(398, 243);
			this.btnInsert.Name = "btnInsert";
			this.btnInsert.Size = new System.Drawing.Size(73, 42);
			this.btnInsert.TabIndex = 7;
			this.btnInsert.Text = "←挿入";
			this.btnInsert.UseVisualStyleBackColor = true;
			this.btnInsert.Click += new System.EventHandler(this.BtnInsert_Click);
			// 
			// dgvEnemies
			// 
			this.dgvEnemies.AllowUserToAddRows = false;
			this.dgvEnemies.AllowUserToDeleteRows = false;
			this.dgvEnemies.AllowUserToResizeColumns = false;
			this.dgvEnemies.AllowUserToResizeRows = false;
			this.dgvEnemies.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvEnemies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvEnemies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Column4,
            this.dataGridViewTextBoxColumn2,
            this.Column6});
			this.dgvEnemies.Location = new System.Drawing.Point(477, 127);
			this.dgvEnemies.MultiSelect = false;
			this.dgvEnemies.Name = "dgvEnemies";
			this.dgvEnemies.RowHeadersVisible = false;
			this.dgvEnemies.RowTemplate.Height = 21;
			this.dgvEnemies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvEnemies.Size = new System.Drawing.Size(380, 277);
			this.dgvEnemies.TabIndex = 8;
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
			this.dataGridViewTextBoxColumn1.HeaderText = "ID";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Width = 36;
			// 
			// Column4
			// 
			this.Column4.DataPropertyName = "TypeNames";
			this.Column4.HeaderText = "艦種";
			this.Column4.Name = "Column4";
			this.Column4.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
			this.dataGridViewTextBoxColumn2.HeaderText = "名前";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			// 
			// Column6
			// 
			this.Column6.DataPropertyName = "airpower";
			this.Column6.HeaderText = "制空";
			this.Column6.Name = "Column6";
			this.Column6.ReadOnly = true;
			this.Column6.Width = 56;
			// 
			// cmbEnemyType
			// 
			this.cmbEnemyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbEnemyType.FormattingEnabled = true;
			this.cmbEnemyType.Location = new System.Drawing.Point(477, 98);
			this.cmbEnemyType.Name = "cmbEnemyType";
			this.cmbEnemyType.Size = new System.Drawing.Size(137, 23);
			this.cmbEnemyType.TabIndex = 5;
			this.cmbEnemyType.SelectedIndexChanged += new System.EventHandler(this.CmbEnemyType_SelectedIndexChanged);
			// 
			// txtSearch
			// 
			this.txtSearch.Location = new System.Drawing.Point(620, 98);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(180, 23);
			this.txtSearch.TabIndex = 4;
			this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(477, 12);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(190, 37);
			this.btnSave.TabIndex = 6;
			this.btnSave.Text = "保存";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(768, 12);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(89, 37);
			this.btnClose.TabIndex = 7;
			this.btnClose.Text = "閉じる";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
			// 
			// lblPatternNo
			// 
			this.lblPatternNo.AutoSize = true;
			this.lblPatternNo.Location = new System.Drawing.Point(167, 34);
			this.lblPatternNo.Name = "lblPatternNo";
			this.lblPatternNo.Size = new System.Drawing.Size(13, 15);
			this.lblPatternNo.TabIndex = 13;
			this.lblPatternNo.Text = "0";
			// 
			// cmbFormation
			// 
			this.cmbFormation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbFormation.FormattingEnabled = true;
			this.cmbFormation.Location = new System.Drawing.Point(167, 98);
			this.cmbFormation.Name = "cmbFormation";
			this.cmbFormation.Size = new System.Drawing.Size(161, 23);
			this.cmbFormation.TabIndex = 2;
			// 
			// cmbNodeType
			// 
			this.cmbNodeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbNodeType.FormattingEnabled = true;
			this.cmbNodeType.Location = new System.Drawing.Point(12, 98);
			this.cmbNodeType.Name = "cmbNodeType";
			this.cmbNodeType.Size = new System.Drawing.Size(149, 23);
			this.cmbNodeType.TabIndex = 1;
			this.cmbNodeType.SelectedIndexChanged += new System.EventHandler(this.CmbNodeType_SelectedIndexChanged);
			// 
			// cmbLevel
			// 
			this.cmbLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbLevel.FormattingEnabled = true;
			this.cmbLevel.Location = new System.Drawing.Point(334, 98);
			this.cmbLevel.Name = "cmbLevel";
			this.cmbLevel.Size = new System.Drawing.Size(58, 23);
			this.cmbLevel.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(51, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(110, 15);
			this.label3.TabIndex = 17;
			this.label3.Text = "編集対象Node ID：";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(90, 34);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(71, 15);
			this.label4.TabIndex = 18;
			this.label4.Text = "パターンNo：";
			// 
			// btnUp
			// 
			this.btnUp.Location = new System.Drawing.Point(398, 195);
			this.btnUp.Name = "btnUp";
			this.btnUp.Size = new System.Drawing.Size(73, 42);
			this.btnUp.TabIndex = 19;
			this.btnUp.Text = "↑上へ";
			this.btnUp.UseVisualStyleBackColor = true;
			this.btnUp.Click += new System.EventHandler(this.BtnUp_Click);
			// 
			// btnDown
			// 
			this.btnDown.Location = new System.Drawing.Point(398, 291);
			this.btnDown.Name = "btnDown";
			this.btnDown.Size = new System.Drawing.Size(73, 42);
			this.btnDown.TabIndex = 20;
			this.btnDown.Text = "↓下へ";
			this.btnDown.UseVisualStyleBackColor = true;
			this.btnDown.Click += new System.EventHandler(this.BtnDown_Click);
			// 
			// txtRemarks
			// 
			this.txtRemarks.Location = new System.Drawing.Point(167, 69);
			this.txtRemarks.Name = "txtRemarks";
			this.txtRemarks.Size = new System.Drawing.Size(161, 23);
			this.txtRemarks.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(94, 72);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(67, 15);
			this.label1.TabIndex = 22;
			this.label1.Text = "パターン名：";
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(673, 12);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(89, 37);
			this.btnDelete.TabIndex = 8;
			this.btnDelete.Text = "削除";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(175, 407);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(115, 15);
			this.label2.TabIndex = 23;
			this.label2.Text = "総制空値（基地）：";
			// 
			// lblSumAirPower
			// 
			this.lblSumAirPower.AutoSize = true;
			this.lblSumAirPower.Location = new System.Drawing.Point(292, 407);
			this.lblSumAirPower.Name = "lblSumAirPower";
			this.lblSumAirPower.Size = new System.Drawing.Size(13, 15);
			this.lblSumAirPower.TabIndex = 24;
			this.lblSumAirPower.Text = "0";
			// 
			// lblSumAirPower_LB
			// 
			this.lblSumAirPower_LB.AutoSize = true;
			this.lblSumAirPower_LB.Location = new System.Drawing.Point(331, 407);
			this.lblSumAirPower_LB.Name = "lblSumAirPower_LB";
			this.lblSumAirPower_LB.Size = new System.Drawing.Size(43, 15);
			this.lblSumAirPower_LB.TabIndex = 25;
			this.lblSumAirPower_LB.Text = "（ 0 ）";
			// 
			// Column3
			// 
			this.Column3.HeaderText = "";
			this.Column3.Name = "Column3";
			this.Column3.Text = "削除";
			this.Column3.UseColumnTextForButtonValue = true;
			this.Column3.Width = 46;
			// 
			// Column1
			// 
			this.Column1.DataPropertyName = "id";
			this.Column1.HeaderText = "#";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Column1.Width = 36;
			// 
			// Column2
			// 
			this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Column2.DataPropertyName = "name";
			this.Column2.HeaderText = "名前";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// Column5
			// 
			this.Column5.DataPropertyName = "airpower";
			this.Column5.HeaderText = "制空";
			this.Column5.Name = "Column5";
			this.Column5.ReadOnly = true;
			this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Column5.Width = 56;
			// 
			// Column7
			// 
			this.Column7.DataPropertyName = "LandBaseAirPower";
			this.Column7.HeaderText = "基地";
			this.Column7.Name = "Column7";
			this.Column7.ReadOnly = true;
			this.Column7.Width = 56;
			// 
			// FrmEnemyFleetEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(869, 428);
			this.Controls.Add(this.lblSumAirPower_LB);
			this.Controls.Add(this.lblSumAirPower);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtRemarks);
			this.Controls.Add(this.btnDown);
			this.Controls.Add(this.btnUp);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cmbLevel);
			this.Controls.Add(this.cmbNodeType);
			this.Controls.Add(this.cmbFormation);
			this.Controls.Add(this.lblPatternNo);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.txtSearch);
			this.Controls.Add(this.cmbEnemyType);
			this.Controls.Add(this.dgvEnemies);
			this.Controls.Add(this.btnInsert);
			this.Controls.Add(this.dgvFleet);
			this.Controls.Add(this.lblNodeId);
			this.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "FrmEnemyFleetEdit";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "敵艦隊編集";
			this.Load += new System.EventHandler(this.FrmEnemyFleetEdit_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvFleet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvEnemies)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblNodeId;
		private System.Windows.Forms.DataGridView dgvFleet;
		private System.Windows.Forms.Button btnInsert;
		private System.Windows.Forms.DataGridView dgvEnemies;
		private System.Windows.Forms.ComboBox cmbEnemyType;
		private System.Windows.Forms.TextBox txtSearch;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Label lblPatternNo;
		private System.Windows.Forms.ComboBox cmbFormation;
		private System.Windows.Forms.ComboBox cmbNodeType;
		private System.Windows.Forms.ComboBox cmbLevel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnUp;
		private System.Windows.Forms.Button btnDown;
		private System.Windows.Forms.TextBox txtRemarks;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblSumAirPower;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
		private System.Windows.Forms.Label lblSumAirPower_LB;
		private System.Windows.Forms.DataGridViewButtonColumn Column3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
	}
}