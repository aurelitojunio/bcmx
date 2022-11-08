using Domain.Enums;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class BracoEsquerdo : IBracoEsquerdo
    {
        
        public BracoEsquerdo()
        {
            Repousar();
        }
        public ContracaoCotovelo Cotovelo { get; set; }
        public RotacaoPulso Pulso { get; set; }
        public void ContrairCotovelo(ContracaoCotovelo cotovelo)
        {
            this.Cotovelo = cotovelo;
        }
        public void GirarPulso(RotacaoPulso angulo)
        {
            this.Pulso = angulo;
        }
        public void Repousar()
        {
            this.Pulso = RotacaoPulso.Em_Repouso;
            this.Cotovelo = ContracaoCotovelo.Em_Repouso;
        }
    }
}