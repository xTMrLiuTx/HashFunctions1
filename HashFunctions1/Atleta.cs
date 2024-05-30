using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashFunctions1
{
    public class Atleta
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Categoria { get; set; }

        public override string ToString()
        {
            return $"{Nombre},{Apellido},{Edad},{Sexo},{FechaNacimiento.ToString("dd/MM/yyyy")},{Categoria}";
        }

        public static Atleta FromString(string data)
        {
            var parts = data.Split(',');
            return new Atleta
            {
                Nombre = parts[0],
                Apellido = parts[1],
                Edad = int.Parse(parts[2]),
                Sexo = parts[3],
                FechaNacimiento = DateTime.Parse(parts[4]),
                Categoria = parts[5]
            };
        }
    }
}
