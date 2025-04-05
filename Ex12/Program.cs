using System.Text.RegularExpressions;
using System.Text;

namespace Ex12
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //linha para permitir emojis
            Console.OutputEncoding = Encoding.UTF8;

            //para manter o menu rodando no loop até que digite 3
            bool menu = true;

            //caminho para salvar ou procurar o txt
            string pathArquivo = Path.Combine(Directory.GetCurrentDirectory(), "contatos.txt");

            while (menu)
            {
                Console.Clear();
                FormatarBackground("--- Gerenciador de Contatos ---");
                Console.WriteLine("1 - Adicionar novo contato");
                Console.WriteLine("2 - Listar contatos cadastrados");
                Console.WriteLine("3 - Sair");
                Console.Write("\nDigite uma opção: ");

                //_ foi indicação de uso do Visual Code
                _ = int.TryParse(Console.ReadLine(), out int userOpt);

                switch (userOpt)
                {
                    case 1:
                        Console.Clear();
                        FormatarBackground("--- Cadastrando Novo Contato ---");

                        //simplificação indicada pelo visual studio
                        Contato contato = new()
                        {
                            nomeContato = validarNome("Digite o nome do contato: "),

                            telefone = ValidarTelefone("Digite o número do contato no formato xx xxxxx-xxxx: "),

                            email = ValidarEmail("Digite o email do contato: ")
                        };

                        try
                        {
                            //criando ou acessando o arquivo txt
                            using (StreamWriter txt = new(pathArquivo, true))
                            {
                                txt.WriteLine($"{contato.nomeContato},{contato.telefone},{contato.email}");
                            }

                            Console.WriteLine("\nContato cadastrado com sucesso!");

                            Console.Write("\nPressione qualquer tecla para voltar ao menu");
                            Console.ReadKey();
                        }
                        catch (IOException ex)
                        {
                            Console.WriteLine($"Erro ao acessar o arquivo: {ex.Message}");
                        }

                        break;

                    case 2:

                        Console.Clear();
                        FormatarBackground("--- Lista de Contatos ---");
                        try
                        {
                            //verifica se o arquivo existe e tem tamanho(essa parte se torna necessária para o else funcionar caso o arquivo exista vazio)
                            if (File.Exists(pathArquivo) && File.ReadAllLines(pathArquivo).Length > 0)
                            {
                                List<Contato> contatos = new();

                                string[] linhasArquivo = File.ReadAllLines(pathArquivo);

                                if (linhasArquivo.Length != contatos.Count())
                                {
                                    foreach (string linha in linhasArquivo)
                                    {
                                        string[] dados = linha.Split(",");
                                        string telefone = dados[1].ToString();
                                        telefone = "(" + telefone.Substring(0, 2) + ") " + telefone.Substring(3);
                                        contatos.Add(new Contato { nomeContato = dados[0], telefone = telefone, email = dados[2] });
                                    }
                                }

                                //novo menu para escolher a formatação
                                while (true)
                                {
                                    Console.WriteLine("Escolha o formato de exibição:");
                                    Console.WriteLine("1 - Markdown");
                                    Console.WriteLine("2 - Tabela");
                                    Console.WriteLine("3 - RawText");
                                    Console.Write("\nDigite uma opção: ");

                                    _ = int.TryParse(Console.ReadLine(), out int formatoEscolhido);

                                    switch (formatoEscolhido)
                                    {
                                        case 1:
                                            new MarkdownFormatter().ExibirContatos(contatos);
                                            break;

                                        case 2:
                                            new TabelaFormatter().ExibirContatos(contatos);
                                            break;

                                        case 3:
                                            new RawTextFormatter().ExibirContatos(contatos);
                                            break;

                                        default:
                                            new RawTextFormatter().ExibirContatos(contatos);
                                            break;
                                    }

                                    break;
                                }

                                
                            }
                            else
                            {
                                Console.WriteLine("Nenhum contato cadastrado");
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
            string ValidarEmail(string msg)
            {
                string result;
                bool validacao;

                Console.Write(msg);

                do
                {
                    result = Console.ReadLine();
                    validacao = Regex.IsMatch(result, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");

                    if (!validacao)
                    {
                        Console.SetCursorPosition(msg.Length, Console.CursorTop - 1);
                        Console.Write(new string(' ', Console.WindowWidth));
                        Console.SetCursorPosition(msg.Length, Console.CursorTop - 1);
                    }

                } while (!validacao);
                return result;
            }

            string ValidarTelefone(string msg)
            {
                string result;
                bool validacao;

                Console.Write(msg);

                do
                {
                    result = Console.ReadLine();
                    validacao = Regex.IsMatch(result, @"^\d{2} \d{5}-\d{4}$");

                    if (!validacao)
                    {
                        Console.SetCursorPosition(msg.Length, Console.CursorTop - 1);
                        Console.Write(new string(' ', Console.WindowWidth));
                        Console.SetCursorPosition(msg.Length, Console.CursorTop - 1);
                    }

                } while (!validacao);

                return result;
            }

            string validarNome(string msg)
            {
                string result;
                bool validacao;

                Console.Write(msg);

                do
                {
                    result = Console.ReadLine();
                    validacao = Regex.IsMatch(result, @"^[A-Za-z][A-Za-z]{2,}$");

                    if (!validacao)
                    {
                        Console.SetCursorPosition(msg.Length, Console.CursorTop - 1);
                        Console.Write(new string(' ', Console.WindowWidth));
                        Console.SetCursorPosition(msg.Length, Console.CursorTop - 1);
                    }

                } while (!validacao);

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

        public class Contato
        {
            public string nomeContato;
            public string telefone;
            public string email;
        }

        //classe de formatação
        public class ContatoFormatter
        {
            public virtual void ExibirContatos(List<Contato> contatos) { }
        }

        //subclasse Markdown
        public class MarkdownFormatter : ContatoFormatter
        {
            public override void ExibirContatos(List<Contato> contatos)
            {
                foreach (var contato in contatos)
                {
                    Console.WriteLine($"\nNome: {contato.nomeContato}");
                    Console.WriteLine($"📞 Telefone: {contato.telefone}");
                    Console.WriteLine($"📧 Email: {contato.email}");
                }
            }
        }

        //subclasse Tabela
        public class TabelaFormatter : ContatoFormatter
        {
            public override void ExibirContatos(List<Contato> contatos)
            {
                Console.WriteLine("\n---------------------------------------------------");
                Console.WriteLine("| Nome\t|\tTelefone\t|\tEmail\t|");
                Console.WriteLine("---------------------------------------------------");
                foreach (var contato in contatos)
                {
                    Console.WriteLine($"|\t{contato.nomeContato}\t|\t{contato.telefone}\t|\t{contato.email}\t|");
                }
                Console.WriteLine("---------------------------------------------------");
            }
        }

        //subclasse RawTextFormatter
        public class RawTextFormatter : ContatoFormatter
        {
            public override void ExibirContatos(List<Contato> contatos)
            {
                foreach (var contato in contatos)
                {
                    Console.WriteLine($"\nNome: {contato.nomeContato}\t|\tTelefone: {contato.telefone}\t|\tEmail: {contato.email}");
                }
            }
        }
    }
}
