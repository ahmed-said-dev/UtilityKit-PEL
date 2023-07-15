using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityKit.Components.Pel.Application.Contracts.Data.Crt_ATL.Requests
{
    public class ATLAppClearLogsRequest
    {
        public Boolean clearAll { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
