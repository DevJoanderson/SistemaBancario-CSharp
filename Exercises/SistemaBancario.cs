using System.IO;
namespace SistemaBancario.Exercises
{
    public class BancoApp
    {
        private static double saldo = 0;
        private static string caminhoArquivo = "saldo.txt";
        public static void Executar()
        {
            CarregarSaldo();
            Console.WriteLine("==== SISTEMA BANCÁRIO ====");
            Console.WriteLine("0 - Ver saldo");
            Console.WriteLine("1 - Depositar");
            Console.WriteLine("2 - Sacar");
            Console.WriteLine("3 - Sair");
            Console.WriteLine();
            Console.Write("Escolha uma opção: ");
            

            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 0:
                    Console.WriteLine($"O seu saldo é de R$ {saldo}");
                    break;
                case 1:
                    Console.WriteLine("Digite o valor do depósito: ");
                    double valor = double.Parse(Console.ReadLine());
                    saldo = saldo + valor;
                    SalvarSaldo();
                    Console.WriteLine($"Novo saldo: R$ {saldo}");
                    break;
                case 2:
                    Console.WriteLine("Digite o valor do saque: ");

                    double valorSaque = double.Parse(Console.ReadLine());

                    if (valorSaque <= saldo)
                    {
                        saldo = saldo - valorSaque;

                        SalvarSaldo();


                        Console.WriteLine($"Saque realizado com sucesso!");
                        Console.WriteLine($"Novo saldo: R$ {saldo}");
                    } 
                    else
                    {
                        Console.WriteLine("Saldo insuficiente.");
                    }
                    break;
                case 3:
                    Console.WriteLine("Saindo...");
                    break;

            }

        }
            private static void SalvarSaldo()
        {
            File.WriteAllText(caminhoArquivo, saldo.ToString());
        }

        private static void CarregarSaldo()
        {
            if (File.Exists(caminhoArquivo))
            {
                string texto = File.ReadAllText(caminhoArquivo);

                saldo = double.Parse(texto);
            }

        }
    }
}