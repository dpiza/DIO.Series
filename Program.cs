using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio serieRepositorio = new SerieRepositorio();
        static FilmeRepositorio filmeRepositorio = new FilmeRepositorio();
        static void Main(string[] args)
        {
           string opcaoUsuario = ObterOpcaoUsuario();

           while (opcaoUsuario.ToUpper() != "X")
           {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.Clear();
                        MenuFilme();
                        break;
                    case "2":
                        Console.Clear();
                        MenuSerie();
                        break;


                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
           }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Menu DIO.Séries && Filmes");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine();
            Console.WriteLine("1 - Filmes");
            Console.WriteLine("2 - Séries");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static void MenuFilme()
        {
            string menuFilme = ObterOpcaoFilme();
            while (menuFilme.ToUpper() != "0")
           {
                switch (menuFilme)
                {
                    case "1":
                        ListarShow(1);
                        break;
                    case "2":
                        InserirShow(1);
                        break;
                    case "3":
                        AtualizarShow(1);
                        break;
                    case "4":
                        ExcluirShow(1);
                        break;
                    case "5":
                        VisualizarShow(1);
                        break;
                    case "0":
                        ObterOpcaoUsuario();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                menuFilme = ObterOpcaoFilme();
           }
        }

        private static string ObterOpcaoFilme()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Menu DIO.Séries && FILMES");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine();
            Console.WriteLine("1 - Listar filmes");
            Console.WriteLine("2 - Inserir novo filme");
            Console.WriteLine("3 - Atualizar filme");
            Console.WriteLine("4 - Excluir filme");
            Console.WriteLine("5 - Visualizar filme");
            Console.WriteLine();
            Console.WriteLine("0 - Menu Anterior");
            Console.WriteLine();

            string opcaoSerie = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoSerie;
        }

        private static void MenuSerie()
        {
            string menuSerie = ObterOpcaoSerie();
            while (menuSerie.ToUpper() != "0")
           {
                switch (menuSerie)
                {
                    case "1":
                        ListarShow(2);
                        break;
                    case "2":
                        InserirShow(2);
                        break;
                    case "3":
                        AtualizarShow(2);
                        break;
                    case "4":
                        ExcluirShow(2);
                        break;
                    case "5":
                        VisualizarShow(2);
                        break;
                    case "0":
                        ObterOpcaoUsuario();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                menuSerie = ObterOpcaoSerie();
           }
        }
        private static string ObterOpcaoSerie()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Menu DIO.SÉRIES && Filmes");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine();
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine();
            Console.WriteLine("0 - Menu Anterior");
            Console.WriteLine();

            string opcaoSerie = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoSerie;
        }

        private static void VisualizarShow(int obj)
        {
            Console.Clear();
            Console.Write("Digite o id do show: ");
            int indiceShow = int.Parse(Console.ReadLine());

            if (obj == 1)
            {
                var filme = filmeRepositorio.RetornaPorId(indiceShow);
                Console.WriteLine(filme);
                Console.ReadLine();
            }
            else
            {
                var serie = serieRepositorio.RetornaPorId(indiceShow);
                Console.WriteLine(serie);
                Console.ReadLine();
            }
        }

        private static void ExcluirShow(int obj)
        {
            Console.Clear();
            Console.WriteLine();
            Console.Write("Digite o id do show: ");
            int indiceShow = int.Parse(Console.ReadLine());

            

            if (obj == 1)
            {
                var filme = filmeRepositorio.RetornaPorId(indiceShow);
                
                Console.WriteLine();
                Console.WriteLine("O show abaixo será excluido:");
                Console.WriteLine();
                Console.WriteLine(filme);
                Console.WriteLine();
                Console.Write("Deseja continuar? S/N: ");
                string confirma = Console.ReadLine();

                if (confirma.ToUpper() == "S")
                {
                    filmeRepositorio.Exclui(indiceShow);
                    Console.WriteLine("Show excluído com sucesso.");
                    Console.ReadLine();
                }
                else
                {
                    return;
                }
            }
            else
            {
                var serie = serieRepositorio.RetornaPorId(indiceShow);
                
                Console.WriteLine();
                Console.WriteLine("O show abaixo será excluido:");
                Console.WriteLine();
                Console.WriteLine(serie);
                Console.WriteLine();
                Console.Write("Deseja continuar? S/N: ");
                string confirma = Console.ReadLine();

                if (confirma.ToUpper() == "S")
                {
                    serieRepositorio.Exclui(indiceShow);
                    Console.WriteLine("Show excluído com sucesso.");
                    Console.ReadLine();
                }
                else
                {
                    return;
                }
            }
        }

        private static void ListarShow(int obj)
        {
            Console.Clear();
            Console.WriteLine("Listar {0}s", Enum.GetName(typeof(Objeto), obj));
            Console.WriteLine();

            if (obj == 1)
            {
                var lista = filmeRepositorio.Lista();

                if (lista.Count == 0)
                {
                    Console.WriteLine("Nenhum filme cadastrado.");
                    Console.ReadLine();
                    return;
                }

                foreach (var filme in lista)
                {
                    var excluido = filme.retornaExcluido();
                    Console.WriteLine("#ID {0}: - {1} {2}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "*Excluido*" : ""));
                }
                Console.ReadLine();
            }
            else
            {
                var lista = serieRepositorio.Lista();

                if (lista.Count == 0)
                {
                    Console.WriteLine("Nenhuma série cadastrada.");
                    Console.ReadLine();
                    return;
                }

                foreach (var serie in lista)
                {
                    var excluido = serie.retornaExcluido();
                    Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluido*" : ""));
                }
                Console.ReadLine();
            }
            
        }

        private static void AtualizarShow(int obj)
        {
            Console.Clear();
            Console.Write("Digite o id do show: ");
            int indiceShow = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título do show: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de início do show: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição do show: ");
            string entradaDescricao = Console.ReadLine();

            if (obj == 1)
            {
                Console.Write("Digite a pontuação do Imdb: ");
                double entradaImdb = double.Parse(Console.ReadLine());

                Filme atualizaFilme = new Filme(id: indiceShow,
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao,
                                            imdb: entradaImdb);

                filmeRepositorio.Atualiza(indiceShow, atualizaFilme);
            }
            else
            {
                Serie atualizaSerie = new Serie(id: indiceShow,
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);

                serieRepositorio.Atualiza(indiceShow, atualizaSerie);
            }
        }

        private static void InserirShow(int obj)
        {
            Console.Clear();
            Console.WriteLine("Inserir novo show");
            Console.WriteLine();

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine();
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título do show: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite a descrição do show: ");
            string entradaDescricao = Console.ReadLine();

            if (obj == 1)
            {
                Console.Write("Digite o ano do show: ");
                int entradaAno = int.Parse(Console.ReadLine());
                Console.Write("Digite a pontuação do Imdb: ");
                double entradaImdb = double.Parse(Console.ReadLine());
                Filme novoFilme = new Filme(id: filmeRepositorio.ProximoId(),
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao,
                                            imdb: entradaImdb);

                filmeRepositorio.Insere(novoFilme);
                Console.WriteLine();
                Console.Write("Show {0} adicionado ao repositório de {1}s", entradaTitulo, Enum.GetName(typeof(Objeto), obj));
                Console.ReadLine();
            }
            else
            {
                Console.Write("Digite o ano de início do show: ");
                int entradaAno = int.Parse(Console.ReadLine());
                Serie novaSerie = new Serie(id: serieRepositorio.ProximoId(),
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);

                serieRepositorio.Insere(novaSerie);
                Console.WriteLine();
                Console.Write("Show {0} adicionado ao repositório de {1}s", entradaTitulo, Enum.GetName(typeof(Objeto), obj));
                Console.ReadLine();
            }
        }
    }
}
