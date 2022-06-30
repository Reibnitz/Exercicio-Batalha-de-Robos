using Projeto.Enum;
using Projeto.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Models
{
    public abstract class Robo : IRobo
    {
        public virtual string Nome { get; protected set; }
        public virtual int PontosDeVida { get; protected set; }
        public virtual EStatus Status { get; protected set; }

        public Robo(string nome)
        {
            Nome = nome;
            PontosDeVida = 100;
            Status = EStatus.Desligado;
        }

        public void Iniciar()
        {
            Status = EStatus.Ligado;
        }

        public void Parar()
        {
            Status = EStatus.Desligado;
        }

        public abstract int CausarDano();

        public void ReduzirPontosDeVida(int dano)
        {
            if (PontosDeVida - dano <= 0)
            {
                PontosDeVida = 0;
                Status = EStatus.Destruido;
            }
            else
            {
                PontosDeVida -= dano;
            }
        }
    }
}
