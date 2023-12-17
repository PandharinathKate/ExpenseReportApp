using System.ComponentModel.DataAnnotations;

namespace ExpenseReport.Models;

public partial class ExpenseReportMaster
{
    public int Id { get; set; }
        
    public string? Description { get; set; }

    [Required(ErrorMessage = "Please enter Amount")]
    public decimal Amount { get; set; }

    [Required(ErrorMessage = "Please select Type")]
    public string Type { get; set; } = null!;

    public DateTime Date { get; set; }

    public int? Userid { get; set; }

    public virtual UserData? User { get; set; }
}
