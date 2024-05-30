using HashFunctions1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashFunctions1
{
    public class Nodo
    {
        public Atleta Atleta { get; set; }
        public Nodo Siguiente { get; set; }

        public Nodo(Atleta atleta)
        {
            Atleta = atleta;
            Siguiente = null;
        }
    }
}

