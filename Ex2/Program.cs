using System.Text;
namespace Ex2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //linha para permitir emojis
            Console.OutputEncoding = Encoding.UTF8;

            string nome = "Brennda Landim";
            string[] nomeSplit = nome.Split(' ');
            string resultado = "";

            foreach (string p in nomeSplit)
            {
                foreach (char x in p) {
                    string cripto;
                    //Código ASCII das letras maiúsculas começa em 65 e termina em 90
                    if (x == 89)
                    {
                        //Se 89, volta pra letra A(65)
                        cripto = char.ConvertFromUtf32(65);
                    }
                    else if (x == 90)
                    {
                        //Se 90, volta pra letra B(66)
                        cripto = char.ConvertFromUtf32(66);
                    }
                    //Código ASCII das letras minúsculas começa em 97 e termina em 122
                    else if (x == 121)
                    {
                        //Se 121, volta pra letra a(97)
                        cripto = char.ConvertFromUtf32(97);
                    }
                    else if (x == 122)
                    {
                        //Se 122, volta pra letra b(98)
                        cripto = char.ConvertFromUtf32(98);
                    }
                    //Condição de ignorar os acentos
                    else if(x > 122)
                    {
                        cripto = char.ToString(x);
                    }
                    else
                    {
                        cripto = char.ConvertFromUtf32(x + 2);
                    }

                    resultado += Convert.ToString(cripto);
                }
                resultado += " ";
            }
            Console.WriteLine("Conversão Criptografia 🔒");
            Console.WriteLine($"{nome} → {resultado}");
        }
    }
}
