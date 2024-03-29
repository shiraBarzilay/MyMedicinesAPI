﻿using System;
using System.Collections.Generic;

namespace Repository.GeneratedModels;

public partial class MedicinesTbl
{
    public int MedicineId { get; set; }

    public string? MedicineNameHebrew { get; set; }

    public string? MedicineNameEnglish { get; set; }

    public string? MedicineUrlImage { get; set; }

    public virtual ICollection<UserMedicinesTbl> UserMedicinesTbls { get; } = new List<UserMedicinesTbl>();
}
