using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SspService
{
    [ServiceContract]
    public interface IHotelService
    {

        [OperationContract]
        string GetData(int value);
        
    }

    public class HotelService : IHotelService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
    }
}
