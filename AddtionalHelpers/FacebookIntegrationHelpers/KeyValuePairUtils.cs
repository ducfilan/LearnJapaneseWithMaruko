// Tools/KeyValuePairUtils.cs
using System;
using System.Collections.Generic;

namespace Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers.FacebookIntegrationHelpers
{
    public static class KeyValuePairUtils
    {
        public static TValue GetValue<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> pairs, TKey key)
        {
            foreach (KeyValuePair<TKey, TValue> pair in pairs)
            {
                if (key.Equals(pair.Key))
                    return pair.Value;
            }

            throw new Exception("the value is not found in the dictionary");
        }
    }
}
