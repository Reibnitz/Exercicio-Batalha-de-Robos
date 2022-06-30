using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Services
{
    public class RespostaService<T>
    {
        public T Resposta { get; set; }
        public bool Sucesso { get; set; }
        public string MensagemErro { get; set; }
    }
}
