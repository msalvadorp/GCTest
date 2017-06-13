using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema1
{
    public class ChangeString
    {
        string[] caracteres = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "ñ", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };


        public string build(string palabra)
        {
            List<string> caracteresLista = caracteres.ToList();
            StringBuilder sb = new StringBuilder();
            palabra = palabra.ToLower();
            foreach (char item in palabra)
            {

                if ((from x in caracteresLista
                     where x == item.ToString()
                     select x).Count() == 0)
                {
                    sb.Append(item);
                }
                else if (item == 'z')
                {
                    sb.Append('a');
                }
                else
                {
                    string cadenanueva = (from x in caracteresLista
                                          where (int)x.ToCharArray()[0] > (int)item
                                          orderby x
                                          select x).FirstOrDefault();

                    sb.Append(cadenanueva);
                }
            }


            return sb.ToString();

        }
    }
}
