using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendaIngressos.Domain.Entities
{
    public class Produto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }

        public List<ProdutoDesconto> Descontos { get; set; }

        public Produto()
        {
            Descontos = new List<ProdutoDesconto>();
        }
    }

}
