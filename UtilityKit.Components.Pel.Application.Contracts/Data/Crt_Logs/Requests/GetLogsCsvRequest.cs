using LINQtoCSV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityKit.Components.Pel.Application.Contracts.Data.Crt_Logs.Requests
{
    [Serializable]
    public class GetLogsCsvRequest
    {
        [CsvColumn(Name = "ApplicationName", FieldIndex = 1)]
        public string AppName { get; set; }
        [CsvColumn(Name = "title", FieldIndex = 2)]
        public string Title { get; set; }
        [CsvColumn(Name = "details", FieldIndex = 3)]
        public string Details { get; set; }
        [CsvColumn(Name = "severity", FieldIndex = 4)]
        public string Severity { get; set; }
        [CsvColumn(Name = "user", FieldIndex = 5)]
        public string User { get; set; }
    }
}
