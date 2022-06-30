using Projeto.Enum;

namespace Projeto.Interfaces
{
    public interface IRobo
    {
        public string Nome { get; }
        public int PontosDeVida { get; }
        public EStatus Status { get; }

        public void Iniciar();
        public void Parar();
        public abstract int CausarDano();
        public void ReduzirPontosDeVida(int dano);
    }
}
