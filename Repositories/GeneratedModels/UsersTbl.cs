using System;
using System.Collections.Generic;
using System.Collections;

namespace Repositories.GeneratedModels
{
    public partial class UsersTbl
    {
        public int UserId { get; set; }
        public int? UserPassword { get; set; }
        public string? UserFirstName { get; set; }
        public string? UserLastName { get; set; }
        public string? UserEmail { get; set; }
        public DateOnly? UserBirthDate { get; set; }
        public string? UserAddress { get; set; }
        public string? UserUniqueId { get; set; }
        public DateOnly? CreateDate { get; set; }
        public DateOnly? UpdateDate { get; set; }
        public BitArray? IsActive { get; set; }
    }
}
