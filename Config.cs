using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Removeo
{
    static class Config
    {
        public static string SystemHostsFile;
        private static bool activated;
        public static BlockOption CustomOption = new BlockOption("custom");
        public static List<BlockOption> BlockOptions = new List<BlockOption>();
        public static bool Activated
        {
            get => activated;
            set { activated = value; SetValueBool("activated", value); }
        }


        public static void Initialize()
        {
            BlockOptions.Add(new BlockOption("ads"));
            BlockOptions.Add(new BlockOption("trackers"));
            BlockOptions.Add(new BlockOption("malware"));
            BlockOptions.Add(new BlockOption("scams"));
            BlockOptions.Add(new BlockOption("telemetry"));
            Activated = GetValueBool("activated");
            SystemHostsFile = Path.Combine(Environment.GetEnvironmentVariable("SystemRoot"), "system32\\drivers\\etc\\hosts");
        }

        public class BlockOption
        {
            private bool enabled;
            public readonly string IpFileName;
            public readonly string DomainsFileName;
            public readonly string IpUrl;
            public readonly string DomainsUrl;
            public string Tag;
            static readonly string CurrentDir = Path.GetDirectoryName(new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).LocalPath);

            public BlockOption(string tag)
            {
                this.Tag = tag;
                this.IpFileName = Path.Combine(CurrentDir, $"{Tag}.txt");
                this.DomainsFileName = Path.Combine(CurrentDir, $"{Tag}_hosts.txt");
                if (tag != "custom")
                {
                    this.IpUrl = $"https://omerta.io/removeo/{tag}.txt";
                    this.DomainsUrl = $"https://omerta.io/removeo/{tag}_hosts.txt";
                    this.Enabled = GetValueBool(tag, true);
                }
                else
                {
                    this.IpUrl = "";
                    this.Enabled = true;
                }
            }
            
            public bool Enabled
            {
                get => enabled;
                set { enabled = value; SetValueBool(Tag, value); }
            }
        }

        private static RegistryKey GetAppSettingsKey()
        {
            RegistryKey registryKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Removeo", RegistryKeyPermissionCheck.ReadWriteSubTree);
            return registryKey;
        }

        private static void SetValueString(string name, string value)
        {
            try
            {
                GetAppSettingsKey().SetValue(name, value, RegistryValueKind.String);
            }
            catch
            {
            }
        }

        private static string GetValueString(string name, string defaultV = "")
        {
            string r1 = null;
            try
            {
                r1 = (string)GetAppSettingsKey().GetValue(name, null);
            }
            catch
            {
            }

            if (r1 == null)
            {
                SetValueString(name, defaultV);
                return defaultV;
            }
            return r1;
        }

        private static void SetValueInt(string name, int value)
        {
            try
            {
                GetAppSettingsKey().SetValue(name, value, RegistryValueKind.DWord);
            }
            catch
            {
            }
        }

        private static int GetValueInt(string name, int defaultV = 0)
        {
            int r1 = defaultV;
            try
            {
                var k = GetAppSettingsKey();
                r1 = (int)(k.GetValue(name, defaultV));
            }
            catch
            {
            }

            if (r1 == defaultV)
            {
                SetValueInt(name, defaultV);
                return defaultV;
            }
            return r1;
        }

        private static void SetValueBool(string name, bool value)
        {
            SetValueInt(name, value ? 1 : 0);
        }

        private static bool GetValueBool(string name, bool defaultV = false)
        {
            return (GetValueInt(name, (defaultV ? 1 : 0))) == 1;
        }
    }
}
