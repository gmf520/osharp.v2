/************************************************************************ 
 * 项目名称 :  Cares.Service.Common.Extensions   
 * 项目描述 :      
 * 类 名 称 :  AutoMapperExtension 
 * 版 本 号 :  v1.0.0.0  
 * 说    明 :      
 * 作    者 :  Administrator 
 * 创建时间 :  2015/3/4 10:43:21 
 * 更新时间 :  2015/3/4 10:43:21 
************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;

using AutoMapper;


namespace OSharp.Core.Data.Entity.Extensions
{
    /// <summary>
    /// AutoMapper扩展方法
    /// 使用：obj.MapTo<Entity/>()
    /// </summary>
    public static class AutoMapperExtension
    {
        /// <summary>
        /// 集合 ==> 集合
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static List<TResult> MapTo<TResult>(this IEnumerable self)
        {
            if (self == null)
            {
                throw new ArgumentNullException();
            }

            return (List<TResult>)Mapper.Map(self, self.GetType(), typeof(List<TResult>));
        }

        /// <summary>
        /// 对象 ==> 对象
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static TResult MapTo<TResult>(this object self)
        {
            if (self == null)
            {
                throw new ArgumentNullException();
            }

            return (TResult)Mapper.Map(self, self.GetType(), typeof(TResult));
        }
    }
}
