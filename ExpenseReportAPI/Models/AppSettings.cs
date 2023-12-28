using System.Data.Common;

namespace ExpenseReportAPI.Models
{
    public class AppSettings:IAppSettings
    {
        public string DBConnection { get; set; }
    }
}
