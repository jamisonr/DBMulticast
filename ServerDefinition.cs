using System;
using System.Collections;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DBMulticast
{
	[XmlRoot("serverList")]
	public class ServerList
	{
		private ArrayList listServers;

		public ServerList()
		{
			listServers = new ArrayList();
		}

        [XmlAttribute("expanded")]
        public bool Expanded { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("serverList")]
        public List<ServerList> ServerLists { get; set; }

		[XmlElement("server")]
		public Server[] Servers
		{
			get
			{
				var servers = new Server[listServers.Count];
				listServers.CopyTo(servers);
				return servers;
			}
			set
			{
				if(value==null) return;
				var servers = (Server[]) value;
				listServers.Clear();
				foreach (var server in servers)
					listServers.Add(server);
			}
		}

		public int AddServer(Server server)
		{
			return listServers.Add(server);
		}
	}

	public class Server
	{
		[XmlAttribute("ServerName")] public string servername;
		[XmlAttribute("Server")] public string svr;
		[XmlAttribute("DB")] public string database;
		[XmlAttribute("Username")] public string username;
		[XmlAttribute("Password")] public string password;
		[XmlAttribute("UseSSPI")] public bool usesspi;
        [XmlAttribute("Type")] public string type;

		public Server()
		{
		}

		public Server(string serverName, string svr, string database, string username, string password, bool usesspi)
		{
			this.servername = serverName;
			this.svr = svr;
			this.database = database;
			this.username = username;
			this.password = password;
			this.usesspi = usesspi;
		}

		public override string ToString()
		{
			return this.servername;
		}
	}

}

