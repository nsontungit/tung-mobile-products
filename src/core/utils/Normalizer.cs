using entities.main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace core.utils
{
    public static class Normalizer
    {
        public static Laptop Normalize(this Laptop laptop)
        {
            // TODO
            // string: TRIM
            return laptop.NormalizeString();
        }
        private static Laptop NormalizeString(this Laptop laptop)
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
