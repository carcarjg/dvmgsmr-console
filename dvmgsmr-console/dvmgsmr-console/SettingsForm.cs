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
	public partial class SettingsForm : Form
	{
		public SettingsForm()
		{
			InitializeComponent();
			if (Settings.Default.ButtonBeep == true)
			{
				buttonbeepButton.Text = "Enabled";
			}
			else
			{
				buttonbeepButton.Text = "Disabled";
			}
			if (Settings.Default.RingerOff == false)
			{
				Settings.Default.RingerOff = true;
				ringBut.Text = "Enabled";
			}
			else { Settings.Default.RingerOff = false; ringBut.Text = "Disabled"; }
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

		private void button1_Click(object sender, EventArgs e)
		{
			ButtonBeep();
			this.Close();
		}

		private void buttonbeepButton_Click(object sender, EventArgs e)
		{
			if (Settings.Default.ButtonBeep == true)
			{
				Settings.Default.ButtonBeep = false;
				buttonbeepButton.Text = "Disabled";
			}
			else
			{
				Settings.Default.ButtonBeep = true;
				buttonbeepButton.Text = "Enabled";
				ButtonBeep();
			}
		}

		private void ringBut_Click(object sender, EventArgs e)
		{
			ButtonBeep();
			if (Settings.Default.RingerOff == false)
			{
				Settings.Default.RingerOff = true;
				ringBut.Text = "Disabled";
			}
			else { Settings.Default.RingerOff = false; ringBut.Text = "Enabled"; }
		}
	}
}