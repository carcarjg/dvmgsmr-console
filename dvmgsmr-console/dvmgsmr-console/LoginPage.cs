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

using Org.BouncyCastle.Utilities;
using System;
using System.Collections;
using System.Media;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace dvmgsmr_console
{
	public partial class LoginPage : UserControl
	{
		internal static string us3rB0x = "";

		internal static string PS = "";

		internal bool UserBoxSel = true;

		internal bool Shift = false;

		public LoginPage()
		{
			InitializeComponent();
			string DTMD = DateTime.Now.Day.ToString();
			DateTime M = DateTime.Now;
			string DTMM = M.ToString("MMM");
			string DTMY = DateTime.Now.Year.ToString();
			daymonthyearLAB.Text = DTMD + " " + DTMM + " " + DTMY;
			BUTlog.Enabled = false;
		}

		private void MaintTMR_Tick(object sender, EventArgs e)
		{
			string DTMD = DateTime.Now.Day.ToString();
			DateTime M = DateTime.Now;
			string DTMM = M.ToString("MMM");
			string DTMY = DateTime.Now.Year.ToString();
			daymonthyearLAB.Text = DTMD + " " + DTMM + " " + DTMY;
			if (us3rB0x.Length != 0 && PS.Length != 0 && BUTlog.ForeColor == SystemColors.ControlDark)
			{
				BUTlog.ForeColor = Color.Black;
				BUTlog.Enabled = true;
			}
			else if (us3rB0x.Length == 0 && PS.Length == 0 && BUTlog.ForeColor == Color.Black)
			{
				BUTlog.ForeColor = SystemColors.ControlDark;
				BUTlog.Enabled = false;
			}
		}

		private void BUTlog_Click(object sender, EventArgs e)
		{
			ButtonBeep();
			bool loginperm = false;

			//UserAuthCodeHere
			//For rn just open the main page
			if (us3rB0x == "ADMIN" && PS == "ADMIN")
			{
				UserInforStore.SigBox = "Network Control";
				UserInforStore.UserRole = "ADMIN";
				UserInforStore.boxPHnumb = 8002738255;
				loginperm = true;
			}
			else if (us3rB0x == "CMTY" && PS == "CMTY")
			{
				UserInforStore.SigBox = "CMTY Central Sub";
				UserInforStore.UserRole = "CMTY";
				UserInforStore.boxPHnumb = 8002738255;
				loginperm = true;
			}
			else
			{
				MessageBox.Show("Username/Password Incorrect");
			}

			if (loginperm == true)
			{
				using (Aes aesAlg = Aes.Create())
				{
					byte[] key = Convert.FromHexString("1d7f44327a2fe29429d976d267e87b4f5290f87c221636f4c680c1e906340e4c");
					byte[] iv = Convert.FromHexString("5f7b7a6b7d1092774a31ba13470b78f0");
					aesAlg.Key = key;
					aesAlg.IV = iv;

					ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

					using (MemoryStream msEncrypt = new MemoryStream())
					{
						using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
						{
							using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
							{
								swEncrypt.Write(PS);
							}

							PS = Convert.ToBase64String(msEncrypt.ToArray());
						}
					}
				}
				loginperm = false;
				MainForm.CLOSE = true;
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
			else { }
		}

		private void KBBUT_Click(object sender, EventArgs e)
		{
			if (sender.GetHashCode() == BUTqustat.GetHashCode())
			{
				if (UserBoxSel == true && Shift == false) { us3rB0x = us3rB0x + "?"; UserLAB.Text = us3rB0x; }
				else if (UserBoxSel == true && Shift == true) { us3rB0x = us3rB0x + "@"; UserLAB.Text = us3rB0x; }
				else if (UserBoxSel == false && Shift == false) { PS = PS + "?"; passLAB.Text = PS; }
				else { PS = PS + "@"; passLAB.Text = PS; }
			}
			else if (sender.GetHashCode() == BUTbars.GetHashCode())
			{
				if (UserBoxSel == true && Shift == false) { us3rB0x = us3rB0x + "_"; UserLAB.Text = us3rB0x; }
				else if (UserBoxSel == true && Shift == true) { us3rB0x = us3rB0x + "-"; UserLAB.Text = us3rB0x; }
				else if (UserBoxSel == false && Shift == false) { PS = PS + "_"; passLAB.Text = PS; }
				else { PS = PS + "-"; passLAB.Text = PS; }
			}
			else if (sender.GetHashCode() == BUTexl.GetHashCode())
			{
				if (UserBoxSel == true && Shift == false) { us3rB0x = us3rB0x + ","; UserLAB.Text = us3rB0x; }
				else if (UserBoxSel == true && Shift == true) { us3rB0x = us3rB0x + "!"; UserLAB.Text = us3rB0x; }
				else if (UserBoxSel == false && Shift == false) { PS = PS + ","; passLAB.Text = PS; }
				else { PS = PS + "!"; passLAB.Text = PS; }
			}
			else if (sender.GetHashCode() == BUTplus.GetHashCode())
			{
				if (UserBoxSel == true && Shift == false) { us3rB0x = us3rB0x + "\""; UserLAB.Text = us3rB0x; }
				else if (UserBoxSel == true && Shift == true) { us3rB0x = us3rB0x + "+"; UserLAB.Text = us3rB0x; }
				else if (UserBoxSel == false && Shift == false) { PS = PS + "\""; passLAB.Text = PS; }
				else { PS = PS + "+"; passLAB.Text = PS; }
			}
			else if (sender.GetHashCode() == BUThash.GetHashCode())
			{
				if (UserBoxSel == true && Shift == false) { us3rB0x = us3rB0x + "."; UserLAB.Text = us3rB0x; }
				else if (UserBoxSel == true && Shift == true) { us3rB0x = us3rB0x + "#"; UserLAB.Text = us3rB0x; }
				else if (UserBoxSel == false && Shift == false) { PS = PS + "."; passLAB.Text = PS; }
				else { PS = PS + "#"; passLAB.Text = PS; }
			}
			else if (sender.GetHashCode() == BUTshift.GetHashCode())
			{
				if (Shift == false)
				{
					Shift = true;
					BUTshift.FlatAppearance.BorderSize = 2;
					BUTshift.FlatAppearance.BorderColor = Color.Red;
				}
				else if (Shift == true)
				{
					Shift = false;
					BUTshift.FlatAppearance.BorderSize = 0;
				}
			}
			else if (sender.GetHashCode() == BUTspace.GetHashCode())
			{
				if (UserBoxSel == true) { us3rB0x = us3rB0x + " "; UserLAB.Text = us3rB0x; }
				else { PS = PS + " "; passLAB.Text = PS; }
			}
			else if (sender.GetHashCode() == BUTbackspace.GetHashCode() || sender.GetHashCode() == BUTdelete.GetHashCode())
			{
				if (UserBoxSel == true)
				{
					if (us3rB0x.Length != 0)
					{
						us3rB0x = us3rB0x.Substring(0, us3rB0x.Length - 1);
						UserLAB.Text = us3rB0x;
					}
				}
				else
				{
					if (PS.Length != 0)
					{
						PS = PS.Substring(0, PS.Length - 1);
						passLAB.Text = PS;
					}
				}
			}
			else if (sender.GetHashCode() == BUT1.GetHashCode())
			{
				if (UserBoxSel == true) { us3rB0x = us3rB0x + "1"; UserLAB.Text = us3rB0x; }
				else { PS = PS + "1"; passLAB.Text = PS; }
			}
			else if (sender.GetHashCode() == BUT2.GetHashCode())
			{
				if (UserBoxSel == true) { us3rB0x = us3rB0x + "2"; UserLAB.Text = us3rB0x; }
				else { PS = PS + "2"; passLAB.Text = PS; }
			}
			else if (sender.GetHashCode() == BUT3.GetHashCode())
			{
				if (UserBoxSel == true) { us3rB0x = us3rB0x + "3"; UserLAB.Text = us3rB0x; }
				else { PS = PS + "3"; passLAB.Text = PS; }
			}
			else if (sender.GetHashCode() == BUT4.GetHashCode())
			{
				if (UserBoxSel == true) { us3rB0x = us3rB0x + "4"; UserLAB.Text = us3rB0x; }
				else { PS = PS + "4"; passLAB.Text = PS; }
			}
			else if (sender.GetHashCode() == BUT5.GetHashCode())
			{
				if (UserBoxSel == true) { us3rB0x = us3rB0x + "5"; UserLAB.Text = us3rB0x; }
				else { PS = PS + "5"; passLAB.Text = PS; }
			}
			else if (sender.GetHashCode() == BUT6.GetHashCode())
			{
				if (UserBoxSel == true) { us3rB0x = us3rB0x + "6"; UserLAB.Text = us3rB0x; }
				else { PS = PS + "6"; passLAB.Text = PS; }
			}
			else if (sender.GetHashCode() == BUT7.GetHashCode())
			{
				if (UserBoxSel == true) { us3rB0x = us3rB0x + "7"; UserLAB.Text = us3rB0x; }
				else { PS = PS + "7"; passLAB.Text = PS; }
			}
			else if (sender.GetHashCode() == BUT8.GetHashCode())
			{
				if (UserBoxSel == true) { us3rB0x = us3rB0x + "8"; UserLAB.Text = us3rB0x; }
				else { PS = PS + "8"; passLAB.Text = PS; }
			}
			else if (sender.GetHashCode() == BUT9.GetHashCode())
			{
				if (UserBoxSel == true) { us3rB0x = us3rB0x + "9"; UserLAB.Text = us3rB0x; }
				else { PS = PS + "9"; passLAB.Text = PS; }
			}
			else if (sender.GetHashCode() == BUT0.GetHashCode())
			{
				if (UserBoxSel == true) { us3rB0x = us3rB0x + "0"; UserLAB.Text = us3rB0x; }
				else { PS = PS + "0"; passLAB.Text = PS; }
			}
			else if (sender.GetHashCode() == BUTQ.GetHashCode())
			{
				if (UserBoxSel == true) { us3rB0x = us3rB0x + "Q"; UserLAB.Text = us3rB0x; }
				else { PS = PS + "Q"; passLAB.Text = PS; }
			}
			else if (sender.GetHashCode() == BUTW.GetHashCode())
			{
				if (UserBoxSel == true) { us3rB0x = us3rB0x + "W"; UserLAB.Text = us3rB0x; }
				else { PS = PS + "W"; passLAB.Text = PS; }
			}
			else if (sender.GetHashCode() == BUTE.GetHashCode())
			{
				if (UserBoxSel == true) { us3rB0x = us3rB0x + "E"; UserLAB.Text = us3rB0x; }
				else { PS = PS + "E"; passLAB.Text = PS; }
			}
			else if (sender.GetHashCode() == BUTR.GetHashCode())
			{
				if (UserBoxSel == true) { us3rB0x = us3rB0x + "R"; UserLAB.Text = us3rB0x; }
				else { PS = PS + "R"; passLAB.Text = PS; }
			}
			else if (sender.GetHashCode() == BUTT.GetHashCode())
			{
				if (UserBoxSel == true) { us3rB0x = us3rB0x + "T"; UserLAB.Text = us3rB0x; }
				else { PS = PS + "T"; passLAB.Text = PS; }
			}
			else if (sender.GetHashCode() == BUTY.GetHashCode())
			{
				if (UserBoxSel == true) { us3rB0x = us3rB0x + "Y"; UserLAB.Text = us3rB0x; }
				else { PS = PS + "Y"; passLAB.Text = PS; }
			}
			else if (sender.GetHashCode() == BUTU.GetHashCode())
			{
				if (UserBoxSel == true) { us3rB0x = us3rB0x + "U"; UserLAB.Text = us3rB0x; }
				else { PS = PS + "U"; passLAB.Text = PS; }
			}
			else if (sender.GetHashCode() == BUTI.GetHashCode())
			{
				if (UserBoxSel == true) { us3rB0x = us3rB0x + "I"; UserLAB.Text = us3rB0x; }
				else { PS = PS + "I"; passLAB.Text = PS; }
			}
			else if (sender.GetHashCode() == BUTO.GetHashCode())
			{
				if (UserBoxSel == true) { us3rB0x = us3rB0x + "O"; UserLAB.Text = us3rB0x; }
				else { PS = PS + "O"; passLAB.Text = PS; }
			}
			else if (sender.GetHashCode() == BUTP.GetHashCode())
			{
				if (UserBoxSel == true) { us3rB0x = us3rB0x + "P"; UserLAB.Text = us3rB0x; }
				else { PS = PS + "P"; passLAB.Text = PS; }
			}
			else if (sender.GetHashCode() == BUTA.GetHashCode())
			{
				if (UserBoxSel == true) { us3rB0x = us3rB0x + "A"; UserLAB.Text = us3rB0x; }
				else { PS = PS + "A"; passLAB.Text = PS; }
			}
			else if (sender.GetHashCode() == BUTS.GetHashCode())
			{
				if (UserBoxSel == true) { us3rB0x = us3rB0x + "S"; UserLAB.Text = us3rB0x; }
				else { PS = PS + "S"; passLAB.Text = PS; }
			}
			else if (sender.GetHashCode() == BUTD.GetHashCode())
			{
				if (UserBoxSel == true) { us3rB0x = us3rB0x + "D"; UserLAB.Text = us3rB0x; }
				else { PS = PS + "D"; passLAB.Text = PS; }
			}
			else if (sender.GetHashCode() == BUTF.GetHashCode())
			{
				if (UserBoxSel == true) { us3rB0x = us3rB0x + "F"; UserLAB.Text = us3rB0x; }
				else { PS = PS + "F"; passLAB.Text = PS; }
			}
			else if (sender.GetHashCode() == BUTG.GetHashCode())
			{
				if (UserBoxSel == true) { us3rB0x = us3rB0x + "G"; UserLAB.Text = us3rB0x; }
				else { PS = PS + "G"; passLAB.Text = PS; }
			}
			else if (sender.GetHashCode() == BUTH.GetHashCode())
			{
				if (UserBoxSel == true) { us3rB0x = us3rB0x + "H"; UserLAB.Text = us3rB0x; }
				else { PS = PS + "H"; passLAB.Text = PS; }
			}
			else if (sender.GetHashCode() == BUTJ.GetHashCode())
			{
				if (UserBoxSel == true) { us3rB0x = us3rB0x + "J"; UserLAB.Text = us3rB0x; }
				else { PS = PS + "J"; passLAB.Text = PS; }
			}
			else if (sender.GetHashCode() == BUTK.GetHashCode())
			{
				if (UserBoxSel == true) { us3rB0x = us3rB0x + "K"; UserLAB.Text = us3rB0x; }
				else { PS = PS + "K"; passLAB.Text = PS; }
			}
			else if (sender.GetHashCode() == BUTL.GetHashCode())
			{
				if (UserBoxSel == true) { us3rB0x = us3rB0x + "L"; UserLAB.Text = us3rB0x; }
				else { PS = PS + "L"; passLAB.Text = PS; }
			}
			else if (sender.GetHashCode() == BUTZ.GetHashCode())
			{
				if (UserBoxSel == true) { us3rB0x = us3rB0x + "Z"; UserLAB.Text = us3rB0x; }
				else { PS = PS + "Z"; passLAB.Text = PS; }
			}
			else if (sender.GetHashCode() == BUTX.GetHashCode())
			{
				if (UserBoxSel == true) { us3rB0x = us3rB0x + "X"; UserLAB.Text = us3rB0x; }
				else { PS = PS + "X"; passLAB.Text = PS; }
			}
			else if (sender.GetHashCode() == BUTC.GetHashCode())
			{
				if (UserBoxSel == true) { us3rB0x = us3rB0x + "C"; UserLAB.Text = us3rB0x; }
				else { PS = PS + "C"; passLAB.Text = PS; }
			}
			else if (sender.GetHashCode() == BUTV.GetHashCode())
			{
				if (UserBoxSel == true) { us3rB0x = us3rB0x + "V"; UserLAB.Text = us3rB0x; }
				else { PS = PS + "V"; passLAB.Text = PS; }
			}
			else if (sender.GetHashCode() == BUTB.GetHashCode())
			{
				if (UserBoxSel == true) { us3rB0x = us3rB0x + "B"; UserLAB.Text = us3rB0x; }
				else { PS = PS + "B"; passLAB.Text = PS; }
			}
			else if (sender.GetHashCode() == BUTN.GetHashCode())
			{
				if (UserBoxSel == true) { us3rB0x = us3rB0x + "N"; UserLAB.Text = us3rB0x; }
				else { PS = PS + "N"; passLAB.Text = PS; }
			}
			else if (sender.GetHashCode() == BUTM.GetHashCode())
			{
				if (UserBoxSel == true) { us3rB0x = us3rB0x + "M"; UserLAB.Text = us3rB0x; }
				else { PS = PS + "M"; passLAB.Text = PS; }
			}
			else if (sender.GetHashCode() == BUTUP.GetHashCode())
			{
				if (UserBoxSel == true) { UserBoxSel = false; }
				else { UserBoxSel = true; }
			}
			else if (sender.GetHashCode() == BUTDOWN.GetHashCode())
			{
				if (UserBoxSel == true) { UserBoxSel = false; }
				else { UserBoxSel = true; }
			}
			ButtonBeep();
		}
	}
}