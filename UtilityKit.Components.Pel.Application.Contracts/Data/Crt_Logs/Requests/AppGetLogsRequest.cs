using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityKit.Components.Pel.Application.Contracts.Data.Crt_Logs.Requests
{
    public class AppGetLogsRequest
    {
        public Boolean IsApp { set; get; }
        public string AppName { set; get; }
        public int ProcessID { set; get; }
    }
}
