namespace SistemaBancario.Exercises
{
    public class BancoApp
    {
        public static void Executar()
        {
            Console.WriteLine("==== SISTEMA BANCÁRIO ====");
            Console.WriteLine("0 - Ver saldo");
            Console.WriteLine("1 - Depositar");
            Console.WriteLine("2 - Sacar");
            Console.WriteLine("3 - Sair");
            Console.WriteLine("4 - 0pção invalida!");

            Console.WriteLine();
            Console.Write("Escolha uma opção: ");

            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 0: Console.WriteLine("O seu saldo é de R$ 0,00");
                    break;
                case 1: Console.WriteLine("Você escolheu Depositar");
                    break;
                case 2: Console.WriteLine("Você escolheu Sacar");
                    break;
                case 3: Console.WriteLine("Saindo...");
                    break;
                case 4: Console.WriteLine("Opção invalida");
                    break;
            }
        }
    }
}