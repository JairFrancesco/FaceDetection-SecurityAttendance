using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;

namespace DeteccionRostros
{
    public class GSMcom
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public GSMcom()
        {

        }

        override
        public string ToString()
        {
            return $"{Description} {Name}";
        }

        public GSMcom[] ListarModemsConectados()
        {
            List<GSMcom> gsmCom = new List<GSMcom>();
            ConnectionOptions options = new ConnectionOptions();
            options.Impersonation = ImpersonationLevel.Impersonate;
            options.EnablePrivileges = true;
            string connString = $@"\\{Environment.MachineName}\root\cimv2";
            ManagementScope scope = new ManagementScope(connString, options);
            scope.Connect();

            ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_POTSModem");
            ManagementObjectSearcher search = new ManagementObjectSearcher(scope, query);
            ManagementObjectCollection collection = search.Get();

            foreach (ManagementObject obj in collection)
            {
                string portName = obj["AttachedTo"].ToString();
                string portDescription = obj["Description"].ToString();

                if (portName != "")
                {
                    GSMcom com = new GSMcom();
                    com.Name = portName;
                    com.Description = portDescription;
                    gsmCom.Add(com);
                }
            }
            return gsmCom.ToArray();
        }
    }
}
