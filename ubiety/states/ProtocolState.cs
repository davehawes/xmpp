// ProtocolState.cs
//
//Ubiety XMPP Library Copyright (C) 2006 - 2012 Dieter Lunn
//
//This library is free software; you can redistribute it and/or modify it under
//the terms of the GNU Lesser General Public License as published by the Free
//Software Foundation; either version 3 of the License, or (at your option)
//any later version.
//
//This library is distributed in the hope that it will be useful, but WITHOUT
//ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
//FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more
//
//You should have received a copy of the GNU Lesser General Public License along
//with this library; if not, write to the Free Software Foundation, Inc., 59
//Temple Place, Suite 330, Boston, MA 02111-1307 USA

using System.Xml;
using ubiety.common.SASL;
using ubiety.net;

namespace ubiety.states
{
	/// <summary>
	/// Keeps track of all the current state information like id, password, socket and the current state.
	/// </summary>
	internal static class ProtocolState
	{
		private static readonly XmlDocument _doc = new XmlDocument();

		static ProtocolState()
		{
			State = new DisconnectedState();
			UbietyMessages.AllMessages += AllMessages;
		}

		private static void AllMessages(object sender, MessageEventArgs e)
		{
			State.Execute(e.Tag);
		}

		/// <value>
		/// The current state we are in.
		/// </value>
		public static State State { get; set; }

		/// <value>
		/// The socket used for connecting to the server.
		/// </value>
		internal static AsyncSocket Socket { get; set; }

		/// <value>
		/// The current SASL processor based on server communication.
		/// </value>
		public static SASLProcessor Processor { get; set; }

		/// <value>
		/// Are we authenticated yet?
		/// </value>
		public static bool Authenticated { get; set; }

		/// <summary>
		/// Is the stream currently compressed?
		/// </summary>
		public static bool Compressed { get; set; }

		public static string Algorithm { get; set; }

		public static XmlDocument Document
		{
			get { return _doc; }
		}
	}
}