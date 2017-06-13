using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool respuesta = false;
            bool pedirNumero = false;
            int cantidad = 0;
            int numero = 0;
            List<int> listaNumero = new List<int>();
            do
            {
                
                Console.Clear();
                Console.WriteLine("Ingrese la cantidad de numeros de la secuencia");
                cantidad = int.Parse(Console.ReadLine());

                for (int i = 1; i <= cantidad; i++)
                {
                    Console.WriteLine("Ingrese un numero. {0} de {1}", i, cantidad);
                    string temporal = Console.ReadLine();
                    do
                    {

                        if (!int.TryParse(temporal, out numero))
                        {
                            Console.WriteLine("Debe ingresar un numero entero");
                        }
                        else
                        {
                            pedirNumero = false;
                        }

                    } while (pedirNumero);

                    listaNumero.Add(numero);
                }
                int[] arregloRespuesta = new ChangeRange().build(listaNumero.ToArray());

                Console.WriteLine("Los numeros ordenados son: " + string.Join(",", arregloRespuesta));
                
                Console.WriteLine();
                Console.Write("¿Desea ingresar otros numeros? (y/n)");
                respuesta = Console.ReadLine() == "y";

            } while (respuesta);


        }
    }
}
