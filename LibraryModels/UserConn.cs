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

        public int? UserId { get; set; }

        public Users? Users { get; set; }

    }
}

