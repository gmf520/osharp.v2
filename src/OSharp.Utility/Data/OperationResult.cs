// -----------------------------------------------------------------------
//  <copyright file="OperationResult.cs" company="OSharp开源团队">
//      Copyright (c) 2014 OSharp. All rights reserved.
//  </copyright>
//  <last-editor>最后修改人</last-editor>
//  <last-date>2014-07-30 5:15</last-date>
// -----------------------------------------------------------------------


namespace OSharp.Utility.Data
{
    /// <summary>
    /// 业务操作结果信息类，对操作结果进行封装
    /// </summary>
    public class OperationResult
    {
        #region 构造函数

        /// <summary>
        /// 初始化一个<see cref="OperationResult"/>类型的新实例
        /// </summary>
        public OperationResult(OperationResultType resultType)
        {
            ResultType = resultType;
        }

        /// <summary>
        /// 初始化一个<see cref="OperationResult"/>类型的新实例
        /// </summary>
        public OperationResult(OperationResultType resultType, string message)
            : this(resultType)
        {
            Message = message;
        }



        #endregion

        #region 属性

        /// <summary>
        /// 获取或设置 操作结果类型
        /// </summary>
        public OperationResultType ResultType { get; set; }

        /// <summary>
        /// 获取或设置 操作返回信息
        /// </summary>
        public string Message { get; set; }



        #endregion
    }

    /// <summary>
    ///     业务操作结果信息类，对操作结果进行封装，带返回值
    /// </summary>
    public class OperationResult<T> : OperationResult
    {
        /// <summary>
        /// 返回值 
        /// </summary>
        public T Value { get; set; }

        public OperationResult(OperationResultType resultType)
            : base(resultType)
        {
        }

        public OperationResult(OperationResultType resultType, string message)
            : base(resultType, message)
        {
        }



        public OperationResult(OperationResultType resultType, string message, T value)
            : base(resultType, message)
        {
            this.Value = value;
        }





    }
}