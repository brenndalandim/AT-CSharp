using System.Text.RegularExpressions;
using System.Text;

namespace Ex7
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //linha para permitir emojis no console
            Console.OutputEncoding = Encoding.UTF8;

            ContaBancaria testeConta = new("Brennda Landim");
            testeConta.Sacar(50);
            testeConta.Depositar(50);
            testeConta.Sacar(20);
            testeConta.Depositar(-10);
            testeConta.ExibirSaldo();
        }

        public class ContaBancaria
        {
            public string nomeCliente;
            private decimal saldo = 0; //conta abre zerada

            public ContaBancaria(string nome)
            {
                Console.WriteLine("Acessando dados da conta...⏳\n");
                
                //regex para confirmar se o nome inserido é válido (começa apenas com letras)
                if(Regex.IsMatch(nome, "^[a-zA-z]"))
                {
                    this.nomeCliente = nome;
                    Console.WriteLine($"Titular: {nome}");
                }
                else
                {
                    new Formatar().NaoValido("Titular com nome inválido.");
                }
            }

            public void Depositar(decimal valor)
            {
                new Formatar().PulaLinha();

                if (valor > 0)
                {
                    saldo += valor;
                    new Formatar().Valido($"Depósito de {(valor).ToString("C")} realizado com sucesso!");
                }
                else
                {
                    Console.WriteLine($"Tentativa de depósito de {(valor).ToString("C")}");
                    new Formatar().NaoValido("O valor do depósito deve ser positivo!");
                }

                ExibirSaldo();
            }

            public void Sacar(decimal valor)
            {
                new Formatar().PulaLinha();

                if (valor < saldo)
                {
                    saldo -= valor;
                    new Formatar().Valido($"Saque de {(valor).ToString("C")} realizado com sucesso!");
                }
                else
                {
                    Console.WriteLine($"Tentativa de saque de {(valor).ToString("C")}");
                    new Formatar().NaoValido("Saldo insuficiente para realizar o saque!");
                }

                ExibirSaldo();
            }

            public void ExibirSaldo()
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine($"→ Saldo atual: {saldo.ToString("C")}");
                Console.ResetColor();
            }

            //classe de formatações
            private class Formatar
            {
                //da um enter para o conteúdo não ficar todo colado
                public void PulaLinha()
                {
                    Console.WriteLine();
                }

                //deixa o texto verde quando da sucesso
                public void Valido(string mensagem)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(mensagem);
                    Console.ResetColor();
                }

                //deixa o texto vermelho quando não da sucesso
                public void NaoValido(string mensagem)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(mensagem);
                    Console.ResetColor();
                }
            }
        }
    }
}
