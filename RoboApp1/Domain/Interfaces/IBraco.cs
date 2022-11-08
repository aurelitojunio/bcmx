using Domain.Entities;
using Domain.Enums;

namespace Domain.Interfaces
{
    public interface IBraco
    {
        public ContracaoCotovelo Cotovelo { get; set; }
        public RotacaoPulso Pulso { get; set; }
        void ContrairCotovelo(ContracaoCotovelo cotovelo);
        void GirarPulso(RotacaoPulso angulo);
        void Repousar();
    }
}
