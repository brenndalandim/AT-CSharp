namespace Ex9b
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //para manter o menu rodando no loop até que digite 3
            bool menu = true;

            //caminho para salvar ou procurar o txt
            string pathArquivo = Path.Combine(Directory.GetCurrentDirectory(), "estoque.txt");

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

                        //definir o total de produtos através do tamanho do arquivo para controlar o máximo de 5 produtos
                        int totalProdutos = File.Exists(pathArquivo) ? File.ReadAllLines(pathArquivo).Length : 0;

                        Console.Clear();
                        FormatarBackground("--- Cadastrando Novo Produto ---");

                        if (totalProdutos < 5)
                        {
                            //simplificação indicada pelo visual studio
                            Produto produto = new()
                            {
                                nomeProduto = validarString("Digite o nome do produto: "),

                                qtd = ValidarInt("Digite a quantidade do produto: "),

                                preco = ValidarDouble("Digite o preço do produto: ")
                            };

                            try
                            {
                                //criando ou acessando o arquivo txt
                                using (StreamWriter txt = new (pathArquivo, true))
                                {
                                    txt.WriteLine($"{produto.nomeProduto},{produto.qtd},{(produto.preco).ToString().Replace(",", ".")}");
                                }

                                Console.WriteLine("\nProduto cadastrado com sucesso!");
                            }
                            catch (IOException ex)
                            {
                                Console.WriteLine($"Erro ao acessar o arquivo: {ex.Message}");
                            }
                        }
                        else Console.WriteLine("Máximo de 5 produtos atingido");

                        Console.Write("\nPressione qualquer tecla para voltar ao menu");
                        Console.ReadKey();

                        break;

                    case 2:

                        Console.Clear();
                        FormatarBackground("--- Lista de Produtos ---");
                        try
                        {
                            //verifica se o arquivo existe e tem tamanho(essa parte se torna necessária para o else funcionar caso o arquivo exista vazio)
                            if (File.Exists(pathArquivo) && File.ReadAllLines(pathArquivo).Length > 0)
                            {
                                string[] linhasArquivo = File.ReadAllLines(pathArquivo);

                                if (linhasArquivo.Length > 0)
                                {
                                    foreach(string linha in linhasArquivo)
                                    {
                                        string[] dados = linha.Split(",");
                                        Console.WriteLine($"Produto: {dados[0]}\t|\tQuantidade: {dados[1]}\t|\tPreço: R$ {dados[2].Replace(".",",")}");
                                    }
                                }

                            }
                            else
                            {
                                Console.WriteLine("Nenhum produto cadastrado");
                            }
                        }
                        catch (IOException ex)
                        {
                            Console.WriteLine($"Erro ao acessar o arquivo: {ex.Message}");
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
