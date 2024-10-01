using System.ComponentModel.Design;

List<decimal> rctValor = new List<decimal>();
List<string> rctDescricao = new List<string>();
List<decimal> dpsValor = new List<decimal>();
List<string> dpsDescricao = new List<string>();
decimal rctTotal = 0, dpsTotal = 0;

menu:
Console.WriteLine("Calculadora Financeira");
Console.WriteLine("1- Adicionar Receita");
Console.WriteLine("2- Adicionar Despesa");
Console.WriteLine("3- Calcular Saldo");
Console.Write("Escolha uma opção: ");
string opcao = Console.ReadLine();
switch (opcao)
{
    case "1":
        Console.Write("Insira o valor da receita: ");
        decimal rctValorAdd = decimal.Parse(Console.ReadLine());
        rctValor.Add(rctValorAdd);
        Console.WriteLine(rctValor[0]);

        Console.Write("Insira uma descrição para a receita: ");
        string rctDescricaoAdd = Console.ReadLine();
        rctDescricao.Add(rctDescricaoAdd);
        Console.WriteLine(rctDescricao[0]);
        goto menu;
        break;

    case "2":
        Console.Write("Insira o valor da despesa: ");
        decimal dpsValorAdd = decimal.Parse(Console.ReadLine());
        dpsValor.Add(dpsValorAdd);
        Console.WriteLine(dpsValor[0]);

        Console.Write("Insira uma descrição para a despesa: ");
        string dpsDescricaoAdd = Console.ReadLine();
        dpsDescricao.Add(dpsDescricaoAdd);
        Console.WriteLine(dpsDescricao[0]);
        goto menu;
        break;

    case "3":
        for (int i = 0; i < (rctValor.Count + dpsValor.Count); i++)
        {
            rctTotal += rctValor[i];
            dpsTotal += dpsValor[i];
        }
        Console.WriteLine(rctTotal - dpsTotal);
        goto menu;
        break;

    default:
        Console.WriteLine("Opção inválida.");
        break;
}