using Microsoft.Extensions.Caching.Memory;
using System;

namespace TianCheng.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class CachingHelper
    {
        #region 缓存操作对象
        static private IMemoryCache _cache = null;
        /// <summary>
        /// 缓存操作对象
        /// </summary>
        protected IMemoryCache CacheObject
        {
            get
            {
                if (_cache == null)
                {
                    _cache = new MemoryCache(new MemoryCacheOptions());
                }
                return _cache;
            }
        }
        #endregion

        #region 设置缓存数据默认配置

        /// <summary>
        /// 保存一天的缓存配置信息
        /// </summary>
        static protected readonly MemoryCacheEntryOptions OneDayOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(1));

        #endregion

        #region 获取缓存数据
        /// <summary>
        /// 当缓存信息为空时的处理
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected virtual T OnCacheEmpty<T>() => default;

        /// <summary>
        /// 获取缓存信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual T GetCache<T>(string key)
        {
            if (!CacheObject.TryGetValue(key, out T val))
            {
                // 如果缓存值不存在
                return OnCacheEmpty<T>();
            }
            return val;
        }
        #endregion

        #region 设置缓存信息
        /// <summary>
        /// 设置缓存信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="val"></param>
        public virtual void SetCache<T>(string key, T val) => CacheObject.Set(key, val, OneDayOptions);
        #endregion
    }
}
