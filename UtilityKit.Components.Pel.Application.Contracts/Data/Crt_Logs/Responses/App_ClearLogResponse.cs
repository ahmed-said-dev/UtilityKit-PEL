﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityKit.Components.Pel.Application.Contracts.Data.Crt_Logs.Responses
{
    public class App_ClearLogResponse
    {
        public string result { get; set; }
        public App_ClearLogResponse(string _result)
        {
            result = _result;
        }
        
    }
}
