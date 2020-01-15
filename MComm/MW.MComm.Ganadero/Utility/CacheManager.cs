using System;
using System.Collections.Generic;
using System.Text;
using MSCaching = Microsoft.Practices.EnterpriseLibrary.Caching;


namespace MW.MComm.Ganadero.Utility
{
    public class CacheManager
    {
        public static MSCaching.CacheManager Cache
        {
            get { return MSCaching.CacheFactory.GetCacheManager();}
        }
    }
}
