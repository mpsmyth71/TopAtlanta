using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopAtlanta.Common
{
    public static class Config
    {
        public static int MaxResults { get { return AppSettings.Get<int>("MaxResults"); } }
        public static string MsgNoRecordsFound { get { return AppSettings.Get<string>("MsgNoRecordsFound"); } }
    }
}
