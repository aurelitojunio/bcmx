using Application.Interfaces;

namespace Domain.Entities
{
    public class RoboService : IRoboService
    {
        public ICabecaService Cabeca { get; set; }
        public IBracoService BracoEsquerdo { get; set; }
        public IBracoService BracoDireito { get; set; }    
        public RoboService(ICabecaService cabeca, IBracoService bracoEsquerdo, IBracoService bracoDireito)
        {
            Cabeca = cabeca;
            BracoEsquerdo = bracoEsquerdo;
            BracoDireito = bracoDireito;
        }
    }
}
