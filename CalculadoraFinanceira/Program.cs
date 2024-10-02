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
    static void Main()
    {
        List<Receita> receitas = new List<Receita>();
        List<Despesa> despesas = new List<Despesa>();
        decimal totalReceita, totalDespesa, saldo;

    menu:
        Console.Clear();

        Console.WriteLine("Calculadora Financeira");
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

                Console.Write("Insira o valor da receita: ");
                decimal valorReceita = decimal.Parse(Console.ReadLine());

                Console.Write("Insira uma descrição para a receita: ");
                string descricaoReceita = Console.ReadLine();

                receitas.Add(new Receita { Valor = valorReceita, Descricao = descricaoReceita });
                Console.WriteLine("Receita adicionada com sucesso!");
                Console.Write("Pressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
                goto menu;
                break;

            case "2":
                Console.Clear();

                Console.Write("Insira o valor da despesa: ");
                decimal valorDespesa = decimal.Parse(Console.ReadLine());

                Console.Write("Insira uma descrição para a despesa: ");
                string descricaoDespesa = Console.ReadLine();

                despesas.Add(new Despesa { Valor = valorDespesa, Descricao = descricaoDespesa });
                Console.WriteLine("Despesa adicionada com sucesso!");
                Console.Write("Pressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
                goto menu;
                break;

            case "3":
                Console.Clear();

                totalReceita = 0; totalDespesa = 0;

                foreach (var receita in receitas)
                    totalReceita += receita.Valor;

                foreach (var despesa in despesas)
                    totalDespesa += despesa.Valor;

                saldo = totalReceita - totalDespesa;

                // to do - inserir cores diferentes pra cd saldo:
                if (saldo > 0)
                    Console.WriteLine($"Você está com um saldo de {saldo:C}."); //verde

                else if (saldo < 0)
                    Console.WriteLine($"Você está com um saldo de {saldo:C}."); //vermelho

                else
                    Console.WriteLine($"Você está com um saldo de {saldo:C}."); //branco

                Console.Write("Pressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
                goto menu;
                break;

            case "4":
                Console.Clear();

                totalReceita = 0; totalDespesa = 0;

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

                saldo = totalReceita - totalDespesa;
                Console.Write("SALDO FINAL\t\t");
                Console.WriteLine($"{saldo:C}");

                Console.Write("Pressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
                goto menu;
                break;

            default:
                Console.WriteLine("Opção inválida! Tente novamente.");
                goto escolhaOpcao;
                break;
        }
    }
}