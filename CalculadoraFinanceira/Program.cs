using Newtonsoft.Json;

class Receita
{
    public decimal Valor { get; set; }
    public string Descricao { get; set; }
}

class Despesa
{
    public decimal Valor { get; set; }
    public string Descricao { get; set; }
}

class Program
{
    static List<Receita> receitas = new List<Receita>();
    static List<Despesa> despesas = new List<Despesa>();
    static string filePath = "financas.json";

    static void Main()
    {
        CarregarDados();
    menu:
        Console.Clear();
        Console.WriteLine("CALCULADORA FINANCEIRA");
        Console.WriteLine("1- Adicionar Receita");
        Console.WriteLine("2- Adicionar Despesa");
        Console.WriteLine("3- Calcular Saldo");
        Console.WriteLine("4- Relatórios");
    escolhaOpcao:
        Console.Write("Escolha uma opção: ");
        string opcao = Console.ReadLine();
        switch (opcao)
        {
            case "1":
                Console.Clear();
                AdicionarReceita();
                break;
            case "2":
                Console.Clear();
                AdicionarDespesa();
                break;
            case "3":
                Console.Clear();
                CalcularSaldo();
                break;
            case "4":
                Console.Clear();
                Relatorios();
                break;
            default:
                Console.WriteLine("Opção inválida! Tente novamente.");
                goto escolhaOpcao;
        }
        SalvarDados();
        Console.Write("\nPressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();
        goto menu;
    }

    static void AdicionarReceita()
    {
        Console.Write("Insira o valor da receita: ");
        decimal valorReceita = decimal.Parse(Console.ReadLine());

        Console.Write("Insira um descritor breve para a receita: ");
        string descricaoReceita = Console.ReadLine();

        receitas.Add(new Receita { Valor = valorReceita, Descricao = descricaoReceita });
        Console.WriteLine("Receita adicionada com sucesso!");
    }

    static void AdicionarDespesa()
    {
        Console.Write("Insira o valor da despesa: ");
        decimal valorDespesa = decimal.Parse(Console.ReadLine());

        Console.Write("Insira um descritor breve para a despesa: ");
        string descricaoDespesa = Console.ReadLine();

        despesas.Add(new Despesa { Valor = valorDespesa, Descricao = descricaoDespesa });
        Console.WriteLine("Despesa adicionada com sucesso!");
    }

    static void CalcularSaldo()
    {
        decimal totalReceita = 0, totalDespesa = 0;

        foreach (var receita in receitas)
            totalReceita += receita.Valor;

        foreach (var despesa in despesas)
            totalDespesa += despesa.Valor;

        decimal saldo = totalReceita - totalDespesa;

        if (saldo > 0)
            Console.WriteLine($"Você está com um saldo de \u001b[32m{saldo:C}\u001b[0m.");

        else if (saldo < 0)
            Console.WriteLine($"Você está com um saldo de \u001b[31m{saldo:C}\u001b[0m.");

        else
            Console.WriteLine($"Você está com um saldo de {saldo:C}.");
    }

    static void Relatorios()
    {
        decimal totalReceita = 0, totalDespesa = 0;

        Console.WriteLine(new string('-', 32)); // Linha de separação
        Console.WriteLine($"{"RECEITAS".PadLeft(15 + "RECEITAS".Length / 2).PadRight(32)}");
        Console.WriteLine(new string('-', 32)); // Linha de separação
        Console.WriteLine($"{"DESCRIÇÃO".PadRight(20)} {"VALOR",-10}"); // Cabeçalho
        Console.WriteLine(new string('-', 32)); // Linha de separação
        foreach (var receita in receitas)
        {
            Console.WriteLine($"{receita.Descricao.PadRight(20)} {receita.Valor,-10:C}");
            totalReceita += receita.Valor;
        }
        Console.WriteLine(new string('-', 32)); // Linha de separação
        Console.WriteLine($"{"TOTAL RECEITAS".PadRight(20)} {totalReceita,-10:C}\n");

        Console.WriteLine(new string('-', 32)); // Linha de separação
        Console.WriteLine($"{"DESPESAS".PadLeft(15 + "DESPESAS".Length / 2).PadRight(32)}");
        Console.WriteLine(new string('-', 32)); // Linha de separação
        Console.WriteLine($"{"DESCRIÇÃO".PadRight(20)} {"VALOR",-10}"); // Cabeçalho
        Console.WriteLine(new string('-', 32)); // Linha de separação
        foreach (var despesa in despesas)
        {
            Console.WriteLine($"{despesa.Descricao.PadRight(20)} {despesa.Valor,-10:C}");
            totalDespesa += despesa.Valor;
        }
        Console.WriteLine(new string('-', 32)); // Linha de separação
        Console.WriteLine($"{"TOTAL DESPESAS".PadRight(20)} {totalDespesa,-10:C}\n");

        decimal saldo = totalReceita - totalDespesa;
        Console.WriteLine(new string('-', 32)); // Linha de separação
        Console.WriteLine($"{"SALDO FINAL".PadRight(20)} {saldo,-10:C}");
    }

    static void CarregarDados()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            var financas = JsonConvert.DeserializeObject<Financas>(json);

            receitas = financas.Receitas ?? new List<Receita>();
            despesas = financas.Despesas ?? new List<Despesa>();
        }
    }
    static void SalvarDados()
    {
        var financas = new { receitas, despesas };
        string json = JsonConvert.SerializeObject(financas, Formatting.Indented);

        File.WriteAllText(filePath, json);
    }
}
class Financas
{
    public List<Receita> Receitas { get; set; }
    public List<Despesa> Despesas { get; set; }
}