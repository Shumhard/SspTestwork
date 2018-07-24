using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ServiceRequest;
using ServiceResult;

namespace SspService.Services
{
    [ServiceContract]
    public interface IHotelService
    {

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/GetHotel",
            ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        ResultBody<GetHotelResult> GetHotel(GetHotelRequest request);

    }
}
