using System.Collections.Generic;

namespace AtividadeLINQ.Models
{
    public partial class ProdutoVendas
    {
        public Produto Produtos { get; set; }
        public IEnumerable<Pedido> Pedidos { get; set; }
    }
}
