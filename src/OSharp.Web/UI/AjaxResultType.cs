using OSharp.Utility.Data;


namespace OSharp.Web.UI
{
    public enum AjaxResultType
    {
        Info,

        Success,

        Warning,

        Error
    }


    public static class AjaxResultTypeExtensions
    {
        /// <summary>
        /// 把业务结果类型<see cref="OperationResultType"/>转换为Ajax结果类型<see cref="AjaxResultType"/>
        /// </summary>
        public static AjaxResultType ToAjaxResultType(this OperationResultType resultType)
        {
            switch (resultType)
            {
                case OperationResultType.Success:
                    return AjaxResultType.Success;
                case OperationResultType.NoChanged:
                    return AjaxResultType.Info;
                default:
                    return AjaxResultType.Error;
            }
        }
        
        /// <summary>
        /// 判断业务结果类型是否是Error结果
        /// </summary>
        public static bool IsError(this OperationResultType resultType)
        {
            return resultType == OperationResultType.QueryNull || resultType == OperationResultType.ValidError
                || resultType == OperationResultType.Error;
        }
    }
}
