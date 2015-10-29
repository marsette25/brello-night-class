using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Brello.Models
{
    public class BoardContext : DbContext
    {
        //uses the connection string from the Web.confirg named "BoardContext"
        //public BoardContext() : base("nameBoardContext") { }

        //these properties make the connection between the classes and the tables of
        //those models
        public virtual IDbSet<Color> Colors { get; set; }
        public virtual IDbSet<Card> Cards { get; set; }
    }
}