using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class Stato
    {
        public Stato Prestito { get; internal set; }
        public Stato? Disponibile { get; internal set; }
    }
}
