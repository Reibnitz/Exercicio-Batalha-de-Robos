using Projeto;
using Projeto.Factory;
using Projeto.Interfaces;
using Projeto.Models;
using Projeto.Services;

RoboFactory factory = new();

Console.WriteLine("########## Bem-vindo a Batalha de Robôs ##########");

Console.WriteLine("Escolha o tipo do primeiro competidor (leve / pesado):");
string? tipo1 = Convert.ToString(Console.ReadLine());

Console.WriteLine("Escolha o nome do primeiro competidor:");
string? nome1 = Convert.ToString(Console.ReadLine());

Console.WriteLine("Escolha o tipo do segundo competidor (leve / pesado):");
string? tipo2 = Convert.ToString(Console.ReadLine());

Console.WriteLine("Escolha o nome do segundo competidor:");
string? nome2 = Convert.ToString(Console.ReadLine());

RespostaService<IRobo> robo1 = factory.MakeRobo(tipo1, nome1);
RespostaService<IRobo> robo2 = factory.MakeRobo(tipo2, nome2);

Console.WriteLine("Defina o número de rodadas:");
int rodadas = Convert.ToInt32(Console.ReadLine());

if (robo1.Sucesso && robo2.Sucesso)
{
    Console.WriteLine("Pressione ENTER para começar a batalha!");
    Console.ReadLine();
    Console.Clear();

    PartidaBatalha.Batalhar(robo1, robo2, rodadas);
}

else
{
    if (!robo1.Sucesso) Console.WriteLine(robo1.MensagemErro);
    if (!robo2.Sucesso) Console.WriteLine(robo2.MensagemErro);
}