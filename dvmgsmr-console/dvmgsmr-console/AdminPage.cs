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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dvmgsmr_console
{
	public partial class AdminPage : Form
	{
		public AdminPage()
		{
			InitializeComponent();
			switch (Properties.Settings.Default.ConnMODE)
			{
				case "RC2":
					rc2BUT.BackColor = Color.Blue;
					break;

				case "GSMR":
					break;

				case "SIP":
					break;
			}
		}

		private void rc2BUT_Click(object sender, EventArgs e)
		{
			Properties.Settings.Default.ConnMODE = "RC2";
			rc2BUT.BackColor = Color.Blue;
			ButtonBeep();
		}

		private void gsmrbut_Click(object sender, EventArgs e)
		{
			MessageBox.Show("GSMR Not Available as a Connection Type");
			ButtonBeep();
		}

		private void sipBUT_Click(object sender, EventArgs e)
		{
			MessageBox.Show("SIP Not Available as a Connection Type");
			ButtonBeep();
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
			else { }
		}
	}
}