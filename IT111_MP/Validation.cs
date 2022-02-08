using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT111_MP
{
    class Validation
    {
        public bool GoodInput(string name)
        {
            if (name.All(char.IsWhiteSpace) == false)
            {
                return true;
            }
            return false;
        }

    }
}
