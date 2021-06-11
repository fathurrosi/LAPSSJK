using LAPS.SJK.Dta;
using LAPS.SJK.Dto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace LAPS.SJK.Logic
{
    public class CustomResourceManager : System.Resources.ResourceManager
    {
        private const string CacheLabelKey = "availableLabels";
        private const string CacheMenuKey = "availableMenus";
        public CustomResourceManager(Type resourceSource)
            : base(resourceSource)
        {
        }

        public CustomResourceManager(string baseName, Assembly assembly)
            : base(baseName, assembly)
        {
        }

        public CustomResourceManager(string baseName, Assembly assembly, Type usingResourceSet)
            : base(baseName, assembly, usingResourceSet)
        {
        }

        public override object GetObject(string name)
        {
            return base.GetObject(name);
        }
        public override string GetString(string name)
        {
            // your business logic
            string lang = CultureInfo.CurrentUICulture.Name;
            if (!string.IsNullOrEmpty(lang))
            {
                List<tbl_label> list = GetAvailableLabel();
                tbl_label lbl = list.Where(t => t.c_flag.ToUpper() == lang.ToUpper() && t.name.ToUpper() == name.ToUpper()).FirstOrDefault();
                return lbl != null ? lbl.value : string.Empty;
            }
            else
            {
                return name;
                //return base.GetString(name);
            }

        }

        public override string GetString(string name, CultureInfo culture)
        {
            // your business logic
            return base.GetString(name, culture);
        }



        public List<tbl_menu> GetAvailableMenus()
        {
            ObjectCache cache = MemoryCache.Default;

            if (cache.Contains(CacheMenuKey))
                return (List<tbl_menu>)cache.Get(CacheMenuKey);
            else
            {
                List<tbl_menu> availableMenus = tbl_menuItem.GetAll();

                // Store data in the cache    
                CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
                cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddHours(1.0);
                cache.Add(CacheMenuKey, availableMenus, cacheItemPolicy);

                return availableMenus;
            }
        }

        public List<tbl_label> GetAvailableLabel()
        {
            ObjectCache cache = MemoryCache.Default;

            if (cache.Contains(CacheLabelKey))
                return (List<tbl_label>)cache.Get(CacheLabelKey);
            else
            {
                List<tbl_label> availableMenus = tbl_labelItem.GetAll();

                // Store data in the cache    
                CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
                cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddHours(1.0);
                cache.Add(CacheLabelKey, availableMenus, cacheItemPolicy);

                return availableMenus;
            }
        }
    }
}
