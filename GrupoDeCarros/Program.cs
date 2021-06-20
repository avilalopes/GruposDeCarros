using System;

namespace GrupoDeCarros
{
    class Program
    {

        static FrotaRepositorio repositorio = new FrotaRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarGrupo();
						break;
					case "2":
						InserirGrupo();
						break;
					case "3":
						AtualizarGrupo();
						break;
					case "4":
						ExcluirGrupo();
						break;
					case "5":
						VisualizarGrupo();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

        }

        private static void ExcluirGrupo()
		{
			Console.WriteLine("4 - Excluir grupo de carro");
			Console.WriteLine();			
			Console.Write("Digite o id do grupo: ");
			int indiceFrota = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceFrota);
		}

        private static void VisualizarGrupo()
		{
			Console.WriteLine("5 - Visualizar grupo de carro");
			Console.WriteLine();			
			Console.Write("Digite o id do grupo: ");
			int indiceFrota = int.Parse(Console.ReadLine());

			var frota = repositorio.RetornaPorId(indiceFrota);

			Console.WriteLine(frota);
		}

        private static void AtualizarGrupo()
		{
			Console.WriteLine("3 - Atualizar grupo de carro");
			Console.WriteLine();
			Console.Write("Digite o id do grupo: ");
			int indiceFrota = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Grupo)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Grupo), i));
			}
			Console.Write("Digite o grupo entre as opções acima: ");
			int entradaGrupo = int.Parse(Console.ReadLine());

			Console.Write("Informe o título do grupo: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Informe um veículo similar para o grupo: ");
			string entradaVeiculoSimilar = Console.ReadLine();

			Console.Write("Informe o Sipp Code do grupo: ");
			string entradaSippCode = Console.ReadLine();

			Console.Write("Informe a cilindrada do motor para o grupo: ");
			double entradaMotor = double.Parse(Console.ReadLine());

			Console.Write("Informe a quantidade de lugares para o grupo: ");
			int entradaLugares = int.Parse(Console.ReadLine());

			Console.Write("Informe a quantidade de portas para o grupo: ");
			int entradaPortas = int.Parse(Console.ReadLine());            

			Frota atualizaFrota = new Frota(id: indiceFrota,
										grupo: (Grupo)entradaGrupo,
										titulo: entradaTitulo,
										VeiculoSimilar: entradaVeiculoSimilar,
										SippCode: entradaSippCode,
                                        Motor: entradaMotor,
                                        Lugares: entradaLugares,
                                        Portas: entradaPortas);

			repositorio.Atualiza(indiceFrota, atualizaFrota);
		}
        private static void ListarGrupo()
		{
			Console.WriteLine("1 - Listar frota");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum grupo cadastrado.");
				return;
			}

			foreach (var frota in lista)
			{
                var excluido = frota.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", frota.retornaId(), frota.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirGrupo()
		{
			Console.WriteLine("2 - Cadastrar um novo grupo de carro");
			Console.WriteLine();
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Grupo)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Grupo), i));
			}
			Console.WriteLine();
			Console.Write("Digite o grupo entre as opções acima: ");
			int entradagrupo = int.Parse(Console.ReadLine());

			Console.Write("Digite o título do grupo: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Informe um veículo similar para o grupo: ");
			string entradaVeiculoSimilar = Console.ReadLine();

			Console.Write("Informe o Sipp Code do grupo: ");
			string entradaSippCode = Console.ReadLine();

			Console.Write("Informe a cilindrada do motor para o grupo: ");
			double entradaMotor = double.Parse(Console.ReadLine());

			Console.Write("Informe a quantidade de lugares para o grupo: ");
			int entradaLugares = int.Parse(Console.ReadLine());

			Console.Write("Informe a quantidade de portas para o grupo: ");
			int entradaPortas = int.Parse(Console.ReadLine());            

			Frota novaFrota = new Frota(id: repositorio.ProximoId(),
										grupo: (Grupo)entradagrupo,
										titulo: entradaTitulo,
										VeiculoSimilar: entradaVeiculoSimilar,
										SippCode: entradaSippCode,
                                        Motor: entradaMotor,
                                        Lugares: entradaLugares,
                                        Portas: entradaPortas);

			repositorio.Insere(novaFrota);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine("		LOCALIZA - GRUPOS DE CARROS");	
			Console.WriteLine();								
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar frota");
			Console.WriteLine("2- Cadastrar um novo grupo de carro");
			Console.WriteLine("3- Atualizar grupo de carro");
			Console.WriteLine("4- Excluir grupo de carro");
			Console.WriteLine("5- Visualizar grupo de carro");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
