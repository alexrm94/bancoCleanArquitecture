using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Application.DTOs
{
    public class ContaDTOPost
    {


        public decimal Saldo { get; set; }

        public string Tipo { get; set; }

        public int ClienteId { get; set; }



    }
}
