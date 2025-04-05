namespace Ex6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Aluno aluno1 = new Aluno("Brennda", "0625", "Engenharia de Software", 10);
            aluno1.ExibirDados();
            aluno1.VerificarAprovacao();
        }

        //classe aluno
        class Aluno
        {
            private string nome;
            private string matricula;
            private string curso;
            private double mediaNotas;

            //construtor da classe
            public Aluno(string nome, string matricula, string curso, double mediaNotas)
            {
                this.nome = nome;
                this.matricula = matricula;
                this.curso = curso;
                this.mediaNotas = mediaNotas;
            }

            //função para exibir os dados do aluno
            public void ExibirDados()
            {
                Console.WriteLine("=== Dados aluno ===\n");
                Console.WriteLine($"Nome: {nome}");
                Console.WriteLine($"Matrícula: {matricula}");
                Console.WriteLine($"Curso: {curso}");
                Console.WriteLine($"Média de Notas: {mediaNotas}");
            }

            //função para verificar a aprovação do aluno
            public void VerificarAprovacao()
            {
                if(mediaNotas >= 7)
                {
                    Console.WriteLine("\nAluno(a) Aprovado!");
                }
                else
                {
                    Console.WriteLine("\nAluno(a) Reprovado!");
                }
            }
        }
    }
}
