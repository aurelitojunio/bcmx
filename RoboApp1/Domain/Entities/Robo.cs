using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Robo : IRobo
    {
        public ICabeca Cabeca { get; set; }
        public IBraco BracoEsquerdo { get; set; }
        public IBraco BracoDireito { get; set; }    
        public Robo(ICabeca cabeca, IBraco bracoEsquerdo, IBraco bracoDireito)
        {
            Cabeca = cabeca;
            BracoEsquerdo = bracoEsquerdo;
            BracoDireito = bracoDireito;
        }
    }
}
