using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityKit.Components.Pel.Application.Contracts.Data.Crt_Logs.Requests
{
    public class AppAddLogsRequest
    {
        public Boolean IsApp { get; set; }
        public string AppName { get; set; }
        public int ProcessID { get; set; }
        public DateTime CreationDate { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Severity { get; set; }
        public string User { get; set; }
    }
}
