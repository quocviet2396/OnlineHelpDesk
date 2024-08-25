using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModels
{
    [Table("tbTicket")]
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? Attachment { get; set; }



        // Mối quan hệ một-nhiều với TicketStatus (Trạng thái yêu cầu)
        public int? TicketStatusId { get; set; }
        public TicketStatus? TicketStatus { get; set; }

        // Mối quan hệ nhiều-một với Category 
        public int? CategoryId { get; set; }
        public Facilities? Category { get; set; }

        // Mối quan hệ một-nhiều với Users (Người nhận yêu cầu - Employee)
        public int? CreatorId { get; set; }
        public Users? Creator { get; set; }

        // Mối quan hệ một-nhiều với Users (Người hỗ trợ yêu cầu - Supporter)
        public int? SupporterId { get; set; }
        public Users? Supporter { get; set; }
        public string? feedback { get; set; }
        public int? PriorityId { get; set; }
        public Priority? Priority { get; set; }
    }
}
