using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryModels
{
    [Table("tbNotification")]
    public class Notifications
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? url { get; set; }

        public bool? readed { get; set; } = false;

        public bool? status { get; set; } = false;

        public UserConn? userConn { get; set; }

        public int? userConnId { get; set; }
    }
}

