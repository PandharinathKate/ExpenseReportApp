using ExpenseReport.Models;
using ExpenseReportAPI.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace ExpenseReportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseReportMasterController : ControllerBase
    {
        private readonly IExpenseReportMasterService _service;

        public ExpenseReportMasterController(IExpenseReportMasterService expenseReportMasterService)
        {
            this._service = expenseReportMasterService;
        }

        [HttpGet]
        public IActionResult GetAllRecords()
        {            
            return Ok(_service.GetAllRecords());
        }
    }
}
