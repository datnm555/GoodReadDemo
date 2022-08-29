using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodRead.Services.Models.UserRead
{
    public class UserReadCompleteDto
    {
        public int UserId { get; set; }

        public List<UserReadDto> UserReadDto { get; set; }
    }
}
