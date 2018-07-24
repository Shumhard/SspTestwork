using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceRequest;
using ServiceResult;

namespace SspClient.ServiceWorker
{
    public interface IServiceWorker
    {
        Task<ResultBody<GetHotelResult>> GetHotel(GetHotelRequest request);
    }
}
