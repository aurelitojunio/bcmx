using Domain.Enums;
using Domain.Interfaces;

namespace Application.Interfaces
{
    public interface IBracoEsquerdoService 
    {
        ContracaoCotovelo Cotovelo { get; set; }
        RotacaoPulso Pulso { get; set; }
        string ContrairCotovelo(string posicao);
        string GirarPulso(string posicao);
        void Repousar();
    }
}
