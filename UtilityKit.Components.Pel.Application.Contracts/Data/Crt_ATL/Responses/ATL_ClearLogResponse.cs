using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityKit.Components.Pel.Application.Contracts.Data.Crt_ATL.Responses
{
    public class ATL_ClearLogResponse
    {
        public string result { get; set; }
        public ATL_ClearLogResponse(string _result)
        {
            result = _result;
        }
        
    }
}
