using ExpenseReport.Models;
using ExpenseReportAPI.Models;
using ExpenseReportAPI.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace ExpenseReportAPI.Repositories
{
    public class ExpenseReportMasterRepository : IExpenseReportMasterRepository
    {
        IAppSettings appSettings;

        public ExpenseReportMasterRepository(IAppSettings appSettings)
        {
            this.appSettings = appSettings;
        }
        public List<ExpenseReportMaster> GetAllRecords()
        {
            List<ExpenseReportMaster> expenseReportMasterList = new List<ExpenseReportMaster>();
            using(IDbConnection connection = GetConnection(appSettings.DBConnection)){
                connection.Open();
                var result = connection.QueryMultiple("select * from expensereportmaster");
                expenseReportMasterList = result.Read<ExpenseReportMaster>().ToList();
            }
            return expenseReportMasterList;
        }

        private IDbConnection GetConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
    }
}
