﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Brello.Models
{
    public class Card
    {
        public int CardId { get; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Color BorderColor { get; set; }
        // Assigned To
        public virtual ICollection<ApplicationUser> Assignees { get; set; }
        // Vote mechanism
        public virtual ICollection<Vote> Votes { get; set; }
         
    }
}