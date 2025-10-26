// %%%%%%    @%%%%%@
//%%%%%%%%   %%%%%%%@
//@%%%%%%%@  %%%%%%%%%        @@      @@  @@@      @@@ @@@     @@@ @@@@@@@@@@   @@@@@@@@@
//%%%%%%%%@ @%%%%%%%%       @@@@@   @@@@ @@@@@   @@@@ @@@@   @@@@ @@@@@@@@@@@@@@@@@@@@@@@ @@@@
// @%%%%%%%%  %%%%%%%%%      @@@@@@  @@@@  @@@@  @@@@   @@@@@@@@@     @@@@    @@@@         @@@@
//  %%%%%%%%%  %%%%%%%%@     @@@@@@@ @@@@   @@@@@@@@     @@@@@@       @@@@    @@@@@@@@@@@  @@@@
//   %%%%%%%%@  %%%%%%%%%    @@@@@@@@@@@@     @@@@        @@@@@       @@@@    @@@@@@@@@@@  @@@@
//    %%%%%%%%@ @%%%%%%%%    @@@@ @@@@@@@     @@@@      @@@@@@@@      @@@@    @@@@         @@@@
//    @%%%%%%%%% @%%%%%%%%   @@@@   @@@@@     @@@@     @@@@@ @@@@@    @@@@    @@@@@@@@@@@@ @@@@@@@@@@
//     @%%%%%%%%  %%%%%%%%@  @@@@    @@@@     @@@@    @@@@     @@@@   @@@@    @@@@@@@@@@@@ @@@@@@@@@@@
//      %%%%%%%%@ @%%%%%%%%
//      @%%%%%%%%  @%%%%%%%%
//       %%%%%%%%   %%%%%%%@
//         %%%%%      %%%%
//
// (C) Nyx Gallini 2025
//
using System.Media;
using System.Xml.Linq;

namespace dvmgsmr_console
{
	public partial class RadSch : Form
	{
		private bool acbflashcycle;

		internal static bool callringging;

		internal static bool activecall;

		internal static string[] acallsHC = new string[4];

		internal static string[] acallsTG = new string[4];

		private static readonly CancellationTokenSource cts = new CancellationTokenSource();

		public RadSch()
		{
			InitializeComponent();

			acbLAB1.Text = "Ready";
			acbLAB1.TextAlign = ContentAlignment.MiddleRight;
			string DTMD = DateTime.Now.Day.ToString();
			DateTime M = DateTime.Now;
			string DTMM = M.ToString("MMMM");
			string DTMY = DateTime.Now.Year.ToString();
			daymonthyearLAB.Text = DTMD + " " + DTMM + " " + DTMY;
			if (Properties.Settings.Default.ConnMODE == "RC2")
			{
				RC2Con();
			}
#if DEBUG

			//ringACB(500150, "CM_RAIL");
#endif
		}

		internal void ringACB(int HC, string TG)
		{
			callringging = true;
			ACBhcLAB.Text = string.Format("{0:x}", HC).ToUpper();
			ACBtgLAB.Text = TG;
			ACBhcLAB.Visible = true;
			ACBtgLAB.Visible = true;
			ACBicoPB.Visible = true;
			ACBtimer.Enabled = true;
			ACBtimer.Start();

			int availslt = AddNewCall(HC, TG);
			if (availslt != 99)
			{
			}
		}

		/// <summary>
		/// Someone Clicked the ACB
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void acbBUT_Click(object sender, EventArgs e)
		{
			if (callringging == true)
			{
				acbflashcycle = false;
				callringging = false;
				activecall = true;
				acbFLASHbut.Visible = false;
				changeBUTbg("ACB", Color.Orange);
				acbLAB1.BackColor = Color.Orange;
				ACBtimer.Stop();
				acbLAB1.Text = "[End Call]";
			}
			else if (activecall == true)
			{
				ACBhcLAB.Visible = false;
				ACBtgLAB.Visible = false;
				ACBicoPB.Visible = false;
				activecall = false;
				acbLAB1.Text = "Ready";
				Removecall(ACBhcLAB.Text);
				ResetBUTbg("ACB");
				int aslot = 0;
				bool found = false;
				foreach (string s in acallsHC) { if (s == ACBhcLAB.Text) { found = true; break; } if (found != true) { aslot++; } }

				//I kid you not I forgot where I was going with this... its 230am... so.. yea
			}
		}

