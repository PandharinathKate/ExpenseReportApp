using ExpenseReport.Models;

namespace ExpenseReportAPI.Services.IServices
{
    public interface IExpenseReportMasterService
    {
        public List<ExpenseReportMaster> GetAllRecords();
    }
}
