using ExpenseReport.Models;

namespace ExpenseReport.ViewModels
{
    public class ExpenseReportViewModel
    {
        public List<ExpenseReportMaster> reportMasters { get; set; }
        public decimal? TotalExpense { 
            get
            {
                var expense = reportMasters.Where(e => e.Type == "EXP").ToList();
                decimal? expAmt = 0;
                foreach (var e in expense)
                {
                    expAmt += e.Amount;
                }
                return expAmt;
            }
        }
        public decimal? TotalIncome { 
            get
            {
                var expense = reportMasters.Where(e => e.Type == "INC").ToList();
                decimal? expAmt = 0;
                foreach (var e in expense)
                {
                    expAmt += e.Amount;
                }
                return expAmt;
            }
             
        }
        public decimal? Balance {
            get
            {
                return TotalIncome - TotalExpense;
            }
        
        }
        public string? Type { get; set; }
        public DateTime? Date { get; set; }

    }
}
