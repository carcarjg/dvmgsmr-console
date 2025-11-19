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
///TODO:MXTMR needs to handle pending calls, Current ACBed call needs to be blue in the list, all others if they are in the list need to be Purple if pending, green if RXing,
///ACB needs to also be able to switch between calls and put a call on "hold"
using dvmgsmr_console.Properties;
using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using NHotkey;
using NHotkey.WindowsForms;
using Org.BouncyCastle.Pqc.Crypto.Frodo;
using System.Collections.Generic;
using System.Configuration;
using System.Media;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml.Linq;
using Windows.Perception.People;
using Windows.UI.Composition;

namespace dvmgsmr_console
{
	public partial class RadSch : Form
	{
		private bool acbflashcycle;

		private bool fireonce;

		internal static bool callringging;

		internal static bool activecall;

		internal static Dictionary<int, string> Pending_CallsRID = new Dictionary<int, string>();

		internal static Dictionary<int, string> Pending_CallsTG = new Dictionary<int, string>();

		internal static Dictionary<int, string> Pending_CallsType = new Dictionary<int, string>();

		internal static Dictionary<string, int> TG_to_ConID = new Dictionary<string, int>();

		internal static Dictionary<string, int> Pend_RX_Text_TextIDs = new Dictionary<string, int>();

		internal static Dictionary<int, string> Pend_RX_Text = new Dictionary<int, string>();

		internal static Dictionary<int, string> Pend_RX_Text_Subj = new Dictionary<int, string>();

		internal static Dictionary<int, string> Pend_RX_Text_Src = new Dictionary<int, string>();

		/// <summary>
		/// Key = From Addr
		/// Value = TxtMsgID
		/// </summary>
		internal static Dictionary<string, int> Pend_RX_Text_ToSlot = new Dictionary<string, int>();

		internal static Dictionary<string, int> RX_Text_TextIDs = new Dictionary<string, int>();

		internal static Dictionary<int, string> RX_Text = new Dictionary<int, string>();

		internal static Dictionary<int, string> RX_Text_Subj = new Dictionary<int, string>();

		internal static Dictionary<int, string> RX_Text_Src = new Dictionary<int, string>();

		/// <summary>
		/// Key = From Addr
		/// Value = TxtMsgID
		/// </summary>
		internal static Dictionary<string, int> RX_Text_ToSlot = new Dictionary<string, int>();

		internal static string[] acallsHC = new string[4];

		internal static string calltype;

		internal static string[] acallsTG = new string[4];

		internal static int selCallID;

		private static readonly CancellationTokenSource cts = new CancellationTokenSource();

		internal static bool callspending;

		internal static bool callwaitingpickup;

		internal static bool textpending;

		internal static bool textwaitingack;

		internal static int nextTMSID;

		internal static int selectedPendTXTBOX = 0;

		internal static int selectedTXTBOX = 0;

		/// <summary>
		/// Tab 5 = Incoming (Default)
		/// Tab 4 = Trains Mobiles
		/// Tab 3 = Log
		/// Tab 2 = Speed Dial
		/// Tab 1 = Group Call
		/// </summary>
		internal int currenttab = 5;

