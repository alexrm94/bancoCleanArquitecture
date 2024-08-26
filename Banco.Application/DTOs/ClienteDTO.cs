
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Banco.Application.DTOs
{
    [Table("Clientes")]
    public class ClienteDTO
    {
        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "O nome do cliente deve ser informado")]
        [Display(Name = "Nome do Cliente")]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2} caracteres")]
        public string Nome { get; set; }
       
    }
}
