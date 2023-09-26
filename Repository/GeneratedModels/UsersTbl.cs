using System;
using System.Collections.Generic;

namespace Repository.GeneratedModels;

public partial class UsersTbl
{
    public int UserId { get; set; }

    public string UserPassword { get; set; } = null!;

    public string UserEmail { get; set; } = null!;

    public string? UserAddress { get; set; }

    public string UserFirstName { get; set; } = null!;

    public string UserLastName { get; set; } = null!;

    public DateOnly? UserBirthDate { get; set; }

    public string? UserCity { get; set; }

    public virtual ICollection<UserMedicinesTbl> UserMedicinesTbls { get; } = new List<UserMedicinesTbl>();
}
