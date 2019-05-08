using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Removeo
{
    static class HostsFile
    {
        public static void AppendDomainsToHosts(string hostsPath, List<string> domains)
        {
            StringBuilder domainBatch = new StringBuilder();
            foreach (var domain in domains)
            {
                domainBatch.AppendFormat($"0.0.0.0 {domain} #RMV\n");
            }
            using (var hostsFile = File.Open(hostsPath, FileMode.Open, FileAccess.ReadWrite))
            {
                hostsFile.Position = hostsFile.Length - 1;
                if (hostsFile.ReadByte() != 10)
                    domainBatch.Insert(0, "\n");
                var stringBytes = ASCIIEncoding.ASCII.GetBytes(domainBatch.ToString());
                domainBatch = null;
                hostsFile.Write(stringBytes, 0, stringBytes.Length);
            }
        }

        public static void RemoveDomainsFromHosts(string hostsPath)
        {
            var domains = File.ReadAllLines(hostsPath).Where(d => !d.Contains("#RMV"));
            File.WriteAllLines(hostsPath, domains);
        }
    }
}
