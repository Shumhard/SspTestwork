using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceResult;

namespace SspService
{
    public class ServiceExecutor
    {
        public static ResultBody<T> Execute<T>(Func<T> action, string serviceInfo)
        {
            try
            {
                var actionResult = action();
                var successResult = ResultBody<T>.GeneratePackage(serviceInfo, actionResult, RequestStatus.OK);
                return successResult;
            }
            catch (Exception ex)
            {
                return ResultBody<T>.GeneratePackage(serviceInfo, default(T), RequestStatus.INTERNAL_ERROR, ex.Message);
            }
        }
    }
}