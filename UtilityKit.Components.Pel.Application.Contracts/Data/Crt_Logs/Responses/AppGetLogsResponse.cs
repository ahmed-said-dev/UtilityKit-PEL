using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityKit.Components.Pel.Application.Contracts.Data.Crt_Logs.Requests;

namespace UtilityKit.Components.Pel.Application.Contracts.Data.Crt_Logs.Responses
{
    public class AppGetLogsResponse
    {
        public string result { get; set; }
        public GetLogsCsvRequest _GetLogsCsvRequest;
        public List<GetLogsCsvRequest> _LogsList;

    }
}
