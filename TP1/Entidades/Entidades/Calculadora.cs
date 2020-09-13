using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Entidades
{
    public class Calculadora
    {
        private static string ValidarOperador(string operador)
        {
            Regex simbolosValidos = new Regex(@"[/*+-]");
            if (simbolosValidos.IsMatch(operador))
            {
                return operador;
            }
            else
            {
                return "+";
            }
        }

        public static double Operar(Numero numeroUno, Numero numeroDos, string operador)
        {
            double resultado = default;

            switch (ValidarOperador(operador))
            {
                case "+":
                    resultado = numeroUno + numeroDos;
                    break;

                case "-":
                    resultado = numeroUno - numeroDos;
                    break;

                case "*":
                    resultado = numeroUno * numeroDos;
                    break;

                case "/":
                    resultado = numeroUno / numeroDos;
                    break;
            }
            return resultado;
        }
    }
}
