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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			this.cmbWorld = new System.Windows.Forms.ComboBox();
			this.cmbMap = new System.Windows.Forms.ComboBox();
			this.cmbNode = new System.Windows.Forms.ComboBox();
			this.btnAddWorld = new System.Windows.Forms.Button();
			this.btnAddMap = new System.Windows.Forms.Button();
			this.btnAddNode = new System.Windows.Forms.Button();
			this.dgvPatterns = new System.Windows.Forms.DataGridView();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnAddPattern = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnSearch = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgvPatterns)).BeginInit();
			this.SuspendLayout();
			// 
			// cmbWorld
			// 
			this.cmbWorld.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbWorld.FormattingEnabled = true;
			this.cmbWorld.Location = new System.Drawing.Point(12, 59);
			this.cmbWorld.Name = "cmbWorld";
			this.cmbWorld.Size = new System.Drawing.Size(192, 23);
			this.cmbWorld.TabIndex = 0;
			this.cmbWorld.SelectedIndexChanged += new System.EventHandler(this.CmbWorld_SelectedIndexChanged);
			// 
			// cmbMap
			// 
			this.cmbMap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMap.FormattingEnabled = true;
			this.cmbMap.Location = new System.Drawing.Point(210, 60);
			this.cmbMap.Name = "cmbMap";
			this.cmbMap.Size = new System.Drawing.Size(172, 23);
			this.cmbMap.TabIndex = 1;
			this.cmbMap.SelectedIndexChanged += new System.EventHandler(this.CmbMap_SelectedIndexChanged);
			// 
			// cmbNode
			// 
			this.cmbNode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbNode.FormattingEnabled = true;
			this.cmbNode.Location = new System.Drawing.Point(388, 60);
			this.cmbNode.Name = "cmbNode";
			this.cmbNode.Size = new System.Drawing.Size(121, 23);
			this.cmbNode.TabIndex = 2;
			this.cmbNode.SelectedIndexChanged += new System.EventHandler(this.CmbNode_SelectedIndexChanged);
			// 
			// btnAddWorld
			// 
			this.btnAddWorld.Location = new System.Drawing.Point(12, 12);
			this.btnAddWorld.Name = "btnAddWorld";
			this.btnAddWorld.Size = new System.Drawing.Size(192, 35);
			this.btnAddWorld.TabIndex = 3;
			this.btnAddWorld.Text = "海域追加";
			this.btnAddWorld.UseVisualStyleBackColor = true;
			this.btnAddWorld.Click += new System.EventHandler(this.BtnAddWorld_Click);
			// 
			// btnAddMap
			// 
			this.btnAddMap.Location = new System.Drawing.Point(210, 12);
			this.btnAddMap.Name = "btnAddMap";
			this.btnAddMap.Size = new System.Drawing.Size(172, 35);
			this.btnAddMap.TabIndex = 4;
			this.btnAddMap.Text = "マップ追加";
			this.btnAddMap.UseVisualStyleBackColor = true;
			this.btnAddMap.Click += new System.EventHandler(this.BtnAddMap_Click);
			// 
			// btnAddNode
			// 
			this.btnAddNode.Location = new System.Drawing.Point(388, 12);
			this.btnAddNode.Name = "btnAddNode";
			this.btnAddNode.Size = new System.Drawing.Size(121, 35);
			this.btnAddNode.TabIndex = 5;
			this.btnAddNode.Text = "マス追加";
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
			this.dgvPatterns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvPatterns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column1});
			this.dgvPatterns.Location = new System.Drawing.Point(12, 92);
			this.dgvPatterns.MultiSelect = false;
			this.dgvPatterns.Name = "dgvPatterns";
			this.dgvPatterns.RowHeadersVisible = false;
			this.dgvPatterns.RowTemplate.Height = 21;
			this.dgvPatterns.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvPatterns.Size = new System.Drawing.Size(825, 221);
			this.dgvPatterns.TabIndex = 6;
			this.dgvPatterns.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPatterns_CellDoubleClick);
			// 
			// Column2
			// 
			this.Column2.DataPropertyName = "map_name";
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.Column2.DefaultCellStyle = dataGridViewCellStyle1;
			this.Column2.HeaderText = "海域";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column2.Width = 64;
			// 
			// Column3
			// 
			this.Column3.DataPropertyName = "name";
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.Column3.DefaultCellStyle = dataGridViewCellStyle2;
			this.Column3.HeaderText = "セル";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			this.Column3.Width = 64;
			// 
			// Column4
			// 
			this.Column4.DataPropertyName = "node_type";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.Column4.DefaultCellStyle = dataGridViewCellStyle3;
			this.Column4.HeaderText = "形式";
			this.Column4.Name = "Column4";
			this.Column4.ReadOnly = true;
			this.Column4.Width = 84;
			// 
			// Column5
			// 
			this.Column5.DataPropertyName = "formation";
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.Column5.DefaultCellStyle = dataGridViewCellStyle4;
			this.Column5.HeaderText = "陣形";
			this.Column5.Name = "Column5";
			this.Column5.ReadOnly = true;
			this.Column5.Width = 64;
			// 
			// Column6
			// 
			this.Column6.DataPropertyName = "level";
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.Column6.DefaultCellStyle = dataGridViewCellStyle5;
			this.Column6.HeaderText = "Lv";
			this.Column6.Name = "Column6";
			this.Column6.ReadOnly = true;
			this.Column6.Width = 32;
			// 
			// Column7
			// 
			this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Column7.DataPropertyName = "enemy_name";
			this.Column7.HeaderText = "敵一覧";
			this.Column7.Name = "Column7";
			this.Column7.ReadOnly = true;
			// 
			// Column1
			// 
			this.Column1.DataPropertyName = "node_detail_id";
			this.Column1.HeaderText = "セル詳細ID";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Visible = false;
			// 
			// btnAddPattern
			// 
			this.btnAddPattern.Enabled = false;
			this.btnAddPattern.Location = new System.Drawing.Point(612, 53);
			this.btnAddPattern.Name = "btnAddPattern";
			this.btnAddPattern.Size = new System.Drawing.Size(225, 35);
			this.btnAddPattern.TabIndex = 7;
			this.btnAddPattern.Text = "パターン追加";
			this.btnAddPattern.UseVisualStyleBackColor = true;
			this.btnAddPattern.Click += new System.EventHandler(this.BtnAddPattern_Click);
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(746, 12);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(91, 35);
			this.btnClose.TabIndex = 9;
			this.btnClose.Text = "閉じる";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(515, 53);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(91, 35);
			this.btnSearch.TabIndex = 10;
			this.btnSearch.Text = "検索";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
			// 
			// FrmMapMaster
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(849, 325);
			this.Controls.Add(this.btnSearch);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnAddPattern);
			this.Controls.Add(this.dgvPatterns);
			this.Controls.Add(this.btnAddNode);
			this.Controls.Add(this.btnAddMap);
			this.Controls.Add(this.btnAddWorld);
			this.Controls.Add(this.cmbNode);
			this.Controls.Add(this.cmbMap);
			this.Controls.Add(this.cmbWorld);
			this.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "FrmMapMaster";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "海域編集";
			this.Load += new System.EventHandler(this.FrmMapMaster_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvPatterns)).EndInit();
			this.ResumeLayout(false);

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
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
	}
}