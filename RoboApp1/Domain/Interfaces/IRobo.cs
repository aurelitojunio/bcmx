using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IRobo
    {
        ICabeca Cabeca { get; set; }
        IBracoEsquerdo BracoEsquerdo { get; set; }
        IBracoDireito BracoDireito { get; set; }
    }
}
