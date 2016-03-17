using Microsoft.AspNet.Http.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetterSession.AspNet.Mvc.Tests
{
    public class FakeSession : ISession
    {
        public IDictionary<string, byte[]> cache = new Dictionary<string, byte[]>();
        public IEnumerable<string> Keys
        {
            get
            {
                return cache.Keys;
            }
        }

        public void Clear()
        {
            cache.Clear();
        }

        public Task CommitAsync()
        {
            throw new NotImplementedException();
        }

        public Task LoadAsync()
        {
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {
            cache.Remove(key);
        }

        public void Set(string key, byte[] value)
        {
            if (cache.ContainsKey(key))
            {
                cache[key] = value;
                return;
            }
            cache.Add(key, value);
        }

        public bool TryGetValue(string key, out byte[] value)
        {
            return cache.TryGetValue(key, out value);
        }
    }
}
