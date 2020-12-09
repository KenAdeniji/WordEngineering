using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//	2015-11-10	http://stackoverflow.com/questions/7599732/caching-in-a-console-application
namespace CySoft.Collections
{
    public class Cache<TKey,TValue>
    {
        private readonly Dictionary<TKey, CacheItem> _cache = new Dictionary<TKey, CacheItem>();
        private TimeSpan _maxCachingTime;

        /// <summary>
        /// Creates a cache which holds the cached values for an infinite time.
        /// </summary>
        public Cache()
            : this(TimeSpan.MaxValue)
        {
        }

        /// <summary>
        /// Creates a cache which holds the cached values for a limited time only.
        /// </summary>
        /// <param name="maxCachingTime">Maximum time for which the a value is to be hold in the cache.</param>
        public Cache(TimeSpan maxCachingTime)
        {
            _maxCachingTime = maxCachingTime;
        }

        /// <summary>
        /// Tries to get a value from the cache. If the cache contains the value and the maximum caching time is
        /// not exceeded (if any is defined), then the cached value is returned, else a new value is created.
        /// </summary>
        /// <param name="key">Key of the value to get.</param>
        /// <param name="createValue">Function creating a new value.</param>
        /// <returns>A cached or a new value.</returns>
        public TValue Get(TKey key, Func<TValue> createValue)
        {
            CacheItem cacheItem;
            if (_cache.TryGetValue(key, out cacheItem) && (DateTime.Now - cacheItem.CacheTime) <= _maxCachingTime) {
                return cacheItem.Item;
            }
            TValue value = createValue();
            _cache[key] = new CacheItem(value);
            return value;
        }

        private struct CacheItem
        {
            public CacheItem(TValue item)
                : this()
            {
                Item = item;
                CacheTime = DateTime.Now;
            }

            public TValue Item { get; private set; }
            public DateTime CacheTime { get; private set; }
        }

    }
}
