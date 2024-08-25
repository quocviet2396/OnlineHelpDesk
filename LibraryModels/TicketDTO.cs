using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryModels
{
    [Table("tbTicketDTO")]
    public class TicketDTO
    {

        public string? Decription { get; set; }

        public string? EmailCreator { get; set; }

        public string? EmailSupporter { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? PhotoPerson { get; set; }

        public int? TicketId { get; set; }

        public string? TicketStatus { get; set; }

        public string? Title { get; set; }

        public string? UserNameCreator { get; set; }

        public string? UserNameSupporter { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool? Areaded { get; set; } = false;

        public bool? Ureaded { get; set; } = false;

        public bool? Sreaded { get; set; } = false;

        public TicketDTO()
        {
        }
    }
}

