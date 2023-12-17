using ExpenseReport.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseReport.DAL
{
    public interface IExpenseReportService
    {
        public List<ExpenseReportMaster> GetAllRecords();
        public ExpenseReportMaster GetRecordById(int id);
        public void AddRecord(ExpenseReportMaster record);
        public void DeleteRecord(int id);
        public void UpdateRecord(ExpenseReportMaster record);
    }
}
