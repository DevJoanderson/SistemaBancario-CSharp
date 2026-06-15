using System;

namespace SistemaBancario.Exercises
{
    public class Conta
    {
        public string Nome;
        public double Saldo;

        public Conta(string nome)
        {
            Nome = nome;
            Saldo = 0;
        }
    }
}