using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendaIngressos.Application.DTOs.ProdutoReadDto;

namespace VendaIngressos.Application.DTOs.Produto
{
    public class ProdutoReadDto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
    }
}
