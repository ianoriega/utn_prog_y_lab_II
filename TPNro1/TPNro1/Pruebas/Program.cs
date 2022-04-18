using Entidades;
using System;

namespace Pruebas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Operando operando = new Operando();
            Console.WriteLine($"{operando.BinarioDecimal("10011.1")}");
        }
    }
}
