namespace Manager.Forms
{
	partial class FrmMapMaster
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
			this.cmbWorld = new System.Windows.Forms.ComboBox();
			this.cmbMap = new System.Windows.Forms.ComboBox();
			this.cmbNode = new System.Windows.Forms.ComboBox();
			this.btnAddWorld = new System.Windows.Forms.Button();
			this.btnAddMap = new System.Windows.Forms.Button();
			this.btnAddNode = new System.Windows.Forms.Button();
			this.dgvPatterns = new System.Windows.Forms.DataGridView();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnAddPattern = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnCopyPattern = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnDeleteWorld = new System.Windows.Forms.Button();
			this.btnEditWorld = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnDeleteMap = new System.Windows.Forms.Button();
			this.btnEditMap = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.btnDeleteNode = new System.Windows.Forms.Button();
			this.btnEditNode = new System.Windows.Forms.Button();
			this.btnDown = new System.Windows.Forms.Button();
			this.btnUp = new System.Windows.Forms.Button();
			this.btnUpdateSort = new System.Windows.Forms.Button();
			this.chkKo = new System.Windows.Forms.CheckBox();
			this.chkOtsu = new System.Windows.Forms.CheckBox();
			this.chkHei = new System.Windows.Forms.CheckBox();
			this.chkTei = new System.Windows.Forms.CheckBox();
			this.chkAll = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.dgvPatterns)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmbWorld
			// 
			this.cmbWorld.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbWorld.FormattingEnabled = true;
			this.cmbWorld.Location = new System.Drawing.Point(6, 24);
			this.cmbWorld.Name = "cmbWorld";
			this.cmbWorld.Size = new System.Drawing.Size(288, 23);
			this.cmbWorld.TabIndex = 0;
			this.cmbWorld.SelectedIndexChanged += new System.EventHandler(this.CmbWorld_SelectedIndexChanged);
			// 
			// cmbMap
			// 
			this.cmbMap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMap.FormattingEnabled = true;
			this.cmbMap.Location = new System.Drawing.Point(6, 24);
			this.cmbMap.Name = "cmbMap";
			this.cmbMap.Size = new System.Drawing.Size(225, 23);
			this.cmbMap.TabIndex = 1;
			this.cmbMap.SelectedIndexChanged += new System.EventHandler(this.CmbMap_SelectedIndexChanged);
			// 
			// cmbNode
			// 
			this.cmbNode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbNode.FormattingEnabled = true;
			this.cmbNode.Location = new System.Drawing.Point(6, 24);
			this.cmbNode.Name = "cmbNode";
			this.cmbNode.Size = new System.Drawing.Size(183, 23);
			this.cmbNode.TabIndex = 2;
			this.cmbNode.SelectedValueChanged += new System.EventHandler(this.CmbNode_SelectedValueChanged);
			// 
			// btnAddWorld
			// 
			this.btnAddWorld.Location = new System.Drawing.Point(6, 53);
			this.btnAddWorld.Name = "btnAddWorld";
			this.btnAddWorld.Size = new System.Drawing.Size(92, 23);
			this.btnAddWorld.TabIndex = 3;
			this.btnAddWorld.Text = "追加";
			this.btnAddWorld.UseVisualStyleBackColor = true;
			this.btnAddWorld.Click += new System.EventHandler(this.BtnAddWorld_Click);
			// 
			// btnAddMap
			// 
			this.btnAddMap.Location = new System.Drawing.Point(6, 53);
			this.btnAddMap.Name = "btnAddMap";
			this.btnAddMap.Size = new System.Drawing.Size(71, 23);
			this.btnAddMap.TabIndex = 4;
			this.btnAddMap.Text = "追加";
			this.btnAddMap.UseVisualStyleBackColor = true;
			this.btnAddMap.Click += new System.EventHandler(this.BtnAddMap_Click);
			// 
			// btnAddNode
			// 
			this.btnAddNode.Location = new System.Drawing.Point(6, 53);
			this.btnAddNode.Name = "btnAddNode";
			this.btnAddNode.Size = new System.Drawing.Size(57, 23);
			this.btnAddNode.TabIndex = 5;
			this.btnAddNode.Text = "追加";
			this.btnAddNode.UseVisualStyleBackColor = true;
			this.btnAddNode.Click += new System.EventHandler(this.BtnAddNode_Click);
			// 
			// dgvPatterns
			// 
			this.dgvPatterns.AllowUserToAddRows = false;
			this.dgvPatterns.AllowUserToDeleteRows = false;
			this.dgvPatterns.AllowUserToResizeRows = false;
			this.dgvPatterns.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle8.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvPatterns.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
			this.dgvPatterns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvPatterns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column2,
            this.Column7,
            this.Column1});
			this.dgvPatterns.Location = new System.Drawing.Point(12, 130);
			this.dgvPatterns.MultiSelect = false;
			this.dgvPatterns.Name = "dgvPatterns";
			this.dgvPatterns.RowHeadersVisible = false;
			this.dgvPatterns.RowTemplate.Height = 21;
			this.dgvPatterns.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvPatterns.Size = new System.Drawing.Size(941, 219);
			this.dgvPatterns.TabIndex = 6;
			this.dgvPatterns.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPatterns_CellDoubleClick);
			// 
			// Column3
			// 
			this.Column3.DataPropertyName = "NodeRemarks";
			dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.Column3.DefaultCellStyle = dataGridViewCellStyle9;
			this.Column3.HeaderText = "セル";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Column3.Width = 80;
			// 
			// Column4
			// 
			this.Column4.DataPropertyName = "TypeName";
			dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.Column4.DefaultCellStyle = dataGridViewCellStyle10;
			this.Column4.HeaderText = "形式";
			this.Column4.Name = "Column4";
			this.Column4.ReadOnly = true;
			this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Column4.Width = 80;
			// 
			// Column5
			// 
			this.Column5.DataPropertyName = "FormationName";
			dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.Column5.DefaultCellStyle = dataGridViewCellStyle11;
			this.Column5.HeaderText = "陣形";
			this.Column5.Name = "Column5";
			this.Column5.ReadOnly = true;
			this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Column5.Width = 64;
			// 
			// Column6
			// 
			this.Column6.DataPropertyName = "LevelName";
			dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.Column6.DefaultCellStyle = dataGridViewCellStyle12;
			this.Column6.HeaderText = "Lv";
			this.Column6.Name = "Column6";
			this.Column6.ReadOnly = true;
			this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Column6.Width = 32;
			// 
			// Column2
			// 
			this.Column2.DataPropertyName = "AirPower";
			dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.Column2.DefaultCellStyle = dataGridViewCellStyle13;
			this.Column2.HeaderText = "制空";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Column2.Width = 48;
			// 
			// Column7
			// 
			this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Column7.DataPropertyName = "EnemyName";
			dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.Column7.DefaultCellStyle = dataGridViewCellStyle14;
			this.Column7.HeaderText = "敵一覧";
			this.Column7.Name = "Column7";
			this.Column7.ReadOnly = true;
			this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// Column1
			// 
			this.Column1.DataPropertyName = "DetailId";
			this.Column1.HeaderText = "セル詳細ID";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Visible = false;
			// 
			// btnAddPattern
			// 
			this.btnAddPattern.Enabled = false;
			this.btnAddPattern.Location = new System.Drawing.Point(766, 24);
			this.btnAddPattern.Name = "btnAddPattern";
			this.btnAddPattern.Size = new System.Drawing.Size(110, 32);
			this.btnAddPattern.TabIndex = 7;
			this.btnAddPattern.Text = "パターン追加";
			this.btnAddPattern.UseVisualStyleBackColor = true;
			this.btnAddPattern.Click += new System.EventHandler(this.BtnAddPattern_Click);
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(882, 24);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(110, 32);
			this.btnClose.TabIndex = 9;
			this.btnClose.Text = "閉じる";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
			// 
			// btnCopyPattern
			// 
			this.btnCopyPattern.Location = new System.Drawing.Point(766, 62);
			this.btnCopyPattern.Name = "btnCopyPattern";
			this.btnCopyPattern.Size = new System.Drawing.Size(110, 32);
			this.btnCopyPattern.TabIndex = 11;
			this.btnCopyPattern.Text = "複製して新規";
			this.btnCopyPattern.UseVisualStyleBackColor = true;
			this.btnCopyPattern.Click += new System.EventHandler(this.BtnCopyPattern_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnDeleteWorld);
			this.groupBox1.Controls.Add(this.btnEditWorld);
			this.groupBox1.Controls.Add(this.cmbWorld);
			this.groupBox1.Controls.Add(this.btnAddWorld);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(300, 82);
			this.groupBox1.TabIndex = 12;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "海域";
			// 
			// btnDeleteWorld
			// 
			this.btnDeleteWorld.Location = new System.Drawing.Point(202, 53);
			this.btnDeleteWorld.Name = "btnDeleteWorld";
			this.btnDeleteWorld.Size = new System.Drawing.Size(92, 23);
			this.btnDeleteWorld.TabIndex = 5;
			this.btnDeleteWorld.Text = "削除";
			this.btnDeleteWorld.UseVisualStyleBackColor = true;
			this.btnDeleteWorld.Click += new System.EventHandler(this.BtnDeleteWorld_Click);
			// 
			// btnEditWorld
			// 
			this.btnEditWorld.Location = new System.Drawing.Point(104, 53);
			this.btnEditWorld.Name = "btnEditWorld";
			this.btnEditWorld.Size = new System.Drawing.Size(92, 23);
			this.btnEditWorld.TabIndex = 4;
			this.btnEditWorld.Text = "編集";
			this.btnEditWorld.UseVisualStyleBackColor = true;
			this.btnEditWorld.Click += new System.EventHandler(this.BtnEditWorld_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btnDeleteMap);
			this.groupBox2.Controls.Add(this.btnEditMap);
			this.groupBox2.Controls.Add(this.btnAddMap);
			this.groupBox2.Controls.Add(this.cmbMap);
			this.groupBox2.Location = new System.Drawing.Point(318, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(237, 82);
			this.groupBox2.TabIndex = 13;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "マップ";
			// 
			// btnDeleteMap
			// 
			this.btnDeleteMap.Location = new System.Drawing.Point(160, 53);
			this.btnDeleteMap.Name = "btnDeleteMap";
			this.btnDeleteMap.Size = new System.Drawing.Size(71, 23);
			this.btnDeleteMap.TabIndex = 5;
			this.btnDeleteMap.Text = "削除";
			this.btnDeleteMap.UseVisualStyleBackColor = true;
			this.btnDeleteMap.Click += new System.EventHandler(this.BtnDeleteMap_Click);
			// 
			// btnEditMap
			// 
			this.btnEditMap.Location = new System.Drawing.Point(83, 53);
			this.btnEditMap.Name = "btnEditMap";
			this.btnEditMap.Size = new System.Drawing.Size(71, 23);
			this.btnEditMap.TabIndex = 4;
			this.btnEditMap.Text = "編集";
			this.btnEditMap.UseVisualStyleBackColor = true;
			this.btnEditMap.Click += new System.EventHandler(this.BtnEditMap_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.btnDeleteNode);
			this.groupBox3.Controls.Add(this.btnEditNode);
			this.groupBox3.Controls.Add(this.cmbNode);
			this.groupBox3.Controls.Add(this.btnAddNode);
			this.groupBox3.Location = new System.Drawing.Point(561, 12);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(196, 82);
			this.groupBox3.TabIndex = 14;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "セル";
			// 
			// btnDeleteNode
			// 
			this.btnDeleteNode.Location = new System.Drawing.Point(132, 53);
			this.btnDeleteNode.Name = "btnDeleteNode";
			this.btnDeleteNode.Size = new System.Drawing.Size(57, 23);
			this.btnDeleteNode.TabIndex = 5;
			this.btnDeleteNode.Text = "削除";
			this.btnDeleteNode.UseVisualStyleBackColor = true;
			this.btnDeleteNode.Click += new System.EventHandler(this.BtnDeleteNode_Click);
			// 
			// btnEditNode
			// 
			this.btnEditNode.Location = new System.Drawing.Point(69, 53);
			this.btnEditNode.Name = "btnEditNode";
			this.btnEditNode.Size = new System.Drawing.Size(57, 23);
			this.btnEditNode.TabIndex = 4;
			this.btnEditNode.Text = "編集";
			this.btnEditNode.UseVisualStyleBackColor = true;
			this.btnEditNode.Click += new System.EventHandler(this.BtnEditNode_Click);
			// 
			// btnDown
			// 
			this.btnDown.Location = new System.Drawing.Point(959, 253);
			this.btnDown.Name = "btnDown";
			this.btnDown.Size = new System.Drawing.Size(33, 60);
			this.btnDown.TabIndex = 22;
			this.btnDown.Text = "↓下へ";
			this.btnDown.UseVisualStyleBackColor = true;
			this.btnDown.Click += new System.EventHandler(this.BtnDown_Click);
			// 
			// btnUp
			// 
			this.btnUp.Location = new System.Drawing.Point(959, 187);
			this.btnUp.Name = "btnUp";
			this.btnUp.Size = new System.Drawing.Size(33, 60);
			this.btnUp.TabIndex = 21;
			this.btnUp.Text = "↑上へ";
			this.btnUp.UseVisualStyleBackColor = true;
			this.btnUp.Click += new System.EventHandler(this.BtnUp_Click);
			// 
			// btnUpdateSort
			// 
			this.btnUpdateSort.Location = new System.Drawing.Point(882, 62);
			this.btnUpdateSort.Name = "btnUpdateSort";
			this.btnUpdateSort.Size = new System.Drawing.Size(110, 32);
			this.btnUpdateSort.TabIndex = 23;
			this.btnUpdateSort.Text = "順序更新";
			this.btnUpdateSort.UseVisualStyleBackColor = true;
			this.btnUpdateSort.Click += new System.EventHandler(this.BtnUpdateSort_Click);
			// 
			// chkKo
			// 
			this.chkKo.AutoSize = true;
			this.chkKo.Checked = true;
			this.chkKo.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkKo.Location = new System.Drawing.Point(12, 105);
			this.chkKo.Name = "chkKo";
			this.chkKo.Size = new System.Drawing.Size(38, 19);
			this.chkKo.TabIndex = 24;
			this.chkKo.Text = "甲";
			this.chkKo.UseVisualStyleBackColor = true;
			this.chkKo.CheckedChanged += new System.EventHandler(this.ChkLevel_CheckedChanged);
			// 
			// chkOtsu
			// 
			this.chkOtsu.AutoSize = true;
			this.chkOtsu.Checked = true;
			this.chkOtsu.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkOtsu.Location = new System.Drawing.Point(56, 105);
			this.chkOtsu.Name = "chkOtsu";
			this.chkOtsu.Size = new System.Drawing.Size(38, 19);
			this.chkOtsu.TabIndex = 25;
			this.chkOtsu.Text = "乙";
			this.chkOtsu.UseVisualStyleBackColor = true;
			this.chkOtsu.CheckedChanged += new System.EventHandler(this.ChkLevel_CheckedChanged);
			// 
			// chkHei
			// 
			this.chkHei.AutoSize = true;
			this.chkHei.Checked = true;
			this.chkHei.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkHei.Location = new System.Drawing.Point(100, 105);
			this.chkHei.Name = "chkHei";
			this.chkHei.Size = new System.Drawing.Size(38, 19);
			this.chkHei.TabIndex = 26;
			this.chkHei.Text = "丙";
			this.chkHei.UseVisualStyleBackColor = true;
			this.chkHei.CheckedChanged += new System.EventHandler(this.ChkLevel_CheckedChanged);
			// 
			// chkTei
			// 
			this.chkTei.AutoSize = true;
			this.chkTei.Checked = true;
			this.chkTei.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkTei.Location = new System.Drawing.Point(144, 105);
			this.chkTei.Name = "chkTei";
			this.chkTei.Size = new System.Drawing.Size(38, 19);
			this.chkTei.TabIndex = 27;
			this.chkTei.Text = "丁";
			this.chkTei.UseVisualStyleBackColor = true;
			this.chkTei.CheckedChanged += new System.EventHandler(this.ChkLevel_CheckedChanged);
			// 
			// chkAll
			// 
			this.chkAll.AutoSize = true;
			this.chkAll.Checked = true;
			this.chkAll.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkAll.Location = new System.Drawing.Point(188, 105);
			this.chkAll.Name = "chkAll";
			this.chkAll.Size = new System.Drawing.Size(50, 19);
			this.chkAll.TabIndex = 28;
			this.chkAll.Text = "全部";
			this.chkAll.UseVisualStyleBackColor = true;
			this.chkAll.CheckedChanged += new System.EventHandler(this.ChkAll_CheckedChanged);
			// 
			// FrmMapMaster
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1004, 361);
			this.Controls.Add(this.chkAll);
			this.Controls.Add(this.chkTei);
			this.Controls.Add(this.chkHei);
			this.Controls.Add(this.chkOtsu);
			this.Controls.Add(this.chkKo);
			this.Controls.Add(this.btnUpdateSort);
			this.Controls.Add(this.btnDown);
			this.Controls.Add(this.btnUp);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnCopyPattern);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnAddPattern);
			this.Controls.Add(this.dgvPatterns);
			this.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MinimumSize = new System.Drawing.Size(1020, 400);
			this.Name = "FrmMapMaster";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "海域編集";
			this.Load += new System.EventHandler(this.FrmMapMaster_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvPatterns)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cmbWorld;
		private System.Windows.Forms.ComboBox cmbMap;
		private System.Windows.Forms.ComboBox cmbNode;
		private System.Windows.Forms.Button btnAddWorld;
		private System.Windows.Forms.Button btnAddMap;
		private System.Windows.Forms.Button btnAddNode;
		private System.Windows.Forms.DataGridView dgvPatterns;
		private System.Windows.Forms.Button btnAddPattern;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnCopyPattern;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnDeleteWorld;
		private System.Windows.Forms.Button btnEditWorld;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnDeleteMap;
		private System.Windows.Forms.Button btnEditMap;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button btnDeleteNode;
		private System.Windows.Forms.Button btnEditNode;
		private System.Windows.Forms.Button btnDown;
		private System.Windows.Forms.Button btnUp;
		private System.Windows.Forms.Button btnUpdateSort;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.CheckBox chkKo;
		private System.Windows.Forms.CheckBox chkOtsu;
		private System.Windows.Forms.CheckBox chkHei;
		private System.Windows.Forms.CheckBox chkTei;
		private System.Windows.Forms.CheckBox chkAll;
	}
}