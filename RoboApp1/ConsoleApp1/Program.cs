using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;

namespace ConsoleApp1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Robô - v1.0");
            Console.WriteLine("=================");
            Console.WriteLine("Interface de linha de comando para administração do robô");
            Console.WriteLine("Iniciando o Robô...");

            var cabeca = new Cabeca();
            Console.WriteLine("Cabeça Ok!");
            Console.WriteLine("...");
            var bracoEsquerdo = new BracoEsquerdo();
            Console.WriteLine("Braço Esquerdo Ok!");
            Console.WriteLine("...");
            var bracoDireito = new BracoDireito();
            Console.WriteLine("Braço Direito Ok!");
            Console.WriteLine("...");
            
            string? result = "";
            string? posicao = "";

            while (true)
            {
                MostrarComandos();
                result = Console.ReadLine();

                if (result == "1")
                {
                    Console.WriteLine("\nRotação atual da Cabeça: " + cabeca.rotacao);
                    ComandosParaGirarCabeca();
                    posicao = Console.ReadLine();
                    GirarCabeca(cabeca, posicao);
                }
                else if (result == "2")
                {
                    ComandosParaInclinarCabeca();
                    posicao = Console.ReadLine();
                    InclinarCabeca(cabeca, posicao);                    
                }
                else if (result == "3")
                {
                    Console.WriteLine("\nContração atual do cotovelo: " + bracoEsquerdo.Cotovelo);
                    ComandosParaContrairCotovelo();
                    posicao = Console.ReadLine();
                    ContrairCotovelo(bracoEsquerdo, posicao);
                }
                else if (result == "4")
                {
                    Console.WriteLine("\nPosição do pulso Esquerdo atual: " + bracoEsquerdo.Pulso);
                    ComandosParaGirarPulso();
                    posicao = Console.ReadLine();
                    GirarPulso(bracoEsquerdo, posicao);
                }
                else if (result == "5")
                {
                    Console.WriteLine("\nContração atual do cotovelo: " + bracoDireito.Cotovelo);
                    ComandosParaContrairCotovelo();
                    posicao = Console.ReadLine();
                    ContrairCotovelo(bracoDireito, posicao);
                }
                else if (result == "6")
                {
                    Console.WriteLine("\nPosição do pulso Esquerdo atual: " + bracoDireito.Pulso);
                    ComandosParaGirarPulso();
                    posicao = Console.ReadLine();
                    GirarPulso(bracoDireito, posicao);
                }
                else if (result == "9")
                {
                    Console.WriteLine("Encerrando o Robô...");
                    break;
                }
                else
                {
                    Console.WriteLine("Opção inválida!");
                    MostrarComandos();
                }
            }
        }
        private static void MostrarComandos()
        {
            Console.WriteLine("\n---------------------");
            Console.WriteLine("Comandos disponíveis:\n");
            Console.WriteLine("  1 - Girar a cabeça");
            Console.WriteLine("  2 - Inclinar a cabeça");
            Console.WriteLine("  3 - Contrair Cotovelo esquerdo");
            Console.WriteLine("  4 - Girar Pulso esquerdo");
            Console.WriteLine("  5 - Contrair Cotovelo direito");
            Console.WriteLine("  6 - Girar Pulso direito");
            Console.WriteLine("  9 - Sair");
            Console.WriteLine("  Digite uma opção: ");
        }

        private static void ComandosParaGirarCabeca()
        {
            Console.WriteLine("\nGirar cabeça para que lado?");
            Console.WriteLine("  1 - Direita");
            Console.WriteLine("  2 - Esquerda");
            Console.WriteLine("  Digite uma opção: ");
        }
        private static void ComandosParaInclinarCabeca()
        {
            Console.WriteLine("\nInclinar para que lado?");
            Console.WriteLine("  1 - Para cima");
            Console.WriteLine("  2 - Em repouso");
            Console.WriteLine("  3 - Para baixo");
            Console.WriteLine("  Digite uma opção: ");
        }
        private static void ComandosParaContrairCotovelo()
        {
            Console.WriteLine("\nContração do cotovelo:");
            Console.WriteLine("  1 - Em Repouso");
            Console.WriteLine("  2 - Levemente Contraído");
            Console.WriteLine("  3 - Contraído");
            Console.WriteLine("  4 - Fortemtente Contraído");
            Console.WriteLine("  Digite uma opção: ");
        }
        private static void ComandosParaGirarPulso()
        {
            Console.WriteLine("\nGirar pulso para que lado?");
            Console.WriteLine("  1 - Direita");
            Console.WriteLine("  2 - Esquerda");
            Console.WriteLine("  Digite uma opção: ");
        }

        private static void GirarCabeca(ICabeca cabeca, string? posicao)
        {
            try
            {
                if (cabeca.inclinacao == InclinacaoCabeca.Para_Baixo)
                {
                    Console.WriteLine("Para inclinar a cabeça do robô, a cabeça não pode estar Para Baixo!");
                    return;
                }
                else
                {
                    if (posicao == "1")
                    {
                        cabeca.GirarCabeca(cabeca.rotacao.Next());
                    }
                    else if (posicao == "2")
                    {
                        cabeca.GirarCabeca(cabeca.rotacao.Previous());
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida!");
                        return;
                    }
                }
                Console.WriteLine("Rotação da Cabeça: " + cabeca.rotacao);
            }
            catch (Exception)
            {
                Console.WriteLine("Não foi possível girar a cabeça do Robô!");
            }
        }

        private static void InclinarCabeca(ICabeca cabeca, string? posicao)
        {
            try
            {
                var inclinacao = (InclinacaoCabeca)Convert.ToInt32(posicao) - 1;

                bool success = Enum.IsDefined(typeof(InclinacaoCabeca), inclinacao);
                if (success)
                {
                    cabeca.InclinarCabeca((InclinacaoCabeca)inclinacao);
                    Console.WriteLine("Inclinação da cabeça: " + cabeca.inclinacao);
                }
                else
                {
                    Console.WriteLine("Inclinação Incorreta da cabeça!");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Não foi Inclinar a cabeça do Robô!");
            }
        }


        private static void GirarPulso(IBraco pulso, string? posicao)
        {
            try
            {
                if (pulso.Cotovelo == ContracaoCotovelo.Fortemente_Contraido)
                {
                    if (posicao == "1")
                    {
                        pulso.GirarPulso(pulso.Pulso.Next());
                    }
                    else if (posicao == "2")
                    {
                        pulso.GirarPulso(pulso.Pulso.Previous());
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida!");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("O Cotovelo do robô precisa estar Fortemente Contraído para essa ação!");
                    return;
                }
                Console.WriteLine("Rotação do Pulso: " + pulso.Pulso);
            }
            catch (Exception)
            {
                Console.WriteLine("Não foi possível girar o Pulso do Robô!");
            }
        }

        private static void ContrairCotovelo(IBraco cotovelo, string? posicao)
        {
            try
            {
                var contracao = (ContracaoCotovelo)Convert.ToInt32(posicao) - 1;

                bool success = Enum.IsDefined(typeof(ContracaoCotovelo), contracao);
                if (success)
                {
                    cotovelo.ContrairCotovelo((ContracaoCotovelo)contracao);
                    Console.WriteLine("Contração do cotovelo: " + cotovelo.Cotovelo);
                }
                else
                {
                    Console.WriteLine("Contração Incorreta do cotovelo do Robô!");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Não foi Contrair o cotovelo do Robô!");
            }
        }
    }
}
