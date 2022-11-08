using Domain.Enums;

namespace Domain.Interfaces
{
    public interface ICabeca
    {
        RotacaoCabeca rotacao { get; set; }
        InclinacaoCabeca inclinacao { get; set; }
        void GirarCabeca(RotacaoCabeca angulo);
        void InclinarCabeca(InclinacaoCabeca inclinacao);
        void Repousar();
    }
}
