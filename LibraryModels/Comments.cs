using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModels
{

        [Table("tbComments")]
        public class Comments
        {
            public int Id { get; set; }
            public string Text { get; set; }
            public DateTime CommentDate { get; set; }
            public string UserId { get; set; }
            public News News { get; set; }
            public int NewId { get; set; }
        }
    }

