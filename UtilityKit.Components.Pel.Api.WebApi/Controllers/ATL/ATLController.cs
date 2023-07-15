using MediatR;
using Microsoft.AspNetCore.Mvc;
using UtilityKit.Components.Atl.Api.WebApi.Controllers;
using UtilityKit.Components.Pel.Application.Commands.Cmd_ATL;
using UtilityKit.Components.Pel.Application.Contracts.Data.Crt_ATL.Requests;

namespace UtilityKit.Components.Pel.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ATLController : BaseController
    {

        [HttpDelete("")]
        public async Task<IActionResult> clear([FromBody] ATLAppClearLogsRequest ATLApp, CancellationToken cancellationToken)
              => Ok(await Mediator.Send(new ClearLogsCommand() { _ATLAppClearLogsRequest = ATLApp }, cancellationToken));
        ////ClearLogsCommand _ClearLogsCommand = new ClearLogsCommand();
        //string path = Directory.GetCurrentDirectory();

        ////string[] files = Directory.GetFiles();

        //[HttpDelete("{clearAll}/{from}/{to}")]
        //public string ClearAll(ClearLogsCommand _clearLogsCommand,Boolean clearAll,DateTime from,DateTime to,CancellationToken cancellationToken)
        //{
        //    if (clearAll)
        //    {
        //         return _clearLogsCommand.clearAll();
        //    }
        //    else
        //    {
        //        return _clearLogsCommand.clearFromTo(from,to);
        //    }

        //}
    }
}