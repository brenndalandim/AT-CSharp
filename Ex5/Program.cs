using System.Text;

namespace Ex5
{
    public  class Program
    {
        public static void Main(string[] args)
        {
            //linha para permitir emojis no console
            Console.OutputEncoding = Encoding.UTF8;

            DateTime dataFormatura = new DateTime(2028, 12, 20);

            string user;
            DateTime dataAtual;

            do
            {
                Console.Clear();
                Console.Write("Digite a data atual no formato dd/mm/aaaa: ");
                user = Console.ReadLine();

            } while (!DateTime.TryParse(user, out dataAtual));

            //validação se a data atual está certa
            if (dataAtual.ToString("dd/MM/yyyy") != DateTime.Now.ToString("dd/MM/yyyy"))
            {
                Console.WriteLine("\nErro: A data informada não é a data de hoje!");
            }
            //validação se a data da formatura já passou
            else if (dataFormatura < dataAtual)
            {
                Console.WriteLine("\nParabéns! Você já deveria estar formado!");
            }
            else
            {
                //calculo aproximado da diferença das datas
                var diferencaDatas = dataFormatura - dataAtual;
                int anos = diferencaDatas.Days / 365;
                int meses = (diferencaDatas.Days % 365) / 30;
                int dias = (diferencaDatas.Days % 365) % 30;

                Console.WriteLine($"\nFaltam aproximadamente {anos} anos, {meses} meses e {dias} dias para sua formatura! 🎓");

                //mensagem para menos de 6 meses
                if (anos == 0 && meses < 6)
                {
                    Console.WriteLine("\nA reta final chegou! Prepare-se para a formatura! 🎉");
                }
            }
        }
    }
}
