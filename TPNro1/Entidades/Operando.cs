using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        private string Numero
        {
            set { numero = ValidarOperando(value); }
        }

        public Operando()
        {
            numero = 0;
        }

        public Operando(double numero)
        {
            this.numero = numero;
        }

        public Operando(string strNumero)
        {
            Numero = strNumero;
        }

        /// <summary>
        /// Perimite validar que el operando ingresado sea un numero
        /// </summary>
        /// <param name="strNumero">el numero a validar en formato string</param>
        /// <returns>el numero validado en formato double ó 0 si no pudo validar</returns>
        private double ValidarOperando(string strNumero)
        {
            if (strNumero.Contains('.'))
            {
                strNumero = strNumero.Replace('.', ',');
            }
            double auxNumero;
            if (double.TryParse(strNumero, out auxNumero))
            {
                return auxNumero;
            }

            return 0;
        }

        /// <summary>
        /// Permite comprobar si el string recibido esta compuesto por 0 y 1
        /// </summary>
        /// <param name="binario">Cadena de caracteres a validar</param>
        /// <returns>true si la cadena es binaria, caso contrario false</returns>
        private bool EsBinario(string binario)
        {
            foreach (char caracter in binario)
            {
                if (caracter != 48 && caracter != 49)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Permite convertir el numero binario en decimal
        /// </summary>
        /// <param name="binario">la cadena que contiene el numero a convertir</param>
        /// <returns>el numero convertido a decimal, o si no pudo "Valor Invalido"</returns>
        public string BinarioDecimal(string binario)
        {
            string numeroDecimal = "Valor Inválido";

            if (EsBinario(binario))
            {
                double[] aux = new double[binario.Length];
                int largo = binario.Length -1;
                int i = 0;
                int auxDecimal = 0;

                do
                {
                    double aux2 = int.Parse(binario[i].ToString()) * Math.Pow(2, largo);
                    aux[i] = aux2;
                    largo--;
                    i++;

                } while (largo >= 0);

                foreach (int item in aux)
                {
                    auxDecimal += item;
                }

                numeroDecimal = auxDecimal.ToString();
            }

            return numeroDecimal;
        }

        /// <summary>
        /// Permite convertir un numero decimal a binario
        /// </summary>
        /// <param name="numero">cadena con el numero decimal a convertir</param>
        /// <returns>retorna el numero convertido a binario, o si no pudo "Valor invalido"</returns>
        public string DecimalBinario(string numero)
        {
            return DecimalBinario(double.Parse(numero));
        }

        /// <summary>
        /// Permite convertir un numero decimal a binario
        /// </summary>
        /// <param name="numero">el numero decimal a convertir</param>
        /// <returns>retorna el numero convertido a binario, o si no pudo "Valor invalido"</returns>
        public string DecimalBinario(double numero)
        {
            numero = Math.Abs(numero);
            string numeroBinario = Convert.ToString((int)numero, 2);

            if (EsBinario(numeroBinario))
            {
                return numeroBinario;
            }
            else
            {
                return "Valor Inválido";
            }
        }

        /// <summary>
        /// Sobrecarga operador +
        /// </summary>
        /// <param name="n1">Objeto del tipo Operando</param>
        /// <param name="n2">Objeto del tipo Operando</param>
        /// <returns>la suma del valor numero de los objeos recibidos</returns>
        public static double operator + (Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Sobrecarga operador -
        /// </summary>
        /// <param name="n1">Objeto del tipo Operando</param>
        /// <param name="n2">Objeto del tipo Operando</param>
        /// <returns>la resta del valor numero de los objeos recibidos</returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Sobrecarga operador *
        /// </summary>
        /// <param name="n1">Objeto del tipo Operando</param>
        /// <param name="n2">Objeto del tipo Operando</param>
        /// <returns>la multiplicacion del valor numero de los objeos recibidos</returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Sobrecarga operador /
        /// </summary>
        /// <param name="n1">Objeto del tipo Operando</param>
        /// <param name="n2">Objeto del tipo Operando</param>
        /// <returns>la division del valor numero de los objeos recibidos
        /// en caso de division por 0 retorna Mat.minValue </returns>
        public static double operator /(Operando n1, Operando n2)
        {
            if (n2.numero != 0)
            {
                return n1.numero / n2.numero;
            }
            else
            {
                return double.MinValue;
            }
        }
    }
}
