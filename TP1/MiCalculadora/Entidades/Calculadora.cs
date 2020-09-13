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
        /// <summary>
        /// Valida el operador de la calculadora
        /// </summary>
        /// <param name="operador">El operador</param>
        /// <returns>Retorna un string que es el operador valido o "+" sino lo es</returns>
        private static string ValidarOperador(char operador)
        {
            if (operador == '+' || operador == '-' || operador == '*' || operador == '/')
                return operador.ToString();
            else
                return "+";
        }

        /// <summary>
        /// Es el metodo encargado de realizar la operacion con los valores numericos
        /// </summary>
        /// <param name="numeroUno">Primer numero del calculo</param>
        /// <param name="numeroDos">Segundo numero del calculo</param>
        /// <param name="operador">El operador del calculo a realizar</param>
        /// <returns></returns>
        public static double Operar(Numero numeroUno, Numero numeroDos, string operador)
        {
            double resultado = default;
            char.TryParse(operador, out char operar);

            switch (ValidarOperador(operar))
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
