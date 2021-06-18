using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TIMES
{
    public class UserInfo
    {
        public int UserNo { get; set; }
        public string UserId { get; set; }
        public string UserPwd { get; set; }
        public string UserName { get; set; }
        public int UserType { get; set; }
        public DateTime StartDate { get; set; }
        public string UserPosition { get; set; }

        public string Authkey { get; set; }
        public int Authstatus { get; set; }
    }
}