class Program
{
    static void Main()
    {
        List<decimal> rctValor = new List<decimal>();
        List<string> rctDescricao = new List<string>();
        List<decimal> dpsValor = new List<decimal>();
        List<string> dpsDescricao = new List<string>();

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
                decimal rctValorAdd = decimal.Parse(Console.ReadLine());
                rctValor.Add(rctValorAdd);

                Console.Write("Insira uma descrição para a receita: ");
                string rctDescricaoAdd = Console.ReadLine();
                rctDescricao.Add(rctDescricaoAdd);

                Console.WriteLine("Receita adicionada com sucesso!");
                Console.Write("Pressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
                goto menu;
                break;

            case "2":
                Console.Clear();
                Console.Write("Insira o valor da despesa: ");
                decimal dpsValorAdd = decimal.Parse(Console.ReadLine());
                dpsValor.Add(dpsValorAdd);
                Console.WriteLine(dpsValor[0]);

                Console.Write("Insira uma descrição para a despesa: ");
                string dpsDescricaoAdd = Console.ReadLine();
                dpsDescricao.Add(dpsDescricaoAdd);
                Console.WriteLine(dpsDescricao[0]);

                Console.WriteLine("Despesa adicionada com sucesso!");
                Console.Write("Pressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
                goto menu;
                break;

            case "3":
                Console.Clear();
                decimal rctTotal = 0, dpsTotal = 0, saldo = 0;
                for (int i = 0; i <= (rctValor.Count - 1) + (dpsValor.Count - 1); i++)
                {
                    rctTotal += rctValor[i];
                    dpsTotal += dpsValor[i];
                }
                saldo = rctTotal - dpsTotal;
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

                rctTotal = 0; dpsTotal = 0; saldo = 0;

                Console.WriteLine("RECEITAS");
                for (int i = 0; i < rctValor.Count; i++)
                {
                    Console.Write($"{rctDescricao[i]}\t\t");
                    Console.WriteLine($"{rctValor[i]:C}");
                    rctTotal += rctValor[i];
                }
                Console.Write("TOTAL RECEITAS\t");
                Console.WriteLine($"{rctTotal:C}");

                Console.WriteLine("DESPESAS");
                for (int i = 0; i < dpsValor.Count; i++)
                {
                    Console.Write($"{dpsDescricao[i]}\t\t");
                    Console.WriteLine($"{dpsValor[i]:C}");
                    dpsTotal += dpsValor[i];
                }
                Console.Write("TOTAL DESPESAS\t");
                Console.WriteLine($"{dpsTotal:C}");

                saldo = rctTotal - dpsTotal;
                Console.Write("SALDO FINAL\t");
                Console.WriteLine($"{saldo:C}");
                break;

            default:
                Console.WriteLine("Opção inválida! Tente novamente.");
                goto escolhaOpcao;
                break;
        }
    }
}