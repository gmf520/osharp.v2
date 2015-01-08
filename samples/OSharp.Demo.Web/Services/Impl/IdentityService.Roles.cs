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
        /// 获取 角色信息查询数据集
        /// </summary>
        public IQueryable<Role> Roles { get { return _roleRepository.Entities; } }

        /// <summary>
        /// 检查角色信息信息是否存在
        /// </summary>
        /// <param name="predicate">检查谓语表达式</param>
        /// <param name="id">更新的角色信息编号</param>
        /// <returns>角色信息是否存在</returns>
        public bool CheckRoleExists(Expression<Func<Role, bool>> predicate, int id = 0)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 添加角色信息信息
        /// </summary>
        /// <param name="dtos">要添加的角色信息DTO信息</param>
        /// <returns>业务操作结果</returns>
        public OperationResult AddRoles(params RoleDto[] dtos)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 更新角色信息信息
        /// </summary>
        /// <param name="dtos">包含更新信息的角色信息DTO信息</param>
        /// <returns>业务操作结果</returns>
        public OperationResult EditRoles(params RoleDto[] dtos)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除角色信息信息
        /// </summary>
        /// <param name="ids">要删除的角色信息编号</param>
        /// <returns>业务操作结果</returns>
        public OperationResult DeleteRoles(params int[] ids)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}