using Application.Interfaces;
using CrossCutting.Extensions;
using Domain.Enums;
using Domain.Interfaces;
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
        public RotacaoCabeca rotacao {
            get { return _cabeca.rotacao; }
            set { _cabeca.rotacao = value; }
        }
        public InclinacaoCabeca inclinacao {
            get { return _cabeca.inclinacao; }
            set { _cabeca.inclinacao = value; }
        }
        public string GirarCabeca(string posicao)
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
                    return "Opção inválida!";
                }
                return "Rotação da Cabeça: " + _cabeca.rotacao;
            }
            catch (Exception)
            {
                throw new HttpException(HttpStatusCode.NotFound, "BUG no Robô!");
            }
        }

        public string InclinarCabeca(string posicao)
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
                    return "Opção inválida!";
                }
                return "Inclinação da cabeça: " + _cabeca.inclinacao;
            }
            catch (Exception)
            {
                throw new HttpException(HttpStatusCode.NotFound, "BUG no Robô!");
            }
        }
        public void Repousar()
        {
            _cabeca.Repousar();
        }
    }
}