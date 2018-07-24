using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using ServiceRequest;
using ServiceResult;

namespace SspService.Services
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class HotelService : IHotelService
    {
        public ResultBody<GetHotelResult> GetHotel(GetHotelRequest request)
        {
            Func<GetHotelResult> x = () =>
            {
                return new GetHotelResult();
            };
            return ServiceExecutor.Execute(x, "HotelService/GetHotel");
        }
    }
}
