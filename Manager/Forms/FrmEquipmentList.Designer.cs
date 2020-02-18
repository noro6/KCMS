namespace Manager.Forms
{
	partial class FrmEquipmentList
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
			this.dgvEquipments = new System.Windows.Forms.DataGridView();
			this.cmbType = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dgvEquipments)).BeginInit();
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
			// dgvEquipments
			// 
			this.dgvEquipments.AllowUserToAddRows = false;
			this.dgvEquipments.AllowUserToDeleteRows = false;
			this.dgvEquipments.AllowUserToResizeColumns = false;
			this.dgvEquipments.AllowUserToResizeRows = false;
			this.dgvEquipments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvEquipments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvEquipments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Column7,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13});
			this.dgvEquipments.Location = new System.Drawing.Point(12, 94);
			this.dgvEquipments.MultiSelect = false;
			this.dgvEquipments.Name = "dgvEquipments";
			this.dgvEquipments.RowHeadersVisible = false;
			this.dgvEquipments.RowTemplate.Height = 21;
			this.dgvEquipments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvEquipments.Size = new System.Drawing.Size(924, 363);
			this.dgvEquipments.TabIndex = 12;
			this.dgvEquipments.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvEquipments_CellDoubleClick);
			// 
			// cmbType
			// 
			this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbType.FormattingEnabled = true;
			this.cmbType.Location = new System.Drawing.Point(241, 65);
			this.cmbType.Name = "cmbType";
			this.cmbType.Size = new System.Drawing.Size(174, 23);
			this.cmbType.TabIndex = 1;
			this.cmbType.SelectedIndexChanged += new System.EventHandler(this.CmbShipType_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 68);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 15);
			this.label1.TabIndex = 13;
			this.label1.Text = "IDや名称：";
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(851, 12);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(85, 32);
			this.btnClose.TabIndex = 2;
			this.btnClose.Text = "閉じる";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(851, 56);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(85, 32);
			this.btnAdd.TabIndex = 3;
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
			// Column7
			// 
			this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Column7.DataPropertyName = "Abbr";
			this.Column7.HeaderText = "略称";
			this.Column7.Name = "Column7";
			this.Column7.ReadOnly = true;
			// 
			// Column1
			// 
			this.Column1.DataPropertyName = "TypeName";
			this.Column1.HeaderText = "種別";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Width = 80;
			// 
			// Column2
			// 
			this.Column2.DataPropertyName = "AntiAir";
			this.Column2.HeaderText = "対空";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column2.Width = 42;
			// 
			// Column3
			// 
			this.Column3.DataPropertyName = "torpedo";
			this.Column3.HeaderText = "雷装";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			this.Column3.Width = 42;
			// 
			// Column4
			// 
			this.Column4.DataPropertyName = "bomber";
			this.Column4.HeaderText = "爆装";
			this.Column4.Name = "Column4";
			this.Column4.ReadOnly = true;
			this.Column4.Width = 42;
			// 
			// Column5
			// 
			this.Column5.DataPropertyName = "interception";
			this.Column5.HeaderText = "迎撃";
			this.Column5.Name = "Column5";
			this.Column5.ReadOnly = true;
			this.Column5.Width = 42;
			// 
			// Column6
			// 
			this.Column6.DataPropertyName = "AntiBomber";
			this.Column6.HeaderText = "対爆";
			this.Column6.Name = "Column6";
			this.Column6.ReadOnly = true;
			this.Column6.Width = 42;
			// 
			// Column9
			// 
			this.Column9.DataPropertyName = "scout";
			this.Column9.HeaderText = "索敵";
			this.Column9.Name = "Column9";
			this.Column9.ReadOnly = true;
			this.Column9.Width = 42;
			// 
			// Column10
			// 
			this.Column10.DataPropertyName = "CanRemodelString";
			this.Column10.HeaderText = "改修";
			this.Column10.Name = "Column10";
			this.Column10.ReadOnly = true;
			this.Column10.Width = 42;
			// 
			// Column11
			// 
			this.Column11.DataPropertyName = "radius";
			this.Column11.HeaderText = "半径";
			this.Column11.Name = "Column11";
			this.Column11.ReadOnly = true;
			this.Column11.Width = 42;
			// 
			// Column12
			// 
			this.Column12.DataPropertyName = "cost";
			this.Column12.HeaderText = "コスト";
			this.Column12.Name = "Column12";
			this.Column12.ReadOnly = true;
			this.Column12.Width = 48;
			// 
			// Column13
			// 
			this.Column13.DataPropertyName = "AvoidName";
			this.Column13.HeaderText = "回避";
			this.Column13.Name = "Column13";
			this.Column13.ReadOnly = true;
			this.Column13.Width = 42;
			// 
			// FrmEquipmentList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(948, 469);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dgvEquipments);
			this.Controls.Add(this.txtSearch);
			this.Controls.Add(this.cmbType);
			this.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "FrmEquipmentList";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "装備一覧";
			this.Load += new System.EventHandler(this.FrmShipList_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvEquipments)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TextBox txtSearch;
		private System.Windows.Forms.DataGridView dgvEquipments;
		private System.Windows.Forms.ComboBox cmbType;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
	}
}