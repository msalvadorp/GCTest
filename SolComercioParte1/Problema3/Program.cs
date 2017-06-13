using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool respuesta = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Ingrese el numero a validar");
                decimal monto = decimal.Parse(Console.ReadLine());
                List<List<decimal>> resultado = new MoneyParts().build(monto);
                Console.WriteLine("El resultado es: ");
                foreach (List<decimal> item in resultado)
                {
                    Console.WriteLine("- " + string.Join(", ", item));
                }
                
                Console.WriteLine();
                Console.Write("¿Desea ingresar otro caracter? (y/n)");
                respuesta = Console.ReadLine() == "y";

            } while (respuesta);


        }
    }
}
