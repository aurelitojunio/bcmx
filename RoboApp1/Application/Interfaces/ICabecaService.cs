using Domain.Enums;

namespace Application.Interfaces
{
    public interface ICabecaService
    {
        RotacaoCabeca rotacao { get; set; }
        InclinacaoCabeca inclinacao { get; set; }
        string GirarCabeca(string direcao);
        string InclinarCabeca(string direcao);
        void Repousar();
    }
}
