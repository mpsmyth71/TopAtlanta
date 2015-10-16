using System;
using System.Runtime.Caching;


namespace TopAtlanta.Common
{
    public class MemCache<K, O> : ICache<K, O> where O : class
    {
        private static MemoryCache cache = new MemoryCache(typeof(O).FullName);

        public void Put(K key, O value)
        {
            cache.Add(key.ToString(), value, DateTimeOffset.MaxValue);
        }

        public void Put(K key, O value, DateTimeOffset ttl)
        {
            cache.Add(key.ToString(), value, ttl);
        }

        public void Put(K key, O value, TimeSpan ttl)
        {
            cache.Add(key.ToString(), value, DateTimeOffset.Now.Add(ttl));
        }

        public O Get(K key)
        {
            return cache.Get(key.ToString()) as O;
        }

        public void Expire(K key)
        {
            cache.Remove(key.ToString());
        }

        public void Clear()
        {
            cache.Dispose();
            cache = new MemoryCache(typeof(O).FullName);
        }
    }
}
