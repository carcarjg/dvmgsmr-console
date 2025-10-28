namespace dvmgsmr_console
{
	partial class SettingsForm
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
			CloseButton = new Button();
			buttonbeepButton = new Button();
			ringBut = new Button();
			label1 = new Label();
			label2 = new Label();
			SuspendLayout();
			// 
			// CloseButton
			// 
			CloseButton.Font = new Font("Rockwell Condensed", 30F, FontStyle.Bold);
			CloseButton.Location = new Point(724, 12);
			CloseButton.Name = "CloseButton";
			CloseButton.Size = new Size(153, 116);
			CloseButton.TabIndex = 0;
			CloseButton.Text = "X";
			CloseButton.UseVisualStyleBackColor = true;
			CloseButton.Click += button1_Click;
			// 
			// buttonbeepButton
			// 
			buttonbeepButton.Location = new Point(32, 230);
			buttonbeepButton.Name = "buttonbeepButton";
			buttonbeepButton.Size = new Size(112, 87);
			buttonbeepButton.TabIndex = 1;
			buttonbeepButton.Text = "Enabled";
			buttonbeepButton.UseVisualStyleBackColor = true;
			buttonbeepButton.Click += buttonbeepButton_Click;
			// 
			// ringBut
			// 
			ringBut.Location = new Point(189, 230);
			ringBut.Name = "ringBut";
			ringBut.Size = new Size(112, 87);
			ringBut.TabIndex = 2;
			ringBut.Text = "Enabled";
			ringBut.UseVisualStyleBackColor = true;
			ringBut.Click += ringBut_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(210, 202);
			label1.Name = "label1";
			label1.Size = new Size(63, 25);
			label1.TabIndex = 3;
			label1.Text = "Ringer";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(35, 202);
			label2.Name = "label2";
			label2.Size = new Size(109, 25);
			label2.TabIndex = 4;
			label2.Text = "Button Beep";
			// 
			// SettingsForm
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ControlLight;
			ClientSize = new Size(889, 704);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(ringBut);
			Controls.Add(buttonbeepButton);
			Controls.Add(CloseButton);
			Name = "SettingsForm";
			StartPosition = FormStartPosition.CenterParent;
			Text = "SettingsForm";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button CloseButton;
		private Button buttonbeepButton;
		private Button ringBut;
		private Label label1;
		private Label label2;
	}
}