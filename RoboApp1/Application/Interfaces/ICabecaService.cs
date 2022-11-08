using Domain.Enums;

namespace Application.Interfaces
{
    public interface ICabecaService
    {
        RotacaoCabeca rotacao { get; set; }
        InclinacaoCabeca inclinacao { get; set; }
        void GirarCabeca(string direcao);
        void InclinarCabeca(string direcao);
        void Repousar();
    }
}
