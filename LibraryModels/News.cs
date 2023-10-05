using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LibraryModels
{
    [Table("tbNews")]
    public class News
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string? Author { get; set; }
        public DateTime PublishDate { get; set; }
        public List<Comment> Comments { get; set; }
        public string? Img { get; set; }
        [NotMapped]  // Đánh dấu không ánh xạ vào cơ sở dữ liệu
        public string CommentText { get; set; }
        public int Status { get; set; }

    }
}
 
