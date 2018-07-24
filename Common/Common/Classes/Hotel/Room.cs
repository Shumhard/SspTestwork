using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [DataContract]
    public class Room
    {
        [DataMember]
        public Guid Guid { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public RoomStatus? Status { get; set; }

        [DataMember]
        public double? CostPerDay { get; set; }

        [DataMember]
        public double? CostService { get; set; }
    }
}
