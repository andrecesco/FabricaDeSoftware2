using FabricaDeSoftware.Core;
using FabricaDeSoftware.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FabricaDeSoftware.Domain
{
    public class Calculo : Entity, IAggregateRoot
    {
        public Guid IdConfiguracao { get; private set; }
        public Guid IdUsuario { get; private set; }
        public decimal DistanciaDaReta { get; private set; }
        public int QuantidadeDePilares { get; private set; }
        public int QuantidadeDePilaresReforcados { get; private set; }
        public string PilaresComBaseReforcada { get; private set; }
        public decimal DistanciaEntreVaos { get; private set; }

        public DateTime DataCadastro { get; private set; }
        public DateTime? DataDelecao { get; private set; }

        public Configuracao Configuracao { get; private set; }
        public Usuario Usuario { get; private set; }

        protected Calculo() { }

        public Calculo(Guid idConfiguracao, Guid idUsuario, decimal distanciaDaReta)
        {
            IdConfiguracao = idConfiguracao;
            IdUsuario = idUsuario;
            DistanciaDaReta = distanciaDaReta;
            DataCadastro = DateTime.Now;

            Validar();
        }

        public void AtualizarQuantidadeDePilares(int quantidadeDePilares)
        {
            Validacoes.ValidarSeMenorQue(quantidadeDePilares, 0, "A quantidade de pilares não pode ser menor do que zero");
            QuantidadeDePilares = quantidadeDePilares;
        }

        public void AtualizarDistanciaDosVaos(decimal distancaiEntreVaos)
        {
            Validacoes.ValidarSeMenorIgualQue(distancaiEntreVaos, 0, "A distância entre vãos não pode ser menor ou igual a zero");
            DistanciaEntreVaos = distancaiEntreVaos;
        }

        public void AtualizarPilaresComBaseReforcada(List<int> listaPilaresComBaseReforcada)
        {
            Validacoes.ValidarSeNulo(listaPilaresComBaseReforcada, "A lista de pilares com base reforçada não pode ser nula");
            QuantidadeDePilaresReforcados = listaPilaresComBaseReforcada.Count;
            PilaresComBaseReforcada = string.Join(",", listaPilaresComBaseReforcada);
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
