using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TIMES
{
    public class Work
    {

        public int WorkNo { get; set; }
        public int UserNo { get; set; }
        public DateTime InTime { get; set; }
        public DateTime OutTime { get; set; }
        public int WorkTime { get; set; }
        public int WorkStatus { get; set; }
        public int WorkCheck { get; set; }
    }
}