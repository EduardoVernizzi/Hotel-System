using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();



Console.WriteLine("Bem vindo ao hotel Tropical Manaus!!");
Console.WriteLine("Selecione a opção desejada: ");
Console.WriteLine("1 - Fazer reserva");
Console.WriteLine("2 - Consultar valores da suíte");
Console.WriteLine("0 - Sair");

int opcao = 0;
opcao = Convert.ToInt32(Console.ReadLine());

switch (opcao)
{
    case 1:

        Console.Clear();

        Suite suite = new Suite(tipoSuite: "Premium", capacidade: 3, valorDiaria: 30);
        
        Console.WriteLine($"Temos a seguinte suíte disponível: {suite.TipoSuite} - Capacidade de " +
                  $"{suite.Capacidade} pessoas e custa {suite.ValorDiaria} reais a diária.");
        Console.WriteLine("Pressione qualquer tecla para continuar");
        Console.ReadKey();
        Console.Clear();


        int numHospedes;
        Console.WriteLine("Digite a quantidade de hóspedes: ");
        numHospedes = Convert.ToInt32(Console.ReadLine());

        Reserva reserva = new Reserva();
        reserva.CadastrarSuite(suite);


        if (numHospedes > suite.Capacidade)
        {
            throw new ArgumentException("A quantidade de hóspedes não pode exceder a capacidade da suíte!");
        } else
        {
            reserva.CadastrarHospedes(hospedes);
        }

        Pessoa p1 = new Pessoa();
        Pessoa p2 = new Pessoa();
       

        Console.WriteLine($"Digite o nome da 1ª pessoa: ");
        p1.Nome = Console.ReadLine();

        Console.WriteLine($"Digite o nome da 2ª pessoa: ");
        p2.Nome = Console.ReadLine();

        hospedes.Add(p1);
        hospedes.Add(p2);

        Console.Clear();

        
        Console.WriteLine("Quantos dias desejam ficar hospedados? ");
        reserva.DiasReservados = Convert.ToInt32(Console.ReadLine());
      

        Console.WriteLine($"Você está reservando a suíte {suite.TipoSuite}, que tem a capacidade de " +
                           $"{suite.Capacidade} pessoas e custa {suite.ValorDiaria} reais a diária.");
        Console.WriteLine($"Você irá ficar {reserva.DiasReservados} dias, então o total ficou: ");

        Console.WriteLine($"Para os {reserva.ObterQuantidadeHospedes()} hóspedes, " +
                            $"{reserva.CalcularValorDiaria()} reais!");
        Console.WriteLine($"Desejamos uma boa estadia para {p1.Nome} e {p2.Nome}! ");

        break;

    case 2:
        Console.Clear();


        Suite suite2 = new Suite(tipoSuite: "Premium", capacidade: 3, valorDiaria: 30);
        Console.WriteLine($"Temos a seguinte suíte disponível: {suite2.TipoSuite} - Capacidade de " +
                  $"{suite2.Capacidade} pessoas e custa {suite2.ValorDiaria} reais a diária.");
        Console.WriteLine("Pressione qualquer tecla para sair");
        Console.ReadKey();
        Console.Clear();
        break;

     case 3:

        Environment.Exit(0);
        break;

    default:
        Console.WriteLine("Opção inválida!!");
        break;

}



