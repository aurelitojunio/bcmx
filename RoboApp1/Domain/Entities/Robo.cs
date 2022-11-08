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
        public IBracoEsquerdo BracoEsquerdo { get; set; }
        public IBracoDireito BracoDireito { get; set; }    
        public Robo(ICabeca cabeca, IBracoEsquerdo bracoEsquerdo, IBracoDireito bracoDireito)
        {
            Cabeca = cabeca;
            BracoEsquerdo = bracoEsquerdo;
            BracoDireito = bracoDireito;
        }
    }
}
