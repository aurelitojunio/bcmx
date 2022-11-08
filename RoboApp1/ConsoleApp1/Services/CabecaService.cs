using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;

namespace ConsoleApp1.Services
{
    public class CabecaService
    {
        private readonly ICabeca _cabeca;
        public CabecaService(ICabeca cabeca)
        {
            _cabeca = cabeca;
            _cabeca.Repousar();
        }

        private void GirarCabeca(string posicao)
        {
            try
            {
                if (posicao == "1")
                {
                    _cabeca.GirarCabeca(_cabeca.rotacao.Next());
                }
                else if (posicao == "2")
                {
                    _cabeca.GirarCabeca(_cabeca.rotacao.Previous());
                }
                else
                {
                    Console.WriteLine("Opção inválida!");
                    return;
                }
                Console.WriteLine("Rotação da Cabeça: " + _cabeca.rotacao);
            }
            catch (Exception)
            {
                Console.WriteLine("Não foi possível girar a cabeça do Robô!");
            }
        }

        private void InclinarCabeca(string posicao)
        {
            try
            {
                var inclinacao = (InclinacaoCabeca)Convert.ToInt32(posicao) - 1;

                bool success = Enum.IsDefined(typeof(InclinacaoCabeca), inclinacao);
                if (success)
                {
                    _cabeca.InclinarCabeca((InclinacaoCabeca)inclinacao);
                    Console.WriteLine("Inclinação da cabeça: " + _cabeca.inclinacao);
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
    }
}
