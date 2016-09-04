using Newtonsoft.Json;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace BetterSession.AspNetCore.Http
{
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T data)
        {
            if (typeof(T) == typeof(string))
            {
                var v = data as string;
                session.Set(key, v.ToBytes());
            }
            else
            {
                var sData = JsonConvert.SerializeObject(data);
                session.Set(key, sData);
            }
        }

        public static T Get<T>(this ISession session, string key)
        {
            if (session.Keys.Contains(key))
            {
                byte[] v;
                if(session.TryGetValue(key, out v))
                {
                    if (typeof(T) == typeof(string))
                    {
                        var sData = v.MakeString();
                        var obj = Convert.ChangeType(sData, typeof(T));
                        return (T)obj;
                    }

                    if (typeof(T) != typeof(string))
                    {
                        var sData = v.MakeString();
                        var obj = JsonConvert.DeserializeObject<T>(sData);
                        return obj;
                    }
                }
            }

            return default(T);
        }
    }
}
