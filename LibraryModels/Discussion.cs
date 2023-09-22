using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModels
{
    [Table("tbDiscussion")]
    public class Discussion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Topic { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Quan hệ một-nhiều với Users
        public int UsersId { get; set; }
        public Users Users { get; set; }

        // Mối quan hệ một-nhiều với Ticket (Yêu cầu hỗ trợ)
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }

        // Mối quan hệ một-nhiều với Facilities
        public int FacilitiesId { get; set; }
        public Facilities Facilities { get; set; }
    }
}
