using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServiceResult
{
    public enum RequestStatus
    {
        [Description("Успех")]
        OK = 200,

        [Description("Ошибка на сервере")]
        INTERNAL_ERROR = 500,

        [Description("Сервис не реализован")]
        NOT_IMPLEMENTED = 501,

        [Description("Ошибка обращения к сервису")]
        RESPONSE_ERROR = 502,

        [Description("Страница не найдена")]
        PAGE_NOT_FOUND = 404
    }

    [DataContract]
    public class ResultBody<T>
    {
        [DataMember(Order = 1)]
        public string ApiDescription { get; set; }

        [DataMember(Order = 2)]
        public RequestStatus Status { get; set; }

        [DataMember(Order = 3)]
        public T Data { get; set; }

        [DataMember(Order = 4)]
        public string Message { get; set; }

        [DataMember(Order = 5)]
        public int? MessageCode { get; set; }

        public static ResultBody<T> GeneratePackage(string apiDescription, T data, RequestStatus status, string message = null, int? messageCode = null)
        {
            var package = new ResultBody<T>
            {
                ApiDescription = apiDescription,
                Data = data,
                Status = status,
                Message = message,
                MessageCode = messageCode
            };

            return package;
        }
    }
}
