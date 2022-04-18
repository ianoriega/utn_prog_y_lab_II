using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Permite realizar la operacion matematica
        /// </summary>
        /// <param name="num1">el primer operando</param>
        /// <param name="num2">el segundo operando</param>
        /// <param name="operador">el operador de la operacion</param>
        /// <returns>el valor de la operacion</returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            char operadorValidado = ValidarOperador(operador);
            
            switch(operadorValidado)
            {
                case '+':
                    return num1 + num2;
                case '-':
                    return num1 - num2;
                case '*':
                    return num1 * num2;
                default:
                    return num1 / num2;
            }
        }

        /// <summary>
        /// Permite validar que el operador ingresado sea + - * /
        /// </summary>
        /// <param name="operador">el operador a validar</param>
        /// <returns>retorna el operador validado o en su defecto '+' </returns>
        private static char ValidarOperador(char operador)
        {
            if (operador == '+' || operador == '-' || operador == '*' || operador == '/')
            {
                return operador;
            }
            else
            {
                return '+';
            }    
        }
    }
}
