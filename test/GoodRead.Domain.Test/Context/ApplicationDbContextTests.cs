using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodRead.Domain.Context;
using NUnit.Framework;

namespace GoodRead.Domain.Test.Context
{
    [TestFixture]
    public class ApplicationDbContextTests
    {
        private readonly ApplicationDbContext _context;

        public ApplicationDbContextTests(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
