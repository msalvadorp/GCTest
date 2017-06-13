using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool respuesta = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Ingrese el caracter");
                string origen = Console.ReadLine();
                ChangeString operador = new ChangeString();
                string destino = operador.build(origen);
                Console.WriteLine("El resultado es: " + destino);
                Console.WriteLine();
                Console.Write("¿Desea ingresar otro caracter? (y/n)");
                respuesta = Console.ReadLine() == "y";
                
            } while (respuesta);


        }
    }
}
