namespace Ex10
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Random geradorRandom = new();
            int randomNum = geradorRandom.Next(1, 51);

            int tentativa = 0;
            int user;

            //log de teste para confirmar o número
            //Console.WriteLine(randomNum);
            Console.WriteLine("Jogo de Adivinhação - Acerte o número surpresa entre 1 e 50 em 5 tentativas");

            do
            {
                Console.Write($"\nTentativa {tentativa + 1}/5: ");

                bool validacao = int.TryParse(Console.ReadLine(), out user);
                tentativa++;


                if (validacao)
                {
                    if (user > 50 || user < 1) Console.WriteLine("Digite apenas números no intervalo de 1 a 50");
                    else if (user > randomNum) Console.WriteLine("O número é menor");
                    else if (user < randomNum) Console.WriteLine("O número é maior");
                    else break;
                }
                else Console.WriteLine("Digite apenas números no intervalo de 1 a 50");

            } while (tentativa < 5);

            
            string msg = randomNum == user ? "Parabéns, você acertou o número secreto" : $"Não foi dessa vez, o número era {randomNum}";
            Console.ForegroundColor = randomNum == user ? ConsoleColor.Green : ConsoleColor.Red; ;
            Console.WriteLine("\n" + msg);
            Console.ResetColor();
        }
    }
}