using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Brello.Models
{

    public interface ICar //an interface is a list of method signatures with no implementation. can't use new keyword
    {
        string Honk();
    }
    public class Car
    {
        //in order for Mock to change behavior, Method must be virtual
        public virtual string Horn()
        {
            ReadyEngines();
            return "HONK!";
        }

        //Even when counting method calls, methods should be virtual - just makes it overwrittable
        public virtual void ReadyEngines() { }


    }
}