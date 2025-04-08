using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Exception
{
    public class ConflictException : System.Exception
    {
        public ConflictException(string message) : base(message)
        {
        }

        public ConflictException(string name, object key) : base($"{name} with ID {key} already exists")
        {
        }
    }
}
