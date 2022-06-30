using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Services
{
    public static class PartidaBatalha
    {
        private static int LimiteDeRodadas;
        private static int RodadaAtual = 1;
        private static Robo[] Robos;


        public static void Batalhar(RespostaService<Robo> robo1, RespostaService<Robo> robo2, int limiteDeRodadas = 15)
        {
            LimiteDeRodadas = limiteDeRodadas;

            Robos = new Robo[]
            {
                robo1.Resposta,
                robo2.Resposta
            };

            Robos[0].Iniciar();
            Robos[1].Iniciar();

            CausarDanos();

            Resultado<Robo> resultado = DefinirResultado();
            ImprimirResultado(resultado);
        }

        private static void CausarDanos()
        {
            bool limiteAtingido = false;
            bool roboDestruido = false;

            while (!limiteAtingido && !roboDestruido)
            {
                int primeiro = SortearAtacante();
                int segundo = Math.Abs(primeiro - 1);

                int danoPrimeiro = Robos[primeiro].CausarDano();
                Robos[segundo].ReduzirPontosDeVida(danoPrimeiro);

                int danoSegundo = Robos[segundo].CausarDano();
                Robos[primeiro].ReduzirPontosDeVida(danoSegundo);

                ImprimirRodada(Robos[primeiro], Robos[segundo], danoPrimeiro, danoSegundo);

                RodadaAtual++;
                limiteAtingido = RodadaAtual > LimiteDeRodadas;
                roboDestruido = Robos[0].Status == EStatus.Destruido || Robos[1].Status == EStatus.Destruido;
            }

            return;
        }

        private static int SortearAtacante()
        {
            return new Random().Next(2);
        }

        private static void ImprimirRodada(Robo primeiro, Robo segundo, int danoPrimeiro, int danoSegundo)
        {
            Console.WriteLine($"------------- {RodadaAtual}ª Rodada -------------");
            switch (danoPrimeiro)
            {
                case > 0:
                    Console.WriteLine($"{primeiro.Nome} Ataca! Dano: {danoPrimeiro}");
                    break;
                case 0:
                    Console.WriteLine($"{primeiro.Nome} não pôde atacar nessa rodada");
                    break;
            }
            switch (danoSegundo)
            {
                case > 0:
                    Console.WriteLine($"{segundo.Nome} Ataca! Dano: {danoSegundo}");
                    break;
                case 0:
                    if (segundo.Status == EStatus.Destruido) Console.WriteLine($"{segundo.Nome} Foi destruído!");
                    else Console.WriteLine($"{segundo.Nome} não pôde atacar nessa rodada");
                    break;
            }

            Console.WriteLine($"\nPlacar: {Robos[0].Nome} [{Robos[0].PontosDeVida}HP] x [{Robos[1].PontosDeVida}HP] {Robos[1].Nome}\n");
        }

        private static Resultado<Robo> DefinirResultado()
        {
            Resultado<Robo> vencedor = new();

            if (RodadaAtual > LimiteDeRodadas && Robos[0].PontosDeVida == Robos[1].PontosDeVida)
            {
                vencedor.Empate = true;
                vencedor.Vencedor = null;
            }
            else
            {
                if (Robos[0].PontosDeVida == 0)
                    vencedor.Vencedor = Robos[1];
                else
                    vencedor.Vencedor = Robos[0];
            }

            return vencedor;
        }

        private static void ImprimirResultado(Resultado<Robo> resultado)
        {
            if (resultado.Empate)
                Console.WriteLine("####### EMPATE! OS DOIS PERDERAM #######");
            else
                Console.WriteLine($"####### O VENCEDOR É {resultado.Vencedor.Nome.ToUpper()} #######");
        }
    }
}
