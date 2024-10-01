List<decimal> rctValor = new List<decimal>();
List<string> rctDescricao = new List<string>();
List<decimal> dpsValor = new List<decimal>();
List<string> dpsDescricao = new List<string>();

Console.WriteLine("Calculadora Financeira");
Console.WriteLine("1- Adicionar Receita");
Console.WriteLine("2- Adicionar Despesa");
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
        break;

    default:
        Console.WriteLine("Opção inválida.");
        break;
}