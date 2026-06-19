using System.Globalization;
using System.IO;

namespace SistemaBancario.Exercises
{
    public class BancoApp
    {
        private static double saldo = 0;
        private static string caminhoArquivo = "saldo.txt";

        public static void Executar()
        {
            int opcao = 0;

            CarregarSaldo();

            while (opcao != 3)
            {
                Console.WriteLine("==== SISTEMA BANCÁRIO ====");
                Console.WriteLine("0 - Ver saldo");
                Console.WriteLine("1 - Depositar");
                Console.WriteLine("2 - Sacar");
                Console.WriteLine("3 - Sair");

                Console.WriteLine();
                Console.Write("Escolha uma opção: ");

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 0:
                        Console.WriteLine($"O seu saldo é de R$ {saldo.ToString("F2", CultureInfo.InvariantCulture)}");
                        break;

                    case 1:
                        Console.Write("Digite o valor do depósito: ");
                        double valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                        if (valor <= 0)
                        {
                            Console.WriteLine("O valor precisa ser maior que zero.");
                            break;
                        }

                        saldo = saldo + valor;
                        SalvarSaldo();

                        Console.WriteLine($"Novo saldo: R$ {saldo.ToString("F2", CultureInfo.InvariantCulture)}");
                        break;

                    case 2:
                        Console.Write("Digite o valor do saque: ");
                        double valorSaque = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                        if (valorSaque <= 0)
                        {
                            Console.WriteLine("O valor precisa ser maior que zero.");
                            break;
                        }

                        if (valorSaque <= saldo)
                        {
                            saldo = saldo - valorSaque;
                            SalvarSaldo();

                            Console.WriteLine("Saque realizado com sucesso!");
                            Console.WriteLine($"Novo saldo: R$ {saldo.ToString("F2", CultureInfo.InvariantCulture)}");
                        }
                        else
                        {
                            Console.WriteLine("Saldo insuficiente.");
                        }
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

        private static void SalvarSaldo()
        {
            File.WriteAllText(caminhoArquivo, saldo.ToString(CultureInfo.InvariantCulture));
        }

        private static void CarregarSaldo()
        {
            if (File.Exists(caminhoArquivo))
            {
                string texto = File.ReadAllText(caminhoArquivo);

                saldo = double.Parse(texto, CultureInfo.InvariantCulture);
            }
        }
    }
}