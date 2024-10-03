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
        EscreverTitulo();
        Console.WriteLine("1- Adicionar Receita");
        Console.WriteLine("2- Adicionar Despesa");
        Console.WriteLine("3- Calcular Saldo");
        Console.WriteLine("4- Relatórios");
        Console.WriteLine("0- Sair");
    escolhaOpcao:
        Console.Write("Escolha uma opção: ");
        if (int.TryParse(Console.ReadLine(), out int opcao))
        {
            switch (opcao)
            {
                case 1:
                    EscreverTitulo();
                    AdicionarReceita();
                    break;
                case 2:
                    EscreverTitulo();
                    AdicionarDespesa();
                    break;
                case 3:
                    EscreverTitulo();
                    CalcularSaldo();
                    break;
                case 4:
                    EscreverTitulo();
                    Relatorios();
                    break;
                case 0:
                    EscreverTitulo();
                    Console.WriteLine("Saindo...");
                    return;
                default:
                    ColorirLinha("Opção inválida! Tente novamente.", ConsoleColor.Yellow);
                    goto escolhaOpcao;
            }
            SalvarDados();
            Console.Write("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
            goto menu;
        }
        else
        {
            ColorirLinha("Opção inválida! Tente novamente.", ConsoleColor.Yellow);
            goto escolhaOpcao;
        }
    }

    static void AdicionarReceita()
    {
        string descricaoReceita = ObterDescricao("receita");
        decimal valorReceita = ObterValor("receita");

        receitas.Add(new Receita { Valor = valorReceita, Descricao = descricaoReceita });
        ColorirLinha("\nReceita adicionada com sucesso!", ConsoleColor.Cyan);
    }

    static void AdicionarDespesa()
    {
        string descricaoDespesa = ObterDescricao("despesa");
        decimal valorDespesa = ObterValor("despesa");

        despesas.Add(new Despesa { Valor = valorDespesa, Descricao = descricaoDespesa });
        ColorirLinha("\nDespesa adicionada com sucesso!", ConsoleColor.Cyan);
    }

    static string ObterDescricao(string tipo)
    {
    escolhaDescricao:
        Console.Write($"Insira uma descrição breve para a {tipo} (até 25 caracteres): ");
        string descricao = Console.ReadLine();
        if (string.IsNullOrEmpty(descricao))
        {
            ColorirLinha("A descrição não pode ficar vazia. Tente novamente.", ConsoleColor.Yellow);
            goto escolhaDescricao;
        }
        else if (descricao.Length > 25)
        {
            ColorirLinha("A descrição não pode ter mais que 25 caracteres. Tente novamente.", ConsoleColor.Yellow);
            goto escolhaDescricao;
        }
        return descricao;
    }

    static decimal ObterValor(string tipo)
    {
    escolhaValor:
        Console.Write($"Insira o valor da {tipo}: ");
        if (!(decimal.TryParse(Console.ReadLine(), out decimal valor) && valor > 0))
        {
            ColorirLinha("O valor precisa ser um número maior que 0. Tente novamente.", ConsoleColor.Yellow);
            goto escolhaValor;
        }
        return valor;
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

        if (!receitas.Any() && !despesas.Any())
            ColorirLinha("Nenhuma receita ou despesa salva na memória.", ConsoleColor.Yellow);

        if (receitas.Any())
        {
            Console.WriteLine("\nR E C E I T A S\n");
            Console.Write($"{"DESCRIÇÃO".PadRight(30)}");
            Console.WriteLine("VALOR");
            foreach (var receita in receitas)
            {
                Console.Write($"{receita.Descricao.PadRight(30)}");
                Console.WriteLine($"{receita.Valor:C}");
                totalReceita += receita.Valor;
            }
            Console.Write($"{"TOTAL".PadRight(30)}");
            Console.WriteLine($"{totalReceita:C}\n");
        }

        if (despesas.Any())
        {
            Console.WriteLine("D E S P E S A S\n");
            Console.Write($"{"DESCRIÇÃO".PadRight(30)}");
            Console.WriteLine("VALOR");
            foreach (var despesa in despesas)
            {
                Console.Write($"{despesa.Descricao.PadRight(30)}");
                Console.WriteLine($"{despesa.Valor:C}");
                totalDespesa += despesa.Valor;
            }
            Console.Write($"{"TOTAL".PadRight(30)}");
            Console.WriteLine($"{totalDespesa:C}\n");
        }

        if (!receitas.Any() && despesas.Any())
            ColorirLinha("Nenhuma receita salva na memória.", ConsoleColor.Yellow);
        else if (receitas.Any() && !despesas.Any())
            ColorirLinha("Nenhuma despesa salva na memória.", ConsoleColor.Yellow);

        if (receitas.Any() && despesas.Any())
        {
            decimal saldo = totalReceita - totalDespesa;
            Console.Write($"{"S A L D O   F I N A L".PadRight(30)}");
            Console.WriteLine($"{saldo:C}");
        }
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

    static void EscreverTitulo()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(new string('=', 43));
        Console.WriteLine("C A L C U L A D O R A   F I N A N C E I R A");
        Console.WriteLine(new string('=', 43));
        Console.ResetColor();
    }

    static void ColorirLinha(string texto, ConsoleColor cor)
    {
        Console.ForegroundColor = cor;
        Console.WriteLine(texto);
        Console.ResetColor();
    }
}

class Financas
{
    public List<Receita> Receitas { get; set; }
    public List<Despesa> Despesas { get; set; }
}