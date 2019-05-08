using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using Microsoft.Win32;
using System.Diagnostics;

namespace Removeo
{
    public partial class FormRemoveo : Form
    {
        string lastError;


        public FormRemoveo()
        {
            InitializeComponent();
            Config.Initialize();
            buttonCheckTrackers.Checked = Config.BlockOptions.Single(o => o.Tag == "trackers").Enabled;
            buttonCheckAds.Checked = Config.BlockOptions.Single(o => o.Tag == "ads").Enabled;
            buttonCheckMalware.Checked = Config.BlockOptions.Single(o => o.Tag == "malware").Enabled;
            buttonCheckScams.Checked = Config.BlockOptions.Single(o => o.Tag == "scams").Enabled;
            buttonCheckTelemetry.Checked = Config.BlockOptions.Single(o => o.Tag == "telemetry").Enabled;
        }


        private void SetStatus(string status, Color color)
        {
            labelStatus.Text = status;
            labelStatus.ForeColor = color;
            Application.DoEvents();
        }


        private void FormRemoveoLoad(object sender, EventArgs e)
        {
            if (Config.BlockOptions.All(o => !File.Exists(o.IpFileName) && !File.Exists(o.DomainsFileName)) && !File.Exists(Config.CustomOption.IpFileName) && !File.Exists(Config.CustomOption.DomainsFileName))
            {
                var answer = MessageBox.Show("No hosts file found. Download hosts file ?", "Hosts not found", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (answer == DialogResult.OK)
                {
                    foreach (var option in Config.BlockOptions)
                    {
                        var remoteFileSize = Common.GetRemoteFileSize(option.IpUrl);
                        var localFileSize = File.Exists(option.IpFileName) ? new FileInfo(option.IpFileName).Length : 0;
                        if (remoteFileSize != localFileSize)
                        {
                            var frm = new FormDownload(option.IpUrl, option.IpFileName);
                            frm.ShowDialog(this);
                        }

                        remoteFileSize = Common.GetRemoteFileSize(option.DomainsUrl);
                        localFileSize = File.Exists(option.DomainsFileName) ? new FileInfo(option.DomainsFileName).Length : 0;
                        if (remoteFileSize != localFileSize)
                        {
                            var frm = new FormDownload(option.DomainsUrl, option.DomainsFileName);
                            frm.ShowDialog(this);
                        }
                    }
                }
                else
                {
                    BeginInvoke((MethodInvoker)(() => Close()));
                    return;
                }
            }

            if (!Firewall.Initialize(out var errorMessage))
            {
                Common.Error(errorMessage);
                BeginInvoke((MethodInvoker)(() => Close()));
                return;
            }

            if (!Firewall.IsFirewallEnabled(out errorMessage))
            {
                Common.Error(errorMessage);
                BeginInvoke((MethodInvoker)(() => Close()));
                return;
            }

            if (Config.Activated /*&& Firewall.IsRuleEnabled("removeo")*/)
            {
                SetStatus("Removeo activated", Color.Blue);
            }
            else
            {
                Config.Activated = false;
                buttonDeactivate.Enabled = false;
                SetStatus("Removeo deactivated", Color.Red);
            }
        }


        private void ButtonDeactivate_Click(object sender, EventArgs e)
        {
            SetStatus("Deactivating Removeo, be patient ...", Color.Red);
            if (DeactivateFirewallRules())
            {
                SetStatus("Removeo deactivated", Color.Red);
                buttonDeactivate.Enabled = false;
                Config.Activated = false;
            }
            else
            {
                SetStatus("Deactivation failed", Color.Red);
                Common.Error($"Deactivation failed, error message :\n{lastError}");
            }
        }


        private void ButtonActivateClick(object sender, EventArgs e)
        {
            SetStatus("Activating Removeo, be patient ...", Color.Blue);
            if (ActivateFirewallRules())
            {
                SetStatus("Removeo activated / repaired", Color.Blue);
                buttonDeactivate.Enabled = true;
                Config.Activated = true;
            }
            else
            {
                SetStatus("Activation failed", Color.Red);
                Common.Error($"Activation failed, error message :\n{lastError}");
            }
        }


        private bool ActivateFirewallRules()
        {
            try
            {
                Firewall.RemoveRules("Removeo");
                HostsFile.RemoveDomainsFromHosts(Config.SystemHostsFile);
                foreach (var option in new List<Config.BlockOption>(Config.BlockOptions.Where(opt => opt.Enabled)) { Config.CustomOption })
                {
                    if (File.Exists(option.IpFileName))
                    {
                        var ipv4 = Common.ReadUniqueIpv4(option.IpFileName);
                        // add ip rules
                        if (ipv4.Count > 0)
                        {
                            foreach (var chunk in Common.Split(ipv4, 1000))
                            {
                                var address = string.Join(",", chunk);
                                Firewall.AddRule("Removeo", address);
                            }
                        }
                    }

                    if (File.Exists(option.DomainsFileName))
                    {
                        var domains = File.ReadAllLines(option.DomainsFileName).Distinct().ToList();
                        // add domains to hosts file
                        if (domains.Count > 0)
                        {
                            HostsFile.AppendDomainsToHosts(Config.SystemHostsFile, domains);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                lastError = e.Message;
                return false;
            }

            return true;
        }

        private bool DeactivateFirewallRules()
        {
            try
            {
                Firewall.RemoveRules("Removeo");
                HostsFile.RemoveDomainsFromHosts(Config.SystemHostsFile);
            }
            catch (Exception e)
            {
                lastError = e.Message;
                return false;
            }
            return true;
        }

        private void ButtonEditCustomDomains_Click(object sender, EventArgs e)
        {
            if (!File.Exists(Config.CustomOption.IpFileName))
                File.Create(Config.CustomOption.IpFileName).Close();
            Process.Start(Config.CustomOption.IpFileName);

            if (!File.Exists(Config.CustomOption.DomainsFileName))
                File.Create(Config.CustomOption.DomainsFileName).Close();
            Process.Start(Config.CustomOption.DomainsFileName);
        }

        private void ButtonUpdateDomains_Click(object sender, EventArgs e)
        {
            UpdateHostsFile();
        }

        private void UpdateHostsFile()
        {
            foreach (var option in Config.BlockOptions)
            {
                var remoteFileSize = Common.GetRemoteFileSize(option.IpUrl);
                var localFileSize = File.Exists(option.IpFileName) ? new FileInfo(option.IpFileName).Length : 0;
                if (remoteFileSize != localFileSize)
                {
                    var answer = MessageBox.Show($"A new {option.Tag} ip file was released, do you want to update it ?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (answer == DialogResult.Yes)
                    {
                        var frm = new FormDownload(option.IpUrl, option.IpFileName);
                        frm.ShowDialog(this);
                    }
                }

                remoteFileSize = Common.GetRemoteFileSize(option.DomainsUrl);
                localFileSize = File.Exists(option.DomainsFileName) ? new FileInfo(option.DomainsFileName).Length : 0;
                if (remoteFileSize != localFileSize)
                {
                    var answer = MessageBox.Show($"A new {option.Tag} domains file was released, do you want to update it ?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (answer == DialogResult.Yes)
                    {
                        var frm = new FormDownload(option.DomainsUrl, option.DomainsFileName);
                        frm.ShowDialog(this);
                    }
                }
            }
        }

        private void ButtonCheckClick(object sender, EventArgs e)
        {
            var tag = ((ToolStripMenuItem)sender).Tag as string;
            if (!string.IsNullOrEmpty(tag))
                Config.BlockOptions.Single(o => o.Tag == tag).Enabled ^= true;
        }

        private void disableDNSCacheServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var reg = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\services\\Dnscache", true);
                reg.SetValue("Start", 4, RegistryValueKind.DWord);
                MessageBox.Show("Disabled dns service successfully", "Removeo");
            }
            catch
            {
                Common.Error("Cannot disable dns service");
            }
        }

        private void WebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://omerta.io/removeo");
            }
            catch
            {

            }
        }
    }
}
