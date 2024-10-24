using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubricaContatti
{
    public class Contatto
    {
        public string Nominativo;
        public string Telefono;

        public Contatto(string nominativo, string telefono)
        {
            Nominativo = nominativo;
            Telefono = telefono;
        }

        public override string ToString()
        {
            return $"{Nominativo} - {Telefono}";
        }
    }
}
