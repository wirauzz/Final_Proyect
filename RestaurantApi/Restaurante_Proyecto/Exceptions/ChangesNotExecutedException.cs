using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurante_Proyecto.Exceptions
{
    public class ChangesNotExecutedException : Exception
    {
        public ChangesNotExecutedException(string message): base(message)
        {

        }
    }
}
