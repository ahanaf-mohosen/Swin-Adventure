using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    public interface I_Have_Inventory
    {
        GameObject Locate(string id);
        //Inventory members are by default public abstract!
        String Name { get; }
    }
}
