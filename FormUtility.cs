using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            TextReader r = new StreamReader(getServersFileLocation());
            var loaded = (ServerList)s.Deserialize(r);
            r.Close();

            return loaded;
        }
        internal static string getServersFileLocation()
        {
            return Path.Combine(getServersFilePath(), Settings.Default.ServerConfigFileName);
        }
        internal static string getServersFilePath()
        {
            bool found = true;
            string serversFileName = Settings.Default.ServerConfigFileName;
            string serversFileLocation = Settings.Default.ServerConfigLocation;
            if (! File.Exists(Path.Combine(serversFileLocation, serversFileName)))
            {
                string appDirectory = "DBMulticast\\";
                serversFileLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), appDirectory);
                if (! File.Exists(Path.Combine(serversFileLocation, serversFileName)))
                {
                    serversFileLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), appDirectory);
                    if (! File.Exists(Path.Combine(serversFileLocation, serversFileName)))
                    {
                        serversFileLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), appDirectory);
                        if (! File.Exists(Path.Combine(serversFileLocation, serversFileName)))
                        {
                            serversFileLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), appDirectory);
                            if (!File.Exists(Path.Combine(serversFileLocation, serversFileName)))
                            {
                                found = false;
                                serversFileLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), appDirectory);
                            }
                        }
                    }
                }
            }
            Debug.WriteLine("servers.xml location: {0} (found {1})", serversFileLocation, found);
            return serversFileLocation;
        }
    }
}
