using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [DataContract]
    [Flags]
    public enum RoomStatus
    {
        [EnumMember]
        [Description("")]
        Free = 0,

        [EnumMember]
        [Description("")]
        Inhabited = 1
    }
}
