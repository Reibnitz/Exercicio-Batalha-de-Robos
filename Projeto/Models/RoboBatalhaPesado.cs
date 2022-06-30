using Projeto.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Models
{
    public class RoboBatalhaPesado : Robo
    {
        public RoboBatalhaPesado(string nome) : base(nome)
        {
        }

        public override int CausarDano()
        {
            switch (Status)
            {
                case EStatus.Ligado:
                    Status = EStatus.Aguardando;
                    return 20;
                case EStatus.Aguardando:
                    Status = EStatus.Ligado;
                    break;
            }

            return 0;
        }
    }
}
