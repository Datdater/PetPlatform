using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Exception
{
    public class NotFoundException : System.Exception
    {
        public NotFoundException(string name, object key) : base($"{name} with ID {key} was not found")
        {

        }
    }
}
