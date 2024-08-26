using Banco.Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Domain.Entities
{
    public sealed class Cliente
    {
        public Cliente() { }
        public Cliente(int id, string nome)
        {
            DomainExceptionValidation.When(id < 0, "valor de Id inválido.");
            ClienteId = id;
            ValidateDomain(nome);
        }

        public int ClienteId { get; private set; }

        public string Nome { get; private set; }
        public ICollection<Conta> Contas { get; set; }

        private void ValidateDomain(string nome)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
            "Nome inválido. O nome é obrigatório");

            Nome = nome;
        }

    }
}