using System.Text;
namespace Ex3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //linha para permitir emojis no console
            Console.OutputEncoding = Encoding.UTF8;

            int option;
            double num1;
            double num2;
            bool validacao;

            //menu inicial da calculadora, da clear enquanto não inserir um número válido
            do
            {
                Console.Clear();
                Console.WriteLine("🧮 Calculadora\n");
                Console.WriteLine("1 - Soma\n2 - Subtração\n3 - Multiplicação\n4 - Divisão\n");
                Console.Write("Selecione uma operação: ");

                validacao = int.TryParse(Console.ReadLine(), out option);

            } while ((option < 1 || option > 4) || !validacao);

            switch (option)
            {
                //caso soma +
                case 1:
                    Console.Clear();
                    Console.WriteLine("🧮 Calculadora");
                    Console.WriteLine("\n➕ Somando\n");

                    num1 = ValidarDouble("Digite o primeiro número: ");

                    num2 = ValidarDouble("Digite o segundo número: ");

                    Resultado($"\nResultado: {Math.Round((num1 + num2),2)}");
                    break;

                //caso subtração -
                case 2:
                    Console.Clear();
                    Console.WriteLine("🧮 Calculadora");
                    Console.WriteLine("\n➖ Subtraindo\n");

                    num1 = ValidarDouble("Digite o primeiro número: ");

                    num2 = ValidarDouble("Digite o segundo número: ");

                    Resultado($"\nResultado: {Math.Round((num1 - num2), 2)}");
                    break;

                //caso multiplicação x
                case 3:
                    Console.Clear();
                    Console.WriteLine("🧮 Calculadora");
                    Console.WriteLine("\n✖️ Multiplicando\n");

                    num1 = ValidarDouble("Digite o primeiro número: ");

                    num2 = ValidarDouble("Digite o segundo número: ");

                    Resultado($"\nResultado: {Math.Round((num1 * num2), 2)}");
                    break;

                //caso divisão /
                case 4:
                    Console.Clear();
                    Console.WriteLine("🧮 Calculadora");
                    Console.WriteLine("\n➗ Divindo\n");

                    num1 = ValidarDouble("Digite o primeiro número: ");

                    num2 = ValidarDouble("Digite o segundo número: ");

                    if (num2 == 0)
                    {
                        Console.WriteLine("Divisão por zero é impossível");
                    }
                    else
                    {
                        Resultado($"\nResultado: {Math.Round((num1 / num2), 2)}");
                    }
                    break;
            }

            //função para validar a entrada do usuário e apagar somente o conteúdo que ele digitou sem alterar o conteúdo presente na tela
            double ValidarDouble(string msg)
            {
                double result;
                bool validacao = false;

                Console.Write(msg);

                do
                {
                    validacao = double.TryParse(Console.ReadLine(), out result);
                    if (!validacao)
                    {
                        Console.SetCursorPosition(msg.Length, Console.CursorTop - 1);
                        Console.Write(new string(' ', Console.WindowWidth));
                        Console.SetCursorPosition(msg.Length, Console.CursorTop - 1);
                    }

                } while (!validacao);

                return result;
            }

            void Resultado(string mensagem)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(mensagem);
                Console.ResetColor();
            }

    }
    }
}
