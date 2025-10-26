namespace dvmgsmr_console
{
	partial class MainForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			logginbutton = new Button();
			Administratorbut = new Button();
			panel1 = new Panel();
			daymonthyearLAB = new Label();
			loginPage1 = new LoginPage();
			MaintTMR = new System.Windows.Forms.Timer(components);
			panel1.SuspendLayout();
			SuspendLayout();
			// 
			// logginbutton
			// 
			logginbutton.Font = new Font("Segoe UI", 14F);
			logginbutton.Location = new Point(466, 364);
			logginbutton.Name = "logginbutton";
			logginbutton.Size = new Size(304, 111);
			logginbutton.TabIndex = 0;
			logginbutton.Text = "Login..";
			logginbutton.UseVisualStyleBackColor = true;
			logginbutton.Click += logginbutton_Click;
			// 
			// Administratorbut
			// 
			Administratorbut.Font = new Font("Segoe UI", 14F);
			Administratorbut.ForeColor = SystemColors.ControlDarkDark;
			Administratorbut.Location = new Point(465, 831);
			Administratorbut.Name = "Administratorbut";
			Administratorbut.Size = new Size(304, 111);
			Administratorbut.TabIndex = 1;
			Administratorbut.Text = "Administrator";
			Administratorbut.UseVisualStyleBackColor = true;
			Administratorbut.Click += Administratorbut_Click;
			// 
			// panel1
			// 
			panel1.BackgroundImage = Properties.Resources.Captuasdadadre1;
			panel1.Controls.Add(daymonthyearLAB);
			panel1.Controls.Add(logginbutton);
			panel1.Controls.Add(loginPage1);
			panel1.Location = new Point(-1, 1);
			panel1.Name = "panel1";
			panel1.Size = new Size(1234, 983);
			panel1.TabIndex = 2;
			// 
			// daymonthyearLAB
			// 
			daymonthyearLAB.BackColor = SystemColors.ControlLight;
			daymonthyearLAB.Font = new Font("Segoe UI", 9F);
			daymonthyearLAB.Location = new Point(912, 13);
			daymonthyearLAB.Name = "daymonthyearLAB";
			daymonthyearLAB.Size = new Size(150, 41);
			daymonthyearLAB.TabIndex = 2;
			daymonthyearLAB.Text = "DD/MMM/YYYY";
			daymonthyearLAB.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// loginPage1
			// 
			loginPage1.BackgroundImage = (Image)resources.GetObject("loginPage1.BackgroundImage");
			loginPage1.Location = new Point(2, 2);
			loginPage1.Name = "loginPage1";
			loginPage1.Size = new Size(1234, 980);
			loginPage1.TabIndex = 3;
			loginPage1.Visible = false;
			// 
			// MaintTMR
			// 
			MaintTMR.Enabled = true;
			MaintTMR.Interval = 1000;
			MaintTMR.Tick += MaintTMR_Tick;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1233, 986);
			Controls.Add(Administratorbut);
			Controls.Add(panel1);
			Name = "MainForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "MainForm";
			panel1.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private Button logginbutton;
		private Button Administratorbut;
		private Panel panel1;
		private Label daymonthyearLAB;
		private System.Windows.Forms.Timer MaintTMR;
		private LoginPage loginPage1;
	}
}
