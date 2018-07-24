using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServiceRequest
{
    [DataContract]
    public class GetHotelRequest
    {
        [DataMember]
        public Guid HotelGuid { get; set; }
    }
}
