using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryModels
{
    [Table("tbUsers")]
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? UserName { get; set; }

        public string Email { get; set; }
        public string? EmailToConfirm { get; set; }

        public string? Code { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool Status { get; set; }
        public string Role { get; set; }




        // Quan hệ một-nhiều với Discussion
        public ICollection<Discussion>? Discussions { get; set; }

        public ICollection<Ticket>? Tickets { get; set; }

        public UserInfo? userInfo { get; set; }
        public UserConn? userConn { get; set; }

    }
}