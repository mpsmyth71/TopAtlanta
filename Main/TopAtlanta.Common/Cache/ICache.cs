using System;

namespace TopAtlanta.Common
{
    public interface ICache<K, O>
    {
        void Put(K key, O value);
        void Put(K key, O value, DateTimeOffset ttl);
        void Put(K key, O value, TimeSpan ttl);

        O Get(K key);

        void Expire(K key);
        void Clear();
    }
}
