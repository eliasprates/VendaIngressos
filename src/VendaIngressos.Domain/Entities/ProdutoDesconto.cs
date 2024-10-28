using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendaIngressos.Domain.Entities
{
    public class ProdutoDesconto
    {
        public int Codigo { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }

        public int ProdutoCodigo { get; set; }
        public Produto Produto { get; set; }
    }

}
