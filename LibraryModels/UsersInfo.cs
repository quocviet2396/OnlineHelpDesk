using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModels
{
    public class UsersInfo
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Photo { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }


        public int UsersId { get; set; }
        public Users Users { get; set; }

    }
}
