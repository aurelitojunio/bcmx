using Domain.Entities;

namespace Application.Interfaces
{
    public interface IRoboService
    {
        ICabecaService Cabeca { get; set; }
        IBracoService BracoEsquerdo { get; set; }
        IBracoService BracoDireito { get; set; }
    }
}
