

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

namespace MW.MComm.Ganadero.BLL.Config
{
    public class ConfigurationValueList : List<IConfigurationValue>
    {
        /// <summary>
        /// Adds new items and replaces existing items.
        /// </summary>
        /// <param name="list"></param>
        public void Merge(ConfigurationValueList list)
        {
            foreach (IConfigurationValue item in list)
                Merge(item);
        }

        public void Merge(IConfigurationValue item)
        {
            // look for an existing item by key
            IConfigurationValue existingItem = FindByKey(item.Key);

            while (existingItem != null)
            {
                Remove(existingItem);
                existingItem = FindByKey(item.Key);
            }

           Add(item);
        }

        public IConfigurationValue FindByKey(string key)
        {
            foreach (IConfigurationValue item in this)
                if (item.Key == key)
                    return item;

            return null;
        }

        public string GetValue(string key)
        {
            IConfigurationValue item = FindByKey(key);

            if (item != null)
                return item.Value;
            else
                return null;
        }

        public bool GetBoolValue(string key, bool defaultValue)
        {
            IConfigurationValue item = FindByKey(key);

            if (item == null)
                return defaultValue;
            else
                return bool.Parse(item.Value);
        }

        public string GetValue(string key, string defaultValue)
        {
            IConfigurationValue item = FindByKey(key);

            if (item != null)
                return item.Value;
            else
                return defaultValue;
        }

        public string GetRequiredValue(string key)
        {
            IConfigurationValue item = FindByKey(key);

            if (item == null)
                throw new MissingConfigurationValueException(key, System.Reflection.Assembly.GetCallingAssembly().ManifestModule.Name);
            else
                return item.Value;
        }

        public int GetRequiredIntValue(string key)
        {
            IConfigurationValue item = FindByKey(key);

            if (item == null)
                throw new MissingConfigurationValueException(key, System.Reflection.Assembly.GetCallingAssembly().ManifestModule.Name);
            else
                return int.Parse(item.Value);
        }

        public int? GetNullableIntValue(string key)
        {
            IConfigurationValue item = FindByKey(key);

            if (item != null)
                return int.Parse(item.Value);
            else
                return null;
        }

        public int GetIntValue(string key, int defaultValue)
        {
            IConfigurationValue item = FindByKey(key);

            if (item == null || item.Value == null || item.Value == string.Empty)
                return defaultValue;
            else
                return int.Parse(item.Value);
        }

        public Guid GetGuidValue(string key, Guid defaultValue)
        {
            IConfigurationValue item = FindByKey(key);

            if (item == null || item.Value == null || item.Value == string.Empty)
                return defaultValue;
            else
                return new Guid(item.Value);
        }

        public Guid GetRequiredGuidValue(string key, Guid defaultValue)
        {
            IConfigurationValue item = FindByKey(key);

            if (item == null)
                throw new MissingConfigurationValueException(key, System.Reflection.Assembly.GetCallingAssembly().ManifestModule.Name);
            else
                return new Guid(item.Value);
        }

        public void ApplyKeyFilter(string p)
        {
            for (int i = this.Count - 1; i >= 0; i--) 
                if (!this[i].Key.Contains(p))
                    this.RemoveAt(i);
        }

        public void ApplyValueFilter(string p)
        {
            for (int i = this.Count - 1; i >= 0; i--)
                if (!this[i].Value.Contains(p))
                    this.RemoveAt(i);
        }
    }
}
