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
			logginbutton = new Button();
			Administratorbut = new Button();
			panel1 = new Panel();
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
			// 
			// panel1
			// 
			panel1.BackgroundImage = Properties.Resources.Captuasdadadre;
			panel1.Controls.Add(logginbutton);
			panel1.Location = new Point(-1, 1);
			panel1.Name = "panel1";
			panel1.Size = new Size(1234, 983);
			panel1.TabIndex = 2;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1233, 986);
			Controls.Add(Administratorbut);
			Controls.Add(panel1);
			Name = "MainForm";
			Text = "MainForm";
			panel1.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private Button logginbutton;
		private Button Administratorbut;
		private Panel panel1;
	}
}
