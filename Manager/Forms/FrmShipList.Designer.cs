namespace Manager.Forms
{
	partial class FrmShipList
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
			this.dgvShip = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cmbShipType = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgvShip)).BeginInit();
			this.SuspendLayout();
			// 
			// txtSearch
			// 
			this.txtSearch.Location = new System.Drawing.Point(94, 65);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(141, 23);
			this.txtSearch.TabIndex = 0;
			this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
			// 
			// dgvShip
			// 
			this.dgvShip.AllowUserToAddRows = false;
			this.dgvShip.AllowUserToDeleteRows = false;
			this.dgvShip.AllowUserToResizeColumns = false;
			this.dgvShip.AllowUserToResizeRows = false;
			this.dgvShip.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvShip.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvShip.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
			this.dgvShip.Location = new System.Drawing.Point(12, 94);
			this.dgvShip.MultiSelect = false;
			this.dgvShip.Name = "dgvShip";
			this.dgvShip.RowHeadersVisible = false;
			this.dgvShip.RowTemplate.Height = 21;
			this.dgvShip.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvShip.Size = new System.Drawing.Size(825, 363);
			this.dgvShip.TabIndex = 12;
			this.dgvShip.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvShips_CellDoubleClick);
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
			this.Column1.DataPropertyName = "TypeName";
			this.Column1.HeaderText = "艦種";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			// 
			// Column2
			// 
			this.Column2.DataPropertyName = "slot1";
			this.Column2.HeaderText = "搭載1";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column2.Width = 64;
			// 
			// Column3
			// 
			this.Column3.DataPropertyName = "slot2";
			this.Column3.HeaderText = "搭載2";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			this.Column3.Width = 64;
			// 
			// Column4
			// 
			this.Column4.DataPropertyName = "slot3";
			this.Column4.HeaderText = "搭載3";
			this.Column4.Name = "Column4";
			this.Column4.ReadOnly = true;
			this.Column4.Width = 64;
			// 
			// Column5
			// 
			this.Column5.DataPropertyName = "slot4";
			this.Column5.HeaderText = "搭載4";
			this.Column5.Name = "Column5";
			this.Column5.ReadOnly = true;
			this.Column5.Width = 64;
			// 
			// Column6
			// 
			this.Column6.DataPropertyName = "slot5";
			this.Column6.HeaderText = "搭載5";
			this.Column6.Name = "Column6";
			this.Column6.ReadOnly = true;
			this.Column6.Width = 64;
			// 
			// Column7
			// 
			this.Column7.DataPropertyName = "IsFinalString";
			this.Column7.HeaderText = "最終";
			this.Column7.Name = "Column7";
			this.Column7.ReadOnly = true;
			this.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Column7.Width = 56;
			// 
			// Column8
			// 
			this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Column8.DataPropertyName = "OriginalName";
			this.Column8.HeaderText = "無印";
			this.Column8.Name = "Column8";
			this.Column8.ReadOnly = true;
			// 
			// cmbShipType
			// 
			this.cmbShipType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbShipType.FormattingEnabled = true;
			this.cmbShipType.Location = new System.Drawing.Point(241, 65);
			this.cmbShipType.Name = "cmbShipType";
			this.cmbShipType.Size = new System.Drawing.Size(174, 23);
			this.cmbShipType.TabIndex = 1;
			this.cmbShipType.SelectedIndexChanged += new System.EventHandler(this.CmbShipType_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 68);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 15);
			this.label1.TabIndex = 13;
			this.label1.Text = "IDや艦名：";
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(752, 12);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(85, 32);
			this.btnClose.TabIndex = 2;
			this.btnClose.Text = "閉じる";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(752, 56);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(85, 32);
			this.btnAdd.TabIndex = 3;
			this.btnAdd.Text = "新規追加";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
			// 
			// FrmShipList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(849, 469);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dgvShip);
			this.Controls.Add(this.txtSearch);
			this.Controls.Add(this.cmbShipType);
			this.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "FrmShipList";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "艦娘一覧";
			this.Load += new System.EventHandler(this.FrmShipList_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvShip)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TextBox txtSearch;
		private System.Windows.Forms.DataGridView dgvShip;
		private System.Windows.Forms.ComboBox cmbShipType;
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
		private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
	}
}