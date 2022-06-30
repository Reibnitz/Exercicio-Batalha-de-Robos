using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Services
{
    public class ResultadoService<T>
    {
        public T Vencedor { get; set; }
        public bool Empate { get; set; }
    }
}
