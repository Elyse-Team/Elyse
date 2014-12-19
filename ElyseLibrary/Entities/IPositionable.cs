using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElyseLibrary
{
    public interface IPositionable
    {
        int X { get; set; }
        int Y { get; set; }
        string Name { get; set; }
        bool Material { get; set; }
    }
}
