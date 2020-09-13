using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string numero)
        {
            double numeroDouble;
            double.TryParse(numero, out numeroDouble);
            this.numero = numeroDouble;
        }

        public double ValidarNumero(string numeroString)
        {
            double numeroDouble;
            if (double.TryParse(numeroString, out numeroDouble))
            {
                return numeroDouble;
            }
            else
            {
                return 0;
            }
        }

        public string SetNumero
        {
            set
            {
                if (ValidarNumero(value) != 0)
                {
                    this.numero = ValidarNumero(value);
                }
            }
        }

        public static double operator +(Numero numeroUno, Numero numeroDos)
        {
            double resultado = numeroUno.numero + numeroDos.numero;
            return resultado;
        }

        public static double operator -(Numero numeroUno, Numero numeroDos)
        {
            double resultado = numeroUno.numero - numeroDos.numero;
            return resultado;
        }

        public static double operator *(Numero numeroUno, Numero numeroDos)
        {
            double resultado = numeroUno.numero * numeroDos.numero;
            return resultado;
        }

        public static double operator /(Numero numeroUno, Numero numeroDos)
        {
            if (numeroUno.numero == 0)
            {
                return double.MinValue;
            }
            else
            {
                return numeroUno.numero / numeroDos.numero;
            }
        }
    }
}
