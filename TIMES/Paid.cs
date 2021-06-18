using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TIMES
{
    public class Paid
    {
        public int PaidReportNo { get; set; }

        public int UserNo { get; set; }

        public string Title { get; set; }
        public string Comment { get; set; }
        public DateTime WantDay { get; set; }
        public string AdminComment { get; set; }
        public int Status { get; set; }
    }
}