using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityKit.Components.Pel.Domain.Exceptions.Broker
{
    public class ATLEmptyLogs : BusinessException  
    {
        public ATLEmptyLogs() :
            base(
                3,
                "ATL logs are empty",
                "",
                HttpStatusCode.BadRequest)
        { }
    }
}
