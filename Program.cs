using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorCat
{
    public class Program
    {
        static Cat cat = new Cat();
        static void Main(string[] args)
        {
            cat.birth();
            cat.live();
        }
    }
}
