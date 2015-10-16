using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TopAtlanta.Common;

namespace TopAtlanta.Web.Models
{
    public class ResultList<T> : List<T>
    {
        public int HitCount { get; set; }
        public bool Maxed { get; set; }

        public string GetMessage()
        {
            if (this.Count == 0) return Config.MsgNoRecordsFound;

            if (this.Maxed) return string.Format("showing {0} of {1} results", this.Count, this.HitCount);

            return string.Format("showing {0} result{1}", this.Count, this.Count == 1 ? "" : "s");
        }

    }
}