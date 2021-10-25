using System;
using System.Collections.Generic;
using System.Text;

namespace AtividadeLINQ.Models
{
    class ProdutoEstatisticas
    {
        public ProdutoEstatisticas()
        {
            Maximo = Decimal.MinValue;
            Minimo = Decimal.MaxValue;

            TotalProdutos = 0;
            Total = 0;
        }

        public int TotalProdutos { get; set; }
        public decimal Maximo { get; set; }
        public decimal Minimo { get; set; }
        public decimal Total { get; set; }
        public decimal Media { get; set; }

        public ProdutoEstatisticas Acumular(Produto prod)
        {
            // Incrementar o total de números por produtos
            TotalProdutos += 1;

            // Adiciona o total do preço de venda
            Total += prod.PrecoVenda;

            // Calcula o Max e Min
            Maximo = Math.Max(Maximo, prod.PrecoVenda);
            Minimo = Math.Min(Minimo, prod.PrecoVenda);

            return this;
        }

        public ProdutoEstatisticas ComputarMedia()
        {
            Media = Total / TotalProdutos;

            return this;
        }
    }
}
