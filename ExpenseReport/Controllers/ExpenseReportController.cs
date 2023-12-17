using ExpenseReport.DAL;
using ExpenseReport.Models;
using ExpenseReport.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;

namespace ExpenseReport.Controllers
{
    public class ExpenseReportController : Controller
    {
        private readonly IExpenseReportService service;

        public ExpenseReportController(IExpenseReportService service)
        {
            this.service = service;
        }
        public IActionResult GetAllRecords(string type, DateTime date)
        {
            ExpenseReportViewModel expenseReportViewModel = new ExpenseReportViewModel();
            if (type == null && date.Year == 1)
            {
                expenseReportViewModel.reportMasters = service.GetAllRecords();
            }
            else if(type != null && date.Year == 1)
            {
                expenseReportViewModel.reportMasters = service.GetAllRecords().Where(t => t.Type == type).ToList();
            }
            else if (type == null && date.Year != 1)
            {
                expenseReportViewModel.reportMasters = service.GetAllRecords().Where(t => t.Date == date).ToList();
            }
            else
            {
                expenseReportViewModel.reportMasters = service.GetAllRecords().Where(t => t.Date == date && t.Type == type).ToList();
            }
            return View(expenseReportViewModel);
        }

        [HttpGet]
        public IActionResult AddRecord()
        {
            ExpenseReportMaster expenseReportMaster = new ExpenseReportMaster();
            expenseReportMaster.Date = DateTime.Now;
            return View(expenseReportMaster);
        }
        [HttpPost]
        public IActionResult AddRecord(ExpenseReportMaster expenseReport)
        {
            if (ModelState.IsValid)
            {
                service.AddRecord(expenseReport);
                return RedirectToAction("GetAllRecords");
            }
            else
            {
                return View(expenseReport);
            }
            
        }

        public IActionResult DeleteRecord(int id)
        {
            service.DeleteRecord(id);
            return RedirectToAction("GetAllRecords");
        }

        [HttpGet]
        public IActionResult UpdateRecord(int id)
        {
            return View(service.GetRecordById(id));
        }
        [HttpPost]
        public IActionResult UpdateRecord(ExpenseReportMaster expenseReport)
        {
            if(ModelState.IsValid)
            {
                service.UpdateRecord(expenseReport);
                return RedirectToAction("GetAllRecords");
            }
            else
            {
                return View(expenseReport);
            }
            
        }

        public IActionResult GetRecordsByType(ExpenseReportMaster expenseReport)
        {
            return RedirectToAction("GetAllRecords", new { type = expenseReport.Type, date = expenseReport.Date});
        }
    }
}
