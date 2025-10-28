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
using dvmgsmr_console.Properties;
using System.Media;
using Windows.Media.Playback;

namespace dvmgsmr_console
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		internal static bool CLOSE;

		private void Administratorbut_Click(object sender, EventArgs e)
		{
			ButtonBeep();
			AdminPage AP = new AdminPage();
			AP.ShowDialog();
		}

		internal static void ButtonBeep()
		{
			if (Settings.Default.ButtonBeep == true)
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
				else { }
			}
		}

		private void MaintTMR_Tick(object sender, EventArgs e)
		{
			string DTMD = DateTime.Now.Day.ToString();
			DateTime M = DateTime.Now;
			string DTMM = M.ToString("MMM");
			string DTMY = DateTime.Now.Year.ToString();
			daymonthyearLAB.Text = DTMD + " " + DTMM + " " + DTMY;
			if (CLOSE == true)
			{
				this.Hide();
				var RadSch = new RadSch();
				RadSch.Closed += (s, args) => this.Close();
				RadSch.Show();
				CLOSE = false;
			}
		}

		private void logginbutton_Click(object sender, EventArgs e)
		{
			ButtonBeep();
			if (Properties.Settings.Default.ConnMODE == "RC2")
			{
				if (Properties.Settings.Default.RC2WSAddr != "" && Properties.Settings.Default.RC2WSPort != "")
				{
					loginPage1.Visible = true;
					loginPage1.BringToFront();
					logginbutton.Visible = false;
					Administratorbut.Visible = false;
				}
				else { MessageBox.Show("Please Enter Server Information in the Administration settings"); }
			}
			else { MessageBox.Show("Please Enter Server Information in the Administration settings"); }
		}
	}
}