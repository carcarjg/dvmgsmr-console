namespace dvmgsmr_console
{
	partial class RadSch
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
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RadSch));
			daymonthyearLAB = new Label();
			ACBtimer = new System.Windows.Forms.Timer(components);
			acbBUT = new Button();
			acbLAB1 = new Label();
			acbFLASHbut = new Button();
			C1BUT = new Button();
			C2BUT = new Button();
			C3BUT = new Button();
			C4BUT = new Button();
			C5BUT = new Button();
			T1BUT = new Button();
			T2 = new Button();
			T3BUT = new Button();
			AT1BUT = new Button();
			AT2BUT = new Button();
			AT3BUT = new Button();
			AT5BUT = new Button();
			AT4BUT = new Button();
			HC2BUT = new Button();
			HC1BUT = new Button();
			mxtmr = new System.Windows.Forms.Timer(components);
			C1lab1 = new Label();
			C1lab2 = new Label();
			C2lab2 = new Label();
			C2lab1 = new Label();
			C3lab2 = new Label();
			C3lab1 = new Label();
			C4lab2 = new Label();
			C4lab1 = new Label();
			C5lab2 = new Label();
			C5lab1 = new Label();
			ACBhcLAB = new Label();
			ACBtgLAB = new Label();
			ACBicoPB = new PictureBox();
			((System.ComponentModel.ISupportInitialize)ACBicoPB).BeginInit();
			SuspendLayout();
			// 
			// daymonthyearLAB
			// 
			daymonthyearLAB.BackColor = SystemColors.ControlLight;
			daymonthyearLAB.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
			daymonthyearLAB.Location = new Point(885, 9);
			daymonthyearLAB.Name = "daymonthyearLAB";
			daymonthyearLAB.Size = new Size(193, 21);
			daymonthyearLAB.TabIndex = 0;
			daymonthyearLAB.Text = "DD/MMMMMMM/YYYY";
			daymonthyearLAB.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// ACBtimer
			// 
			ACBtimer.Enabled = true;
			ACBtimer.Interval = 1000;
			ACBtimer.Tick += ACBtimer_Tick;
			// 
			// acbBUT
			// 
			acbBUT.BackColor = SystemColors.ControlLight;
			acbBUT.FlatAppearance.BorderSize = 0;
			acbBUT.FlatStyle = FlatStyle.Flat;
			acbBUT.Location = new Point(986, 792);
			acbBUT.Name = "acbBUT";
			acbBUT.Size = new Size(235, 182);
			acbBUT.TabIndex = 1;
			acbBUT.UseVisualStyleBackColor = false;
			acbBUT.Click += acbBUT_Click;
			// 
			// acbLAB1
			// 
			acbLAB1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			acbLAB1.BackColor = Color.Transparent;
			acbLAB1.Location = new Point(1075, 929);
			acbLAB1.Name = "acbLAB1";
			acbLAB1.Size = new Size(126, 26);
			acbLAB1.TabIndex = 2;
			acbLAB1.Text = "xXxxxxx Xxxxx";
			acbLAB1.Click += acbBUT_Click;
			// 
			// acbFLASHbut
			// 
			acbFLASHbut.BackColor = Color.Transparent;
			acbFLASHbut.FlatAppearance.BorderSize = 0;
			acbFLASHbut.Location = new Point(1002, 804);
			acbFLASHbut.Name = "acbFLASHbut";
			acbFLASHbut.Size = new Size(207, 157);
			acbFLASHbut.TabIndex = 3;
			acbFLASHbut.UseVisualStyleBackColor = false;
			acbFLASHbut.Visible = false;
			acbFLASHbut.Click += acbBUT_Click;
			// 
			// C1BUT
			// 
			C1BUT.BackColor = Color.White;
			C1BUT.FlatAppearance.BorderSize = 0;
			C1BUT.FlatStyle = FlatStyle.Flat;
			C1BUT.Location = new Point(90, 86);
			C1BUT.Name = "C1BUT";
			C1BUT.Size = new Size(526, 44);
			C1BUT.TabIndex = 4;
			C1BUT.UseVisualStyleBackColor = false;
			// 
			// C2BUT
			// 
			C2BUT.BackColor = Color.White;
			C2BUT.FlatAppearance.BorderSize = 0;
			C2BUT.FlatStyle = FlatStyle.Flat;
			C2BUT.Location = new Point(90, 134);
			C2BUT.Name = "C2BUT";
			C2BUT.Size = new Size(526, 44);
			C2BUT.TabIndex = 5;
			C2BUT.UseVisualStyleBackColor = false;
			// 
			// C3BUT
			// 
			C3BUT.BackColor = Color.White;
			C3BUT.FlatAppearance.BorderSize = 0;
			C3BUT.FlatStyle = FlatStyle.Flat;
			C3BUT.Location = new Point(90, 184);
			C3BUT.Name = "C3BUT";
			C3BUT.Size = new Size(526, 44);
			C3BUT.TabIndex = 6;
			C3BUT.UseVisualStyleBackColor = false;
			// 
			// C4BUT
			// 
			C4BUT.BackColor = Color.White;
			C4BUT.FlatAppearance.BorderSize = 0;
			C4BUT.FlatStyle = FlatStyle.Flat;
			C4BUT.Location = new Point(90, 234);
			C4BUT.Name = "C4BUT";
			C4BUT.Size = new Size(526, 44);
			C4BUT.TabIndex = 7;
			C4BUT.UseVisualStyleBackColor = false;
			// 
			// C5BUT
			// 
			C5BUT.BackColor = Color.White;
			C5BUT.FlatAppearance.BorderSize = 0;
			C5BUT.FlatStyle = FlatStyle.Flat;
			C5BUT.Location = new Point(90, 284);
			C5BUT.Name = "C5BUT";
			C5BUT.Size = new Size(526, 44);
			C5BUT.TabIndex = 8;
			C5BUT.UseVisualStyleBackColor = false;
			// 
			// T1BUT
			// 
			T1BUT.BackColor = Color.White;
			T1BUT.FlatAppearance.BorderSize = 0;
			T1BUT.FlatStyle = FlatStyle.Flat;
			T1BUT.Location = new Point(90, 377);
			T1BUT.Name = "T1BUT";
			T1BUT.Size = new Size(526, 44);
			T1BUT.TabIndex = 9;
			T1BUT.UseVisualStyleBackColor = false;
			// 
			// T2
			// 
			T2.BackColor = Color.White;
			T2.FlatAppearance.BorderSize = 0;
			T2.FlatStyle = FlatStyle.Flat;
			T2.Location = new Point(90, 427);
			T2.Name = "T2";
			T2.Size = new Size(526, 44);
			T2.TabIndex = 10;
			T2.UseVisualStyleBackColor = false;
			// 
			// T3BUT
			// 
			T3BUT.BackColor = Color.White;
			T3BUT.FlatAppearance.BorderSize = 0;
			T3BUT.FlatStyle = FlatStyle.Flat;
			T3BUT.Location = new Point(90, 477);
			T3BUT.Name = "T3BUT";
			T3BUT.Size = new Size(526, 44);
			T3BUT.TabIndex = 11;
			T3BUT.UseVisualStyleBackColor = false;
			// 
			// AT1BUT
			// 
			AT1BUT.BackColor = Color.White;
			AT1BUT.FlatAppearance.BorderSize = 0;
			AT1BUT.FlatStyle = FlatStyle.Flat;
			AT1BUT.Location = new Point(675, 86);
			AT1BUT.Name = "AT1BUT";
			AT1BUT.Size = new Size(526, 44);
			AT1BUT.TabIndex = 12;
			AT1BUT.UseVisualStyleBackColor = false;
			// 
			// AT2BUT
			// 
			AT2BUT.BackColor = Color.White;
			AT2BUT.FlatAppearance.BorderSize = 0;
			AT2BUT.FlatStyle = FlatStyle.Flat;
			AT2BUT.Location = new Point(675, 136);
			AT2BUT.Name = "AT2BUT";
			AT2BUT.Size = new Size(526, 44);
			AT2BUT.TabIndex = 13;
			AT2BUT.UseVisualStyleBackColor = false;
			// 
			// AT3BUT
			// 
			AT3BUT.BackColor = Color.White;
			AT3BUT.FlatAppearance.BorderSize = 0;
			AT3BUT.FlatStyle = FlatStyle.Flat;
			AT3BUT.Location = new Point(675, 184);
			AT3BUT.Name = "AT3BUT";
			AT3BUT.Size = new Size(526, 44);
			AT3BUT.TabIndex = 14;
			AT3BUT.UseVisualStyleBackColor = false;
			// 
			// AT5BUT
			// 
			AT5BUT.BackColor = Color.White;
			AT5BUT.FlatAppearance.BorderSize = 0;
			AT5BUT.FlatStyle = FlatStyle.Flat;
			AT5BUT.Location = new Point(675, 284);
			AT5BUT.Name = "AT5BUT";
			AT5BUT.Size = new Size(526, 44);
			AT5BUT.TabIndex = 15;
			AT5BUT.UseVisualStyleBackColor = false;
			// 
			// AT4BUT
			// 
			AT4BUT.BackColor = Color.White;
			AT4BUT.FlatAppearance.BorderSize = 0;
			AT4BUT.FlatStyle = FlatStyle.Flat;
			AT4BUT.Location = new Point(675, 234);
			AT4BUT.Name = "AT4BUT";
			AT4BUT.Size = new Size(526, 44);
			AT4BUT.TabIndex = 15;
			AT4BUT.UseVisualStyleBackColor = false;
			// 
			// HC2BUT
			// 
			HC2BUT.BackColor = Color.White;
			HC2BUT.FlatAppearance.BorderSize = 0;
			HC2BUT.FlatStyle = FlatStyle.Flat;
			HC2BUT.Location = new Point(90, 732);
			HC2BUT.Name = "HC2BUT";
			HC2BUT.Size = new Size(526, 44);
			HC2BUT.TabIndex = 16;
			HC2BUT.UseVisualStyleBackColor = false;
			// 
			// HC1BUT
			// 
			HC1BUT.BackColor = Color.White;
			HC1BUT.FlatAppearance.BorderSize = 0;
			HC1BUT.FlatStyle = FlatStyle.Flat;
			HC1BUT.Location = new Point(90, 682);
			HC1BUT.Name = "HC1BUT";
			HC1BUT.Size = new Size(526, 44);
			HC1BUT.TabIndex = 17;
			HC1BUT.UseVisualStyleBackColor = false;
			// 
			// mxtmr
			// 
			mxtmr.Enabled = true;
			mxtmr.Interval = 250;
			mxtmr.Tick += mxtmr_Tick;
			// 
			// C1lab1
			// 
			C1lab1.AutoSize = true;
			C1lab1.BackColor = Color.White;
			C1lab1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			C1lab1.Location = new Point(98, 93);
			C1lab1.Name = "C1lab1";
			C1lab1.Size = new Size(83, 32);
			C1lab1.TabIndex = 18;
			C1lab1.Text = "label1";
			C1lab1.TextAlign = ContentAlignment.MiddleLeft;
			C1lab1.Visible = false;
			// 
			// C1lab2
			// 
			C1lab2.AutoSize = true;
			C1lab2.BackColor = Color.White;
			C1lab2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			C1lab2.Location = new Point(360, 93);
			C1lab2.Name = "C1lab2";
			C1lab2.Size = new Size(83, 32);
			C1lab2.TabIndex = 19;
			C1lab2.Text = "label2";
			C1lab2.TextAlign = ContentAlignment.MiddleLeft;
			C1lab2.Visible = false;
			// 
			// C2lab2
			// 
			C2lab2.AutoSize = true;
			C2lab2.BackColor = Color.White;
			C2lab2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			C2lab2.Location = new Point(360, 140);
			C2lab2.Name = "C2lab2";
			C2lab2.Size = new Size(83, 32);
			C2lab2.TabIndex = 21;
			C2lab2.Text = "label2";
			C2lab2.TextAlign = ContentAlignment.MiddleLeft;
			C2lab2.Visible = false;
			// 
			// C2lab1
			// 
			C2lab1.AutoSize = true;
			C2lab1.BackColor = Color.White;
			C2lab1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			C2lab1.Location = new Point(98, 140);
			C2lab1.Name = "C2lab1";
			C2lab1.Size = new Size(83, 32);
			C2lab1.TabIndex = 20;
			C2lab1.Text = "label1";
			C2lab1.TextAlign = ContentAlignment.MiddleLeft;
			C2lab1.Visible = false;
			// 
			// C3lab2
			// 
			C3lab2.AutoSize = true;
			C3lab2.BackColor = Color.White;
			C3lab2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			C3lab2.Location = new Point(360, 188);
			C3lab2.Name = "C3lab2";
			C3lab2.Size = new Size(83, 32);
			C3lab2.TabIndex = 23;
			C3lab2.Text = "label2";
			C3lab2.TextAlign = ContentAlignment.MiddleLeft;
			C3lab2.Visible = false;
			// 
			// C3lab1
			// 
			C3lab1.AutoSize = true;
			C3lab1.BackColor = Color.White;
			C3lab1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			C3lab1.Location = new Point(98, 188);
			C3lab1.Name = "C3lab1";
			C3lab1.Size = new Size(83, 32);
			C3lab1.TabIndex = 22;
			C3lab1.Text = "label1";
			C3lab1.TextAlign = ContentAlignment.MiddleLeft;
			C3lab1.Visible = false;
			// 
			// C4lab2
			// 
			C4lab2.AutoSize = true;
			C4lab2.BackColor = Color.White;
			C4lab2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			C4lab2.Location = new Point(360, 238);
			C4lab2.Name = "C4lab2";
			C4lab2.Size = new Size(83, 32);
			C4lab2.TabIndex = 25;
			C4lab2.Text = "label2";
			C4lab2.TextAlign = ContentAlignment.MiddleLeft;
			C4lab2.Visible = false;
			// 
			// C4lab1
			// 
			C4lab1.AutoSize = true;
			C4lab1.BackColor = Color.White;
			C4lab1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			C4lab1.Location = new Point(98, 238);
			C4lab1.Name = "C4lab1";
			C4lab1.Size = new Size(83, 32);
			C4lab1.TabIndex = 24;
			C4lab1.Text = "label1";
			C4lab1.TextAlign = ContentAlignment.MiddleLeft;
			C4lab1.Visible = false;
			// 
			// C5lab2
			// 
			C5lab2.AutoSize = true;
			C5lab2.BackColor = Color.White;
			C5lab2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			C5lab2.Location = new Point(360, 288);
			C5lab2.Name = "C5lab2";
			C5lab2.Size = new Size(83, 32);
			C5lab2.TabIndex = 27;
			C5lab2.Text = "label2";
			C5lab2.TextAlign = ContentAlignment.MiddleLeft;
			C5lab2.Visible = false;
			// 
			// C5lab1
			// 
			C5lab1.AutoSize = true;
			C5lab1.BackColor = Color.White;
			C5lab1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			C5lab1.Location = new Point(98, 288);
			C5lab1.Name = "C5lab1";
			C5lab1.Size = new Size(83, 32);
			C5lab1.TabIndex = 26;
			C5lab1.Text = "label1";
			C5lab1.TextAlign = ContentAlignment.MiddleLeft;
			C5lab1.Visible = false;
			// 
			// ACBhcLAB
			// 
			ACBhcLAB.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			ACBhcLAB.AutoSize = true;
			ACBhcLAB.BackColor = SystemColors.ControlLight;
			ACBhcLAB.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
			ACBhcLAB.Location = new Point(1061, 809);
			ACBhcLAB.Name = "ACBhcLAB";
			ACBhcLAB.Size = new Size(91, 30);
			ACBhcLAB.TabIndex = 28;
			ACBhcLAB.Text = "999999";
			ACBhcLAB.TextAlign = ContentAlignment.MiddleCenter;
			ACBhcLAB.Visible = false;
			// 
			// ACBtgLAB
			// 
			ACBtgLAB.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			ACBtgLAB.AutoSize = true;
			ACBtgLAB.BackColor = SystemColors.ControlLight;
			ACBtgLAB.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
			ACBtgLAB.Location = new Point(1046, 904);
			ACBtgLAB.Name = "ACBtgLAB";
			ACBtgLAB.Size = new Size(132, 25);
			ACBtgLAB.TabIndex = 29;
			ACBtgLAB.Text = "XXXXXXXXXX";
			ACBtgLAB.TextAlign = ContentAlignment.MiddleCenter;
			ACBtgLAB.Visible = false;
			// 
			// ACBicoPB
			// 
			ACBicoPB.BackColor = Color.Transparent;
			ACBicoPB.BackgroundImageLayout = ImageLayout.Zoom;
			ACBicoPB.Image = (Image)resources.GetObject("ACBicoPB.Image");
			ACBicoPB.InitialImage = null;
			ACBicoPB.Location = new Point(1002, 851);
			ACBicoPB.Name = "ACBicoPB";
			ACBicoPB.Size = new Size(37, 31);
			ACBicoPB.TabIndex = 30;
			ACBicoPB.TabStop = false;
			ACBicoPB.Visible = false;
			// 
			// RadSch
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			BackgroundImage = Properties.Resources.adsadaadadsdasdasCapture1;
			ClientSize = new Size(1233, 986);
			Controls.Add(ACBicoPB);
			Controls.Add(ACBtgLAB);
			Controls.Add(ACBhcLAB);
			Controls.Add(C5lab2);
			Controls.Add(C5lab1);
			Controls.Add(C4lab2);
			Controls.Add(C4lab1);
			Controls.Add(C3lab2);
			Controls.Add(C3lab1);
			Controls.Add(C2lab2);
			Controls.Add(C2lab1);
			Controls.Add(C1lab2);
			Controls.Add(C1lab1);
			Controls.Add(HC1BUT);
			Controls.Add(HC2BUT);
			Controls.Add(AT4BUT);
			Controls.Add(AT5BUT);
			Controls.Add(AT3BUT);
			Controls.Add(AT2BUT);
			Controls.Add(AT1BUT);
			Controls.Add(T3BUT);
			Controls.Add(T2);
			Controls.Add(T1BUT);
			Controls.Add(C5BUT);
			Controls.Add(C4BUT);
			Controls.Add(C3BUT);
			Controls.Add(C2BUT);
			Controls.Add(C1BUT);
			Controls.Add(acbLAB1);
			Controls.Add(acbFLASHbut);
			Controls.Add(acbBUT);
			Controls.Add(daymonthyearLAB);
			Name = "RadSch";
			Text = "RadSch";
			((System.ComponentModel.ISupportInitialize)ACBicoPB).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label daymonthyearLAB;
		private System.Windows.Forms.Timer ACBtimer;
		private Button acbBUT;
		private Label acbLAB1;
		private Button acbFLASHbut;
		private Button C1BUT;
		private Button C2BUT;
		private Button C3BUT;
		private Button C4BUT;
		private Button C5BUT;
		private Button T1BUT;
		private Button T2;
		private Button T3BUT;
		private Button AT1BUT;
		private Button AT2BUT;
		private Button AT3BUT;
		private Button AT5BUT;
		private Button AT4BUT;
		private Button HC2BUT;
		private Button HC1BUT;
		private System.Windows.Forms.Timer mxtmr;
		private Label C1lab1;
		private Label C1lab2;
		private Label C2lab2;
		private Label C2lab1;
		private Label C3lab2;
		private Label C3lab1;
		private Label C4lab2;
		private Label C4lab1;
		private Label C5lab2;
		private Label C5lab1;
		private Label ACBhcLAB;
		private Label ACBtgLAB;
		private PictureBox ACBicoPB;
	}
}