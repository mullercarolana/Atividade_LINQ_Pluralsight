using System;
using System.Collections.Generic;
using System.Text;

namespace AtividadeLINQ.Models
{
    public partial class VendaProdutos
    {
        public int PedidoVendaId { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}
