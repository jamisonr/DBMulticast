using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using DBMulticast.Properties;

namespace DBMulticast
{
    class FormUtility
    {
        public static ServerList LoadDatabaseDefinitions()
        {
            var s = new XmlSerializer(typeof(ServerList));
            TextReader r = new StreamReader(Path.Combine(Settings.Default.ServerConfigLocation, "servers.xml"));
            var loaded = (ServerList)s.Deserialize(r);
            r.Close();

            return loaded;
        }
    }
}
