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
        Console.Write("Pressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();
        goto menu;
    }

    static void AdicionarReceita()
    {
        Console.Write("Insira o valor da receita: ");
        decimal valorReceita = decimal.Parse(Console.ReadLine());

        Console.Write("Insira uma descrição para a receita: ");
        string descricaoReceita = Console.ReadLine();

        receitas.Add(new Receita { Valor = valorReceita, Descricao = descricaoReceita });
        Console.WriteLine("Receita adicionada com sucesso!");        
    }

    static void AdicionarDespesa()
    {
        Console.Write("Insira o valor da despesa: ");
        decimal valorDespesa = decimal.Parse(Console.ReadLine());

        Console.Write("Insira uma descrição para a despesa: ");
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

        Console.WriteLine("RECEITAS");
        foreach (var receita in receitas)
        {
            Console.Write($"{receita.Descricao}\t\t");
            Console.WriteLine($"{receita.Valor:C}");
            totalReceita += receita.Valor;
        }
        Console.Write("TOTAL RECEITAS\t\t");
        Console.WriteLine($"{totalReceita:C}\n");

        Console.WriteLine("DESPESAS");
        foreach (var despesa in despesas)
        {
            Console.Write($"{despesa.Descricao}\t\t");
            Console.WriteLine($"{despesa.Valor:C}");
            totalDespesa += despesa.Valor;
        }
        Console.Write("TOTAL DESPESAS\t\t");
        Console.WriteLine($"{totalDespesa:C}\n");

        decimal saldo = totalReceita - totalDespesa;
        Console.Write("SALDO FINAL\t\t");
        Console.WriteLine($"{saldo:C}");
    }
    static void CarregarDados()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            var financas = JsonConvert.DeserializeObject<Financas>(json);

            receitas = financas.Receitas;
            despesas = financas.Despesas;
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