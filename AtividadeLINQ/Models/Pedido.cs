using System.Text;

namespace AtividadeLINQ.Models
{
    public class Pedido
    {
        public int PedidoVendaId { get; set; }
        public short PedidoQuantidade { get; set; }
        public int ProdutoId { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal ValorTotalPedido { get; set; }

        #region ToString
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"PEDIDO ID: {PedidoVendaId}");
            sb.AppendLine($"PRODUTO ID: {ProdutoId}");
            sb.AppendLine($"QUANTIDADE: {PedidoQuantidade}");
            sb.AppendLine($"PREÇO UNITÁRIO: {PrecoUnitario}");
            sb.AppendLine($"TOTAL: {ValorTotalPedido}");

            return sb.ToString();
        }
        #endregion
    }
}
