// -----------------------------------------------------------------------
//  <copyright file="IdentityService.Organization.cs" company="OSharp开源团队">
//      Copyright (c) 2015 OSharp. All rights reserved.
//  </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2015-01-08 0:32</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

using OSharp.Demo.Web.Dtos;
using OSharp.Demo.Web.Models;
using OSharp.Utility;
using OSharp.Utility.Data;
using OSharp.Utility.Extensions;


namespace OSharp.Demo.Web.Services.Impl
{
    public partial class IdentityService
    {
        #region Implementation of IIdentityContract

        /// <summary>
        /// 获取 组织机构信息查询数据集
        /// </summary>
        public IQueryable<Organization> Organizations { get { return _organizationRepository.Entities; } }

        /// <summary>
        /// 检查组织机构信息信息是否存在
        /// </summary>
        /// <param name="predicate">检查谓语表达式</param>
        /// <param name="id">更新的组织机构信息编号</param>
        /// <returns>组织机构信息是否存在</returns>
        public bool CheckOrganizationExists(Expression<Func<Organization, bool>> predicate, int id = 0)
        {
            return _organizationRepository.ExistsCheck(predicate, id);
        }

        /// <summary>
        /// 添加组织机构信息信息
        /// </summary>
        /// <param name="dtos">要添加的组织机构信息DTO信息</param>
        /// <returns>业务操作结果</returns>
        public OperationResult AddOrganizations(params OrganizationDto[] dtos)
        {
            dtos.CheckNotNull("dtos");
            List<Organization> organizations = new List<Organization>();
            OperationResult result = _organizationRepository.Insert(dtos,
                dto =>
                {
                    if (_organizationRepository.ExistsCheck(m => m.Name == dto.Name))
                    {
                        throw new Exception("组织机构名称“{0}”已存在，不能重复添加。".FormatWith(dto.Name));
                    }
                },
                (dto, entity) =>
                {
                    if (dto.ParentId.HasValue && dto.ParentId.Value > 0)
                    {
                        Organization parent = _organizationRepository.GetByKey(dto.ParentId.Value);
                        if (parent == null)
                        {
                            throw new Exception("指定父组织机构不存在。");
                        }
                        entity.Parent = parent;
                    }
                    organizations.Add(entity);
                    return entity;
                });
            if (result.ResultType == OperationResultType.Success)
            {
                int[] ids = organizations.Select(m => m.Id).ToArray();
                RefreshOrganizationsTreePath(ids);
            }
            return result;
        }

        /// <summary>
        /// 更新组织机构信息信息
        /// </summary>
        /// <param name="dtos">包含更新信息的组织机构信息DTO信息</param>
        /// <returns>业务操作结果</returns>
        public OperationResult EditOrganizations(params OrganizationDto[] dtos)
        {
            dtos.CheckNotNull("dtos");
            List<Organization> organizations = new List<Organization>();
            OperationResult result = _organizationRepository.Update(dtos,
                dto =>
                {
                    if (_organizationRepository.ExistsCheck(m => m.Name == dto.Name, dto.Id))
                    {
                        throw new Exception("组织机构名称“{0}”已存在，不能重复添加。".FormatWith(dto.Name));
                    }
                },
                (dto, entity) =>
                {
                    if (!dto.ParentId.HasValue || dto.ParentId == 0)
                    {
                        entity.Parent = null;
                    }
                    else if (entity.Parent != null && entity.Parent.Id != dto.ParentId)
                    {
                        Organization parent = _organizationRepository.GetByKey(dto.Id);
                        if (parent == null)
                        {
                            throw new Exception("指定父组织机构不存在。");
                        }
                        entity.Parent = parent;
                    }
                    organizations.Add(entity);
                    return entity;
                });
            if (result.ResultType == OperationResultType.Success)
            {
                int[] ids = organizations.Select(m => m.Id).ToArray();
                RefreshOrganizationsTreePath(ids);
            }
            return result;
        }

        /// <summary>
        /// 删除组织机构信息信息
        /// </summary>
        /// <param name="ids">要删除的组织机构信息编号</param>
        /// <returns>业务操作结果</returns>
        public OperationResult DeleteOrganizations(params int[] ids)
        {
            ids.CheckNotNull("ids");
            OperationResult result = _organizationRepository.Delete(ids,
                entity =>
                {
                    if (entity.Children.Any())
                    {
                        throw new Exception("组织机构“{0}”的子级不为空，不能删除。".FormatWith(entity.Name));
                    }
                });
            return result;
        }

        #endregion

        #region 私有方法

        private void RefreshOrganizationsTreePath(params int[] ids)
        {
            if (ids.Length == 0)
            {
                return;
            }
            List<Organization> organizations = _organizationRepository.GetInclude(m => m.Parent).Where(m => ids.Contains(m.Id)).ToList();
            UnitOfWork.TransactionEnabled = true;
            foreach (var organization in organizations)
            {
                organization.TreePath = organization.Parent == null
                    ? organization.Id.ToString()
                    : organization.Parent.TreePathIds.Union(new[] { organization.Id }).ExpandAndToString();
                _organizationRepository.Update(organization);
            }
            UnitOfWork.SaveChanges();
        }

        #endregion
    }
}