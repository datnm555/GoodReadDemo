using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodRead.Services.Models.Book
{
    public class UpdateBookStatusRequestDto
    {
        
        /// <summary>
        /// 0: not read yet; 1: reading ; 2 :completed
        /// </summary>
        public byte Status { get; set; }
    }
}