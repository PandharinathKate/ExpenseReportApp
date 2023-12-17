using System;
using System.Collections.Generic;

namespace ExpenseReport.Models;

public partial class UserData
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<ExpenseReportMaster> ExpenseReportMasters { get; } = new List<ExpenseReportMaster>();
}
