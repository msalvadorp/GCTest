using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema3
{
    public class MoneyParts
    {
        decimal[] denominaciones = new decimal[] { 0.05M, 0.1M, 0.2M, 0.5M, 1M, 2M, 5, 10, 20, 50, 100, 200 };
        public List<List<decimal>> build(decimal monto)
        {
            List<List<decimal>> resultado = new List<List<decimal>>();
            List<decimal> listaEvaluar = denominaciones.ToList();

            foreach (decimal item in denominaciones.ToList().OrderByDescending(t => t).Where(t => t <= monto))
            {
                List<decimal> listaItem = new List<decimal>();
                listaItem = ProcesarDenominaciones(monto, item, listaEvaluar);
                if (listaItem.Count > 0)
                {
                    resultado.Add(listaItem);
                }

            }
            return resultado;

        }

        private List<decimal> ProcesarDenominaciones(decimal monto, decimal item, List<decimal> listaEvaluar)
        {
            decimal denomina = (from x in listaEvaluar where x < item orderby x descending select x).FirstOrDefault();
            decimal nuevoMonto = 0;
            List<decimal> resultado = new List<decimal>();

            

            int cantidad = (int)Math.Floor(monto / item);
            if (cantidad > 0)
            {
                for (int i = 1; i <= cantidad; i++)
                {
                    resultado.Add(item);

                }
                nuevoMonto = monto - (cantidad * item);
            }
            else
            {
                nuevoMonto = monto;
            }

            if (denomina != 0 && nuevoMonto > 0)
            {
                List<decimal> resultadoItem = ProcesarDenominaciones(nuevoMonto, denomina, listaEvaluar);
                resultado.AddRange(resultadoItem);
            }

            return resultado;
        }

    }
}
