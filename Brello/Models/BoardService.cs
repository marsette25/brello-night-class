﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Brello.Models
{
    public class BoardService
    {
        private BoardContext context;
        public BoardService(BoardContext _context) {
            context = _context;
        }

        //we can do void, boolean, or list
        public bool AddList(Board _board, BrelloList _list)
        {
            return false;
        }

        public List<BrelloList> GetAllLists()
        {
            return null;
        }

        //this is an example of overloading a method
        public List<BrelloList> GetAllLists(Board _board)
        {
            return null;
        }
    }
}