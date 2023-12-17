using ExpenseReport.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseReport.DAL
{
    public class ExpenseReportService : IExpenseReportService
    {
        private readonly ExpenseReportDbContext context;
        public ExpenseReportService(ExpenseReportDbContext context)
        {
            this.context = context;
        }

        public void AddRecord(ExpenseReportMaster record)
        {
            context.ExpenseReportMasters.Add(record);
            context.SaveChanges();
        }

        public void DeleteRecord(int id)
        {
            ExpenseReportMaster record = GetRecordById(id);
            context.ExpenseReportMasters.Remove(record);
            context.SaveChanges();
        }

        public List<ExpenseReportMaster> GetAllRecords()
        {
            List<ExpenseReportMaster> expenseReportMaster = new List<ExpenseReportMaster>();
            expenseReportMaster = context.ExpenseReportMasters.ToList();
            return expenseReportMaster;
        }

        public ExpenseReportMaster GetRecordById(int id)
        {
            return context.ExpenseReportMasters.SingleOrDefault(r => r.Id == id)!;
        }

        public void UpdateRecord(ExpenseReportMaster record)
        {
            context.ExpenseReportMasters.Update(record);
            context.SaveChanges();
        }
    }
}
