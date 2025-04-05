using System.Text;

namespace Ex4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //linha para permitir emojis no console
            Console.OutputEncoding = Encoding.UTF8;

            string user;
            DateTime dataNascimento;

            do
            {
                Console.Clear();
                Console.Write("Digite sua data de nascimento no formato dd/mm/aaaa: ");
                user = Console.ReadLine();

            } while (!DateTime.TryParse(user, out dataNascimento));

            //pega a data de aniversário no ano atual
            DateTime proximoAniversario = new (DateTime.Now.Year, dataNascimento.Month, dataNascimento.Day);

            //confirma se já passou no ano atual, se sim passa pro próximo ano
            if (proximoAniversario < DateTime.Now) proximoAniversario = proximoAniversario.AddYears(1);

            int diasFaltando = (proximoAniversario - DateTime.Now).Days;

            Console.WriteLine($"\nFaltam {diasFaltando} dias para o seu próximo aniversário");

            //mensagem se faltar menos de 7 dias
            if (diasFaltando < 7) Console.WriteLine("Seu aniversário está próximo! 🎉");
        }
    }
}