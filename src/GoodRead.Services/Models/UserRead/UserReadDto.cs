﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodRead.Services.Models.Book;

namespace GoodRead.Services.Models.UserRead
{
    public class UserReadDto
    {
        public int Id { get; set; }
        public BookDto BookDto { get; set; }
    }
}
