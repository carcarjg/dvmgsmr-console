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
using RC2ClientLibrary;

namespace dvmgsmr_console
{
	internal class Connections
	{
		/// <summary>
		/// Vars for Con 1
		/// </summary>
		internal static bool WSC1;

		internal static bool RTCC1;

		internal static bool RTTX1;

		internal static string CCH1 = "";

		internal static string CID1 = "";

		internal static bool TXR1;

		internal static bool TXSR1;

		internal static bool RXC1 = false;

		internal static bool TXC1 = false;

		/// <summary>
		/// Vars for Con 2
		/// </summary>
		internal static bool WSC2;

		internal static bool RTCC2;

		internal static bool RTTX2;

		internal static string CCH2 = "";

		internal static string CID2 = "";

		internal static bool TXR2;

		internal static bool TXSR2;

		internal static bool RXC2 = false;

		internal static bool TXC2 = false;

		/// <summary>
		/// Vars for Con 3
		/// </summary>
		internal static bool WSC3;

		internal static bool RTCC3;

		internal static bool RTTX3;

		internal static string CCH3 = "";

		internal static string CID3 = "";

		internal static bool TXR3;

		internal static bool TXSR3;

		internal static bool RXC3 = false;

		internal static bool TXC3 = false;

		/// <summary>
		/// Vars for Con 4
		/// </summary>
		internal static bool WSC4;

		internal static bool RTCC4;

		internal static bool RTTX4;

		internal static string CCH4 = "";

		internal static string CID4 = "";

		internal static bool TXR4;

		internal static bool TXSR4;

		internal static bool RXC4 = false;

		internal static bool TXC4 = false;

		/// <summary>
		/// Vars for Con 5
		/// </summary>
		internal static bool WSC5;

		internal static bool RTCC5;

		internal static bool RTTX5;

		internal static string CCH5 = "";

		internal static string CID5 = "";

		internal static bool TXR5;

		internal static bool TXSR5;

		internal static bool RXC5 = false;

		internal static bool TXC5 = false;

		/// <summary>
		/// Vars for Sig Connection
		/// </summary>
		internal static bool WSC6;

		internal static bool RTCC6;

		internal static bool RTTX6;

		internal static string CCH6 = "";

		internal static string CID6 = "";

		internal static bool TXR6;

		internal static bool TXSR6;

		internal static bool RXC6 = false;

		internal static bool TXC6 = false;

