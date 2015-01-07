using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using OSharp.Utility.Exceptions;
using OSharp.Utility.Properties;


namespace OSharp.Utility.Filter
{
    /// <summary>
    /// <see cref="IQueryable{T}"/>类型字符串排序操作类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class QueryablePropertySorter<T>
    {
        // ReSharper disable StaticFieldInGenericType
        private static readonly ConcurrentDictionary<string, LambdaExpression> Cache = new ConcurrentDictionary<string, LambdaExpression>();

        /// <summary>
        /// 按指定的属性名称对<see cref="IQueryable{T}"/>序列进行排序
        /// </summary>
        /// <param name="source">IQueryable{T}序列</param>
        /// <param name="propertyName">属性名称</param>
        /// <param name="sortDirection">排序方向</param>
        /// <returns></returns>
        public static IOrderedQueryable<T> OrderBy(IQueryable<T> source, string propertyName, ListSortDirection sortDirection)
        {
            dynamic keySelector = GetKeySelector(propertyName);
            return sortDirection == ListSortDirection.Ascending
                ? Queryable.OrderBy(source, keySelector)
                : Queryable.OrderByDescending(source, keySelector);
        }

        /// <summary>
        /// 按指定的属性名称对<see cref="IOrderedQueryable{T}"/>序列进行排序
        /// </summary>
        /// <param name="source">IOrderedQueryable{T}序列</param>
        /// <param name="propertyName">属性名称</param>
        /// <param name="sortDirection">排序方向</param>
        /// <returns></returns>
        public static IOrderedQueryable<T> ThenBy(IOrderedQueryable<T> source, string propertyName, ListSortDirection sortDirection)
        {
            dynamic keySelector = GetKeySelector(propertyName);
            return sortDirection == ListSortDirection.Ascending
                ? Queryable.ThenBy(source, keySelector)
                : Queryable.ThenByDescending(source, keySelector);
        }

        private static LambdaExpression GetKeySelector(string keyName)
        {
            Type type = typeof(T);
            string key = type.FullName + "." + keyName;
            if (Cache.ContainsKey(key))
            {
                return Cache[key];
            }
            ParameterExpression param = Expression.Parameter(type);
            string[] propertyNames = keyName.Split('.');
            Expression propertyAccess = param;
            foreach (string propertyName in propertyNames)
            {
                PropertyInfo property = type.GetProperty(propertyName);
                if (property == null)
                {
                    throw new OSharpException(string.Format(Resources.ObjectExtensions_PropertyNameNotExistsInType, propertyName));
                }
                type = property.PropertyType;
                propertyAccess = Expression.MakeMemberAccess(propertyAccess, property);
            }
            LambdaExpression keySelector = Expression.Lambda(propertyAccess, param);
            Cache[key] = keySelector;
            return keySelector;
        }
    }
}
