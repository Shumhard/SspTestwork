using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceRequest;
using ServiceResult;

namespace SspClient.ServiceWorker
{
    public class ServiceWorker : IServiceWorker
    {
        private readonly string _serviceAddress;

        public ServiceWorker(string serviceAddress)
        {
            _serviceAddress = serviceAddress;
        }

        public async Task<ResultBody<GetHotelResult>> GetHotel(GetHotelRequest request)
        {
            using (var responser = new AsyncResponser())
            {
                responser.SetParameter("request", request);
                var result = await responser.Execute<GetHotelResult>(_serviceAddress + "HotelService.svc/GetHotel");
                return result;
            }
        }
    }
}