		public RadSch()
		{
			InitializeComponent();
			nextTMSID = Settings.Default.NextTXMID;
			acbLAB1.Text = "Ready";
			acbLAB1.TextAlign = ContentAlignment.MiddleRight;
			string DTMD = DateTime.Now.Day.ToString();
			DateTime M = DateTime.Now;
			string DTMM = M.ToString("MMMM");
			string DTMY = DateTime.Now.Year.ToString();
			daymonthyearLAB.Text = DTMD + " " + DTMM + " " + DTMY;
			RoleLab.Text = UserInforStore.SigBox;
			BoxAndNumbErLAB.Text = UserInforStore.SigBox + " (" + UserInforStore.boxPHnumb + ")";
			switch (currenttab)
			{
				case 5:
					IncomingPanel.Visible = true;
					IncomingTabBUT.ForeColor = Color.FromArgb(6, 158, 230);
					GrpCallTABBUt.ForeColor = Color.Black;
					SpdDialTABBUT.ForeColor = Color.Black;
					LogTabBUT.ForeColor = Color.Black;
					TraingMobTABBUT.ForeColor = Color.Black;
					break;

				case 4:
					IncomingPanel.Visible = false;
					IncomingTabBUT.ForeColor = Color.Black;
					GrpCallTABBUt.ForeColor = Color.Black;
					SpdDialTABBUT.ForeColor = Color.Black;
					LogTabBUT.ForeColor = Color.Black;
					TraingMobTABBUT.ForeColor = Color.FromArgb(6, 158, 230);
					break;

				case 3:
					IncomingPanel.Visible = false;
					IncomingTabBUT.ForeColor = Color.Black;
					GrpCallTABBUt.ForeColor = Color.Black;
					SpdDialTABBUT.ForeColor = Color.Black;
					LogTabBUT.ForeColor = Color.FromArgb(6, 158, 230);
					TraingMobTABBUT.ForeColor = Color.Black;
					break;

				case 2:
					IncomingPanel.Visible = false;
					IncomingTabBUT.ForeColor = Color.Black;
					GrpCallTABBUt.ForeColor = Color.Black;
					SpdDialTABBUT.ForeColor = Color.FromArgb(6, 158, 230);
					LogTabBUT.ForeColor = Color.Black;
					TraingMobTABBUT.ForeColor = Color.Black;
					break;

				case 1:
					IncomingPanel.Visible = false;
					IncomingTabBUT.ForeColor = Color.Black;
					GrpCallTABBUt.ForeColor = Color.FromArgb(6, 158, 230);
					SpdDialTABBUT.ForeColor = Color.Black;
					LogTabBUT.ForeColor = Color.Black;
					TraingMobTABBUT.ForeColor = Color.Black;
					break;
			}
			if (Properties.Settings.Default.ConnMODE == "RC2")
			{
				RC2Con();
			}
			NewTxTMsg(0, UserInforStore.SigBox, "new role", UserInforStore.SigBox + "role added to your FT");
			HotkeyManager.Current.AddOrReplace("PTT", Keys.F7, OnF7PTT);

#if DEBUG

			//ringACB(500150, "CM_RAIL");
#endif
		}

		private void OnF7PTT(object sender, HotkeyEventArgs e)
		{
			switch (CheckForCallTG(ACBtgLAB.Text))
			{
				case 0:
					if (Connections.TXC1 == true)
					{
						Connections.TXSR1 = true;
						Connections.TXC1 = false;
					}
					else
					{
						Connections.TXR1 = true;
						Connections.TXC1 = true;
					}

					break;

				case 1:
					if (Connections.TXC2 == true)
					{
						Connections.TXSR2 = true;
						Connections.TXC2 = false;
					}
					else
					{
						Connections.TXR2 = true;
						Connections.TXC2 = true;
					}
					break;

				case 2:
					if (Connections.TXC3 == true)
					{
						Connections.TXSR3 = true;
						Connections.TXC3 = false;
					}
					else
					{
						Connections.TXR3 = true;
						Connections.TXC3 = true;
					}
					break;

				case 3:
					if (Connections.TXC4 == true)
					{
						Connections.TXSR4 = true;
						Connections.TXC4 = false;
					}
					else
					{
						Connections.TXR4 = true;
						Connections.TXC4 = true;
					}
					break;

				case 4:
					if (Connections.TXC5 == true)
					{
						Connections.TXSR5 = true;
						Connections.TXC5 = false;
					}
					else
					{
						Connections.TXR5 = true;
						Connections.TXC5 = true;
					}
					break;

				case 5:
					if (Connections.TXC6 == true)
					{
						Connections.TXSR6 = true;
						Connections.TXC6 = false;
					}
					else
					{
						Connections.TXR6 = true;
						Connections.TXC6 = true;
					}
					break;
			}

			e.Handled = true;
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
			if (calltype == "Train")
			{
				ACBicoPB.Image = Resources._9_96528_best_free_train_png_icon_train_icon__1_;
			}
			else if (calltype == "UnregTrain")
			{
			}
			else if (calltype == "SigBox")
			{
			}
			else if (calltype == "Phone")
			{
			}

			ACBtimer.Start();
		}

