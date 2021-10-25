using System.Collections.Generic;
using AtividadeLINQ.Models;

namespace AtividadeLINQ.Repositorios
{
    //Partial class = permite que uma única classe possa ser implementada em múltiplos arquivos com extensão .cs
    public partial class ProdutosRepositorio
    {
        public static List<Produto> ObterTodos()
        {
            return new List<Produto>
            {
                new Produto
                {
                    ProdutoId = 1,
                    Nome = "CAMISETA BASICA FEMININA",
                    Cor = "PRETO",
                    CustoPadrao = 15.00M,
                    PrecoVenda = 30.00M,
                    Tamanho = "P",
                },
                new Produto
                {
                    ProdutoId = 2,
                    Nome = "CAMISETA BASICA FEMININA",
                    Cor = "PRETO",
                    CustoPadrao = 15.00M,
                    PrecoVenda = 30.00M,
                    Tamanho = "M",
                },
                new Produto
                {
                    ProdutoId = 3,
                    Nome = "CAMISETA BASICA FEMININA",
                    Cor = "PRETO",
                    CustoPadrao = 15.00M,
                    PrecoVenda = 30.00M,
                    Tamanho = "G",
                },
                new Produto
                {
                    ProdutoId = 4,
                    Nome = "CAMISETA BABY LOOK FEMININA",
                    Cor = "BRANCO",
                    CustoPadrao = 15.00M,
                    PrecoVenda = 30.00M,
                    Tamanho = "P",
                },
                new Produto
                {
                    ProdutoId = 5,
                    Nome = "CAMISETA BABY LOOK FEMININA",
                    Cor = "BRANCO",
                    CustoPadrao = 15.00M,
                    PrecoVenda = 30.00M,
                    Tamanho = "M",
                },
                new Produto
                {
                    ProdutoId = 6,
                    Nome = "CAMISETA BABY LOOK FEMININA",
                    Cor = "BRANCO",
                    CustoPadrao = 15.00M,
                    PrecoVenda = 30.00M,
                    Tamanho = "G",
                },
                new Produto
                {
                    ProdutoId = 7,
                    Nome = "CAMISETA NARUTO FEMININA",
                    Cor = "LARANJA",
                    CustoPadrao = 20.00M,
                    PrecoVenda = 55.00M,
                    Tamanho = "P",
                },
                new Produto
                {
                    ProdutoId = 8,
                    Nome = "CAMISETA NARUTO FEMININA",
                    Cor = "LARANJA",
                    CustoPadrao = 20.00M,
                    PrecoVenda = 55.00M,
                    Tamanho = "M",
                },
                new Produto
                {
                    ProdutoId = 9,
                    Nome = "CAMISETA NARUTO FEMININA",
                    Cor = "LARANJA",
                    CustoPadrao = 20.00M,
                    PrecoVenda = 55.00M,
                    Tamanho = "G",
                },
                new Produto
                {
                    ProdutoId = 10,
                    Nome = "GUARDA CHUVA DRAGON BOLL",
                    Cor = "VERMELHO",
                    CustoPadrao = 10.50M,
                    PrecoVenda = 28.00M,
                    Tamanho = "U",
                },
                new Produto
                {
                    ProdutoId = 11,
                    Nome = "BONÉ MASCULINO DARK",
                    Cor = "PRETO",
                    CustoPadrao = 25.00M,
                    PrecoVenda = 60.00M,
                    Tamanho = "U",
                },
                new Produto
                {
                    ProdutoId = 12,
                    Nome = "MOCHILA ESCOLAR STRANGER THINGS",
                    Cor = "PRETO",
                    CustoPadrao = 60.00M,
                    PrecoVenda = 180.00M,
                    Tamanho = "U",
                },
                new Produto
                {
                    ProdutoId = 13,
                    Nome = "XICARA STRANGER THINGS",
                    Cor = "BRANCO",
                    CustoPadrao = 8.00M,
                    PrecoVenda = 23.00M,
                    Tamanho = "U",
                },
                new Produto
                {
                    ProdutoId = 14,
                    Nome = "XICARA DARK",
                    Cor = "PRETO",
                    CustoPadrao = 8.00M,
                    PrecoVenda = 23.00M,
                    Tamanho = "U",
                },
                new Produto
                {
                    ProdutoId = 15,
                    Nome = "XICARA NARUTO",
                    Cor = "LARANJA",
                    CustoPadrao = 8.00M,
                    PrecoVenda = 23.00M,
                    Tamanho = "U",
                },
            };
        }
    }
}
