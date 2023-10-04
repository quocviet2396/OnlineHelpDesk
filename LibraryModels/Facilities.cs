using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LibraryModels
{
    [Table("tbFacilities")]
    public class Facilities
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Mối quan hệ một-nhiều với Ticket (Yêu cầu hỗ trợ)
        public ICollection<Ticket> Ticket { get; set; }

        // Mối quan hệ một-nhiều với Discussion
        public ICollection<Discussion> Discussion { get; set; }

        public int? SupporterId { get; set; }
        [JsonIgnore]
        public Users? Supporter { get; set; }
    }
}
