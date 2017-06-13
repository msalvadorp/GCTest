using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema2
{
    public class ChangeRange
    {
        public int[] build(int[] parametro)
        {
            List<int> origen = parametro.ToList();
            List<int> resultado = new List<int>();
            int maximo = origen.Max();
            for (int i = 1; i <= maximo; i++)
            {
                resultado.Add(i);
            }

            return resultado.ToArray();
        
        }
    }
}
