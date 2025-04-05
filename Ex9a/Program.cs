namespace Ex9a
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool menu = true;
            Produto[] produtos = new Produto[5];
            int contadorProdutos = 0;

            while (menu)
            {
                Console.Clear();
                FormatarBackground("--- Menu Principal ---");
                Console.WriteLine("1 - Inserir Produtos");
                Console.WriteLine("2 - Listar Produtos");
                Console.WriteLine("3 - Sair");
                Console.Write("\nDigite uma opção: ");

                //_ foi indicação de uso do Visual Code
                _ = int.TryParse(Console.ReadLine(), out int userOpt);

                switch (userOpt)
                {
                    case 1:

                        Console.Clear();
                        FormatarBackground("--- Cadastrando Novo Produto ---");

                        if (contadorProdutos < 5)
                        {
                            //simplificação indicada pelo visual studio
                            Produto produto = new()
                            {
                                nomeProduto = validarString("Digite o nome do produto: "),

                                qtd = ValidarInt("Digite a quantidade do produto: "),

                                preco = ValidarDouble("Digite o preço do produto: ")
                            };

                            produtos[contadorProdutos] = produto;
                            contadorProdutos++;

                            Console.WriteLine("\nProduto cadastrado com sucesso!");
                        }
                        else Console.WriteLine("Máximo de 5 produtos atingido");

                        Console.Write("\nPressione qualquer tecla para voltar ao menu");
                        Console.ReadKey();

                        break;

                    case 2:

                        Console.Clear();
                        FormatarBackground("--- Lista de Produtos ---");

                        if (contadorProdutos > 0)
                        {
                            for (int i = 0; i < contadorProdutos; i++)
                            {
                                Console.WriteLine($"Produto: {produtos[i].nomeProduto}\t|\tQuantidade: {produtos[i].qtd}\t|\tPreço: {(produtos[i].preco).ToString("C")}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nenhum produto cadastrado");
                        }

                        Console.Write("\nPressione qualquer tecla para voltar ao menu");
                        Console.ReadKey();

                        break;

                    case 3:
                        menu = false;
                        break;
                }
            }

            //funções de formatação
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

            int ValidarInt(string msg)
            {
                int result;
                bool validacao = false;

                Console.Write(msg);

                do
                {
                    validacao = int.TryParse(Console.ReadLine(), out result);
                    if (!validacao)
                    {
                        Console.SetCursorPosition(msg.Length, Console.CursorTop - 1);
                        Console.Write(new string(' ', Console.WindowWidth));
                        Console.SetCursorPosition(msg.Length, Console.CursorTop - 1);
                    }

                } while (!validacao);

                return result;
            }

            string validarString(string msg)
            {
                string result;

                Console.Write(msg);

                do
                {
                    result = Console.ReadLine();

                    if (result.Length == 0)
                    {
                        Console.SetCursorPosition(msg.Length, Console.CursorTop - 1);
                        Console.Write(new string(' ', Console.WindowWidth));
                        Console.SetCursorPosition(msg.Length, Console.CursorTop - 1);
                    }

                } while (result.Length == 0);

                return result;
            }

            void FormatarBackground(string msg)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(msg + "\n");
                Console.ResetColor();
            }
        }

        public class Produto
        {
            public string nomeProduto;
            public int qtd;
            public double preco;
        }
    }
}