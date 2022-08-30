using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodRead.Services.Models.UserRead
{
    public class UserReadDto
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public BookDto BookDto { get; set; }
        public byte Status { get; set; }
    }
}
