using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TIMES
{
    public class ChangeReport
    {
        public int ChangeReportNo { get; set; }
        public int WorkNo { get; set; }
        public int UserNo { get; set; }
        public DateTime NewInTime { get; set; }

        public DateTime NewOutTime { get; set; }

        public string Title { get; set; }

        public string Comment { get; set; }

        public string AdminComment { get; set; }

        public int Status { get; set; }


    }
}