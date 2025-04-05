namespace Ex8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Funcionario testeFuncionario = new("Brennda", "Estagiaria", 2000);
            testeFuncionario.ExibirDados();

            Gerente testeGerente = new("Brennda", 5000);
            testeGerente.ExibirDados();
        }

        public class Funcionario
        {
            public string nome;
            public string cargo;
            public double salBase;

            public Funcionario(string nome, string cargo, double salBase)
            {
                this.nome = nome;
                this.cargo = cargo;
                this.salBase = salBase;
            }

            public void ExibirDados()
            {
                Console.WriteLine("----------------------");
                Console.WriteLine($"Nome: {nome}");
                Console.WriteLine($"Cargo: {cargo}");
                Console.WriteLine($"Salário Base: {(salBase).ToString("C")}");
            }
        }

        public class Gerente : Funcionario
        {
            public Gerente(string nome, double salBase) : base(nome, "Gerente", salBase) { }

            //uso do new e não do override para apenas ocultar esse método no base ao invés de trocar para qualquer uso
            public new void ExibirDados()
            {
                base.ExibirDados();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Salário com bônus de 20%: {(salBase*1.2).ToString("C")}");
                Console.ResetColor();

            }

        }
    }
}