		/// <summary>
		/// Task for Connection to RC2
		/// </summary>
		/// <param name="token"></param>
		/// <param name="RC2addr"></param>
		/// <param name="RC2port"></param>
		/// <param name="txaudio"></param>
		/// <param name="rxaudio"></param>
		/// <param name="connID"></param>
		/// <returns></returns>
		internal static async Task RC2(CancellationToken token, string RC2addr, int RC2port, int txaudio, int rxaudio, int connID)
		{
			// Create and configure client
			var client = new RC2Client(RC2addr, RC2port);
			client.SetMicrophoneDevice(txaudio);
			client.SetSpeakerDevice(rxaudio);

			// Subscribe to all events
			client.WebSocketConnected += (s, e) => WSC1 = true;
			client.WebRtcConnected += (s, e) => RTCC1 = true;
			client.WebRtcDisconnected += (S, E) => RTCC1 = false;
			client.WebSocketDisconnected += (S, E) => WSC1 = false;
			client.StatusReceived += (s, status) =>
			{
				/*
				Console.WriteLine($"Status: {status.Name}");
				Console.WriteLine($"  Zone: {status.ZoneName}");
				Console.WriteLine($"  Channel: {status.ChannelName}");
				Console.WriteLine($"  State: {status.State}");
				Console.WriteLine($"  Caller: {status.CallerId}"); */
				string schs = "XXXX";
				try { schs = status.ChannelName.Substring(0, 4); } catch (Exception) { }

				if (schs == "ID: ")
				{
					switch (connID)
					{
						case 1:
							CID1 = status.ChannelName.Substring(4);
							break;

						case 2:
							CID2 = status.ChannelName.Substring(4);
							break;

						case 3:
							CID3 = status.ChannelName.Substring(4);
							break;

						case 4:
							CID4 = status.ChannelName.Substring(4);
							break;

						case 5:
							CID5 = status.ChannelName.Substring(4);
							break;

						case 6:
							CID6 = status.ChannelName.Substring(4);
							break;
					}
				}
				else
				{
					switch (connID)
					{
						case 1:
							CCH1 = status.ZoneName;
							break;

						case 2:
							CCH2 = status.ZoneName;
							break;

						case 3:
							CCH3 = status.ZoneName;
							break;

						case 4:
							CCH4 = status.ZoneName;
							break;

						case 5:
							CCH5 = status.ZoneName;
							break;

						case 6:
							CCH6 = status.ZoneName;
							break;

						default:
							CCH1 = status.ZoneName;
							break;
					}
				}
				switch (connID)
				{
					case 1:
						WSC1 = client.IsWebSocketConnected;
						RTCC1 = client.IsWebRtcConnected;
						RTTX1 = client.IsTransmitting;
						break;

					case 2:
						WSC2 = client.IsWebSocketConnected;
						RTCC2 = client.IsWebRtcConnected;
						RTTX2 = client.IsTransmitting;
						break;

					case 3:
						WSC3 = client.IsWebSocketConnected;
						RTCC3 = client.IsWebRtcConnected;
						RTTX3 = client.IsTransmitting;
						break;

					case 4:
						WSC4 = client.IsWebSocketConnected;
						RTCC4 = client.IsWebRtcConnected;
						RTTX4 = client.IsTransmitting;
						break;

					case 5:
						WSC5 = client.IsWebSocketConnected;
						RTCC5 = client.IsWebRtcConnected;
						RTTX5 = client.IsTransmitting;
						break;

					case 6:
						WSC6 = client.IsWebSocketConnected;
						RTCC6 = client.IsWebRtcConnected;
						RTTX6 = client.IsTransmitting;
						break;
				}
				bool tmprxc = false;
				if (client.CurrentStatus.State == RC2ClientLibrary.RadioState.Receiving)
				{
					tmprxc = true;
				}
				else
				{
					tmprxc = false;
				}
				switch (connID)
				{
					case 1:
						RXC1 = tmprxc;

						break;

					case 2:
						RXC2 = tmprxc;

						break;

					case 3:
						RXC3 = tmprxc;

						break;

					case 4:
						RXC4 = tmprxc;

						break;

					case 5:
						RXC5 = tmprxc;

						break;

					case 6:
						RXC6 = tmprxc;

						break;
				}

				//TODO: use above data to trigger stuff on the CH
			};
			client.AckReceived += (s, cmd) => Console.WriteLine($"✓ {cmd}");
			client.NackReceived += (s, cmd) => Console.WriteLine($"✗ {cmd}");
			client.ErrorOccurred += (s, err) => Console.WriteLine($"ERROR: {err}");

			// Connect
			if (await client.ConnectAsync())
			{
				// Interactive command loop
				bool tmprxc = false;
				bool tmptxr = false;
				if (token.IsCancellationRequested == true)
				{
					client.Disconnect();
				}
				switch (connID)
				{
					case 1:
						RXC1 = tmprxc;
						tmptxr = TXR1;
						break;

					case 2:
						RXC2 = tmprxc;
						tmptxr = TXR2;
						break;

					case 3:
						RXC3 = tmprxc;
						tmptxr = TXR3;
						break;

					case 4:
						RXC4 = tmprxc;
						tmptxr = TXR4;
						break;

					case 5:
						RXC5 = tmprxc;
						tmptxr = TXR5;
						break;

					case 6:
						RXC6 = tmprxc;
						tmptxr = TXR6;
						break;
				}
				if (tmptxr == true)
				{
					//TXRequested
					client.StartTransmit();
					tmptxr = false;
				}
				if (tmptxr == true)
				{
					client.StopTransmit();
					tmptxr = false;
				}
				switch (connID)
				{
					case 1:
						TXR1 = tmptxr;

						break;

					case 2:
						TXR2 = tmptxr;

						break;

					case 3:
						TXR3 = tmptxr;

						break;

					case 4:
						TXR4 = tmptxr;
						break;

					case 5:
						TXR5 = tmptxr;
						break;

					case 6:
						TXR6 = tmptxr;
						break;
				}

				await Task.Delay(100);
			}
		}
	}
}