using FabricaDeSoftware.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FabricaDeSoftware.Domain
{

    public class Configuracao : Entity
    {
        public Guid IdUsuario { get; private set; }
        public decimal DistanciaMaximaEntrePilares { get; private set; }
        public decimal DistanciaMaximaDaReta { get; private set; }
        public DateTime DataAlteracao { get; private set; }

        protected Configuracao() { }

        public Configuracao(Guid idUsuario, decimal distanciaMaximaEntrePilares, decimal distanciaMaximaDaReta)
        {
            IdUsuario = idUsuario;
            DistanciaMaximaEntrePilares = distanciaMaximaEntrePilares;
            DistanciaMaximaDaReta = distanciaMaximaDaReta;

            Validar();
        }

        public void Validar()
        {
            Validacoes.ValidarSeIgual(Id, Guid.Empty, "O Id da entidade não pode ser vazio");
            Validacoes.ValidarSeIgual(IdUsuario, Guid.Empty, "O Id do usuario não pode ser vazio");
            Validacoes.ValidarSeMenorIgualQue(DistanciaMaximaEntrePilares, 0, "A distância máxima ente pilares não pode ser menor ou igual a zero");
            Validacoes.ValidarSeMenorIgualQue(DistanciaMaximaDaReta, 0, "A distância máxima da reta não pode ser menor ou igual a zero");
        }
    }
}
