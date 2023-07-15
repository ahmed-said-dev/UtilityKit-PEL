using CsvHelper;
using MediatR;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UtilityKit.Components.Pel.Application.Contracts.Data.Crt_Logs.Requests;
using UtilityKit.Components.Pel.Application.Contracts.Data.Crt_Logs.Responses;

namespace UtilityKit.Components.Pel.Application.Commands.Cmd_Logs
{
    public class AddLogsCommand : IRequest<App_AddLogResponse>
    {
        
        public AppAddLogsRequest _AppAddLogsRequest { set; get;}

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
        public class Handler :IRequestHandler<AddLogsCommand, App_AddLogResponse>
        {
            public async Task<App_AddLogResponse> Handle(AddLogsCommand request, CancellationToken cancellationToken)
            {
                string CurrentDate = DateTime.Now.ToString("dd-MM-yyyy").Split(" ")[0];
                if (request._AppAddLogsRequest.IsApp)
                {
                    string AppPath = request.LogDirectory + $"\\apps\\{request._AppAddLogsRequest.AppName}";
                    if (!Directory.Exists(AppPath))
                    {
                        Directory.CreateDirectory(AppPath);
                    }
                    String separator = ",";
                    StringBuilder stringBuilder = new StringBuilder();
                    
                    String[] newLine = { request._AppAddLogsRequest.AppName, request._AppAddLogsRequest.Title,
                                         request._AppAddLogsRequest.Details, request._AppAddLogsRequest.Severity,
                                         request._AppAddLogsRequest.User };
                    
                    string FilePath = AppPath + $"\\{CurrentDate}.CSV";
                    if (!File.Exists(FilePath))
                    {
                        String[] headings = { "ApplicationName", "title", "details", "severity", "user" };
                        stringBuilder.AppendLine(string.Join(separator, headings));
                    }

                    stringBuilder.AppendLine(string.Join(separator, newLine));
                    try
                    {
                        File.AppendAllText(FilePath, stringBuilder.ToString());
                    }
                    catch (Exception ex)
                    {
                        return new App_AddLogResponse($"Data could not be written to the {request._AppAddLogsRequest.AppName} file.");
                    }
                    return new App_AddLogResponse($"{request._AppAddLogsRequest.AppName} event log added");
                }
                else
                {
                    String separator = ",";
                    StringBuilder stringBuilder = new StringBuilder();

                    String[] newLine = { request._AppAddLogsRequest.ProcessID.ToString(), request._AppAddLogsRequest.Title,
                                         request._AppAddLogsRequest.Details, request._AppAddLogsRequest.Severity,
                                         request._AppAddLogsRequest.User };
                    string ProcessPath = request.LogDirectory + $"\\processes\\{request._AppAddLogsRequest.ProcessID}";
                    if (!Directory.Exists(ProcessPath))
                    {
                        Directory.CreateDirectory(ProcessPath);
                    }
                    string FilePath = ProcessPath + $"\\{CurrentDate}.csv";
                    if (!File.Exists(FilePath))
                    {
                        String[] headings = { "process id", "title", "details", "severity", "user" };
                        stringBuilder.AppendLine(string.Join(separator, headings));
                    }
                    stringBuilder.AppendLine(string.Join(separator, newLine));
                    try
                    {
                        File.AppendAllText(FilePath, stringBuilder.ToString());
                    }
                    catch (Exception ex)
                    {
                        return new App_AddLogResponse($"Data could not be written to the process id : {request._AppAddLogsRequest.ProcessID} file.");
                    }
                    return new App_AddLogResponse($"Process ID : {request._AppAddLogsRequest.ProcessID} event logs added");
                }
            }
        }

    }
}
