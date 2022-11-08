using Domain.Entities;
using Domain.Enums;

namespace Domain.Interfaces
{
    public interface IBracoEsquerdo 
    {
        ContracaoCotovelo Cotovelo { get; set; }
        RotacaoPulso Pulso { get; set; }
        void ContrairCotovelo(ContracaoCotovelo cotovelo);
        void GirarPulso(RotacaoPulso angulo);
        void Repousar();
    }
}
