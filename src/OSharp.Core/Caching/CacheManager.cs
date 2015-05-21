// -----------------------------------------------------------------------
//  <copyright file="CacheManager.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2015 OSharp. All rights reserved.
//  </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2015-03-22 14:59</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSharp.Utility;


namespace OSharp.Core.Caching
{
    /// <summary>
    /// 缓存操作管理器
    /// </summary>
    public static class CacheManager
    {
        private static readonly object LockObj = new object();
        private static readonly ConcurrentDictionary<string, ICache> Cachers;

        static CacheManager()
        {
            Cachers = new ConcurrentDictionary<string, ICache>();
            CacheProviders = new List<ICacheProvider>();
        }

        /// <summary>
        /// 获取或设置 缓存提供程序集合
        /// </summary>
        internal static ICollection<ICacheProvider> CacheProviders { get; private set; }

        /// <summary>
        /// 添加缓存提供者
        /// </summary>
        /// <param name="provider">缓存提供者</param>
        public static void AddProvider(ICacheProvider provider)
        {
            lock (LockObj)
            {
                if (CacheProviders.Contains(provider))
                {
                    return;
                }
                CacheProviders.Add(provider);
            }
        }

        /// <summary>
        /// 移除缓存提供者
        /// </summary>
        public static void RemoveProvider(ICacheProvider provider)
        {
            lock (LockObj)
            {
                if (!CacheProviders.Contains(provider))
                {
                    return;
                }
                CacheProviders.Remove(provider);
            }
        }

        /// <summary>
        /// 获取指定区域的缓存执行者实例
        /// </summary>
        public static ICache GetCacher(string region)
        {
            region.CheckNotNullOrEmpty("region");
            ICache cache;
            if (Cachers.TryGetValue(region, out cache))
            {
                return cache;
            }
            cache = new InternalCacher(region);
            Cachers[region] = cache;
            return cache;
        }

        /// <summary>
        /// 获取指定类型的缓存执行者实例
        /// </summary>
        public static ICache GetCacher(Type type)
        {
            type.CheckNotNull("type");
            return GetCacher(type.FullName);
        }
    }
}