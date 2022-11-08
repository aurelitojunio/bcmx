using Domain.Entities;
using Domain.Enums;

namespace Application.Interfaces
{
    public interface IBracoService
    {
        public ContracaoCotovelo Cotovelo { get; set; }
        public int Pulso { get; set; }
        void ContrairCotovelo(ContracaoCotovelo cotovelo);
        void GirarPulso(int angulo);
        void Repousar();
    }
}
