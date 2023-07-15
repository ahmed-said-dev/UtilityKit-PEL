using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UtilityKit.Components.Pel.Application.Contracts.Data.Crt_Logs.Requests;
using UtilityKit.Components.Pel.Application.Contracts.Data.Crt_Logs.Responses;

namespace UtilityKit.Components.Pel.Application.Commands.Cmd_App
{
    public class ClearLogsCommand : IRequest<App_ClearLogResponse>
    {
        public AppClearLogsRequest _AppClearLogsRequest { get; set; }

        //<TODO> : To be replaced with configurable value
        string directory = "C:\\UtilityKit\\Log";

        public string GetAppLogPath(string AppName)
        {
            return $"{directory}\\apps\\{AppName}";
        }
        public string GetProcessLogPath(string processId)
        {
            return $"{directory}\\processes\\{processId}";
        }
        
        public class Handler : IRequestHandler<ClearLogsCommand, App_ClearLogResponse>
        {
            public async Task<App_ClearLogResponse> Handle(ClearLogsCommand request, CancellationToken cancellationToken)
            {
                if (request._AppClearLogsRequest.IsApp)
                {
                    string AppLogPath = request.GetAppLogPath(request._AppClearLogsRequest.AppName);
                    string[] AppLogsFiles = Directory.GetFiles(AppLogPath);
                    if (request._AppClearLogsRequest.clearAll)
                    {
                        if (AppLogsFiles.IsNullOrEmpty())
                        {
                            return new App_ClearLogResponse($"{request._AppClearLogsRequest.AppName} logs files are empty");
                        }
                        else
                        {
                            foreach (string file in AppLogsFiles)
                            {
                                File.Delete(file);
                            }
                            return new App_ClearLogResponse($"All {request._AppClearLogsRequest.AppName} logs deleted");
                        }
                    }
                    else
                    {
                        int CompareFromTo = DateTime.Compare(request._AppClearLogsRequest.From, request._AppClearLogsRequest.To);
                        if (CompareFromTo > 0)
                        {
                            return new App_ClearLogResponse("From date must be earlier than to date");
                        }
                        if (AppLogsFiles.IsNullOrEmpty())
                        {
                            return new App_ClearLogResponse($"{request._AppClearLogsRequest.AppName} logs files are empty");
                        }
                        else
                        {
                            foreach (string file in AppLogsFiles)
                            {
                                int length = file.GetSearchableArabicText().Split("\\").Length;
                                string FileName = file.GetSearchableArabicText().Split("\\")[length - 1].Split(".")[0];
                                //string CreationText = file.GetDisplayName();
                                DateTime CreationDate = DateTime.Parse(FileName);
                                int compare1 = DateTime.Compare(CreationDate, request._AppClearLogsRequest.From);
                                int compare2 = DateTime.Compare(CreationDate, request._AppClearLogsRequest.To);
                                if (compare1 >= 0 && compare2 <= 0)
                                {
                                    File.Delete(file);
                                };
                            }
                        }

                        return new App_ClearLogResponse($"All {request._AppClearLogsRequest.AppName} logs from {request._AppClearLogsRequest.From} to {request._AppClearLogsRequest.To} deleted");
                    }

                }
                else
                {
                    string ProcessLogPath = request.GetAppLogPath($"{request._AppClearLogsRequest.ProcessID}");
                    string[] ProcessLogsFiles = Directory.GetFiles(ProcessLogPath);
                    if (request._AppClearLogsRequest.clearAll)
                    {
                        if (ProcessLogsFiles.IsNullOrEmpty())
                        {
                            return new App_ClearLogResponse($"Process ID :  {request._AppClearLogsRequest.ProcessID} logs files are empty");
                        }
                        else
                        {
                            foreach (string file in ProcessLogsFiles)
                            {
                                File.Delete(file);
                            }
                            return new App_ClearLogResponse($"All process id : {request._AppClearLogsRequest.ProcessID} logs deleted");
                        }
                    }
                    else
                    {
                        int CompareFromTo = DateTime.Compare(request._AppClearLogsRequest.From, request._AppClearLogsRequest.To);
                        if (CompareFromTo > 0)
                        {
                            return new App_ClearLogResponse("From date must be earlier than to date");
                        }
                        if (ProcessLogsFiles.IsNullOrEmpty())
                        {
                            return new App_ClearLogResponse($"Process ID : {request._AppClearLogsRequest.ProcessID} logs files are empty");
                        }
                        else
                        {
                            foreach (string file in ProcessLogsFiles)
                            {
                                int length = file.GetSearchableArabicText().Split("\\").Length;
                                string FileName = file.GetSearchableArabicText().Split("\\")[length - 1].Split(".")[0];
                                DateTime CreationDate = DateTime.Parse(FileName);
                                int compare1 = DateTime.Compare(CreationDate, request._AppClearLogsRequest.From);
                                int compare2 = DateTime.Compare(CreationDate, request._AppClearLogsRequest.To);
                                if (compare1 >= 0 && compare2 <= 0)
                                {
                                    File.Delete(file);
                                };
                            }
                        }

                        return new App_ClearLogResponse($"All process id : {request._AppClearLogsRequest.ProcessID} logs from {request._AppClearLogsRequest.From} to {request._AppClearLogsRequest.To} deleted");
                    }
                }
                
                      
            }
        }
        }
    }


