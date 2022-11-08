using Domain.Enums;
using Application.Interfaces;

namespace Domain.Entities
{
    public class BracoEsquerdoService : IBracoService
    {
        
        public BracoEsquerdoService()
        {
            Repousar();
        }
        public ContracaoCotovelo Cotovelo { get; set; }
        public int Pulso { get; set; }
        public void ContrairCotovelo(ContracaoCotovelo cotovelo)
        {
            this.Cotovelo = cotovelo;
        }
        public void GirarPulso(int angulo)
        {
            this.Pulso = angulo;
        }
        public void Repousar()
        {
            this.Pulso = 0;
            this.Cotovelo = ContracaoCotovelo.Em_Repouso;
        }
    }
}