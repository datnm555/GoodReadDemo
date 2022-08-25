using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodRead.Services.Models.Book
{
    public class UpdateBookStatusRequestDto
    {
        public int UserId { get; set; }

        public int BookId { get; set; }

        public  bool Status { get; set; }
    }
}
