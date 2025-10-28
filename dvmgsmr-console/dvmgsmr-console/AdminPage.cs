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
			svraddrTXT.Text = Properties.Settings.Default.RC2WSAddr;
			svrportTXT.Text = Properties.Settings.Default.RC2WSPort;
			switch (Properties.Settings.Default.RC2NumbCH)
			{
				case 1:
					button1.BackColor = Color.Blue;
					button2.BackColor = SystemColors.Control;
					button3.BackColor = SystemColors.Control;
					button4.BackColor = SystemColors.Control;
					button5.BackColor = SystemColors.Control;
					break;

				case 2:
					button1.BackColor = SystemColors.Control;
					button2.BackColor = Color.Blue;
					button3.BackColor = SystemColors.Control;
					button4.BackColor = SystemColors.Control;
					button5.BackColor = SystemColors.Control;
					break;

				case 3:
					button1.BackColor = SystemColors.Control;
					button2.BackColor = SystemColors.Control;
					button3.BackColor = Color.Blue;
					button4.BackColor = SystemColors.Control;
					button5.BackColor = SystemColors.Control;
					break;

				case 4:
					button1.BackColor = SystemColors.Control;
					button2.BackColor = SystemColors.Control;
					button3.BackColor = SystemColors.Control;
					button4.BackColor = Color.Blue;
					button5.BackColor = SystemColors.Control;
					break;

				case 5:
					button1.BackColor = SystemColors.Control;
					button2.BackColor = SystemColors.Control;
					button3.BackColor = SystemColors.Control;
					button4.BackColor = SystemColors.Control;
					button5.BackColor = Color.Blue;
					break;

				default:
					button1.BackColor = Color.Blue;
					button2.BackColor = SystemColors.Control;
					button3.BackColor = SystemColors.Control;
					button4.BackColor = SystemColors.Control;
					button5.BackColor = SystemColors.Control;
					break;
			}
			if (Properties.Settings.Default.RC2SigCHP)
			{
				yesBUT.BackColor = Color.Blue;
				noBUT.BackColor = SystemColors.Control;
			}
			else
			{
				yesBUT.BackColor = SystemColors.Control;
				noBUT.BackColor = Color.Blue;
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

		private void saveBUT_Click(object sender, EventArgs e)
		{
			ButtonBeep();
			if (svraddrTXT.Text != "" && svrportTXT.Text != "")
			{
				Properties.Settings.Default.RC2WSAddr = svraddrTXT.Text;
				Properties.Settings.Default.RC2WSPort = svrportTXT.Text;
			}
			else { MessageBox.Show("Please Enter Server Information"); }
			this.Close();
			Properties.Settings.Default.Save();
		}

		private void oskLaunchBUT_Click(object sender, EventArgs e)
		{
			ButtonBeep();
			try { System.Diagnostics.Process.Start("osk.exe"); } catch (Exception) { }
		}

		private void yesnoBUT_Click(object sender, EventArgs e)
		{
			ButtonBeep();
			if (sender.GetHashCode == yesBUT.GetHashCode)
			{
				yesBUT.BackColor = Color.Blue;
				noBUT.BackColor = SystemColors.Control;
			}
			else
			{
				noBUT.BackColor = Color.Blue;
				yesBUT.BackColor = SystemColors.Control;
			}
		}

		private void chNumbBUT_Click(object sender, EventArgs e)
		{
			ButtonBeep();
			if (sender.GetHashCode == button1.GetHashCode)
			{
				button1.BackColor = Color.Blue;
				button2.BackColor = SystemColors.Control;
				button3.BackColor = SystemColors.Control;
				button4.BackColor = SystemColors.Control;
				button5.BackColor = SystemColors.Control;
				Properties.Settings.Default.RC2NumbCH = 1;
			}
			else if (sender.GetHashCode == button2.GetHashCode)
			{
				button1.BackColor = SystemColors.Control;
				button2.BackColor = Color.Blue;
				button3.BackColor = SystemColors.Control;
				button4.BackColor = SystemColors.Control;
				button5.BackColor = SystemColors.Control;
				Properties.Settings.Default.RC2NumbCH = 2;
			}
			else if (sender.GetHashCode == button3.GetHashCode)
			{
				button1.BackColor = SystemColors.Control;
				button2.BackColor = SystemColors.Control;
				button3.BackColor = Color.Blue;
				button4.BackColor = SystemColors.Control;
				button5.BackColor = SystemColors.Control;
				Properties.Settings.Default.RC2NumbCH = 3;
			}
			else if (sender.GetHashCode == button4.GetHashCode)
			{
				button1.BackColor = SystemColors.Control;
				button2.BackColor = SystemColors.Control;
				button3.BackColor = SystemColors.Control;
				button4.BackColor = Color.Blue;
				button5.BackColor = SystemColors.Control;
				Properties.Settings.Default.RC2NumbCH = 4;
			}
			else if (sender.GetHashCode == button5.GetHashCode)
			{
				button1.BackColor = SystemColors.Control;
				button2.BackColor = SystemColors.Control;
				button3.BackColor = SystemColors.Control;
				button4.BackColor = SystemColors.Control;
				button5.BackColor = Color.Blue;
				Properties.Settings.Default.RC2NumbCH = 5;
			}
		}
	}
}