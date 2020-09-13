using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        /// <summary>
        /// Constructor sin parametros, el numero se asigna a 0
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Constructor que asigna el valor al numero
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            SetNumero = numero.ToString();
        }

        /// <summary>
        /// Constructor que asigna el valor al numero
        /// </summary>
        /// <param name="numero"></param>
        public Numero(string numero)
        {
            SetNumero = numero;
        }

        /// <summary>
        /// Comprobará que el valor recibido sea numérico.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>Retorna el numero en formato double. Sino es valido, retornará 0.</returns>
        public double ValidarNumero(string numero)
        {
            double numeroDouble;
            if (double.TryParse(numero, out numeroDouble))
            {
                return numeroDouble;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Asignará un valor al atributo número, previa validación.
        /// </summary>
        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        /// <summary>
        /// Sobrecarga del operador + para poder operar con Objetos numero
        /// </summary>
        /// <param name="numeroUno">El primer numero de la operacion</param>
        /// <param name="numeroDos">El segundo numero de la operacion</param>
        /// <returns>Retorna la suma</returns>
        public static double operator +(Numero numeroUno, Numero numeroDos)
        {
            double resultado = numeroUno.numero + numeroDos.numero;
            return resultado;
        }

        /// <summary>
        /// Sobrecarga del operador - para poder operar con Objetos numero
        /// </summary>
        /// <param name="numeroUno"></param>
        /// <param name="numeroDos"></param>
        /// <returns>Retorna la resta</returns>
        public static double operator -(Numero numeroUno, Numero numeroDos)
        {
            double resultado = numeroUno.numero - numeroDos.numero;
            return resultado;
        }

        /// <summary>
        /// Sobrecarga del operador * para poder operar con Objetos numero
        /// </summary>
        /// <param name="numeroUno">El primer numero de la operacion</param>
        /// <param name="numeroDos">El segundo numero de la operacion</param>
        /// <returns>Retorna la suma</returns>
        public static double operator *(Numero numeroUno, Numero numeroDos)
        {
            double resultado = numeroUno.numero * numeroDos.numero;
            return resultado;
        }

        /// <summary>
        /// Sobrecarga del operador / para poder operar con Objetos numero
        /// </summary>
        /// <param name="numeroUno">El primer numero de la operacion</param>
        /// <param name="numeroDos">El segundo numero de la operacion</param>
        /// <returns>Retorna la division si el primer numero es distinto de 0, caso contrario retorna el valor minimo del tipo double</returns>
        public static double operator /(Numero numeroUno, Numero numeroDos)
        {
            if (numeroUno.numero != 0)
            {
                return numeroUno.numero / numeroDos.numero;
            }
            else
            {
                return double.MinValue;
            }
        }

        /// <summary>
        /// Validacion de que el numero recibido contenga solo 1 y 0
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        private static bool EsBinario(string binario)
        {
            Regex rgx = new Regex("^[0-1]*");
            if (rgx.IsMatch(binario))
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// Metodo que recibe un numero decimal y lo convierte a binario
        /// </summary>
        /// <param name="input"></param>
        /// <returns>El numero binario en formato string</returns>
        public static string DecimalBinario(double numero)
        {
            string binario = "";
            do
            {
                if ((numero % 2) == 0)
                    binario = "0" + binario;
                else
                    binario = "1" + binario;
                numero = (int)(numero / 2);
            } while (numero > 0);

            return binario;
        }

        /// <summary>
        /// Metodo que recibe un numero decimal string lo parsea a double y lo retorna en formato string llamando al mismo metodo con otro parametro 
        /// </summary>
        /// <param name="numero">El numero a convertir</param>
        /// <returns>Retorna el numero B</returns>
        public static string DecimalBinario(string numero)
        {
            double convertido;
            if (Double.TryParse(numero, out convertido))
            {
                return DecimalBinario(Math.Truncate(convertido));
            }
            else
            {
                return "Valor Invalido";
            }
        }

        /// <summary>
        /// Metodo que recibe un numero binaro y lo convierte a decimal
        /// </summary>
        /// <param name="numero">El numero a convertir</param>
        /// <returns>Retorna el numero convertido o en su defecto "Valor Invalido"</returns>
        public static string BinarioDecimal(string numero)
        {
            if (EsBinario(numero))
            {
                string convertido = Convert.ToInt64(numero, 2).ToString();
                return convertido;
            }
            else
            {
                return "Valor Invalido";
            }

        }
    }
}