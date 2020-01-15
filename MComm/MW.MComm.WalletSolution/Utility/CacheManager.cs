using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Reflection;
using MSCaching = Microsoft.Practices.EnterpriseLibrary.Caching;
using MW.MComm.WalletSolution.BLL.Config;
namespace MW.MComm.WalletSolution.Utility
{
    /// <summary>
    /// A wrapper for Microsoft.Practices.EnterpriseLibrary.Caching.
    /// </summary>
    public class CacheManager
    {
           
        /// <summary>
        /// Checks application config file for the name of an XML file which lists
        /// the classes that can be cached.
        /// </summary>
        static CacheManager()
        {
            string fileName = ConfigurationContext.Current.AllValues.GetValue("CachedEntityFilePath");
			if (fileName != null && BLL.BusinessObjectManager.DBOptions.CachedEntities.Count == 0)
            {
                fileName = Path.Combine(Assembly.GetExecutingAssembly().CodeBase, fileName);
                XmlDocument xml = new XmlDocument();
                xml.Load(fileName);
                XmlNodeList nodes = xml.SelectNodes("/Entities/Entity");
                foreach (XmlNode node in nodes)
                {
                    BLL.BusinessObjectManager.DBOptions.CachedEntities[node.Attributes["FullName"].Value] = true;
                }
            }
        }
        public static MSCaching.CacheManager Cache
        {
            get { return MSCaching.CacheFactory.GetCacheManager();}
        }
    }
}
