using System.Text;
namespace Ex1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //linha para permitir emojis
            Console.OutputEncoding = Encoding.UTF8;

            string nome = "Brennda";
            string dataNascimento = "09/01/2002";

            Console.WriteLine($"Olá, meu nome é {nome}!🙂\nNasci em {dataNascimento} e estou aprendendo C#!📘");
        }
    }
}
