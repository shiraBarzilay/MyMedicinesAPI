using System;
using System.Collections.Generic;

namespace Repository.GeneratedModels;

public partial class UserMedicinesTbl
{
    public int UserMedicineId { get; set; }

    public int UserId { get; set; }

    public int? MedicineId { get; set; }

    public string? UserNewMedicineName { get; set; }

    public int? UserMedicineDayTaken { get; set; }

    public int? UserMedicineTimeTaken { get; set; }

    public DateOnly? UserMedicineStartDateTaken { get; set; }

    public DateOnly? UserMedicineEndDateTaken { get; set; }

    public virtual MedicinesTbl? Medicine { get; set; }

    public virtual UsersTbl User { get; set; } = null!;
}
