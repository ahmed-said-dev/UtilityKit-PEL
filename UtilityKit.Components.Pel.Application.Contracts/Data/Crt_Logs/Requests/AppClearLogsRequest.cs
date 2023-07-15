using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityKit.Components.Pel.Application.Contracts.Data.Crt_Logs.Requests
{
    public class AppClearLogsRequest
    {
        public Boolean clearAll { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public Boolean IsApp { get; set; }
        public string AppName { get; set; }
        public int ProcessID { get; set; }
    }
}
