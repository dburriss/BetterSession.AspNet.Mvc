using Newtonsoft.Json;
using PhilosophicalMonkey;
using System;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace BetterSession.AspNetCore.Mvc
{
    public static class TempDataExtensions
    {
        public static void Set<T>(this ITempDataDictionary tempData, string key, T data)
        {
            if (Reflect.OnTypes.IsSimple(typeof(T)))
            {
                tempData[key] = data;
                return;
            }
            var sData = JsonConvert.SerializeObject(data);
            tempData[key] = sData;
        }

        public static T Get<T>(this ITempDataDictionary tempData, string key)
        {
            if (tempData.ContainsKey(key))
            {
                var v = tempData[key];

                if (Reflect.OnTypes.IsSimple(typeof(T)))
                {
                    var obj = Convert.ChangeType(v, typeof(T));
                    return (T)obj;
                }

                if (v is T)
                {
                    return (T)v;
                }

                if (v is string && typeof(T) != typeof(string))
                {
                    var obj = JsonConvert.DeserializeObject<T>((string)v);
                    return obj;
                }
            }

            return default(T);
        }
    }
}
