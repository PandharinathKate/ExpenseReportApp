using ExpenseReport.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseReportAPI.Repositories.IRepositories
{
    public interface IExpenseReportMasterRepository
    {
        public List<ExpenseReportMaster> GetAllRecords();
    }
}
