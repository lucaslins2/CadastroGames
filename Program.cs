using GAMESFLIX.Classes;

using System;

namespace GAMESFLIX
{
    class Program
    {
		static GamesRepositorio repositorio = new GamesRepositorio();
		static void Main(string[] args)
        {
			string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarSeries();
						break;
					case "2":
						//usando conceito de orientacao objeto reutilizando o codigo
						PreencerJogo( DadosGames());
						break;
					case "3":
						AtualizarJogo(IdConsole(),DadosGames());
						break;
					case "4":
						ExcluirGame();
						break;
					case "5":
						VisualizarGame();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();

		}
		private static void ListarSeries()
		{
			Console.WriteLine("Listar Games");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum jogo  cadastrado.");
				return;
			}

			foreach (var games in lista)
			{
				var excluido = games.returnExcluido();
				Console.WriteLine("#ID {0}: - {1} {2}", games.returnId(), games.returnTitleGame(), (excluido ? "*Excluído*" : ""));
			}
		}
		private static Games DadosGames()

		{

			Console.WriteLine("Inserir nova Jogo");

            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
            foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero do jogo entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o None do jogo: ");
			string entertitle = Console.ReadLine();
			foreach (int i in Enum.GetValues(typeof(Plataforma)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Plataforma), i));
			}
			Console.Write("Digite a Plataforma do game: ");
			int entraPlataforma = int.Parse(Console.ReadLine());
			Console.Write("Digite a data do jogo! padrao XX/MM/YYYY");
			string dataJogo = Console.ReadLine();

			Console.Write("Digite a Descrição do jogo: ");
			string enterDescricao = Console.ReadLine();

			Console.Write("O jogo e mutiplayer S ou N");
			string  A=Console.ReadLine();
			bool multiplayer;
			if (Equals(A, "Sim")) { multiplayer = true; }
            else { multiplayer = false; }
			//	int id, Genero Genero, Plataforma platform, string gameName, string descricao, string datalanc
			Games novaGames = new Games(id: repositorio.ProximoId(),
										Genero: (Genero)entradaGenero,
										platform: (Plataforma)entraPlataforma,
										gameName: entertitle,
										descricao: enterDescricao,
										datalanc: dataJogo,
										multiplayer: multiplayer
										) ;

			return novaGames;
		}
		private static void AtualizarJogo(int idJogo, Games jogo)
		{
		
			repositorio.Atualiza(idJogo, jogo);
		}
		private static void PreencerJogo(Games jogo)
        {
			repositorio.Insere(jogo);
			Console.Write("Inserido com sucesso!");
		}
		private static void ExcluirGame() {

			repositorio.Exclui(IdConsole());
			Console.Write("Excluido com sucesso!");
		}
		private static int IdConsole() {
			Console.Write("Digite o id da Jogo: ");
			int idJogo = int.Parse(Console.ReadLine());

			return idJogo;
		}




			//n prescisa de codigo use o conceito de reutilizacao de codigo fazendo metodo retornar metodo
		/*
		private static void AtualizarJogo()
		{
			Console.Write("Digite o id da Jogo: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o genero de jogo entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o nome do jogo: ");
			string entertitle = Console.ReadLine();

			Console.Write("Digite a data do jogo! ");
			string dataJogo = Console.ReadLine();

			Console.Write("Digite a Descrição da jogo: ");
			string enterDescricao = Console.ReadLine();

			Games novaGames = new Games(id: repositorio.ProximoId(),
											Genero: (Genero)entradaGenero,
											platform: (Plataforma)entraPlataforma,
											gameName: entertitle,
											descricao: enterDescricao,
											datalanc: dataJogo);
			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}
		*/
			private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("GAMESFLIX a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar Jogos");
			Console.WriteLine("2- Inserir nova jogo");
			Console.WriteLine("3- Atualizar jogo");
			Console.WriteLine("4- Excluir Jogo");
			Console.WriteLine("5- Visualizar Jogo");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
		private static void VisualizarGame()
		{
			Console.Write("Digite o id dO JOGO");
			int idJogo = int.Parse(Console.ReadLine());

			var games = repositorio.RetornaPorId(idJogo);

			Console.WriteLine(games);
		}


	}
}
