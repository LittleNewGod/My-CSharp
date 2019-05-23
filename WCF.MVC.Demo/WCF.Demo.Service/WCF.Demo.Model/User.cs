using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WCF.Demo.Model
{
    [DataContract]
    public class User
    {
        [DataMember]
        public int UserID { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Discribe { get; set; }
        [DataMember]
        public DateTime SubmitTime { get; set; }
    }
}
