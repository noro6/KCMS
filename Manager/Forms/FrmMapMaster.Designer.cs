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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
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
			this.tabDataBase = new System.Windows.Forms.TabControl();
			this.tabManual = new System.Windows.Forms.TabPage();
			this.tabPoi = new System.Windows.Forms.TabPage();
			this.dgvPois = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnRegistName = new System.Windows.Forms.Button();
			this.btnDeletePoi = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgvPatterns)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.tabDataBase.SuspendLayout();
			this.tabManual.SuspendLayout();
			this.tabPoi.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvPois)).BeginInit();
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
			dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle16.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvPatterns.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
			this.dgvPatterns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvPatterns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column2,
            this.Column7,
            this.Column1});
			this.dgvPatterns.Location = new System.Drawing.Point(6, 6);
			this.dgvPatterns.MultiSelect = false;
			this.dgvPatterns.Name = "dgvPatterns";
			this.dgvPatterns.RowHeadersVisible = false;
			this.dgvPatterns.RowTemplate.Height = 21;
			this.dgvPatterns.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvPatterns.Size = new System.Drawing.Size(956, 264);
			this.dgvPatterns.TabIndex = 6;
			this.dgvPatterns.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPatterns_CellDoubleClick);
			this.dgvPatterns.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPatterns_CellFormatting);
			// 
			// Column3
			// 
			this.Column3.DataPropertyName = "NodeRemarks";
			dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.Column3.DefaultCellStyle = dataGridViewCellStyle17;
			this.Column3.HeaderText = "編成名";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Column3.Width = 80;
			// 
			// Column4
			// 
			this.Column4.DataPropertyName = "TypeName";
			dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.Column4.DefaultCellStyle = dataGridViewCellStyle18;
			this.Column4.HeaderText = "形式";
			this.Column4.Name = "Column4";
			this.Column4.ReadOnly = true;
			this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Column4.Width = 80;
			// 
			// Column5
			// 
			this.Column5.DataPropertyName = "FormationName";
			dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.Column5.DefaultCellStyle = dataGridViewCellStyle19;
			this.Column5.HeaderText = "陣形";
			this.Column5.Name = "Column5";
			this.Column5.ReadOnly = true;
			this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Column5.Width = 64;
			// 
			// Column6
			// 
			this.Column6.DataPropertyName = "LevelName";
			dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.Column6.DefaultCellStyle = dataGridViewCellStyle20;
			this.Column6.HeaderText = "Lv";
			this.Column6.Name = "Column6";
			this.Column6.ReadOnly = true;
			this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Column6.Width = 32;
			// 
			// Column2
			// 
			this.Column2.DataPropertyName = "AirPower";
			dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.Column2.DefaultCellStyle = dataGridViewCellStyle21;
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
			dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.Column7.DefaultCellStyle = dataGridViewCellStyle22;
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
			this.btnAddPattern.Location = new System.Drawing.Point(801, 22);
			this.btnAddPattern.Name = "btnAddPattern";
			this.btnAddPattern.Size = new System.Drawing.Size(110, 32);
			this.btnAddPattern.TabIndex = 7;
			this.btnAddPattern.Text = "パターン追加";
			this.btnAddPattern.UseVisualStyleBackColor = true;
			this.btnAddPattern.Click += new System.EventHandler(this.BtnAddPattern_Click);
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(917, 22);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(110, 32);
			this.btnClose.TabIndex = 9;
			this.btnClose.Text = "閉じる";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
			// 
			// btnCopyPattern
			// 
			this.btnCopyPattern.Location = new System.Drawing.Point(801, 60);
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
			this.btnDown.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.btnDown.Location = new System.Drawing.Point(994, 291);
			this.btnDown.Name = "btnDown";
			this.btnDown.Size = new System.Drawing.Size(33, 60);
			this.btnDown.TabIndex = 22;
			this.btnDown.Text = "↓下へ";
			this.btnDown.UseVisualStyleBackColor = true;
			this.btnDown.Click += new System.EventHandler(this.BtnDown_Click);
			// 
			// btnUp
			// 
			this.btnUp.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.btnUp.Location = new System.Drawing.Point(994, 225);
			this.btnUp.Name = "btnUp";
			this.btnUp.Size = new System.Drawing.Size(33, 60);
			this.btnUp.TabIndex = 21;
			this.btnUp.Text = "↑上へ";
			this.btnUp.UseVisualStyleBackColor = true;
			this.btnUp.Click += new System.EventHandler(this.BtnUp_Click);
			// 
			// btnUpdateSort
			// 
			this.btnUpdateSort.Location = new System.Drawing.Point(801, 98);
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
			this.chkKo.Location = new System.Drawing.Point(16, 100);
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
			this.chkOtsu.Location = new System.Drawing.Point(60, 100);
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
			this.chkHei.Location = new System.Drawing.Point(104, 100);
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
			this.chkTei.Location = new System.Drawing.Point(148, 100);
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
			this.chkAll.Location = new System.Drawing.Point(192, 100);
			this.chkAll.Name = "chkAll";
			this.chkAll.Size = new System.Drawing.Size(50, 19);
			this.chkAll.TabIndex = 28;
			this.chkAll.Text = "全部";
			this.chkAll.UseVisualStyleBackColor = true;
			this.chkAll.CheckedChanged += new System.EventHandler(this.ChkAll_CheckedChanged);
			// 
			// tabDataBase
			// 
			this.tabDataBase.Controls.Add(this.tabManual);
			this.tabDataBase.Controls.Add(this.tabPoi);
			this.tabDataBase.Location = new System.Drawing.Point(12, 125);
			this.tabDataBase.Name = "tabDataBase";
			this.tabDataBase.SelectedIndex = 0;
			this.tabDataBase.Size = new System.Drawing.Size(976, 304);
			this.tabDataBase.TabIndex = 29;
			this.tabDataBase.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
			// 
			// tabManual
			// 
			this.tabManual.Controls.Add(this.dgvPatterns);
			this.tabManual.Location = new System.Drawing.Point(4, 24);
			this.tabManual.Name = "tabManual";
			this.tabManual.Padding = new System.Windows.Forms.Padding(3);
			this.tabManual.Size = new System.Drawing.Size(968, 276);
			this.tabManual.TabIndex = 0;
			this.tabManual.Text = "手動";
			this.tabManual.UseVisualStyleBackColor = true;
			// 
			// tabPoi
			// 
			this.tabPoi.Controls.Add(this.dgvPois);
			this.tabPoi.Location = new System.Drawing.Point(4, 24);
			this.tabPoi.Name = "tabPoi";
			this.tabPoi.Padding = new System.Windows.Forms.Padding(3);
			this.tabPoi.Size = new System.Drawing.Size(968, 276);
			this.tabPoi.TabIndex = 1;
			this.tabPoi.Text = "Poi";
			this.tabPoi.UseVisualStyleBackColor = true;
			// 
			// dgvPois
			// 
			this.dgvPois.AllowUserToAddRows = false;
			this.dgvPois.AllowUserToDeleteRows = false;
			this.dgvPois.AllowUserToResizeRows = false;
			this.dgvPois.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle23.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvPois.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle23;
			this.dgvPois.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvPois.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.Rate,
            this.dataGridViewTextBoxColumn6});
			this.dgvPois.Location = new System.Drawing.Point(6, 6);
			this.dgvPois.MultiSelect = false;
			this.dgvPois.Name = "dgvPois";
			this.dgvPois.RowHeadersVisible = false;
			this.dgvPois.RowTemplate.Height = 21;
			this.dgvPois.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvPois.Size = new System.Drawing.Size(956, 264);
			this.dgvPois.TabIndex = 7;
			this.dgvPois.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPois_CellDoubleClick);
			this.dgvPois.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPois_CellFormatting);
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.DataPropertyName = "NodeRemarks";
			dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle24;
			this.dataGridViewTextBoxColumn1.HeaderText = "編成名";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn1.Width = 80;
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.DataPropertyName = "TypeName";
			dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle25;
			this.dataGridViewTextBoxColumn2.HeaderText = "形式";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn2.Width = 80;
			// 
			// dataGridViewTextBoxColumn3
			// 
			this.dataGridViewTextBoxColumn3.DataPropertyName = "FormationName";
			dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle26;
			this.dataGridViewTextBoxColumn3.HeaderText = "陣形";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.ReadOnly = true;
			this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn3.Width = 64;
			// 
			// dataGridViewTextBoxColumn4
			// 
			this.dataGridViewTextBoxColumn4.DataPropertyName = "LevelName";
			dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle27;
			this.dataGridViewTextBoxColumn4.HeaderText = "Lv";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.ReadOnly = true;
			this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn4.Width = 32;
			// 
			// dataGridViewTextBoxColumn5
			// 
			this.dataGridViewTextBoxColumn5.DataPropertyName = "AirPower";
			dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle28;
			this.dataGridViewTextBoxColumn5.HeaderText = "制空";
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn5.ReadOnly = true;
			this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn5.Width = 48;
			// 
			// Rate
			// 
			this.Rate.DataPropertyName = "Rate";
			dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.Rate.DefaultCellStyle = dataGridViewCellStyle29;
			this.Rate.HeaderText = "割合";
			this.Rate.Name = "Rate";
			this.Rate.ReadOnly = true;
			this.Rate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Rate.Width = 48;
			// 
			// dataGridViewTextBoxColumn6
			// 
			this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn6.DataPropertyName = "EnemyName";
			dataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle30;
			this.dataGridViewTextBoxColumn6.HeaderText = "敵一覧";
			this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			this.dataGridViewTextBoxColumn6.ReadOnly = true;
			this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// btnRegistName
			// 
			this.btnRegistName.Location = new System.Drawing.Point(917, 60);
			this.btnRegistName.Name = "btnRegistName";
			this.btnRegistName.Size = new System.Drawing.Size(110, 32);
			this.btnRegistName.TabIndex = 30;
			this.btnRegistName.Text = "編成取込";
			this.btnRegistName.UseVisualStyleBackColor = true;
			this.btnRegistName.Click += new System.EventHandler(this.btnRegistName_Click);
			// 
			// btnDeletePoi
			// 
			this.btnDeletePoi.Location = new System.Drawing.Point(917, 98);
			this.btnDeletePoi.Name = "btnDeletePoi";
			this.btnDeletePoi.Size = new System.Drawing.Size(110, 32);
			this.btnDeletePoi.TabIndex = 31;
			this.btnDeletePoi.Text = "Poi編成削除";
			this.btnDeletePoi.UseVisualStyleBackColor = true;
			this.btnDeletePoi.Click += new System.EventHandler(this.btnDeletePoi_Click);
			// 
			// FrmMapMaster
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1039, 441);
			this.Controls.Add(this.btnDeletePoi);
			this.Controls.Add(this.btnDown);
			this.Controls.Add(this.btnUpdateSort);
			this.Controls.Add(this.btnUp);
			this.Controls.Add(this.btnRegistName);
			this.Controls.Add(this.chkAll);
			this.Controls.Add(this.chkKo);
			this.Controls.Add(this.tabDataBase);
			this.Controls.Add(this.chkTei);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.chkOtsu);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.chkHei);
			this.Controls.Add(this.btnCopyPattern);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnAddPattern);
			this.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MinimumSize = new System.Drawing.Size(1024, 458);
			this.Name = "FrmMapMaster";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "海域編集";
			this.Load += new System.EventHandler(this.FrmMapMaster_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvPatterns)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.tabDataBase.ResumeLayout(false);
			this.tabManual.ResumeLayout(false);
			this.tabPoi.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvPois)).EndInit();
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
		private System.Windows.Forms.CheckBox chkKo;
		private System.Windows.Forms.CheckBox chkOtsu;
		private System.Windows.Forms.CheckBox chkHei;
		private System.Windows.Forms.CheckBox chkTei;
		private System.Windows.Forms.CheckBox chkAll;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.TabControl tabDataBase;
		private System.Windows.Forms.TabPage tabManual;
		private System.Windows.Forms.TabPage tabPoi;
		private System.Windows.Forms.DataGridView dgvPois;
		private System.Windows.Forms.Button btnRegistName;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
		private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
		private System.Windows.Forms.Button btnDeletePoi;
	}
}