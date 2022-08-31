using entities.main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace core.utils
{
    public static class Normalizer
    {
        public static Laptops Normalize(this Laptops laptop)
        {
            // TODO
            // string: TRIM
            return laptop.NormalizeString();
        }
        public static Laptops NormalizeString(this Laptops laptop)
        {
            var strPros = laptop.GetType().GetProperties()
                .Where(e => e.PropertyType == typeof(string));

            foreach (var p in strPros)
            {
                string value = p.GetValue(laptop, null) as string;
                p.SetValue(laptop, value.Trim(), null);
            }
            return laptop;
        }
    }
}
