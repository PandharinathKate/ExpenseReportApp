using ExpenseReport.Models;
using ExpenseReportAPI.Repositories.IRepositories;
using ExpenseReportAPI.Services.IServices;

namespace ExpenseReportAPI.Services
{
    public class ExpenseReportMasterService: IExpenseReportMasterService
    {
        private readonly IExpenseReportMasterRepository _repository;
        public ExpenseReportMasterService(IExpenseReportMasterRepository expenseReportMasterRepository)
        {
            this._repository = expenseReportMasterRepository;
        }
        public List<ExpenseReportMaster> GetAllRecords()
        {
            return _repository.GetAllRecords();
        }
    }
}
