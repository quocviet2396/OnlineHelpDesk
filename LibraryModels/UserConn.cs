using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryModels
{
    [Table("tbUserConn")]
    public class UserConn
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? ConnectionId { get; set; }

        public bool Connected { get; set; } = false;

        public int? UserId { get; set; }

        public Users? Users { get; set; }

        public int? NotiId { get; set; }

        public Notifications? Notifications { get; set; }

    }
}

