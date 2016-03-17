using Microsoft.AspNet.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace BetterSession.AspNet.Mvc.Tests
{
    public class FakeTempData : ITempDataDictionary
    {
        public IDictionary<string, object> cache = new Dictionary<string, object>();
        public object this[string key]
        {
            get
            {
                return cache[key];
            }

            set
            {
                cache[key] = value;
            }
        }

        public int Count
        {
            get
            {
                return cache.Count();
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public ICollection<string> Keys
        {
            get
            {
                return cache.Keys;
            }
        }

        public ICollection<object> Values
        {
            get
            {
                return cache.Values;
            }
        }

        public void Add(KeyValuePair<string, object> item)
        {
            cache.Add(item);
        }

        public void Add(string key, object value)
        {
            cache.Add(key, value);
        }

        public void Clear()
        {
            cache.Clear();
        }

        public bool Contains(KeyValuePair<string, object> item)
        {
            return cache.Contains(item);
        }

        public bool ContainsKey(string key)
        {
            return cache.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            cache.CopyTo(array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return cache.GetEnumerator();
        }

        public void Keep()
        {
            throw new NotImplementedException();
        }

        public void Keep(string key)
        {
            throw new NotImplementedException();
        }

        public void Load()
        {
            throw new NotImplementedException();
        }

        public object Peek(string key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<string, object> item)
        {
            return cache.Remove(item);
        }

        public bool Remove(string key)
        {
            return cache.Remove(key);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(string key, out object value)
        {
            return cache.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return cache.GetEnumerator();
        }
    }
}
