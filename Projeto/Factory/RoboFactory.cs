using Projeto.Models;
using Projeto.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Factory
{
    public class RoboFactory
    {
        public RespostaService<Robo> MakeRobo(string tipoRobo, string nomeRobo)
        {
            RespostaService<Robo> service = new();

            switch (tipoRobo)
            {
                case string tipo when tipo.ToLower().Contains("leve"):
                    service.Sucesso = true;
                    service.Resposta = new RoboBatalhaLeve(nomeRobo);
                    break;
                case string tipo when tipo.ToLower().Contains("pesado"):
                    service.Sucesso = true;
                    service.Resposta = new RoboBatalhaPesado(nomeRobo);
                    break;
                default:
                    service.Sucesso = false;
                    service.MensagemErro = "Tipo de robô inválido";
                    break;
            }

            return service;
        }
    }
}
