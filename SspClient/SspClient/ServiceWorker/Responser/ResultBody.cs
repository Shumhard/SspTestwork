using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceResult;

namespace SspClient.ServiceWorker
{
    public class ResultBody<T>
    {
        public string ApiDescription { get; set; }
        
        public RequestStatus Status { get; set; }
        
        public T Data { get; set; }
        
        public string Message { get; set; }
        
        public int? MessageCode { get; set; }
    }
}
