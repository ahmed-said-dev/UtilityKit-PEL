using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UtilityKit.Components.Pel.Application.Contracts.Data.Crt_ATL.Requests;
using UtilityKit.Components.Pel.Application.Contracts.Data.Crt_ATL.Responses;

namespace UtilityKit.Components.Pel.Application.Commands.Cmd_ATL
{
    public class ClearLogsCommand : IRequest<ATL_ClearLogResponse>
    {
        static readonly string path = Directory.GetCurrentDirectory();
        static readonly DirectoryInfo di = new DirectoryInfo(path);
        string[] ATLDirectories = Directory.GetDirectories(di.Parent.FullName + "\\UtilityKit.Components.Pel.Infrastrcuture\\ApplicationsLogs\\ATL");
        public ATLAppClearLogsRequest _ATLAppClearLogsRequest { get; set; }
        public class Handler : IRequestHandler<ClearLogsCommand, ATL_ClearLogResponse>
        {
            public async Task<ATL_ClearLogResponse> Handle(ClearLogsCommand request, CancellationToken cancellationToken)
            {
                if (request._ATLAppClearLogsRequest.clearAll)
                {
                    if (request.ATLDirectories.IsNullOrEmpty())
                    {
                        return new ATL_ClearLogResponse("ATLDirectories logs are empty");
                    }
                    else
                    {
                        foreach (string directory in request.ATLDirectories)
                        {
                            Directory.Delete(directory, true);
                        }
                        return new ATL_ClearLogResponse("All ATL logs deleted");
                    }
                }
                else
                {
                    int CompareFromTo = DateTime.Compare(request._ATLAppClearLogsRequest.From, request._ATLAppClearLogsRequest.To);
                    if (CompareFromTo > 0)
                    {
                        return new ATL_ClearLogResponse("From date must be earlier than to date");
                    }
                    //return Directory.GetCreationTime(ATLDirectories[1]);
                    //int length = ATLDirectories[1].GetSearchableArabicText().Split("\\").Length;
                    //string CreationText = ATLDirectories[1].GetSearchableArabicText().Split("\\")[length - 1];
                    //DateTime CreationDate = DateTime.Parse(CreationText);
                    //int compare1 = DateTime.Compare(CreationDate, from);
                    //int compare2 = DateTime.Compare(CreationDate, to);
                    if (request.ATLDirectories.IsNullOrEmpty())
                    {
                        return new ATL_ClearLogResponse("ATLDirectories logs are empty");
                    }
                    else
                    {
                        foreach (string directory in request.ATLDirectories)
                        {
                            int length = directory.GetSearchableArabicText().Split("\\").Length;
                            string CreationText = directory.GetSearchableArabicText().Split("\\")[length - 1];
                            DateTime CreationDate = DateTime.Parse(CreationText);
                            int compare1 = DateTime.Compare(CreationDate, request._ATLAppClearLogsRequest.From);
                            int compare2 = DateTime.Compare(CreationDate, request._ATLAppClearLogsRequest.To);
                            if (compare1 >= 0 && compare2 <= 0)
                            {
                                Directory.Delete(directory, true);
                            };
                        }
                    }

                    return new ATL_ClearLogResponse($"All ATL logs from {request._ATLAppClearLogsRequest.From} to {request._ATLAppClearLogsRequest.To} deleted");
                }

            }
        }
        //static readonly string rootFolder = @"../../../";
        //static readonly string path = Directory.GetCurrentDirectory();
        //static readonly DirectoryInfo di = new DirectoryInfo(path);
        //string[] ATLDirectories = Directory.GetDirectories(di.Parent.FullName + "\\UtilityKit.Components.Pel.Domain.BusinessModel\\Applications\\ATL");
        public string clearAll()
        {
            //string path = Directory.GetCurrentDirectory();
            //DirectoryInfo di = new DirectoryInfo(path);

            //string[] ATLDirectories = Directory.GetDirectories(di.Parent.FullName + "\\UtilityKit.Components.Pel.Domain.BusinessModel\\Applications\\ATL");
            if (ATLDirectories.IsNullOrEmpty())
            {
                return "ATLDirectories logs are empty";
            }
            else
            {
                foreach (string directory in ATLDirectories)
                {
                    Directory.Delete(directory, true);
                }
            }
            return "All ATL logs deleted";
        }
        public string clearFromTo(DateTime from, DateTime to)
        {
            int CompareFromTo = DateTime.Compare(from, to);
            if (CompareFromTo > 0)
            {
                return "From date must be earlier than to date";
            }
            //return Directory.GetCreationTime(ATLDirectories[1]);
            //int length = ATLDirectories[1].GetSearchableArabicText().Split("\\").Length;
            //string CreationText = ATLDirectories[1].GetSearchableArabicText().Split("\\")[length - 1];
            //DateTime CreationDate = DateTime.Parse(CreationText);
            //int compare1 = DateTime.Compare(CreationDate, from);
            //int compare2 = DateTime.Compare(CreationDate, to);
            if (ATLDirectories.IsNullOrEmpty())
            {
                return "ATLDirectories logs are empty";
            }
            else
            {
                foreach (string directory in ATLDirectories)
                {
                    int length = directory.GetSearchableArabicText().Split("\\").Length;
                    string CreationText = directory.GetSearchableArabicText().Split("\\")[length - 1];
                    DateTime CreationDate = DateTime.Parse(CreationText);
                    int compare1 = DateTime.Compare(CreationDate, from);
                    int compare2 = DateTime.Compare(CreationDate, to);
                    if (compare1 >= 0 && compare2 <= 0)
                    {
                        Directory.Delete(directory, true);
                    };
                }
            }

            return $"All ATL logs from {from} to {to} deleted";
        }
        //}
        //console.log(rootFolder);
        //string[] files = Directory.GetFiles(rootFolder);    
        //foreach (string file in files)    
        //{    
        //File.Delete(file);    
        //Console.WriteLine($"{file} is deleted.");    
    }
}


