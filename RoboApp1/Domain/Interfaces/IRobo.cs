using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IRobo
    {
        ICabeca Cabeca { get; set; }
        IBraco BracoEsquerdo { get; set; }
        IBraco BracoDireito { get; set; }
    }
}
