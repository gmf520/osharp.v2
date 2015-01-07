using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSharp.Core.Caching
{
    /// <summary>
    /// 作为缓存操作入口，并定义缓存功能通用操作
    /// </summary>
    public interface ICachingProvider
    {
        /// <summary>
        /// 获取指定缓存的数据
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <returns></returns>
        object Get(string key);
    

    }
}
