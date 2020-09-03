namespace Manager
{
	partial class FormMenu
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.btnEnd = new System.Windows.Forms.Button();
			this.btnMapEdit = new System.Windows.Forms.Button();
			this.btnOutputEnemyPatterns = new System.Windows.Forms.Button();
			this.btnEnemyEdit = new System.Windows.Forms.Button();
			this.txtOutput = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnOutputEnemies = new System.Windows.Forms.Button();
			this.btnOutputShips = new System.Windows.Forms.Button();
			this.btnShipEdit = new System.Windows.Forms.Button();
			this.btnOutputEquipments = new System.Windows.Forms.Button();
			this.btnEquipmentEdit = new System.Windows.Forms.Button();
			this.btnOutputEnemyTypes = new System.Windows.Forms.Button();
			this.btnOutputShipTypes = new System.Windows.Forms.Button();
			this.btnOutputEquipmentTypes = new System.Windows.Forms.Button();
			this.btnOutputWorlds = new System.Windows.Forms.Button();
			this.btnOutputAll = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnEnd
			// 
			this.btnEnd.Location = new System.Drawing.Point(358, 12);
			this.btnEnd.Name = "btnEnd";
			this.btnEnd.Size = new System.Drawing.Size(114, 35);
			this.btnEnd.TabIndex = 0;
			this.btnEnd.Text = "終了";
			this.btnEnd.UseVisualStyleBackColor = true;
			this.btnEnd.Click += new System.EventHandler(this.BtnEnd_Click);
			// 
			// btnMapEdit
			// 
			this.btnMapEdit.Location = new System.Drawing.Point(358, 61);
			this.btnMapEdit.Name = "btnMapEdit";
			this.btnMapEdit.Size = new System.Drawing.Size(114, 33);
			this.btnMapEdit.TabIndex = 1;
			this.btnMapEdit.Text = "マップ情報編集";
			this.btnMapEdit.UseVisualStyleBackColor = true;
			this.btnMapEdit.Click += new System.EventHandler(this.BtnMapEdit);
			// 
			// btnOutputEnemyPatterns
			// 
			this.btnOutputEnemyPatterns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOutputEnemyPatterns.Location = new System.Drawing.Point(358, 232);
			this.btnOutputEnemyPatterns.Name = "btnOutputEnemyPatterns";
			this.btnOutputEnemyPatterns.Size = new System.Drawing.Size(114, 33);
			this.btnOutputEnemyPatterns.TabIndex = 2;
			this.btnOutputEnemyPatterns.Text = "敵パターン出力";
			this.btnOutputEnemyPatterns.UseVisualStyleBackColor = true;
			this.btnOutputEnemyPatterns.Click += new System.EventHandler(this.BtnOutputEnemyPatterns_Click);
			// 
			// btnEnemyEdit
			// 
			this.btnEnemyEdit.Location = new System.Drawing.Point(246, 61);
			this.btnEnemyEdit.Name = "btnEnemyEdit";
			this.btnEnemyEdit.Size = new System.Drawing.Size(106, 33);
			this.btnEnemyEdit.TabIndex = 3;
			this.btnEnemyEdit.Text = "敵艦編集";
			this.btnEnemyEdit.UseVisualStyleBackColor = true;
			this.btnEnemyEdit.Click += new System.EventHandler(this.BtnEnemyEdit_Click);
			// 
			// txtOutput
			// 
			this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtOutput.Location = new System.Drawing.Point(12, 271);
			this.txtOutput.Multiline = true;
			this.txtOutput.Name = "txtOutput";
			this.txtOutput.Size = new System.Drawing.Size(460, 78);
			this.txtOutput.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(234, 15);
			this.label1.TabIndex = 5;
			this.label1.Text = "変更が多そうなやつ操作するためだけのシステム。";
			// 
			// btnOutputEnemies
			// 
			this.btnOutputEnemies.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOutputEnemies.Location = new System.Drawing.Point(246, 232);
			this.btnOutputEnemies.Name = "btnOutputEnemies";
			this.btnOutputEnemies.Size = new System.Drawing.Size(106, 33);
			this.btnOutputEnemies.TabIndex = 6;
			this.btnOutputEnemies.Text = "敵艦出力";
			this.btnOutputEnemies.UseVisualStyleBackColor = true;
			this.btnOutputEnemies.Click += new System.EventHandler(this.BtnOutputEnemies_Click);
			// 
			// btnOutputShips
			// 
			this.btnOutputShips.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOutputShips.Location = new System.Drawing.Point(12, 232);
			this.btnOutputShips.Name = "btnOutputShips";
			this.btnOutputShips.Size = new System.Drawing.Size(111, 33);
			this.btnOutputShips.TabIndex = 8;
			this.btnOutputShips.Text = "艦娘情報出力";
			this.btnOutputShips.UseVisualStyleBackColor = true;
			this.btnOutputShips.Click += new System.EventHandler(this.BtnOutputShips_Click);
			// 
			// btnShipEdit
			// 
			this.btnShipEdit.Location = new System.Drawing.Point(12, 61);
			this.btnShipEdit.Name = "btnShipEdit";
			this.btnShipEdit.Size = new System.Drawing.Size(111, 33);
			this.btnShipEdit.TabIndex = 7;
			this.btnShipEdit.Text = "艦娘編集";
			this.btnShipEdit.UseVisualStyleBackColor = true;
			this.btnShipEdit.Click += new System.EventHandler(this.BtnShipEdit_Click);
			// 
			// btnOutputEquipments
			// 
			this.btnOutputEquipments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOutputEquipments.Location = new System.Drawing.Point(129, 232);
			this.btnOutputEquipments.Name = "btnOutputEquipments";
			this.btnOutputEquipments.Size = new System.Drawing.Size(111, 33);
			this.btnOutputEquipments.TabIndex = 10;
			this.btnOutputEquipments.Text = "装備情報出力";
			this.btnOutputEquipments.UseVisualStyleBackColor = true;
			this.btnOutputEquipments.Click += new System.EventHandler(this.BtnOutputEquipments_Click);
			// 
			// btnEquipmentEdit
			// 
			this.btnEquipmentEdit.Location = new System.Drawing.Point(129, 61);
			this.btnEquipmentEdit.Name = "btnEquipmentEdit";
			this.btnEquipmentEdit.Size = new System.Drawing.Size(111, 33);
			this.btnEquipmentEdit.TabIndex = 9;
			this.btnEquipmentEdit.Text = "装備編集";
			this.btnEquipmentEdit.UseVisualStyleBackColor = true;
			this.btnEquipmentEdit.Click += new System.EventHandler(this.BtnEquipmentEdit_Click);
			// 
			// btnOutputEnemyTypes
			// 
			this.btnOutputEnemyTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOutputEnemyTypes.Location = new System.Drawing.Point(246, 193);
			this.btnOutputEnemyTypes.Name = "btnOutputEnemyTypes";
			this.btnOutputEnemyTypes.Size = new System.Drawing.Size(106, 33);
			this.btnOutputEnemyTypes.TabIndex = 11;
			this.btnOutputEnemyTypes.Text = "敵艦カテゴリ出力";
			this.btnOutputEnemyTypes.UseVisualStyleBackColor = true;
			this.btnOutputEnemyTypes.Click += new System.EventHandler(this.BtnOutputEnemyTypes_Click);
			// 
			// btnOutputShipTypes
			// 
			this.btnOutputShipTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOutputShipTypes.Location = new System.Drawing.Point(12, 193);
			this.btnOutputShipTypes.Name = "btnOutputShipTypes";
			this.btnOutputShipTypes.Size = new System.Drawing.Size(111, 33);
			this.btnOutputShipTypes.TabIndex = 12;
			this.btnOutputShipTypes.Text = "艦娘カテゴリ出力";
			this.btnOutputShipTypes.UseVisualStyleBackColor = true;
			this.btnOutputShipTypes.Click += new System.EventHandler(this.BtnOutputShipTypes_Click);
			// 
			// btnOutputEquipmentTypes
			// 
			this.btnOutputEquipmentTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOutputEquipmentTypes.Location = new System.Drawing.Point(129, 193);
			this.btnOutputEquipmentTypes.Name = "btnOutputEquipmentTypes";
			this.btnOutputEquipmentTypes.Size = new System.Drawing.Size(111, 33);
			this.btnOutputEquipmentTypes.TabIndex = 13;
			this.btnOutputEquipmentTypes.Text = "装備カテゴリ出力";
			this.btnOutputEquipmentTypes.UseVisualStyleBackColor = true;
			this.btnOutputEquipmentTypes.Click += new System.EventHandler(this.BtnOutputEquipmentTypes_Click);
			// 
			// btnOutputWorlds
			// 
			this.btnOutputWorlds.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOutputWorlds.Location = new System.Drawing.Point(358, 193);
			this.btnOutputWorlds.Name = "btnOutputWorlds";
			this.btnOutputWorlds.Size = new System.Drawing.Size(114, 33);
			this.btnOutputWorlds.TabIndex = 14;
			this.btnOutputWorlds.Text = "海域一覧出力";
			this.btnOutputWorlds.UseVisualStyleBackColor = true;
			this.btnOutputWorlds.Click += new System.EventHandler(this.BtnOutputWorlds_Click);
			// 
			// btnOutputAll
			// 
			this.btnOutputAll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOutputAll.Location = new System.Drawing.Point(12, 154);
			this.btnOutputAll.Name = "btnOutputAll";
			this.btnOutputAll.Size = new System.Drawing.Size(111, 33);
			this.btnOutputAll.TabIndex = 15;
			this.btnOutputAll.Text = "全出力";
			this.btnOutputAll.UseVisualStyleBackColor = true;
			this.btnOutputAll.Click += new System.EventHandler(this.BtnOutputAll_Click);
			// 
			// Menu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(484, 361);
			this.Controls.Add(this.btnOutputAll);
			this.Controls.Add(this.btnOutputWorlds);
			this.Controls.Add(this.btnOutputEquipmentTypes);
			this.Controls.Add(this.btnOutputShipTypes);
			this.Controls.Add(this.btnOutputEnemyTypes);
			this.Controls.Add(this.btnOutputEquipments);
			this.Controls.Add(this.btnEquipmentEdit);
			this.Controls.Add(this.btnOutputShips);
			this.Controls.Add(this.btnShipEdit);
			this.Controls.Add(this.btnOutputEnemies);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtOutput);
			this.Controls.Add(this.btnEnemyEdit);
			this.Controls.Add(this.btnOutputEnemyPatterns);
			this.Controls.Add(this.btnMapEdit);
			this.Controls.Add(this.btnEnd);
			this.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.Name = "Menu";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "メインメニュー";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnEnd;
		private System.Windows.Forms.Button btnMapEdit;
		private System.Windows.Forms.Button btnOutputEnemyPatterns;
		private System.Windows.Forms.Button btnEnemyEdit;
		private System.Windows.Forms.TextBox txtOutput;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnOutputEnemies;
		private System.Windows.Forms.Button btnOutputShips;
		private System.Windows.Forms.Button btnShipEdit;
		private System.Windows.Forms.Button btnOutputEquipments;
		private System.Windows.Forms.Button btnEquipmentEdit;
		private System.Windows.Forms.Button btnOutputEnemyTypes;
		private System.Windows.Forms.Button btnOutputShipTypes;
		private System.Windows.Forms.Button btnOutputEquipmentTypes;
		private System.Windows.Forms.Button btnOutputWorlds;
		private System.Windows.Forms.Button btnOutputAll;
	}
}

