using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NetFwTypeLib;

namespace Removeo
{
    public static class Firewall
    {
        private static INetFwPolicy2 firewallPolicy = null;

        public static bool Initialize(out string error)
        {
            error = "";
            try
            {
                firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
                return true;
            }
            catch (Exception e)
            {
                firewallPolicy = null;
                error = e.Message;
                return false;
            }
        }

        public static bool IsFirewallEnabled(out string error)
        {
            var ret = false;
            error = "";
            try
            {
                ret = firewallPolicy.FirewallEnabled[(NET_FW_PROFILE_TYPE2_)firewallPolicy.CurrentProfileTypes];
                if (!ret)
                    error = "Windows Firewall is disabled for current network frofile.\nEnable it and restart Removeo";
            }
            catch
            {
                ret = false;
                error = "Windows Firewall service was turned off.\nEnsure that the service is running and restart Removeo.";
            }
            return ret;
        }

        public static void EnableFirewall()
        {
            firewallPolicy.FirewallEnabled[NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_DOMAIN] = true;
            firewallPolicy.FirewallEnabled[NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_PRIVATE] = true;
            firewallPolicy.FirewallEnabled[NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_PUBLIC] = true;
        }

        public static bool IsRuleExist(string name)
        {
            return firewallPolicy.Rules.OfType<INetFwRule2>().Any(r => r.Name == name);
        }

        public static bool IsRuleEnabled(string name)
        {
            return firewallPolicy.Rules.OfType<INetFwRule2>().Any(r => r.Name == name && r.Enabled);
        }

        public static void RemoveRules(string name)
        {
            foreach(INetFwRule2 rule in firewallPolicy.Rules)
            {
                if (rule.Name == name)
                    firewallPolicy.Rules.Remove(name);
            }
        }

        public static void AddRule(string name, string address)
        {
            INetFwRule2 rule = (INetFwRule2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
            rule.Enabled = true;
            rule.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
            rule.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
            rule.Protocol = (int)NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;
            rule.RemotePorts = "80,443";
            rule.RemoteAddresses = address;
            rule.Name = name;
            rule.Description = "Removeo rule for blocking unwanted content.";
            firewallPolicy.Rules.Add(rule);
        }
    }
}
