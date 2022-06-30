using Projeto.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Models
{
    public class RoboBatalhaLeve : Robo
    {
        public RoboBatalhaLeve(string nome) : base(nome)
        {
        }

        public override int CausarDano()
        {
            if (Status == EStatus.Ligado) return 10;
            return 0;
        }
    }
}
