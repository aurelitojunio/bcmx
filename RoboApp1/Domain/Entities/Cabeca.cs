using Domain.Enums;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class Cabeca : ICabeca
    {
        
        public Cabeca()
        {
            Repousar();
        }
        public RotacaoCabeca rotacao { get; set; }
        public InclinacaoCabeca inclinacao { get; set; }
        public void GirarCabeca(RotacaoCabeca angulo)
        {
            this.rotacao = angulo;
        }
        public void InclinarCabeca(InclinacaoCabeca inclinacao)
        {
            this.inclinacao = inclinacao;
        }
        public void Repousar()
        {
            this.rotacao = RotacaoCabeca.Em_Repouso;
            this.inclinacao = InclinacaoCabeca.Em_Repouso;
        }
    }
}