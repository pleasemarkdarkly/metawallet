
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/
using System;
using System.Collections.Generic;
using System.Text;
namespace MW.MComm.WalletSolution.BLL.Config
{
    public class ConfigurationValue : IConfigurationValue
    {
        private string _source;
        private string _key;
        private string _value;
        public string Key
        {
            get { return _key; }
        }
        public string Value
        {
            get { return _value; }
        }
        public string Source
        {
            get { return _source; }
        }
        public string TruncatedValue
        {
            get
            {
                if (_value == null)
                    return null;
                else
                {
                    string output = _value.Substring(0, Math.Min(_value.Length, 40));
                    if (output.Length < _value.Length)
                        output += "...";
                    return output;
                }
            }
        }
        public ConfigurationValue(string key, string value)
        {
            _key = key;
            _value = value;
        }
        public ConfigurationValue(string key, string value, string source)
        {
            _key = key;
            _value = value;
            _source = source;
        }
    }
}
