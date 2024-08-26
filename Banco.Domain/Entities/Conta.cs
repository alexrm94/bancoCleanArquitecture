using Banco.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Domain.Entities
{
    public class Conta
    {
        public Conta() { }
        public Conta(int id, string tipo)
        {
            DomainExceptionValidation.When(id < 0, "valor de Id inválido.");
            ContaId = id;
            ValidateDomain(tipo);
        }
        private void ValidateDomain(string tipo)
        {
            DomainExceptionValidation.When((tipo=="Conta Salário" || tipo == "Conta Corrente" || tipo == "Conta Popança"),
            "O tipo de conta deve ser Conta Salário, Conta Corrente, ou Conta Popança ");

            Tipo = tipo;
           
        }

        public int ContaId { get; private set; }
        public decimal Saldo { get; private set; }
        public string Tipo { get; private set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get;  set; }
        

    }
}
