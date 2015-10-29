using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Brello.Models
{
    public class BoardService
    {
        private BoardContext context; // so it can be available for any other methods
        public BoardService(DbContext _context)
        {
            var context = _context;
        }
    }
}