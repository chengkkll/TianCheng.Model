using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Caching.Memory;
using System.IO;

namespace TianCheng.Model
{
    /// <summary>
    /// 缓存内容与文件关联，如果文件更新缓存重置
    /// </summary>
    /// <typeparam name="T">在文件中读取的数据类型</typeparam>
    public abstract class CachingFromFile<T> : CachingHelper where T : new()
    {
        #region 需要派生类中重写处理的
        /// <summary>
        /// 缓存Key值
        /// </summary>
        protected abstract string CacheKey { get; }
        /// <summary>
        /// 依赖文件名
        /// </summary>
        protected abstract string DependentFile { get; }
        /// <summary>
        /// 依赖文件所在目录
        /// </summary>
        protected virtual string DependentPath
        {
            get
            {
                string path = AppContext.BaseDirectory;
                if (path.Contains("\\bin\\"))
                {
                    path += "..\\..\\..\\";
                }
                return path;
            }
        }
        /// <summary>
        /// 从文件中读取数据处理
        /// </summary>
        /// <param name="fileContent"></param>
        /// <returns></returns>
        protected abstract T ReadFile(string fileContent);
        #endregion

        /// <summary>
        /// 构造方法
        /// </summary>
        public CachingFromFile()
        {
            // 设置文件监听
            WatchFile();
        }

        #region 设置缓存处理
        /// <summary>
        /// 根据文件依赖设置缓存信息
        /// </summary>
        public virtual T SetCache()
        {
            string fileContent = System.IO.File.ReadAllText(System.IO.Path.Combine(DependentPath, DependentFile));
            T val = ReadFile(fileContent);
            SetCache(CacheKey, val);
            return val;
        }
        #endregion

        #region 读取缓存处理
        /// <summary>
        /// 读取缓存操作
        /// </summary>
        /// <returns></returns>
        public virtual T GetCache()
        {
            if (!CacheObject.TryGetValue(CacheKey, out T val))
            {
                // 如果缓存值不存在
                val = SetCache();
            }
            return val;
        }
        #endregion

        #region 设置文件依赖，当文件改动时，自动更新缓存信息  
        /// <summary>
        /// 
        /// </summary>
        static public FileSystemWatcher watch = null;

        /// <summary>
        /// 设置文件监听      监听时过滤VS修改
        /// </summary>
        private void WatchFile()
        {
            if (watch != null)
            {
                return;
            }
            watch = new FileSystemWatcher(DependentPath, DependentFile);
            watch.Changed += Watch_Changed;
            watch.NotifyFilter = NotifyFilters.LastWrite;
            watch.EnableRaisingEvents = true;
        }

        /// <summary>
        /// 文件改变时的处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Watch_Changed(object sender, FileSystemEventArgs e)
        {
            // 重新设置缓存信息
            SetCache();
        }
        #endregion
    }
}
