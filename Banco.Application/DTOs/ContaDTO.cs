  using Banco.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Banco.Application.DTOs
{
    [Table("Contas")]
    public class ContaDTO
    {
        [Key]
        public int ContaId { get; set; }

        [Required(ErrorMessage = "Informe o saldo")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1, 99999999.99, ErrorMessage = "O preço deve estar entre 1 e 99999999,99")]
        public decimal Saldo { get; set; }

        public string Tipo { get; set; }

        public int ClienteId { get; set; }

        
    }

}
