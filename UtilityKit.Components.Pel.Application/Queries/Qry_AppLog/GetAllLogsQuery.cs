using LINQtoCSV;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityKit.Components.Pel.Application.Commands.Cmd_Logs;
using UtilityKit.Components.Pel.Application.Contracts.Data.Crt_Logs.Requests;
using UtilityKit.Components.Pel.Application.Contracts.Data.Crt_Logs.Responses;

namespace UtilityKit.Components.Pel.Application.Queries.Qry_AppLog
{
    public class GetAllLogsQuery :IRequest<AppGetLogsResponse>
    {
        public string _AppName { set; get; }

        //<TODO> : To be replaced with configurable value
        string LogDirectory = "C:\\UtilityKit\\Log";

        public string GetAppLogPath(string AppName)
        {
            return $"{LogDirectory}\\apps\\{AppName}";
        }
        public string GetProcessLogPath(string processId)
        {
            return $"{LogDirectory}\\processes\\{processId}";
        }
        public class Handler : IRequestHandler<GetAllLogsQuery, AppGetLogsResponse>
        {
            public async Task<AppGetLogsResponse> Handle(GetAllLogsQuery request, CancellationToken cancellationToken)
            {
               
                    string AppPath = request.LogDirectory + $"\\apps\\{request._AppName}";
                    if (!Directory.Exists(AppPath))
                    {
                        return new AppGetLogsResponse() { result = "This application not found !"};
                    }
                    else
                    {
                        var csvFileDescription = new CsvFileDescription
                        {
                            FirstLineHasColumnNames = true,
                            IgnoreUnknownColumns = true,
                            SeparatorChar = ',',
                            UseFieldIndexForReadingData = false
                        };
                        var csvContext = new CsvContext(); 
                    //var logs = csvContext.Read<GetLogsCsvRequest>()
                        var Files = Directory.GetFiles(AppPath);
                        List<GetLogsCsvRequest> LogsList = new List<GetLogsCsvRequest>();
                        foreach (var file in Files)
                        {
                            var logs = csvContext.Read<GetLogsCsvRequest>(file);
                            foreach (var log in logs)
                            {
                                //LogsList.Add(new AppGetLogsResponse() { _GetLogsCsvRequest = log });
                                LogsList.Add(log);
                            }
                        }
                        return new AppGetLogsResponse() { _LogsList = LogsList };
                        //var data = JsonConvert.DeserializeObject<IEnumerable<IDictionary<string, object>>>($"[{AllText}]");
                        //var array = data.Select(d => d.Values.ToArray()).ToArray();
                        //return new AppGetLogsResponse($"{AllText}");
                    }
               
                //else
                //{
                //    string ProcessPath = request.LogDirectory + $"\\processes\\{request._AppGetLogsRequest.ProcessID}";
                //    if (!Directory.Exists(ProcessPath))
                //    {
                //        return new AppGetLogsResponse($"This process id : {request._AppGetLogsRequest.ProcessID} not found !");
                //    }
                //    else
                //    {
                //        var Files = Directory.GetFiles(ProcessPath);
                //        string AllText = "";
                //        foreach (var file in Files)
                //        {
                //            string FileText = File.ReadAllText(file);
                //            AllText += FileText;
                //        }
                //        var data = JsonConvert.DeserializeObject<IEnumerable<IDictionary<string, object>>>($"[{AllText}]");
                //        var array = data.Select(d => d.Values.ToArray()).ToArray();
                //        return new AppGetLogsResponse(AllText);
                //    }
                //}
            }
        }
            }
}
