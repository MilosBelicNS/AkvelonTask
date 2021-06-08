using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AkvelonTaskMilosBelic.Models
{
    public class Filter
    {
        //filter object for searching by priority(range)
        public int Min { get; set; }
        public int Max { get; set; }
    }
}