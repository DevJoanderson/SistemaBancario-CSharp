using System.Globalization;
using System.IO;

namespace SistemaBancario.Exercises
{
    public class BancoApp
    {
        private static Conta conta = new Conta(1, "Joanderson");
        private static string caminhoArquivo = "saldo.txt";

        public static void Executar()
        {
            
            int opcao = 0;

            CarregarSaldo();

            while (opcao != 3)
            {
                ExibirMenu();

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 0:
                        VerSaldo();
                        break;

                    case 1:
                        Depositar();
                        break;

                    case 2:
                        Sacar();
                        break;

                    case 3:
                        Console.WriteLine("Saindo...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                Console.WriteLine();
            }
        }

        private static void ExibirMenu()
        {
            Console.WriteLine("==== SISTEMA BANCÁRIO ====");
            Console.WriteLine("0 - Ver saldo");
            Console.WriteLine("1 - Depositar");
            Console.WriteLine("2 - Sacar");
            Console.WriteLine("3 - Sair");
            Console.WriteLine();
            Console.Write("Escolha uma opção: ");
        }

        private static void VerSaldo()
        {
            Console.WriteLine(
                $"O seu saldo é de R$ {conta.Saldo.ToString("F2", CultureInfo.InvariantCulture)}"
            );
        }

        private static void Depositar()
        {
            Console.Write("Digite o valor do depósito: ");

            double valor = double.Parse(
                Console.ReadLine(),
                CultureInfo.InvariantCulture
            );

            if (valor <= 0)
            {
                Console.WriteLine("O valor precisa ser maior que zero.");
                return;
            }

            conta.Saldo = conta.Saldo + valor;

            SalvarSaldo();

            Console.WriteLine(
                $"Novo saldo: R$ {conta.Saldo.ToString("F2", CultureInfo.InvariantCulture)}"
            );
        }

        private static void Sacar()
        {
            Console.Write("Digite o valor do saque: ");

            double valorSaque = double.Parse(
                Console.ReadLine(),
                CultureInfo.InvariantCulture
            );

            if (valorSaque <= 0)
            {
                Console.WriteLine("O valor precisa ser maior que zero.");
                return;
            }

            if (valorSaque <= conta.Saldo)
            {
                conta.Saldo = conta.Saldo - valorSaque;

                SalvarSaldo();

                Console.WriteLine("Saque realizado com sucesso!");

                Console.WriteLine(
                    $"Novo saldo: R$ {conta.Saldo.ToString("F2", CultureInfo.InvariantCulture)}"
                );
            }
            else
            {
                Console.WriteLine("Saldo insuficiente.");
            }
        }

        private static void SalvarSaldo()
        {
            File.WriteAllText(
                caminhoArquivo,
                conta.Saldo.ToString(CultureInfo.InvariantCulture)
            );
        }

        private static void CarregarSaldo()
        {
            if (File.Exists(caminhoArquivo))
            {
                string texto = File.ReadAllText(caminhoArquivo);

                conta.Saldo = double.Parse(
                    texto,
                    CultureInfo.InvariantCulture
                );
            } 
        }
    }
}