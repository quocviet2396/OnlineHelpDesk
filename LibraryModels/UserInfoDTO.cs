using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryModels
{
    public class UserInfoDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Code { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool Status { get; set; }
        public string Role { get; set; }

        public bool? Gender { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? DateOfBirth { get; set; }
        public string? Photo { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
    }
}

