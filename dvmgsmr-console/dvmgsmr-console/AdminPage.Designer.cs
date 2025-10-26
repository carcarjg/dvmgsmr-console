namespace dvmgsmr_console
{
	partial class AdminPage
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
			svraddrTXT = new TextBox();
			label1 = new Label();
			saveBUT = new Button();
			label2 = new Label();
			svrportTXT = new TextBox();
			rc2BUT = new Button();
			gsmrbut = new Button();
			label3 = new Label();
			sipBUT = new Button();
			SuspendLayout();
			// 
			// svraddrTXT
			// 
			svraddrTXT.Location = new Point(149, 25);
			svraddrTXT.Name = "svraddrTXT";
			svraddrTXT.Size = new Size(325, 31);
			svraddrTXT.TabIndex = 0;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(12, 25);
			label1.Name = "label1";
			label1.Size = new Size(131, 25);
			label1.TabIndex = 1;
			label1.Text = "Server Address";
			// 
			// saveBUT
			// 
			saveBUT.Location = new Point(328, 404);
			saveBUT.Name = "saveBUT";
			saveBUT.Size = new Size(112, 34);
			saveBUT.TabIndex = 2;
			saveBUT.Text = "Save";
			saveBUT.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(45, 62);
			label2.Name = "label2";
			label2.Size = new Size(98, 25);
			label2.TabIndex = 4;
			label2.Text = "Server Port";
			// 
			// svrportTXT
			// 
			svrportTXT.Location = new Point(149, 62);
			svrportTXT.Name = "svrportTXT";
			svrportTXT.Size = new Size(325, 31);
			svrportTXT.TabIndex = 3;
			// 
			// rc2BUT
			// 
			rc2BUT.Location = new Point(12, 176);
			rc2BUT.Name = "rc2BUT";
			rc2BUT.Size = new Size(102, 77);
			rc2BUT.TabIndex = 5;
			rc2BUT.Text = "RC2";
			rc2BUT.UseVisualStyleBackColor = true;
			rc2BUT.Click += rc2BUT_Click;
			// 
			// gsmrbut
			// 
			gsmrbut.Location = new Point(136, 176);
			gsmrbut.Name = "gsmrbut";
			gsmrbut.Size = new Size(102, 77);
			gsmrbut.TabIndex = 6;
			gsmrbut.Text = "GSM-R";
			gsmrbut.UseVisualStyleBackColor = true;
			gsmrbut.Click += gsmrbut_Click;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(113, 138);
			label3.Name = "label3";
			label3.Size = new Size(154, 25);
			label3.TabIndex = 7;
			label3.Text = "Connection Mode";
			// 
			// sipBUT
			// 
			sipBUT.Location = new Point(258, 176);
			sipBUT.Name = "sipBUT";
			sipBUT.Size = new Size(102, 77);
			sipBUT.TabIndex = 8;
			sipBUT.Text = "SIP";
			sipBUT.UseVisualStyleBackColor = true;
			sipBUT.Click += sipBUT_Click;
			// 
			// AdminPage
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(sipBUT);
			Controls.Add(label3);
			Controls.Add(gsmrbut);
			Controls.Add(rc2BUT);
			Controls.Add(label2);
			Controls.Add(svrportTXT);
			Controls.Add(saveBUT);
			Controls.Add(label1);
			Controls.Add(svraddrTXT);
			Name = "AdminPage";
			StartPosition = FormStartPosition.CenterParent;
			Text = "AdminPage";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox svraddrTXT;
		private Label label1;
		private Button saveBUT;
		private Label label2;
		private TextBox svrportTXT;
		private Button rc2BUT;
		private Button gsmrbut;
		private Label label3;
		private Button sipBUT;
	}
}