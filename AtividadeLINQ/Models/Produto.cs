using System.Text;

namespace AtividadeLINQ.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public string Cor { get; set; }
        public decimal CustoPadrao { get; set; }
        public decimal PrecoVenda { get; set; }
        public string Tamanho { get; set; }

        public int? ComprimentoDoNome { get; set; }
        public decimal? VendasTotais { get; set; }

        #region ToString()
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("---------------------------------------------");
            sb.AppendLine($"ID: {ProdutoId}");
            sb.AppendLine($"NOME: {Nome}");
            sb.AppendLine($"COR: {Cor}");
            sb.AppendLine($"TAMANHO: {Tamanho}");
            sb.AppendLine($"CUSTO PADRÃO: {CustoPadrao:c}");
            sb.AppendLine($"PREÇO DE VENDA: {PrecoVenda:c}");
            if (ComprimentoDoNome.HasValue)
            {
                sb.AppendLine($"COMPRIMENTO DO NOME: {ComprimentoDoNome}");
            }
            if (VendasTotais.HasValue)
            {
                sb.AppendLine($"VENDAS TOTAIS: {VendasTotais:c}");
            }

            return sb.ToString();
        }
        #endregion
    }
}
