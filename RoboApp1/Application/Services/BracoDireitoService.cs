using Domain.Enums;
using Application.Interfaces;
using Domain.Interfaces;
using CrossCutting.Extensions;
using System.Net;

namespace Domain.Entities
{
    public class BracoDireitoService : IBracoDireitoService
    {

        private readonly IBracoDireito _braco;
        public BracoDireitoService(IBracoDireito braco)
        {
            _braco = braco;
        }
        public ContracaoCotovelo Cotovelo
        {
            get { return _braco.Cotovelo; }
            set { _braco.Cotovelo = value; }
        }
        public RotacaoPulso Pulso
        {
            get { return _braco.Pulso; }
            set { _braco.Pulso = value; }
        }
        public string GirarPulso(string posicao)
        {
            try
            {
                if (_braco.Cotovelo == ContracaoCotovelo.Fortemente_Contraido)
                {
                    if (posicao == "1")
                    {
                        _braco.GirarPulso(_braco.Pulso.Next());
                    }
                    else if (posicao == "2")
                    {
                        _braco.GirarPulso(_braco.Pulso.Previous());
                    }
                    else
                    {
                        return "Opção inválida!";
                    }
                    return "Rotação do Pulso: " + _braco.Pulso;
                }
                else
                {
                    return "O Cotovelo do robô precisa estar Fortemente Contraído para essa ação!";
                }
            }
            catch (Exception)
            {
                throw new HttpException(HttpStatusCode.NotFound, "BUG no Robô!");
            }
        }

        public string ContrairCotovelo(string posicao)
        {
            try
            {
                var contracao = (ContracaoCotovelo)Convert.ToInt32(posicao) - 1;

                bool success = Enum.IsDefined(typeof(ContracaoCotovelo), contracao);
                if (success)
                {
                    _braco.ContrairCotovelo((ContracaoCotovelo)contracao);
                    return "Contração do cotovelo: " + _braco.Cotovelo;
                }
                else
                {
                    return "Opção inválida!";
                }
            }
            catch (Exception)
            {
                throw new HttpException(HttpStatusCode.NotFound, "BUG no Robô!");
            }
        }
        public void Repousar()
        {
            _braco.Repousar();
        }
    }
}