using System.Collections.Generic;
using AtividadeLINQ.Models;

namespace AtividadeLINQ.Repositorios
{
    public partial class PedidosRepositorio
    {
        public static List<Pedido> ObterTodos()
        {
            return new List<Pedido>
            {
                new Pedido
                {
                    PedidoVendaId = 100,
                    PedidoQuantidade = 1,
                    ProdutoId = 3,
                    PrecoUnitario = 30.00M,
                    ValorTotalPedido = 30.00M,
                },
                new Pedido
                {
                    PedidoVendaId = 100,
                    PedidoQuantidade = 1,
                    ProdutoId = 11,
                    PrecoUnitario = 60.00M,
                    ValorTotalPedido = 60.00M,
                },
                new Pedido
                {
                    PedidoVendaId = 101,
                    PedidoQuantidade = 2,
                    ProdutoId = 6,
                    PrecoUnitario = 30.00M,
                    ValorTotalPedido = 60.00M,
                },
                new Pedido
                {
                    PedidoVendaId = 102,
                    PedidoQuantidade = 3,
                    ProdutoId = 13,
                    PrecoUnitario = 23.00M,
                    ValorTotalPedido = 69.00M,
                },
                new Pedido
                {
                    PedidoVendaId = 103,
                    PedidoQuantidade = 1,
                    ProdutoId = 7,
                    PrecoUnitario = 55.00M,
                    ValorTotalPedido = 55.00M,
                },
                new Pedido
                {
                    PedidoVendaId = 103,
                    PedidoQuantidade = 1,
                    ProdutoId = 12,
                    PrecoUnitario = 180.00M,
                    ValorTotalPedido = 180.00M,
                },
            };
        }
    }
}