		/// <summary>
		/// Sets the Button background color using Colors
		/// </summary>
		/// <param name="BUT"></param>
		/// <param name="C"></param>
		internal void changeBUTbg(string BUT, Color C)
		{
			switch (BUT)
			{
				case "ACB":
					acbBUT.FlatAppearance.MouseOverBackColor = C;
					acbBUT.FlatAppearance.MouseDownBackColor = C;
					acbBUT.BackColor = C;
					acbLAB1.BackColor = C;
					ACBhcLAB.BackColor = C;
					ACBtgLAB.BackColor = C;
					ACBicoPB.BackColor = C;
					break;

				case "C1":
					C1BUT.FlatAppearance.MouseOverBackColor = C;
					C1BUT.FlatAppearance.MouseDownBackColor = C;
					C1BUT.BackColor = C;
					C1lab1.BackColor = C;
					C1lab2.BackColor = C;
					break;

				case "C2":
					C2BUT.FlatAppearance.MouseOverBackColor = C;
					C2BUT.FlatAppearance.MouseDownBackColor = C;
					C2BUT.BackColor = C;
					C2lab1.BackColor = C;
					C2lab2.BackColor = C;
					break;

				case "C3":
					C3BUT.FlatAppearance.MouseOverBackColor = C;
					C3BUT.FlatAppearance.MouseDownBackColor = C;
					C3BUT.BackColor = C;
					C3lab1.BackColor = C;
					C3lab2.BackColor = C;
					break;

				case "C4":
					C4BUT.FlatAppearance.MouseOverBackColor = C;
					C4BUT.FlatAppearance.MouseDownBackColor = C;
					C4BUT.BackColor = C;
					C4lab1.BackColor = C;
					C5lab2.BackColor = C;
					break;

				case "C5":
					C5BUT.FlatAppearance.MouseOverBackColor = C;
					C5BUT.FlatAppearance.MouseDownBackColor = C;
					C5BUT.BackColor = C;
					C5lab1.BackColor = C;
					C5lab2.BackColor = C;
					break;
			}
		}

		/// <summary>
		/// Resets the Buttons background color
		/// </summary>
		/// <param name="BUT"></param>
		internal void ResetBUTbg(string BUT)
		{
			switch (BUT)
			{
				case "ACB":
					acbBUT.FlatAppearance.MouseOverBackColor = SystemColors.ControlLight;
					acbBUT.FlatAppearance.MouseDownBackColor = SystemColors.ControlLight;
					acbBUT.BackColor = SystemColors.ControlLight;
					acbLAB1.BackColor = SystemColors.ControlLight;
					ACBhcLAB.BackColor = SystemColors.ControlLight;
					ACBtgLAB.BackColor = SystemColors.ControlLight;
					ACBicoPB.BackColor = SystemColors.ControlLight;
					break;

				case "ACBR":
					acbBUT.FlatAppearance.MouseOverBackColor = SystemColors.ControlLight;
					acbBUT.FlatAppearance.MouseDownBackColor = SystemColors.ControlLight;
					acbBUT.BackColor = SystemColors.ControlLight;
					break;

				case "C1":
					C1BUT.FlatAppearance.MouseOverBackColor = Color.White;
					C1BUT.FlatAppearance.MouseDownBackColor = Color.White;
					C1BUT.BackColor = Color.White;
					C1lab1.BackColor = Color.White;
					C1lab2.BackColor = Color.White;
					break;

				case "C2":
					C2BUT.FlatAppearance.MouseOverBackColor = Color.White;
					C2BUT.FlatAppearance.MouseDownBackColor = Color.White;
					C2BUT.BackColor = Color.White;
					C2lab1.BackColor = Color.White;
					C2lab2.BackColor = Color.White;
					break;

				case "C3":
					C3BUT.FlatAppearance.MouseOverBackColor = Color.White;
					C3BUT.FlatAppearance.MouseDownBackColor = Color.White;
					C3BUT.BackColor = Color.White;
					C3lab1.BackColor = Color.White;
					C3lab2.BackColor = Color.White;
					break;

				case "C4":
					C4BUT.FlatAppearance.MouseOverBackColor = Color.White;
					C4BUT.FlatAppearance.MouseDownBackColor = Color.White;
					C4BUT.BackColor = Color.White;
					C4lab1.BackColor = Color.White;
					C4lab2.BackColor = Color.White;
					break;

				case "C5":
					C5BUT.FlatAppearance.MouseOverBackColor = Color.White;
					C5BUT.FlatAppearance.MouseDownBackColor = Color.White;
					C5BUT.BackColor = Color.White;
					C5lab1.BackColor = Color.White;
					C5lab2.BackColor = Color.White;
					break;
			}
		}

		internal static void ButtonBeep()
		{
			string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
			string wavFileName = "Sounds\\screen_beep.wav";
			string wavFilePath = Path.Combine(currentDirectory, wavFileName);
			if (File.Exists(wavFilePath))
			{
				try
				{
					using (SoundPlayer player = new SoundPlayer(wavFilePath))
					{
						player.Play();
					}
				}
				catch (Exception ex) { }
			}
		}

