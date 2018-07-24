using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace ServiceResult
{
    [DataContract]
    public class GetHotelResult
    {
        [DataMember]
        public Hotel Hotel { get; set; }
    }
}
