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
			oskLaunchBUT = new Button();
			button1 = new Button();
			button2 = new Button();
			button3 = new Button();
			button4 = new Button();
			button5 = new Button();
			yesBUT = new Button();
			noBUT = new Button();
			label4 = new Label();
			label5 = new Label();
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
			saveBUT.Location = new Point(324, 524);
			saveBUT.Name = "saveBUT";
			saveBUT.Size = new Size(111, 67);
			saveBUT.TabIndex = 2;
			saveBUT.Text = "Save";
			saveBUT.UseVisualStyleBackColor = true;
			saveBUT.Click += saveBUT_Click;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(4, 62);
			label2.Name = "label2";
			label2.Size = new Size(139, 25);
			label2.TabIndex = 4;
			label2.Text = "Server Base Port";
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
			rc2BUT.Location = new Point(52, 176);
			rc2BUT.Name = "rc2BUT";
			rc2BUT.Size = new Size(102, 77);
			rc2BUT.TabIndex = 5;
			rc2BUT.Text = "RC2";
			rc2BUT.UseVisualStyleBackColor = true;
			rc2BUT.Click += rc2BUT_Click;
			// 
			// gsmrbut
			// 
			gsmrbut.Location = new Point(176, 176);
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
			label3.Location = new Point(153, 138);
			label3.Name = "label3";
			label3.Size = new Size(154, 25);
			label3.TabIndex = 7;
			label3.Text = "Connection Mode";
			// 
			// sipBUT
			// 
			sipBUT.Location = new Point(298, 176);
			sipBUT.Name = "sipBUT";
			sipBUT.Size = new Size(102, 77);
			sipBUT.TabIndex = 8;
			sipBUT.Text = "SIP";
			sipBUT.UseVisualStyleBackColor = true;
			sipBUT.Click += sipBUT_Click;
			// 
			// oskLaunchBUT
			// 
			oskLaunchBUT.Location = new Point(555, 25);
			oskLaunchBUT.Name = "oskLaunchBUT";
			oskLaunchBUT.Size = new Size(112, 68);
			oskLaunchBUT.TabIndex = 9;
			oskLaunchBUT.Text = "Keyboard";
			oskLaunchBUT.UseVisualStyleBackColor = true;
			oskLaunchBUT.Click += oskLaunchBUT_Click;
			// 
			// button1
			// 
			button1.Location = new Point(21, 306);
			button1.Name = "button1";
			button1.Size = new Size(88, 81);
			button1.TabIndex = 10;
			button1.Text = "1";
			button1.UseVisualStyleBackColor = true;
			button1.Click += chNumbBUT_Click;
			// 
			// button2
			// 
			button2.Location = new Point(130, 306);
			button2.Name = "button2";
			button2.Size = new Size(88, 81);
			button2.TabIndex = 11;
			button2.Text = "2";
			button2.UseVisualStyleBackColor = true;
			button2.Click += chNumbBUT_Click;
			// 
			// button3
			// 
			button3.Location = new Point(248, 306);
			button3.Name = "button3";
			button3.Size = new Size(88, 81);
			button3.TabIndex = 12;
			button3.Text = "3";
			button3.UseVisualStyleBackColor = true;
			button3.Click += chNumbBUT_Click;
			// 
			// button4
			// 
			button4.Location = new Point(363, 306);
			button4.Name = "button4";
			button4.Size = new Size(88, 81);
			button4.TabIndex = 13;
			button4.Text = "4";
			button4.UseVisualStyleBackColor = true;
			button4.Click += chNumbBUT_Click;
			// 
			// button5
			// 
			button5.Location = new Point(470, 306);
			button5.Name = "button5";
			button5.Size = new Size(88, 81);
			button5.TabIndex = 14;
			button5.Text = "5";
			button5.UseVisualStyleBackColor = true;
			button5.Click += chNumbBUT_Click;
			// 
			// yesBUT
			// 
			yesBUT.Location = new Point(21, 446);
			yesBUT.Name = "yesBUT";
			yesBUT.Size = new Size(88, 81);
			yesBUT.TabIndex = 15;
			yesBUT.Text = "Yes";
			yesBUT.UseVisualStyleBackColor = true;
			yesBUT.Click += yesnoBUT_Click;
			// 
			// noBUT
			// 
			noBUT.Location = new Point(130, 446);
			noBUT.Name = "noBUT";
			noBUT.Size = new Size(88, 81);
			noBUT.TabIndex = 16;
			noBUT.Text = "No";
			noBUT.UseVisualStyleBackColor = true;
			noBUT.Click += yesnoBUT_Click;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(39, 418);
			label4.Name = "label4";
			label4.Size = new Size(168, 25);
			label4.TabIndex = 17;
			label4.Text = "Sig Channel Present";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(212, 278);
			label5.Name = "label5";
			label5.Size = new Size(175, 25);
			label5.TabIndex = 18;
			label5.Text = "Number of Channels";
			// 
			// AdminPage
			// 
			AutoScaleMode = AutoScaleMode.None;
			ClientSize = new Size(760, 603);
			Controls.Add(label5);
			Controls.Add(label4);
			Controls.Add(noBUT);
			Controls.Add(yesBUT);
			Controls.Add(button5);
			Controls.Add(button4);
			Controls.Add(button3);
			Controls.Add(button2);
			Controls.Add(button1);
			Controls.Add(oskLaunchBUT);
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
		private Button oskLaunchBUT;
		private Button button1;
		private Button button2;
		private Button button3;
		private Button button4;
		private Button button5;
		private Button yesBUT;
		private Button noBUT;
		private Label label4;
		private Label label5;
	}
}