		private void ACBtimer_Tick(object sender, EventArgs e)
		{
			acbFLASHbut.Visible = true;
			acbFLASHbut.BackColor = Color.Orange;
			acbLAB1.Text = "[Answer Call]";
			acbLAB1.BackColor = Color.Orange;
			acbFLASHbut.FlatAppearance.MouseOverBackColor = Color.Orange;
			acbFLASHbut.FlatAppearance.MouseDownBackColor = Color.Orange;
			if (acbflashcycle == true)
			{
				acbflashcycle = false;
				ResetBUTbg("ACBR");
			}
			else
			{
				acbflashcycle = true;
				changeBUTbg("ACB", Color.Orange);
				string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
				string wavFileName = "Sounds\\GSM-R_Ring.wav";
				string wavFilePath = Path.Combine(currentDirectory, wavFileName);
				if (File.Exists(wavFilePath))
				{
					try
					{
						using (SoundPlayer player = new SoundPlayer(wavFilePath))
						{
							player.Play();
						}
					}
					catch (Exception ex) { }
				}
				else { }
			}
		}

		internal int AddNewCall(int rid, string TGNAME)
		{
			string headcode = string.Format("{0:x}", rid);
			int availslot = 0;
			bool foundslot = false;
			foreach (string s in acallsHC)
			{
				if (s == null)
				{
					foundslot = true;
					break;
				}
				else if (availslot != 5 && foundslot != true) { availslot++; }
				else { return 99; }
			}

			acallsHC[availslot] = headcode.ToUpper();
			acallsTG[availslot] = TGNAME;
			switch (availslot)
			{
				case 0:
					C1lab1.Text = headcode.ToUpper();
					C1lab2.Text = TGNAME;
					C1lab1.Visible = true;
					C1lab2.Visible = true;
					break;

				case 1:
					C2lab1.Text = headcode.ToUpper();
					C2lab2.Text = TGNAME;
					C2lab1.Visible = true;
					C2lab2.Visible = true;
					break;

				case 2:
					C3lab1.Text = headcode.ToUpper();
					C3lab2.Text = TGNAME;
					C3lab1.Visible = true;
					C3lab2.Visible = true;
					break;

				case 3:
					C4lab1.Text = headcode.ToUpper();
					C4lab2.Text = TGNAME;
					C4lab1.Visible = true;
					C4lab2.Visible = true;
					break;

				case 4:
					C5lab1.Text = headcode.ToUpper();
					C5lab2.Text = TGNAME;
					C5lab1.Visible = true;
					C5lab2.Visible = true;
					break;
			}
			return availslot;
		}

		internal void Removecall(string HC)
		{
			int availslot = 0;
			bool foundslot = false;
			foreach (string s in acallsHC)
			{
				if (s == HC)
				{
					foundslot = true;
					break;
				}
				else if (availslot != 5 && foundslot != true) { availslot++; }
				else { }
			}

			acallsHC[availslot] = null;
			acallsTG[availslot] = null;
			switch (availslot)
			{
				case 0:
					C1lab1.Text = "";
					C1lab2.Text = "";
					C1lab1.Visible = false;
					C1lab2.Visible = false;
					break;

				case 1:
					C2lab1.Text = "";
					C2lab2.Text = "";
					C2lab1.Visible = false;
					C2lab2.Visible = false;
					break;

				case 2:
					C3lab1.Text = "";
					C3lab2.Text = "";
					C3lab1.Visible = false;
					C3lab2.Visible = false;
					break;

				case 3:
					C4lab1.Text = "";
					C4lab2.Text = "";
					C4lab1.Visible = false;
					C4lab2.Visible = false;
					break;

				case 4:
					C5lab1.Text = "";
					C5lab2.Text = "";
					C5lab1.Visible = false;
					C5lab2.Visible = false;
					break;
			}
		}

		/// <summary>
		/// Maintance Timer
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mxtmr_Tick(object sender, EventArgs e)
		{
			//Make sure the date is correct, I shoudlnt be doing this ever 250ms...but I dont have a better Idea RN
			string DTMD = DateTime.Now.Day.ToString();
			DateTime M = DateTime.Now;
			string DTMM = M.ToString("MMMM");
			string DTMY = DateTime.Now.Year.ToString();
			daymonthyearLAB.Text = DTMD + " " + DTMM + " " + DTMY;

			//Check for New calls, if new calls exist, add them to the calls display
		}

		internal void RC2Con()
		{
			int RXA = 0;
			int TXA = 0;
			int WSP = 0;
			string WSA = Properties.Settings.Default.RC2WSAddr;

			try { WSP = int.Parse(Properties.Settings.Default.RC2WSPort); }
			catch (Exception)
			{
				MessageBox.Show("Please enter a Daemon address and port, k thx bye");
			}

			if (WSA != null && WSP != 0)
			{
				Connections.RC2(cts.Token, WSA, WSP, TXA, RXA);
			}
			else
			{
				MessageBox.Show("Please enter a Daemon address");
			}
		}

		private static void teardown()
		{
			//Stop Websocket and WebRTC Connections
			try
			{
				cts.Cancel();
			}
			catch (Exception) { }

			Application.Exit();
		}

		private void RadSch_FormClosing(object sender, FormClosingEventArgs e)
		{
			teardown();
		}
	}
}