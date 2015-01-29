using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

using OSharp.Demo.Web.Dtos;
using OSharp.Demo.Web.Models;
using OSharp.Utility.Data;


namespace OSharp.Demo.Web.Services.Impl
{
    public partial class IdentityService
    {
        #region Implementation of IIdentityContract

        /// <summary>
        /// 获取 用户信息查询数据集
        /// </summary>
        public IQueryable<User> Users { get { return _userRepository.Entities; } }

        /// <summary>
        /// 检查用户信息信息是否存在
        /// </summary>
        /// <param name="predicate">检查谓语表达式</param>
        /// <param name="id">更新的用户信息编号</param>
        /// <returns>用户信息是否存在</returns>
        public bool CheckUserExists(Expression<Func<User, bool>> predicate, int id = 0)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 添加用户信息信息
        /// </summary>
        /// <param name="dtos">要添加的用户信息DTO信息</param>
        /// <returns>业务操作结果</returns>
        public OperationResult AddUsers(params UserDto[] dtos)
        {
            var s = new string[] { }.AsQueryable();
            s.Where()
            throw new NotImplementedException();
        }

        /// <summary>
        /// 更新用户信息信息
        /// </summary>
        /// <param name="dtos">包含更新信息的用户信息DTO信息</param>
        /// <returns>业务操作结果</returns>
        public OperationResult EditUsers(params UserDto[] dtos)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除用户信息信息
        /// </summary>
        /// <param name="ids">要删除的用户信息编号</param>
        /// <returns>业务操作结果</returns>
        public OperationResult DeleteUsers(params int[] ids)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}