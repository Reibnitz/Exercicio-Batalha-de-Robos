using Projeto.Interfaces;
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
        public RespostaService<IRobo> MakeRobo(string tipoRobo, string nomeRobo)
        {
            RespostaService<IRobo> service = new();

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
                    service.MensagemErro = $"O tipo determinado para o robô {nomeRobo} é inválido";
                    break;
            }

            return service;
        }
    }
}
