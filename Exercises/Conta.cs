using System;

namespace SistemaBancario.Exercises
{
    public class Conta
    {
        public int Id;
        public string Nome;
        public double Saldo;

        public Conta(int id, string nome)
        {
            Id = id;
            Nome = nome;
            Saldo = 0;
        }
    }
}