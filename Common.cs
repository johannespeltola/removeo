using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Removeo
{
    public static class Common
    {
        private static readonly Regex regex = new Regex("^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$", RegexOptions.Compiled);

        public static void Error(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static long GetRemoteFileSize(string url)
        {
            long result = 0;

            System.Net.WebRequest req = System.Net.WebRequest.Create(url);
            req.Method = "HEAD";
            using (System.Net.WebResponse resp = req.GetResponse())
            {
                if (long.TryParse(resp.Headers.Get("Content-Length"), out long ContentLength))
                {
                    result = ContentLength;
                }
            }

            return result;
        }

        public static bool IsValidIPv4(string ipv4)
        {
            return regex.IsMatch(ipv4);
        }

        public static List<string> ReadUniqueIpv4(string filePath)
        {
            try
            {
                return File.ReadAllLines(filePath).Distinct().Where(ip => IsValidIPv4(ip)).ToList();
            }
            catch
            {
                return new List<string>();
            }
        }

        public static void FetchHostsFile(string filePath, out List<string> ipv4/*, out List<string> domains*/)
        {
            ipv4 = new List<string>();
            //domains = new List<string>();
            try
            {
                foreach(var line in File.ReadAllLines(filePath).Distinct())
                {
                    if (IsValidIPv4(line))
                        ipv4.Add(line);
                    /*else
                        domains.Add(line);*/
                }
            }
            catch
            {
                
            }
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
        
        public static List<List<T>> Split<T>(List<T> source, int chunkSize)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
    }
}
