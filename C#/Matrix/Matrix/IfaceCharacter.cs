using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    interface IfaceCharacter
    {
        void print();
        void prompt();
        void generate(Character[,] matrix);
    
    }
}
