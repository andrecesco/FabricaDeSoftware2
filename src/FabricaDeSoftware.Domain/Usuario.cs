using FabricaDeSoftware.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FabricaDeSoftware.Domain
{

    public class Usuario : Entity
    {
        public string NomeCompleto { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime DataAlteracao { get; private set; }

        protected Usuario() { }

        public Usuario(string nomeCompleto, string email, string telefone)
        {
            NomeCompleto = nomeCompleto;
            Email = email;
            Telefone = telefone;

            Validar();
        }

        public void Validar()
        {
            Validacoes.ValidarSeIgual(Id, Guid.Empty, "O Id da entidade não pode ser vazio");
            Validacoes.ValidarSeVazio(NomeCompleto, "O nome completo não pode ser vazio");
            Validacoes.ValidarSeVazio(Email, "O e-mail não pode ser vazio");
            Validacoes.ValidarSeVazio(Telefone, "O telefone não pode ser vazio");
        }
    }
}