		internal void updateACB(int HC, string TG)
		{
			ACBhcLAB.Text = string.Format("{0:x}", HC).ToUpper();
			ACBtgLAB.Text = TG;
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
				callwaitingpickup = false;
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
				int call = CheckForCallTG(ACBtgLAB.Text);
				switch (call)
				{
					case 0:
						ResetBUTbg("C1");
						break;

					case 1:
						ResetBUTbg("C2");
						break;

					case 2:
						ResetBUTbg("C3");
						break;

					case 3:
						ResetBUTbg("C4");
						break;
				}
				Removecall(ACBhcLAB.Text);
				ResetBUTbg("ACB");
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
					C1lab1.ForeColor = Color.Black;
					C1lab2.ForeColor = Color.Black;
					break;

				case "C2":
					C2BUT.FlatAppearance.MouseOverBackColor = Color.White;
					C2BUT.FlatAppearance.MouseDownBackColor = Color.White;
					C2BUT.BackColor = Color.White;
					C2lab1.BackColor = Color.White;
					C2lab2.BackColor = Color.White;
					C2lab1.ForeColor = Color.Black;
					C2lab2.ForeColor = Color.Black;
					break;

				case "C3":
					C3BUT.FlatAppearance.MouseOverBackColor = Color.White;
					C3BUT.FlatAppearance.MouseDownBackColor = Color.White;
					C3BUT.BackColor = Color.White;
					C3lab1.BackColor = Color.White;
					C3lab2.BackColor = Color.White;
					C3lab1.ForeColor = Color.Black;
					C3lab2.ForeColor = Color.Black;
					break;

				case "C4":
					C4BUT.FlatAppearance.MouseOverBackColor = Color.White;
					C4BUT.FlatAppearance.MouseDownBackColor = Color.White;
					C4BUT.BackColor = Color.White;
					C4lab1.BackColor = Color.White;
					C4lab2.BackColor = Color.White;
					C4lab1.ForeColor = Color.Black;
					C4lab2.ForeColor = Color.Black;
					break;

				case "C5":
					C5BUT.FlatAppearance.MouseOverBackColor = Color.White;
					C5BUT.FlatAppearance.MouseDownBackColor = Color.White;
					C5BUT.BackColor = Color.White;
					C5lab1.BackColor = Color.White;
					C5lab2.BackColor = Color.White;
					C5lab1.ForeColor = Color.Black;
					C5lab2.ForeColor = Color.Black;
					break;
			}
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
				if (Settings.Default.RingerOff != true)
				{
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
						catch (Exception) { }
					}
					else { }
				}
			}
		}

		internal int AddNewCall(int rid, string TGNAME)
		{
			string headcode = string.Format("{0:x}", rid);
			int availslot = 0;
			bool foundslot = false;
			foreach (string s in acallsHC)
			{
				if (s == null && foundslot != true)
				{
					foundslot = true;
				}
				if (availslot != 5 && foundslot != true)
				{
					availslot++;
				}
				if (availslot == 5 && foundslot != true) { return 99; }
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
					C1lab1.ForeColor = Color.White;
					C1lab2.ForeColor = Color.White;
					changeBUTbg("C1", Color.Blue);
					break;

				case 1:
					C2lab1.Text = headcode.ToUpper();
					C2lab2.Text = TGNAME;
					C2lab1.Visible = true;
					C2lab2.Visible = true;
					C2lab1.ForeColor = Color.White;
					C2lab2.ForeColor = Color.White;
					changeBUTbg("C2", Color.Blue);
					break;

				case 2:
					C3lab1.Text = headcode.ToUpper();
					C3lab2.Text = TGNAME;
					C3lab1.Visible = true;
					C3lab2.Visible = true;
					C3lab1.ForeColor = Color.White;
					C3lab2.ForeColor = Color.White;
					changeBUTbg("C3", Color.Blue);
					break;

				case 3:
					C4lab1.Text = headcode.ToUpper();
					C4lab2.Text = TGNAME;
					C4lab1.Visible = true;
					C4lab2.Visible = true;
					C4lab1.ForeColor = Color.White;
					C4lab2.ForeColor = Color.White;
					changeBUTbg("C4", Color.Blue);
					break;

				case 4:
					C5lab1.Text = headcode.ToUpper();
					C5lab2.Text = TGNAME;
					C5lab1.Visible = true;
					C5lab2.Visible = true;
					C5lab1.ForeColor = Color.White;
					C5lab2.ForeColor = Color.White;
					changeBUTbg("C5", Color.Blue);
					break;
			}
			ringACB(rid, TGNAME);
			int callnumb;
			if (activecall == true)
			{
				callnumb = Pending_CallsRID.Count + 1;
			}
			else if (Pending_CallsRID.Count == 0 && activecall == true) { callnumb = 2; }
			else { callnumb = 1; }
			IncomingTabBUT.Text = "Incoming (" + callnumb + ")";
			callcreateinprog = false;
			return availslot;
		}

		internal void Removecall(string HC)
		{
			int availslot = CheckForCallHC(HC);
			int gotvalue;
			TG_to_ConID.TryGetValue(acallsTG[availslot], out gotvalue);
			switch (gotvalue)
			{
				case 1:
					Connections.CID1 = "";
					break;

				case 2:
					Connections.CID2 = "";
					break;

				case 3:
					Connections.CID3 = "";
					break;

				case 4:
					Connections.CID4 = "";
					break;

				case 5:
					Connections.CID5 = "";
					break;

				case 6:
					Connections.CID6 = "";
					break;
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
			int callnumb;
			if (activecall == true)
			{
				callnumb = Pending_CallsRID.Count + 1;
			}
			else if (Pending_CallsRID.Count == 0 && activecall == true) { callnumb = 2; }
			else { callnumb = 1; }
			callnumb = callnumb - 1;
			if (callnumb != 0) { IncomingTabBUT.Text = "Incoming (" + callnumb + ")"; } else { IncomingTabBUT.Text = "Incoming"; }
		}

		private static bool callcreateinprog = false;

		private static bool createcallpendinprog = false;

		internal void AddPendingCall(int rid, string TGNAME)
		{
			int clid;
			TG_to_ConID.TryGetValue(TGNAME, out clid);
			if (clid != 0)
			{
				Pending_CallsRID.TryAdd(clid, rid.ToString());
				Pending_CallsTG.TryAdd(clid, TGNAME);
			}

			string headcode = string.Format("{0:x}", rid);
			int availslot = 0;
			bool foundslot = false;
			foreach (string s in acallsHC)
			{
				if (s == null && foundslot != true)
				{
					foundslot = true;
				}
				if (availslot != 5 && foundslot != true)
				{
					availslot++;
				}
				if (availslot == 5 && foundslot != true) { }
			}
			if (CheckForCallTG(TGNAME) == 99 && createcallpendinprog == false)
			{
				createcallpendinprog = true;
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
			}

			callspending = true;
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

			if (Connections.RXC6 == true)
			{
				if (Connections.CID6 != "0" && Connections.CID6 != "")
				{
					int checkedcall = CheckForCallTG(Connections.CCH6);
					if (checkedcall != 99)
					{
						if (acallsHC[checkedcall] == Connections.CID6)
						{
							//Do nothing
						}
						else
						{
							UpdateCall(checkedcall, Connections.CID6, Connections.CCH6);
						}
					}
					else
					{
						if (callcreateinprog != true && activecall != true && callwaitingpickup != true)
						{
							callcreateinprog = true;
							callwaitingpickup = true;
							calltype = "TRAIN";
							AddNewCall(int.Parse(Connections.CID6), Connections.CCH6);
						}
						else
						{
							AddPendingCall(int.Parse(Connections.CID6), Connections.CCH6);

							callspending = true;

							///You Left off here
							///Update: I forgot what I left off doing
						}
					}
					checkedcall = 0;
				}
			}
			else { Connections.CID6 = "0"; }
			if (Connections.RXC1 == true)
			{
				if (Connections.CID1 != "0" && Connections.CID1 != "")
				{
					int checkedcall = CheckForCallTG(Connections.CCH1);
					if (checkedcall != 99)
					{
						if (acallsHC[checkedcall] == Connections.CID1)
						{
							//Do nothing
						}
						else
						{
							UpdateCall(checkedcall, Connections.CID1, Connections.CCH1);
						}
					}
					else
					{
						if (callcreateinprog != true && activecall != true && callwaitingpickup != true)
						{
							callcreateinprog = true;
							callwaitingpickup = true;
							calltype = "TRAIN";
							AddNewCall(int.Parse(Connections.CID1), Connections.CCH1);
						}
						else
						{
							AddPendingCall(int.Parse(Connections.CID1), Connections.CCH1);

							callspending = true;
						}
					}
					checkedcall = 0;
				}
			}
			else { Connections.CID1 = "0"; }
			if (Connections.RXC2 == true)
			{
				if (Connections.CID2 != "0" && Connections.CID2 != "")
				{
					int checkedcall = CheckForCallTG(Connections.CCH2);
					if (checkedcall != 99)
					{
						if (acallsHC[checkedcall] == Connections.CID2)
						{
							//Do nothing
						}
						else
						{
							UpdateCall(checkedcall, Connections.CID2, Connections.CCH2);
						}
					}
					else
					{
						if (callcreateinprog != true && activecall != true && callwaitingpickup != true)
						{
							callcreateinprog = true;
							callwaitingpickup = true;
							calltype = "TRAIN";
							AddNewCall(int.Parse(Connections.CID2), Connections.CCH2);
						}
						else
						{
							AddPendingCall(int.Parse(Connections.CID2), Connections.CCH2);

							callspending = true;
						}
					}
					checkedcall = 0;
				}
			}
			else { Connections.CID2 = "0"; }
			if (Connections.RXC3 == true)
			{
				if (Connections.CID3 != "0" && Connections.CID3 != "")
				{
					int checkedcall = CheckForCallTG(Connections.CCH3);
					if (checkedcall != 99)
					{
						if (acallsHC[checkedcall] == Connections.CID3)
						{
							//Do nothing
						}
						else
						{
							UpdateCall(checkedcall, Connections.CID3, Connections.CCH3);
						}
					}
					else
					{
						if (callcreateinprog != true && activecall != true && callwaitingpickup != true)
						{
							callcreateinprog = true;
							callwaitingpickup = true;
							calltype = "TRAIN";
							AddNewCall(int.Parse(Connections.CID3), Connections.CCH3);
						}
						else
						{
							AddPendingCall(int.Parse(Connections.CID3), Connections.CCH3);

							callspending = true;
						}
					}
					checkedcall = 0;
				}
			}
			else { Connections.CID3 = "0"; }
			if (Connections.RXC4 == true)
			{
				if (Connections.CID4 != "0" && Connections.CID4 != "")
				{
					int checkedcall = CheckForCallTG(Connections.CCH4);
					if (checkedcall != 99)
					{
						if (acallsHC[checkedcall] == Connections.CID4)
						{
							//Do nothing
						}
						else
						{
							UpdateCall(checkedcall, Connections.CID4, Connections.CCH4);
						}
					}
					else
					{
						if (callcreateinprog != true && activecall != true && callwaitingpickup != true)
						{
							callcreateinprog = true;
							callwaitingpickup = true;
							calltype = "TRAIN";
							AddNewCall(int.Parse(Connections.CID4), Connections.CCH4);
						}
						else
						{
							AddPendingCall(int.Parse(Connections.CID4), Connections.CCH4);

							callspending = true;
						}
					}
					checkedcall = 0;
				}
			}
			else { Connections.CID4 = "0"; }
			if (Connections.RXC5 == true)
			{
				if (Connections.CID5 != "0" && Connections.CID5 != "")
				{
					int checkedcall = CheckForCallTG(Connections.CCH5);
					if (checkedcall != 99)
					{
						if (acallsHC[checkedcall] == Connections.CID5)
						{
							//Do nothing
						}
						else
						{
							UpdateCall(checkedcall, Connections.CID5, Connections.CCH5);
						}
					}
					else
					{
						if (callcreateinprog != true && activecall != true && callwaitingpickup != true)
						{
							callcreateinprog = true;
							callwaitingpickup = true;
							calltype = "TRAIN";
							AddNewCall(int.Parse(Connections.CID5), Connections.CCH5);
						}
						else
						{
							AddPendingCall(int.Parse(Connections.CID5), Connections.CCH5);

							callspending = true;
						}
					}
					checkedcall = 0;
				}
			}
			else { Connections.CID5 = "0"; }

			if (fireonce == false)
			{
				do { Thread.Sleep(1); } while (Connections.CCH1 == "");
				if (Settings.Default.RC2NumbCH >= 2) { do { Thread.Sleep(1); } while (Connections.CCH2 == ""); }
				if (Settings.Default.RC2NumbCH >= 3) { do { Thread.Sleep(1); } while (Connections.CCH3 == ""); }
				if (Settings.Default.RC2NumbCH >= 4) { do { Thread.Sleep(1); } while (Connections.CCH4 == ""); }
				if (Settings.Default.RC2NumbCH == 5) { do { Thread.Sleep(1); } while (Connections.CCH5 == ""); }
				if (Settings.Default.RC2SigCHP == true) { do { Thread.Sleep(1); } while (Connections.CCH6 == ""); }

				TG_to_ConID.Add(Connections.CCH1, 1);
				if (Settings.Default.RC2NumbCH >= 2) { TG_to_ConID.Add(Connections.CCH2, 2); }
				if (Settings.Default.RC2NumbCH >= 3) { TG_to_ConID.Add(Connections.CCH3, 3); }
				if (Settings.Default.RC2NumbCH >= 4) { TG_to_ConID.Add(Connections.CCH4, 4); }
				if (Settings.Default.RC2NumbCH >= 5) { TG_to_ConID.Add(Connections.CCH5, 5); }
				if (Settings.Default.RC2SigCHP == true) { TG_to_ConID.Add(Connections.CCH6, 6); }
				fireonce = true;
			}

			//Check for New calls, if new calls exist, add them to the calls display
		}

		/// <summary>
		/// Check for Call Using Headcode
		/// </summary>
		internal static int CheckForCallHC(string headcode)
		{
			int callID = 0;
			foreach (string s in acallsHC)
			{
				if (s == headcode)
				{
					return callID;
				}
				else
				{
					if (callID != 5)
					{
						return 99;
					}
					else
					{
						callID++;
					}
				}
			}
			if (callID == 0) { return 99; } else { return callID; }
		}

		/// <summary>
		/// Check for Call Using TG
		/// </summary>
		internal static int CheckForCallTG(string Talkgroup)
		{
			int callID = 0;
			foreach (string s in acallsTG)
			{
				if (s == Talkgroup)
				{
					return callID;
				}
				else
				{
					if (callID != 5)
					{
						return 99;
					}
					else
					{
						callID++;
					}
				}
			}
			if (callID == 0) { return 99; } else { return callID; }
		}

		internal void UpdateCall(int callid, string HC, string TG)
		{
			int RID = int.Parse(HC);
			HC = RID.ToString("X");
			acallsHC[callid] = string.Format("{0:x}", HC).ToUpper();
			acallsTG[callid] = TG;
			switch (callid)
			{
				case 0:
					C1lab1.Text = string.Format("{0:x}", HC).ToUpper();
					C1lab2.Text = TG;
					C1lab1.Visible = true;
					C1lab2.Visible = true;
					break;

				case 1:
					C2lab1.Text = string.Format("{0:x}", HC).ToUpper();
					C2lab2.Text = TG;
					C2lab1.Visible = true;
					C2lab2.Visible = true;
					break;

				case 2:
					C3lab1.Text = string.Format("{0:x}", HC).ToUpper();
					C3lab2.Text = TG;
					C3lab1.Visible = true;
					C3lab2.Visible = true;
					break;

				case 3:
					C4lab1.Text = string.Format("{0:x}", HC).ToUpper();
					C4lab2.Text = TG;
					C4lab1.Visible = true;
					C4lab2.Visible = true;
					break;

				case 4:
					C5lab1.Text = string.Format("{0:x}", HC).ToUpper();
					C5lab2.Text = TG;
					C5lab1.Visible = true;
					C5lab2.Visible = true;
					break;
			}
			updateACB(RID, TG);
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
				///
				///
				///TODO: Dynamic, Currently Hardcoded to 1 Connection
				///
				///
				Connections.RC2(cts.Token, WSA, WSP, TXA, RXA, 1);
				if (Settings.Default.RC2NumbCH >= 2) { Connections.RC2(cts.Token, WSA, WSP + 1, TXA, RXA, 2); }
				if (Settings.Default.RC2NumbCH >= 3) { Connections.RC2(cts.Token, WSA, WSP + 2, TXA, RXA, 3); }
				if (Settings.Default.RC2NumbCH >= 4) { Connections.RC2(cts.Token, WSA, WSP + 3, TXA, RXA, 4); }
				if (Settings.Default.RC2NumbCH >= 5) { Connections.RC2(cts.Token, WSA, WSP + 4, TXA, RXA, 5); }
				if (Settings.Default.RC2SigCHP == true) { Connections.RC2(cts.Token, WSA, WSP + 5, TXA, RXA, 6); }
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
			Settings.Default.NextTXMID = nextTMSID + 1;
			Settings.Default.Save();
			Application.Exit();
		}

		private void RadSch_FormClosing(object sender, FormClosingEventArgs e)
		{
			teardown();
		}

		private void TabBut_Click(object sender, EventArgs e)
		{
			ButtonBeep();
			if (sender.GetHashCode() == IncomingTabBUT.GetHashCode())
			{
				currenttab = 5;
				tabPANEL.BackgroundImage = Resources.IncomingSelTAB;
			}
			else if (sender.GetHashCode() == TraingMobTABBUT.GetHashCode())
			{
				currenttab = 4;
				tabPANEL.BackgroundImage = Resources.TrainMOBSelTAB;
			}
			else if (sender.GetHashCode() == LogTabBUT.GetHashCode())
			{
				currenttab = 3;
				tabPANEL.BackgroundImage = Resources.LogSelTAB;
			}
			else if (sender.GetHashCode() == SpdDialTABBUT.GetHashCode())
			{
				currenttab = 2;
				tabPANEL.BackgroundImage = Resources.SPDDialSelTAB;
			}
			else if (sender.GetHashCode() == GrpCallTABBUt.GetHashCode())
			{
				currenttab = 1;
				tabPANEL.BackgroundImage = Resources.GroupSelTAB;
			}
			switch (currenttab)
			{
				case 5:
					IncomingPanel.Visible = true;
					IncomingTabBUT.ForeColor = Color.FromArgb(6, 158, 230);
					GrpCallTABBUt.ForeColor = Color.Black;
					SpdDialTABBUT.ForeColor = Color.Black;
					LogTabBUT.ForeColor = Color.Black;
					TraingMobTABBUT.ForeColor = Color.Black;
					break;

				case 4:
					IncomingPanel.Visible = false;
					IncomingTabBUT.ForeColor = Color.Black;
					GrpCallTABBUt.ForeColor = Color.Black;
					SpdDialTABBUT.ForeColor = Color.Black;
					LogTabBUT.ForeColor = Color.Black;
					TraingMobTABBUT.ForeColor = Color.FromArgb(6, 158, 230);
					break;

				case 3:
					IncomingPanel.Visible = false;
					IncomingTabBUT.ForeColor = Color.Black;
					GrpCallTABBUt.ForeColor = Color.Black;
					SpdDialTABBUT.ForeColor = Color.Black;
					LogTabBUT.ForeColor = Color.FromArgb(6, 158, 230);
					TraingMobTABBUT.ForeColor = Color.Black;
					break;

				case 2:
					IncomingPanel.Visible = false;
					IncomingTabBUT.ForeColor = Color.Black;
					GrpCallTABBUt.ForeColor = Color.Black;
					SpdDialTABBUT.ForeColor = Color.FromArgb(6, 158, 230);
					LogTabBUT.ForeColor = Color.Black;
					TraingMobTABBUT.ForeColor = Color.Black;
					break;

				case 1:
					IncomingPanel.Visible = false;
					IncomingTabBUT.ForeColor = Color.Black;
					GrpCallTABBUt.ForeColor = Color.FromArgb(6, 158, 230);
					SpdDialTABBUT.ForeColor = Color.Black;
					LogTabBUT.ForeColor = Color.Black;
					TraingMobTABBUT.ForeColor = Color.Black;
					break;
			}
		}

		private void CallBut_Click(object sender, EventArgs e)
		{
			ButtonBeep();
		}

		private void SettingBUT_Click(object sender, EventArgs e)
		{
			ButtonBeep();
			SettingsForm SF = new SettingsForm();
			SF.ShowDialog();
		}

		internal void NewTxTMsg(int pri, string from, string subject, string Message)
		{
			bool foundslot = false;
			if (TR1LAB1.Text != "" || TR1LAB1.Text != "label1")
			{
				foundslot = true;
				Pend_RX_Text.TryAdd(nextTMSID, Message);
				Pend_RX_Text_Src.TryAdd(nextTMSID, from);
				Pend_RX_Text_Subj.TryAdd(nextTMSID, subject);
				Pend_RX_Text_ToSlot.TryAdd(from, 1);
				TR1LAB1.Text = from;
				TR1LAB2.Text = subject;
				TR1LAB1.Visible = true;
				TR1LAB2.Visible = true;
				TR1LAB1.BackColor = Color.Blue;
				TR1LAB2.BackColor = Color.Blue;
				TR1LAB1.ForeColor = Color.White;
				TR1LAB2.ForeColor = Color.White;
				T1BUT.BackColor = Color.Blue;
				selectedPendTXTBOX = 1;
				nextTMSID++;
			}
			else if (TR2LAB1.Text != "" || TR2LAB1.Text != "label1" && foundslot != true)
			{
				foundslot = true;
				Pend_RX_Text.TryAdd(nextTMSID, Message);
				Pend_RX_Text_Src.TryAdd(nextTMSID, from);
				Pend_RX_Text_Subj.TryAdd(nextTMSID, subject);
				Pend_RX_Text_ToSlot.TryAdd(from, 2);
				TR2LAB1.Text = from;
				TR2LAB2.Text = subject;
				TR2LAB1.Visible = true;
				TR2LAB2.Visible = true;
				nextTMSID++;
				TR2LAB1.BackColor = Color.Blue;
				TR2LAB2.BackColor = Color.Blue;
				TR2LAB1.ForeColor = Color.White;
				TR2LAB2.ForeColor = Color.White;
				T2.BackColor = Color.Blue;
				selectedPendTXTBOX = 2;
			}
			else if (TR3LAB1.Text != "" || TR3LAB1.Text != "label1" && foundslot != true)
			{
				foundslot = true;
				Pend_RX_Text.TryAdd(nextTMSID, Message);
				Pend_RX_Text_Src.TryAdd(nextTMSID, from);
				Pend_RX_Text_Subj.TryAdd(nextTMSID, subject);
				Pend_RX_Text_ToSlot.TryAdd(from, 3);
				TR3LAB1.Text = from;
				TR3LAB2.Text = subject;
				TR3LAB1.Visible = true;
				TR3LAB2.Visible = true;
				nextTMSID++;
				TR3LAB1.BackColor = Color.Blue;
				TR3LAB2.BackColor = Color.Blue;
				TR3LAB1.ForeColor = Color.White;
				TR3LAB2.ForeColor = Color.White;
				T3BUT.BackColor = Color.Blue;
				selectedPendTXTBOX = 3;
			}

			if (Settings.Default.RingerOff != true)
			{
				string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
				string wavFileName = "Sounds\\message_standard.wav";
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
					catch (Exception) { }
				}
				else { }
			}

			TXTAlrt.Enabled = true;
			TXTAlrt.Start();
			TXTvis.Enabled = true;
			TXTvis.Start();

			//Find avail UI slot for Text MSG---
			//Enter Text MSG info into the Dicts
			//Display info on UI
			//Alert
		}

		private void timer2_Tick(object sender, EventArgs e)
		{
			DateTime M = DateTime.Now;
			string MSTR = M.ToString("HH:MM:ss");
			timelab.Text = MSTR;
		}

		private void TXTstripBUT_Click(object sender, EventArgs e)
		{
			ButtonBeep();
			if (selectedPendTXTBOX != 0)
			{
				//Move it to The Non Pending Inbox
				//TODO:
				//Find Open Slot
				//Transfer data from Pending DB to non Pending DB
				switch (selectedPendTXTBOX)
				{
					case 1:
						int ID;
						Pend_RX_Text_ToSlot.TryGetValue(TR1LAB1.Text, out ID);
						string from;
						string subject;
						string body;
						Pend_RX_Text_Src.TryGetValue(ID, out from);
						Pend_RX_Text_Subj.TryGetValue(ID, out subject);
						Pend_RX_Text.TryGetValue(ID, out body);

						//Bad IDea, Redo THis
						RX_Text.TryAdd(nextTMSID, body);
						RX_Text_Src.TryAdd(nextTMSID, from);
						RX_Text_Subj.TryAdd(nextTMSID, subject);
						RX_Text_ToSlot.TryAdd(from, 1);
						TXTRemoveBUT.Visible = true;
						break;

					case 2:
						TXTRemoveBUT.Visible = true;
						break;

					case 3:
						TXTRemoveBUT.Visible = true;
						break;
				}
			}
		}

		private void TXTAlrt_Tick(object sender, EventArgs e)
		{
			if (Settings.Default.RingerOff != true)
			{
				string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
				string wavFileName = "Sounds\\message_standard.wav";
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
					catch (Exception) { }
				}
				else { }
			}
		}

		internal void RemoveTXT(int ID, bool pending)
		{ }

		private void TXTvis_Tick(object sender, EventArgs e)
		{
			if (TXTstripBUT.BackColor == Color.Orange)
			{
				TXTstripBUT.BackColor = SystemColors.ControlLight;
			}
			else { TXTstripBUT.BackColor = Color.Orange; }
		}

		private void PendTXTButClick(object sender, EventArgs e)
		{
			ButtonBeep();
		}

		private void TXTButClick(object sender, EventArgs e)
		{ }

		private void TXTRemoveBUT_Click(object sender, EventArgs e)
		{
			//Remove the TXT outright
			RemoveTXT(0, false);
		}
	}
}