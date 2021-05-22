namespace Manager.Forms
{
	partial class FrmReadAPI
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnRead = new System.Windows.Forms.Button();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.btnClose = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(61, 67);
			this.textBox1.MaxLength = 999999999;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(307, 23);
			this.textBox1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 70);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(43, 15);
			this.label1.TabIndex = 1;
			this.label1.Text = "入力：";
			// 
			// btnRead
			// 
			this.btnRead.Location = new System.Drawing.Point(374, 66);
			this.btnRead.Name = "btnRead";
			this.btnRead.Size = new System.Drawing.Size(75, 23);
			this.btnRead.TabIndex = 2;
			this.btnRead.Text = "解析";
			this.btnRead.UseVisualStyleBackColor = true;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(12, 95);
			this.textBox2.MaxLength = 999999999;
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(437, 258);
			this.textBox2.TabIndex = 3;
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(308, 12);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(141, 39);
			this.btnClose.TabIndex = 4;
			this.btnClose.Text = "閉じる";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// FrmReadAPI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(461, 365);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.btnRead);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox1);
			this.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "FrmReadAPI";
			this.Text = "FrmReadAPI";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnRead;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button btnClose;
	}
}