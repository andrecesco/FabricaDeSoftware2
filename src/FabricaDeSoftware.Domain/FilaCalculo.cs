using FabricaDeSoftware.Core;
using FabricaDeSoftware.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FabricaDeSoftware.Domain
{
    public class FilaCalculo : Entity, IAggregateRoot
    {
        public Guid IdConfiguracao { get; private set; }
        public Guid IdUsuario { get; private set; }
        public decimal DistanciaDaReta { get; private set; }
        public int QuantidadeDePilares { get; private set; }
        public int QuantidadeDePilaresReforcados { get; private set; }
        public string PilaresComBaseReforcada { get; private set; }
        public decimal DistanciaEntreVaos { get; private set; }
        public DateTime DataCadastro { get; private set; }

        public Configuracao Configuracao { get; private set; }
        public Usuario Usuario { get; private set; }

        protected FilaCalculo() { }

        public FilaCalculo(Guid idConfiguracao, Guid idUsuario, decimal distanciaDaReta, int quantidadeDePilares, int quantidadeDePilaresReforcados, string pilaresComBaseReforcada, decimal distanciaEntreVaos)
        {
            IdConfiguracao = idConfiguracao;
            IdUsuario = idUsuario;
            DistanciaDaReta = distanciaDaReta;
            QuantidadeDePilares = quantidadeDePilares;
            QuantidadeDePilaresReforcados = quantidadeDePilaresReforcados;
            PilaresComBaseReforcada = pilaresComBaseReforcada;
            DistanciaEntreVaos = distanciaEntreVaos;
            DataCadastro = DateTime.Now;

            Validar();
        }



        public void Validar()
        {
            Validacoes.ValidarSeIgual(Id, Guid.Empty, "O Id da entidade não pode ser vazio");
            Validacoes.ValidarSeIgual(IdConfiguracao, Guid.Empty, "O Id da configuração não pode ser vazio");
            Validacoes.ValidarSeIgual(IdUsuario, Guid.Empty, "O Id do usuario não pode ser vazio");
            Validacoes.ValidarSeMenorIgualQue(DistanciaDaReta, 0, "A distância da reta não pode ser menor ou igual a zero");
        }
    }
}
