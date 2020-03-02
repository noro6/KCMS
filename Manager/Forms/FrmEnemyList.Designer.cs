namespace Manager.Forms
{
	partial class FrmEnemyList
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
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.dgvEnemies = new System.Windows.Forms.DataGridView();
			this.cmbEnemyType = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dgvEnemies)).BeginInit();
			this.SuspendLayout();
			// 
			// txtSearch
			// 
			this.txtSearch.Location = new System.Drawing.Point(94, 65);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(141, 23);
			this.txtSearch.TabIndex = 11;
			this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
			// 
			// dgvEnemies
			// 
			this.dgvEnemies.AllowUserToAddRows = false;
			this.dgvEnemies.AllowUserToDeleteRows = false;
			this.dgvEnemies.AllowUserToResizeColumns = false;
			this.dgvEnemies.AllowUserToResizeRows = false;
			this.dgvEnemies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvEnemies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvEnemies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
			this.dgvEnemies.Location = new System.Drawing.Point(12, 94);
			this.dgvEnemies.MultiSelect = false;
			this.dgvEnemies.Name = "dgvEnemies";
			this.dgvEnemies.RowHeadersVisible = false;
			this.dgvEnemies.RowTemplate.Height = 21;
			this.dgvEnemies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvEnemies.Size = new System.Drawing.Size(916, 363);
			this.dgvEnemies.TabIndex = 12;
			this.dgvEnemies.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvEnemies_CellDoubleClick);
			// 
			// cmbEnemyType
			// 
			this.cmbEnemyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbEnemyType.FormattingEnabled = true;
			this.cmbEnemyType.Location = new System.Drawing.Point(241, 65);
			this.cmbEnemyType.Name = "cmbEnemyType";
			this.cmbEnemyType.Size = new System.Drawing.Size(174, 23);
			this.cmbEnemyType.TabIndex = 1;
			this.cmbEnemyType.SelectedIndexChanged += new System.EventHandler(this.CmbEnemyType_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 68);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(76, 15);
			this.label1.TabIndex = 13;
			this.label1.Text = "IDや敵艦名：";
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(843, 12);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(85, 32);
			this.btnClose.TabIndex = 14;
			this.btnClose.Text = "閉じる";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(843, 56);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(85, 32);
			this.btnAdd.TabIndex = 15;
			this.btnAdd.Text = "新規追加";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
			this.dataGridViewTextBoxColumn1.HeaderText = "ID";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Width = 42;
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
			this.dataGridViewTextBoxColumn2.HeaderText = "名前";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			// 
			// Column1
			// 
			this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Column1.DataPropertyName = "TypeNames";
			this.Column1.HeaderText = "艦種";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			// 
			// Column2
			// 
			this.Column2.DataPropertyName = "equipment1";
			this.Column2.HeaderText = "装備1";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column2.Width = 120;
			// 
			// Column3
			// 
			this.Column3.DataPropertyName = "equipment2";
			this.Column3.HeaderText = "装備2";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			this.Column3.Width = 120;
			// 
			// Column4
			// 
			this.Column4.DataPropertyName = "equipment3";
			this.Column4.HeaderText = "装備3";
			this.Column4.Name = "Column4";
			this.Column4.ReadOnly = true;
			this.Column4.Width = 120;
			// 
			// Column5
			// 
			this.Column5.DataPropertyName = "equipment4";
			this.Column5.HeaderText = "装備4";
			this.Column5.Name = "Column5";
			this.Column5.ReadOnly = true;
			this.Column5.Width = 120;
			// 
			// Column6
			// 
			this.Column6.DataPropertyName = "equipment5";
			this.Column6.HeaderText = "装備5";
			this.Column6.Name = "Column6";
			this.Column6.ReadOnly = true;
			this.Column6.Width = 120;
			// 
			// FrmEnemyList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(940, 469);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dgvEnemies);
			this.Controls.Add(this.txtSearch);
			this.Controls.Add(this.cmbEnemyType);
			this.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "FrmEnemyList";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "敵艦一覧";
			this.Load += new System.EventHandler(this.FrmEnemyList_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvEnemies)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TextBox txtSearch;
		private System.Windows.Forms.DataGridView dgvEnemies;
		private System.Windows.Forms.ComboBox cmbEnemyType;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
	}
}