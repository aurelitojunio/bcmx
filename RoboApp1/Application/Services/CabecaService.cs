using Domain.Enums;
using Application.Interfaces;
using Domain.Interfaces;
using CrossCutting.Extensions;
using System.Net;

namespace Domain.Entities
{
    public class CabecaService : ICabecaService
    {
        private readonly ICabeca _cabeca;
        public CabecaService(ICabeca cabeca)
        {
            _cabeca = cabeca;
        }
        public RotacaoCabeca rotacao { get; set; }
        public InclinacaoCabeca inclinacao { get; set; }
        public void GirarCabeca(string posicao)
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
                    return;
                }
            }
            catch (Exception)
            {
                throw new HttpException(HttpStatusCode.NotFound, "Giro incorreto da cabeça!");
            }
        }

        public void InclinarCabeca(string posicao)
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
        public void Repousar()
        {
            _cabeca.Repousar();
        }
    }
}