using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace core.utils
{
    public class Converter
    {
        public static TDest OverrideObject<TSource, TDest>(TSource src, TDest dest) where TSource : class
                                                                   where TDest : class
        {
            var srcType = typeof(TSource);
            var destType = typeof(TDest);
            var srcPropNames = srcType.GetProperties().Select(e => e.Name);
            var destPropNames = destType.GetProperties().Select(e => e.Name);
            foreach (var p in srcPropNames)
            {
                if (destPropNames.Contains(p))
                {
                    var srcProp = srcType.GetProperty(p);
                    var srcPropValue = srcProp.GetValue(src);
                    var destProp = destType.GetProperty(p);
                    destProp.SetValue(dest, srcPropValue);
                }
            }
            return dest;
        }
    }
}
