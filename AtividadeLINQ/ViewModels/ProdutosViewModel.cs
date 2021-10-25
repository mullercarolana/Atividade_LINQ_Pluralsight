using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AtividadeLINQ.Models;
using AtividadeLINQ.Repositorios;

namespace AtividadeLINQ.ViewModels
{
    public class ProdutosViewModel
    {
        public ProdutosViewModel()
        {
            Produtos = ProdutosRepositorio.ObterTodos();

            Pedidos = PedidosRepositorio.ObterTodos();
        }

        public List<Produto> Produtos { get; set; }
        public List<Pedido> Pedidos { get; set; }
        public bool UsarSintaxeQuery { get; set; } = true;
        public string ResultadoQuery { get; set; }

        #region Método Where - Expressão Where
        //<summary>
        //Filtra uma sequência de valores com base em um predicado.
        //</summary>
        public void ExpressaoWhere()
        {
            string pesquisa = "C";

            if (UsarSintaxeQuery)
            {
                // Sintaxe Query
                Produtos = (from prod in Produtos
                            where prod.Nome.StartsWith(pesquisa)
                            select prod).ToList();
            }
            else
            {
                // Método Query
                Produtos = Produtos.Where(p => p.Nome.StartsWith(pesquisa)).ToList();
            }

            ResultadoQuery = $"TOTAL DE PRODUTOS: {Produtos.Count}";
        }
        #endregion

        #region Método Where - Where de Dois Campos
        public void WhereDeDoisCampos()
        {
            string pesquisa = "C";
            decimal custo = 10;

            if (UsarSintaxeQuery)
            {
                // Sintaxe Query
                Produtos = (from prod in Produtos
                            where prod.Nome.StartsWith(pesquisa) && prod.CustoPadrao > custo
                            select prod).ToList();
            }
            else
            {
                // Método Query
                Produtos = Produtos.Where(p => p.Nome.StartsWith(pesquisa) && p.CustoPadrao > custo).ToList();
            }

            ResultadoQuery = $"TOTAL PRODUTOS: {Produtos.Count}";
        }
        #endregion

        #region Método PorCor - Extensão do Método Where
        public void ExtensaoDoMetodoWhere()
        {
            string pesquisa = "Preto";

            if (UsarSintaxeQuery)
            {
                // Sintaxe Query
                Produtos = (from prod in Produtos
                            select prod).PorCor(pesquisa.ToUpper()).ToList();
            }
            else
            {
                // Método Query
                Produtos = Produtos.PorCor(pesquisa).ToList();
            }

            ResultadoQuery = $"TOTAL DE PRODUTOS COM COR {pesquisa}: {Produtos.Count}";
        }
        #endregion

        #region Método First
        //<summary>
        //Retorna o primeiro elemento de uma sequência.
        //</summary>
        public void First()
        {
            string pesquisa = "Branco";
            Produto valor;

            try
            {
                if (UsarSintaxeQuery)
                {
                    // Sintaxe Query
                    valor = (from prod in Produtos
                             select prod).First(p => p.Cor == pesquisa.ToUpper());
                }
                else
                {
                    // Método Query
                    valor = Produtos.First(p => p.Cor == pesquisa.ToUpper());
                }

                ResultadoQuery = $"ENCONTRADO: {valor}";
            }
            catch
            {
                ResultadoQuery = $"NÃO ENCONTRADO";
            }

            Produtos.Clear();
        }

        #endregion

        #region Método FirstOrDefault
        //<summary>
        // Objetivo não é lançar uma excessão com try catch, mas sim verificar se há um valor nulo.
        //</summary>
        public void FirstOrDefault()
        {
            string pesquisa = "Laranja";
            Produto valor;

            if (UsarSintaxeQuery)
            {
                // Sintaxe Query
                valor = (from prod in Produtos
                         select prod).FirstOrDefault(p => p.Cor == pesquisa.ToUpper()); ;
            }
            else
            {
                // Método Query
                valor = Produtos.FirstOrDefault(p => p.Cor == pesquisa.ToUpper());
            }

            if (valor == null)
            {
                ResultadoQuery = $"NÃO ENCONTRADO";
            }
            else
            {
                ResultadoQuery = $"ENCONTRADO: {valor}";
            }

            Produtos.Clear();
        }
        #endregion

        #region Método Last
        //<summary>
        //Retorna o último elemento em uma sequência.
        //</summary>
        public void Last()
        {
            string pesquisa = "Laranja";
            Produto valor;

            try
            {
                if (UsarSintaxeQuery)
                {
                    // Sintaxe Query
                    valor = (from prod in Produtos
                             select prod).Last(p => p.Cor == pesquisa.ToUpper());
                }
                else
                {
                    // Método Query
                    valor = Produtos.Last(p => p.Cor == pesquisa.ToUpper());
                }

                ResultadoQuery = $"ENCONTRADO: {valor}";
            }
            catch
            {
                ResultadoQuery = $"NÃO ENCONTRADO";
            }

            Produtos.Clear();
        }
        #endregion

        #region Método LastOrDefault
        //<summary>
        //Retornará o último elemento de uma sequência ou um valor padrão se nenhum elemento for encontrado.
        //</summary>
        public void LastOrDefault()
        {
            string pesquisa = "Laranja";
            Produto valor;

            if (UsarSintaxeQuery)
            {
                valor = (from prod in Produtos
                         select prod).LastOrDefault(p => p.Cor == pesquisa.ToUpper());
            }
            else
            {
                valor = Produtos.LastOrDefault(p => p.Cor == pesquisa.ToUpper());
            }

            if (valor == null)
            {
                ResultadoQuery = $"NÃO ENCONTRADO";
            }
            else
            {
                ResultadoQuery = $"ENCONTRADO: {valor}";
            }

            Produtos.Clear();
        }
        #endregion

        #region Método Single
        //<summary>
        //Retorna um único elemento específico de uma sequência.
        //</summary>
        public void Single()
        {
            int pesquisa = 2;
            Produto valor;

            try
            {
                if (UsarSintaxeQuery)
                {
                    valor = (from prod in Produtos
                             select prod).Single(p => p.ProdutoId == pesquisa);
                }
                else
                {
                    valor = Produtos.Single(p => p.ProdutoId == pesquisa);
                }

                ResultadoQuery = $"ENCONTRADO: {valor}";
            }
            catch
            {
                ResultadoQuery = $"NÃO ENCONTRADO OU VÁRIOS ELEMENTOS ENCONTRADO";
            }

            Produtos.Clear();
        }
        #endregion

        #region Método SingleOrDefault
        //<summary>
        //Retornará um único elemento específico de uma sequência ou um valor padrão se nenhum elemento assim for encontrado.
        //</summary>
        public void SingleOrDefault()
        {
            int pesquisa = 5;
            Produto valor;

            try
            {
                if (UsarSintaxeQuery)
                {
                    valor = (from prod in Produtos
                             select prod).SingleOrDefault(p => p.ProdutoId == pesquisa);
                }
                else
                {
                    valor = Produtos.SingleOrDefault(p => p.ProdutoId == pesquisa);
                }

                if (valor == null)
                {
                    ResultadoQuery = $"NÃO ENCONTRADO";
                }
                else
                {
                    ResultadoQuery = $"ENCONTRADO: {valor}";
                }
            }
            catch
            {
                ResultadoQuery = $"VÁRIOS ELEMENTOS ENCONTRADO";
            }

            Produtos.Clear();
        }
        #endregion

        #region Método ForEach
        public void ForEach()
        {
            if (UsarSintaxeQuery)
            {
                Produtos = (from prod in Produtos
                            let tmp = prod.ComprimentoDoNome = prod.Nome.Length
                            select prod).ToList();
            }
            else
            {
                Produtos.ForEach(p => p.ComprimentoDoNome = p.Nome.Length);
            }

            ResultadoQuery = $"TOTAL DE PRODUTOS: {Produtos.Count}";
        }
        #endregion

        #region Método ForEach - Método de Chamada
        //<summary>
        //Esse método passa em cada objeto Produto para o método VendasPorProdutos()
        //No método VendasPorProdutos(), é calculado o total de vendas para casa produto
        //O total é colocado na propriedade ResultadoQuery de cada objeto Produto
        //</summary>
        public void MétodoDeChamadaForEach()
        {
            if (UsarSintaxeQuery)
            {
                Produtos = (from prod in Produtos
                            let tmp = prod.VendasTotais = VendasPorProdutos(prod)
                            select prod).ToList();
            }
            else
            {
                Produtos.ForEach(prod => prod.VendasTotais = VendasPorProdutos(prod));
            }

            ResultadoQuery = $"TOTAL DE PRODUTOS: {Produtos.Count}";
        }

        private decimal VendasPorProdutos(Produto prod)
        {
            return Pedidos.Where(venda => venda.ProdutoId == prod.ProdutoId).Sum(venda => venda.ValorTotalPedido);
        }
        #endregion

        #region Método Take
        //<Ssummary>
        //Use Take() para selecionar um especifico número de itens do inicio de uma coleção (SELECT TOP 10)
        //Orderby vai ordernar em order alfabética
        //</summary>
        public void Take()
        {
            if (UsarSintaxeQuery)
            {
                Produtos = (from prod in Produtos
                            orderby prod.Nome
                            select prod).Take(5).ToList();
            }
            else
            {
                Produtos = Produtos.OrderBy(prod => prod.Nome).Take(5).ToList();
            }

            ResultadoQuery = $"TOTAL DE PRODUTOS: {Produtos.Count}";
        }
        #endregion

        #region Método TakeWhile
        public void TakeWhile()
        {
            if (UsarSintaxeQuery)
            {
                Produtos = (from prod in Produtos
                            orderby prod.Nome
                            select prod).TakeWhile(prod => prod.Nome.StartsWith("B")).ToList();
            }
            else
            {
                Produtos = Produtos.OrderBy(prod => prod.Nome).TakeWhile(prod => prod.Nome.StartsWith("B")).ToList();
            }

            ResultadoQuery = $"TOTAL DE PRODUTOS: {Produtos.Count}";
        }
        #endregion

        #region Método Skip
        //<summary>
        //Use Skip () para pular além de um número especificado de itens desde o início de uma coleção
        //</summary>
        public void Skip()
        {
            if (UsarSintaxeQuery)
            {
                Produtos = (from prod in Produtos
                            orderby prod.Nome
                            select prod).Skip(10).ToList();
            }
            else
            {
                Produtos = Produtos.OrderBy(prod => prod.Nome).Skip(10).ToList();
            }

            ResultadoQuery = $"TOTAL DE PRODUTOS: {Produtos.Count}";
        }
        #endregion

        #region Método SkipWhile
        //<summary>
        //Ignora elementos em uma sequência, contanto que uma condição especificada seja verdadeira e retorne os elementos restantes.
        //</summary>
        public void SkipWhile()
        {
            if (UsarSintaxeQuery)
            {
                Produtos = (from prod in Produtos
                            orderby prod.Nome
                            select prod).SkipWhile(prod => prod.Nome.StartsWith("B")).ToList();
            }
            else
            {
                Produtos = Produtos.OrderBy(prod => prod.Nome).SkipWhile(prod => prod.Nome.StartsWith("B")).ToList();
            }

            ResultadoQuery = $"TOTAL DE PRODUTOS: {Produtos.Count}";
        }
        #endregion

        #region Método Distinct
        //<summary>
        //Operador Distinct() encontra todos os valores únicos em uma coleção
        //</summary>
        public void Distinct()
        {
            List<string> cores;

            if (UsarSintaxeQuery)
            {
                //Sintaxe Query
                cores = (from prod in Produtos
                         select prod.Cor).Distinct().ToList();
            }
            else
            {
                // Sintaxe Método
                cores = Produtos.Select(prod => prod.Cor).Distinct().ToList();
            }

            //Para cada cor em cores = construir uma sequência de cores distintas
            foreach (var cor in cores)
            {
                Console.WriteLine($"COR: {cor}");
            }

            Console.WriteLine($"TOTAL DE CORES: {cores.Count}");

            //Limpar Produtos
            Produtos.Clear();
        }
        #endregion

        #region Método All
        //<summary>
        //Use All () para ver se todos os itens em uma coleção atendem a uma condição especificada
        //</summary>
        public void All()
        {
            string pesquisa = "A";
            bool valor;

            if (UsarSintaxeQuery)
            {
                valor = (from prod in Produtos
                         select prod).All(prod => prod.Nome.Contains(pesquisa));
            }
            else
            {
                valor = Produtos.All(prod => prod.Nome.Contains(pesquisa));
            }

            ResultadoQuery = $"TODAS AS PROPRIEDADES DO NOME CONTÊM UM '{pesquisa}': {valor}";

            Produtos.Clear();
        }
        #endregion

        #region Método Any
        //<summary>
        //Determina se qualquer elemento de uma sequência IQueryable<T> existe ou atende a uma condição.
        //</summary>
        public void Any()
        {
            string pesquisa = "F";
            bool valor;

            if (UsarSintaxeQuery)
            {
                valor = (from prod in Produtos
                         select prod).Any(prod => prod.Nome.Contains(pesquisa));
            }
            else
            {
                valor = Produtos.Any(prod => prod.Nome.Contains(pesquisa));
            }

            ResultadoQuery = $"ALGUMA PROPRIEDADES DO NOME CONTÊM UM '{pesquisa}': {valor}";

            Produtos.Clear();
        }
        #endregion

        #region Contagem LINQ
        //<summary>
        //Use o operador LINQ Contains() para ver se uma coleção contém um valor específico
        //</summary>
        public void LINQContains()
        {
            bool valor;
            var numeros = new List<int> { 1, 2, 3, 4, 5 };

            if (UsarSintaxeQuery)
            {
                valor = (from num in numeros
                         select num).Contains(4);
            }
            else
            {
                valor = numeros.Contains(4);
            }

            ResultadoQuery = $"ESSE NÚMERO CONTÉM NA COLEÇÃO? {valor}";

            Produtos.Clear();
        }
        #endregion

        #region Método LINQ Contains - Usando Comparador
        public void LINQContainsUsingComparer()
        {
            int pesquisa = 10;
            bool valor;

            var comparadorProdId = new ComparadorProduto();
            var prodEncontrado = new Produto { ProdutoId = pesquisa };

            if (UsarSintaxeQuery)
            {
                valor = (from prod in Produtos
                         select prod).Contains(prodEncontrado, comparadorProdId);
            }
            else
            {
                valor = Produtos.Contains(prodEncontrado, comparadorProdId);
            }

            ResultadoQuery = $"ID DO PRODUTO: {pesquisa} - ESTÁ NA COLEÇÃO DE PRODUTOS? {valor}";

            Produtos.Clear();
        }
        #endregion

        #region Método SequenceEqual - Sequência Igual de Inteiros
        //<summary>
        //Método SequenceEqual() = compara duas coleções diferentes para ver se são iguais.
        //Ao usar tipos de dados simples, como int, string, uma comparação direta entre os valores é realizada.
        //</summary>
        public void SequenceEqualIntegers()
        {
            //Criação de duas listas de inteiros
            var lista1 = new List<int> { 1, 2, 3, 4, 5 };
            var lista2 = new List<int> { 5, 2, 3, 4, 5 };
            bool valor;

            if (UsarSintaxeQuery)
            {
                valor = (from num in lista1
                         select num).SequenceEqual(lista2);
            }
            else
            {
                valor = lista1.SequenceEqual(lista2);
            }

            if (valor)
            {
                ResultadoQuery = "LISTAS SÃO IGUAIS";
            }
            else
            {
                ResultadoQuery = "LISTAS NÃO SÃO IGUAIS";
            }

            // Limpar Listas
            Produtos.Clear();
        }
        #endregion

        #region Método SequenceEqual - Sequência Igual de Produtos
        //<summary>
        //Ao usar uma coleção de objetos, o método SequenceEqual() realiza uma comparação para ver se as duas referências de objeto apontam para o mesmo objeto.
        //</summary>
        public void SequenceEqualProducts()
        {
            // Criação de 2 listas de produtos
            var lista1 = new List<Produto> {
            new Produto { ProdutoId = 1, Nome = "Produto 1" },
            new Produto { ProdutoId = 2, Nome = "Produto 2" },
            };

            var lista2 = new List<Produto> {
            new Produto { ProdutoId = 1, Nome = "Produto 1" },
            new Produto { ProdutoId = 2, Nome = "Produto 2" },
            };

            bool valor;

            if (UsarSintaxeQuery)
            {
                valor = (from prod in lista1
                         select prod).SequenceEqual(lista2);
            }
            else
            {
                valor = lista1.SequenceEqual(lista2);
            }

            if (valor)
            {
                ResultadoQuery = "LISTAS SÃO IGUAIS";
            }
            else
            {
                ResultadoQuery = "LISTAS NÃO SÃO IGUAIS";
            }

            // Limpar Listas
            Produtos.Clear();
        }
        #endregion

        #region Método SequenceEqual - Sequência igual usando comparador
        //<summary>
        //Use uma classe EqualityComparer (Igualdade de Comparação) para determinar se os objetos são os mesmos com base nos valores nas propriedades
        //</summary>
        public void SequenceEqualUsingComparer()
        {
            var comparadorProd = new ComparadorProduto();
            List<Produto> lista1 = ProdutosRepositorio.ObterTodos();
            List<Produto> lista2 = ProdutosRepositorio.ObterTodos();
            bool valor;

            //Método RemoverAt() para remover um elemento da 'lista1' para tornar as coleções diferentes
            lista1.RemoveAt(0);

            if (UsarSintaxeQuery)
            {
                valor = (from prod in lista1
                         select prod).SequenceEqual(lista2, comparadorProd);
            }
            else
            {
                valor = lista1.SequenceEqual(lista2, comparadorProd);
            }

            if (valor)
            {
                ResultadoQuery = "LISTAS SÃO IGUAIS";
            }
            else
            {
                ResultadoQuery = "LISTAS NÃO SÃO IGUAIS";
            }

            // Limpar Listas
            Produtos.Clear();
        }
        #endregion

        #region Método Except - Exceção de Inteiros
        //<summary>
        //Método Except() encontra todos os valores em uma lista que não estão na outra lista.
        //</summary>
        public void ExceptIntegers()
        {
            List<int> excecao;
            var lista1 = new List<int> { 1, 2, 3, 4 };
            var lista2 = new List<int> { 3, 4, 5 };

            if (UsarSintaxeQuery)
            {
                excecao = (from num in lista1
                           select num).Except(lista2).ToList();
            }
            else
            {
                excecao = lista1.Except(lista2).ToList();
            }

            //Empty = Representa a string vazia. Este campo é só de leitura.
            ResultadoQuery = string.Empty;
            foreach (var item in excecao)
            {
                ResultadoQuery += "NÚMERO: " + item + Environment.NewLine;
            }

            //Limpar Lista
            Produtos.Clear();
        }
        #endregion

        #region Método Except - Exceção
        //<summary>
        //Método Except() encontra todos os produtos em uma lista que não estão na outra lista usando uma classe comparadora.
        //</summary>
        public void Except()
        {
            var comparadorProd = new ComparadorProduto();
            List<Produto> lista1 = ProdutosRepositorio.ObterTodos();
            List<Produto> lista2 = ProdutosRepositorio.ObterTodos();

            // Remova todos os produtos com COR = "LARANJA" de 'list2'
            // Para nos dar uma diferença nas duas listas
            lista2.RemoveAll(prod => prod.Cor == "LARANJA");

            if (UsarSintaxeQuery)
            {
                Produtos = (from prod in lista1
                            select prod).Except(lista2, comparadorProd).ToList();
            }
            else
            {
                Produtos = lista1.Except(lista2, comparadorProd).ToList();
            }

            ResultadoQuery = $"TOTAL DE PRODUTOS: {Produtos.Count}";
        }
        #endregion

        #region Método Intersect - Cruzar Informações
        //<summary>
        //Método Intersect() encontra todos os produtos que são comuns entre duas coleções usando uma classe comparadora.
        //Vai listar nesse contexto todos os produtos com as cores que não foram removidos no RemoveAll().
        //</summary>
        public void Intersect()
        {
            var comparadorProd = new ComparadorProduto();
            //Carregar todos os dados do produto nas listas
            List<Produto> lista1 = ProdutosRepositorio.ObterTodos();
            List<Produto> lista2 = ProdutosRepositorio.ObterTodos();

            //Remove os produtos "BRANCOS" da lista1
            lista1.RemoveAll(prod => prod.Cor == "BRANCO");
            //Remove os produtos "PRETO" da lista2
            lista2.RemoveAll(prod => prod.Cor == "PRETO");

            if (UsarSintaxeQuery)
            {
                Produtos = (from prod in lista1
                            select prod).Intersect(lista2, comparadorProd).ToList();
            }
            else
            {
                Produtos = lista1.Intersect(lista2, comparadorProd).ToList();
            }

            ResultadoQuery = $"TOTAL DE PRODUTOS: {Produtos.Count}";
        }
        #endregion

        #region Método Union - União
        //<summary>
        //Método Union() combina duas listas, mas pula duplicadas usando uma classe comparadora.
        //É como o operador UNION SQL.
        //</summary>
        public void Union()
        {
            var comparadorProd = new ComparadorProduto();
            //Carregar todos os dados do produto nas listas
            List<Produto> lista1 = ProdutosRepositorio.ObterTodos();
            List<Produto> lista2 = ProdutosRepositorio.ObterTodos();

            if (UsarSintaxeQuery)
            {
                Produtos = (from prod in lista1
                            select prod).Union(lista2, comparadorProd).OrderBy(prod => prod.Nome).ToList();
            }
            else
            {
                Produtos = lista1.Union(lista2, comparadorProd).OrderBy(prod => prod.Nome).ToList();
            }

            ResultadoQuery = $"TOTAL DE PRODUTOS: {Produtos.Count}";
        }
        #endregion

        #region Método Concat - União de Duas Listas
        //<summary>
        // Método LINQ Concat() combina duas listas e NÃO verifica se há duplicadas.
        // É como o operador UNION ALL SQL.
        //</summary>
        public void LINQConcat()
        {
            //Carregar todos os dados do produto nas listas
            List<Produto> lista1 = ProdutosRepositorio.ObterTodos();
            List<Produto> lista2 = ProdutosRepositorio.ObterTodos();

            if (UsarSintaxeQuery)
            {
                Produtos = (from prod in lista1
                            select prod).Concat(lista2).OrderBy(prod => prod.Nome).ToList();
            }
            else
            {
                Produtos = lista1.Concat(lista2).OrderBy(prod => prod.Nome).ToList();
            }

            ResultadoQuery = $"TOTAL DE PRODUTOS: {Produtos.Count}";
        }
        #endregion

        #region Método Inner Join
        //<summary>
        //Junte-se a uma coleção de detalhes do pedido de vendas com produtos em uma classe anônima
        //</summary>
        public void InnerJoin()
        {
            var sb = new StringBuilder();
            int contagem = 0;

            if (UsarSintaxeQuery)
            {
                var consulta = (from prod in Produtos
                                join ped in Pedidos
                                on prod.ProdutoId equals ped.ProdutoId
                                select new
                                {
                                    prod.ProdutoId,
                                    prod.Nome,
                                    prod.Cor,
                                    prod.CustoPadrao,
                                    prod.PrecoVenda,
                                    prod.Tamanho,
                                    ped.PedidoVendaId,
                                    ped.PedidoQuantidade,
                                    ped.PrecoUnitario,
                                    ped.ValorTotalPedido
                                });

                foreach (var item in consulta)
                {
                    contagem++;

                    sb.AppendLine("DETALHES DO PEDIDO........................:");
                    sb.AppendLine($"PEDIDO VENDA: {item.PedidoVendaId}");
                    sb.AppendLine($"PRODUTO ID: {item.ProdutoId}");
                    sb.AppendLine($"PRODUTO NOME: {item.Nome}");
                    sb.AppendLine($"TAMANHO: {item.Tamanho}");
                    sb.AppendLine($"QUANTIDADE PEDIDO: {item.PedidoQuantidade}");
                    sb.AppendLine($"TOTAL: {item.ValorTotalPedido:c}");
                    sb.AppendLine();
                }
            }
            else
            {
                var consulta = Produtos.Join(Pedidos, prod => prod.ProdutoId,
                    ped => ped.ProdutoId,
                    (prod, ped) => new
                    {
                        prod.ProdutoId,
                        prod.Nome,
                        prod.Cor,
                        prod.CustoPadrao,
                        prod.PrecoVenda,
                        prod.Tamanho,
                        ped.PedidoVendaId,
                        ped.PedidoQuantidade,
                        ped.PrecoUnitario,
                        ped.ValorTotalPedido
                    });
                foreach (var item in consulta)
                {
                    contagem++;
                    sb.AppendLine("DETALHES DO PEDIDO........................:");
                    sb.AppendLine($"PEDIDO VENDA: {item.PedidoVendaId}");
                    sb.AppendLine($"PRODUTO ID: {item.ProdutoId}");
                    sb.AppendLine($"PRODUTO NOME: {item.Nome}");
                    sb.AppendLine($"TAMANHO: {item.Tamanho}");
                    sb.AppendLine($"QUANTIDADE PEDIDO: {item.PedidoQuantidade}");
                    sb.AppendLine($"TOTAL: {item.ValorTotalPedido:c}");
                    sb.AppendLine();
                }
            }

            ResultadoQuery = sb.ToString() + Environment.NewLine + "TOTAL DE VENDAS: " + contagem.ToString();
            Produtos.Clear();
        }
        #endregion

        #region Método Inner Join - Dois Campos
        //<summary>
        //Junte uma coleção de detalhes do pedido de vendas (Pedidos) com produtos (Produto) usando dois campos
        //</summary>
        public void InnerJoinTwoFields()
        {
            short qtd = 1;
            int contagem = 0;

            var sb = new StringBuilder();

            if (UsarSintaxeQuery)
            {
                var consulta = (from prod in Produtos
                                join ped in Pedidos on
                                new { prod.ProdutoId, Quantidade = qtd }
                                equals
                                new { ped.ProdutoId, Quantidade = ped.PedidoQuantidade }
                                select new
                                {
                                    prod.ProdutoId,
                                    prod.Nome,
                                    prod.Cor,
                                    prod.CustoPadrao,
                                    prod.PrecoVenda,
                                    prod.Tamanho,
                                    ped.PedidoVendaId,
                                    ped.PedidoQuantidade,
                                    ped.PrecoUnitario,
                                    ped.ValorTotalPedido
                                });

                foreach (var item in consulta)
                {
                    contagem++;
                    sb.AppendLine("DETALHES DO PEDIDO........................:");
                    sb.AppendLine($"PEDIDO VENDA: {item.PedidoVendaId}");
                    sb.AppendLine($"PRODUTO ID: {item.ProdutoId}");
                    sb.AppendLine($"PRODUTO NOME: {item.Nome}");
                    sb.AppendLine($"TAMANHO: {item.Tamanho}");
                    sb.AppendLine($"QUANTIDADE PEDIDO: {item.PedidoQuantidade}");
                    sb.AppendLine($"TOTAL: {item.ValorTotalPedido:c}");
                    sb.AppendLine();
                }
            }
            else
            {
                var consulta = Produtos.Join(Pedidos,
                    prod => new { prod.ProdutoId, Quantidade = qtd },
                    ped => new { ped.ProdutoId, Quantidade = ped.PedidoQuantidade },
                    (prod, ped) => new
                    {
                        prod.ProdutoId,
                        prod.Nome,
                        prod.Cor,
                        prod.CustoPadrao,
                        prod.PrecoVenda,
                        prod.Tamanho,
                        ped.PedidoVendaId,
                        ped.PedidoQuantidade,
                        ped.PrecoUnitario,
                        ped.ValorTotalPedido
                    });

                foreach (var item in consulta)
                {
                    contagem++;
                    sb.AppendLine("DETALHES DO PEDIDO........................:");
                    sb.AppendLine($"PEDIDO VENDA: {item.PedidoVendaId}");
                    sb.AppendLine($"PRODUTO ID: {item.ProdutoId}");
                    sb.AppendLine($"PRODUTO NOME: {item.Nome}");
                    sb.AppendLine($"TAMANHO: {item.Tamanho}");
                    sb.AppendLine($"QUANTIDADE PEDIDO: {item.PedidoQuantidade}");
                    sb.AppendLine($"TOTAL: {item.ValorTotalPedido:c}");
                    sb.AppendLine();
                }
            }

            ResultadoQuery = sb.ToString() + Environment.NewLine + "TOTAL DE VENDAS: " + contagem.ToString();
            Produtos.Clear();
        }
        #endregion

        #region Método GroupJoin
        //<summary>
        //Use GroupJoin para criar um novo objeto com uma coleção de vendas para cada produto.
        //A palavra-chave 'into' permite que você coloque as vendas em uma variável de 'vendas' que pode ser usado para recuperar todas as vendas
        //de um produto específico.
        //</summary>
        public void GroupJoin()
        {
            var sb = new StringBuilder(15);
            IEnumerable<ProdutoVendas> agrupado;

            if (UsarSintaxeQuery)
            {
                agrupado = (from prod in Produtos
                            join ped in Pedidos
                            on prod.ProdutoId equals ped.ProdutoId
                            into ped
                            select new ProdutoVendas
                            {
                                Produtos = prod,
                                Pedidos = ped
                            });
            }
            else
            {
                agrupado = Produtos.GroupJoin(Pedidos,
                    prod => prod.ProdutoId,
                    ped => ped.ProdutoId,
                    (prod, ped) => new ProdutoVendas
                    {
                        Produtos = prod,
                        Pedidos = ped.ToList()
                    });
            }

            //Faça um loop em cada produto
            foreach (var pv in agrupado)
            {
                sb.AppendLine($"PRODUTO: {pv.Produtos}");

                //Percorra as vendas deste produto
                if (pv.Pedidos.Count() > 0)
                {
                    sb.AppendLine("**** VENDAS ****");
                    foreach (var venda in pv.Pedidos)
                    {
                        sb.AppendLine($"     PEDIDO VENDA ID: {venda.PedidoVendaId}");
                        sb.AppendLine($"     QUANTIDADE: {venda.PedidoQuantidade}");
                        sb.AppendLine($"     TOTAL: {venda.ValorTotalPedido}");
                    }
                }
                else
                {
                    sb.AppendLine($"**** NÃO HÁ VENDAS POR PRODUTO ****");
                }
                sb.AppendLine("");
            }

            ResultadoQuery = sb.ToString();
            Produtos.Clear();
        }
        #endregion

        #region Método LeftOuterJoin
        //<summary>
        //Execute uma junção à esquerda entre Produtos e Pedidos usando DefaultIfEmpty() e SelectMany()
        //Método DefaultIfEmpty(): Retornará os elementos em uma sequência ou uma coleção de singletons com valor padrão se a sequência estiver vazia.
        //Método SelectMany(): Projeta cada elemento de uma sequência em um IEnumerable<T> e combina as sequências resultantes em uma sequência de tipo
        //IQueryable<T>.
        // ? = se a variável de interválo estiver vazia, vai fornecer um retorno nulo.
        //</summary>
        public void LeftOuterJoin()
        {
            var sb = new StringBuilder();
            int contagem = 0;

            if (UsarSintaxeQuery)
            {
                var consulta = (from prod in Produtos
                                join ped in Pedidos
                                on prod.ProdutoId equals ped.ProdutoId
                                into peds
                                from ped in peds.DefaultIfEmpty()
                                select new
                                {
                                    prod.ProdutoId,
                                    prod.Nome,
                                    prod.Cor,
                                    prod.CustoPadrao,
                                    prod.PrecoVenda,
                                    prod.Tamanho,
                                    ped?.PedidoVendaId,
                                    ped?.PedidoQuantidade,
                                    ped?.PrecoUnitario,
                                    ped?.ValorTotalPedido
                                }).OrderBy(pp => pp.Nome);

                foreach (var item in consulta)
                {
                    contagem++;
                    sb.AppendLine("DETALHES DO PEDIDO........................:");
                    sb.AppendLine($"PRODUTO NOME: {item.Nome} ({item.ProdutoId})");
                    sb.AppendLine($"PEDIDO ID: {item.PedidoVendaId}");
                    sb.AppendLine($"TAMANHO: {item.Tamanho}");
                    sb.AppendLine($"QUANTIDADE PEDIDO: {item.PedidoQuantidade}");
                    sb.AppendLine($"TOTAL: {item.ValorTotalPedido:c}");
                    sb.AppendLine();
                }
            }
            else
            {
                var consulta = Produtos.SelectMany(ped => Pedidos.Where(p => ped.ProdutoId == p.ProdutoId).DefaultIfEmpty(),
                    (prod, ped) => new
                    {
                        prod.ProdutoId,
                        prod.Nome,
                        prod.Cor,
                        prod.CustoPadrao,
                        prod.PrecoVenda,
                        prod.Tamanho,
                        ped?.PedidoVendaId,
                        ped?.PedidoQuantidade,
                        ped?.PrecoUnitario,
                        ped?.ValorTotalPedido
                    }).OrderBy(pp => pp.Nome);

                foreach (var item in consulta)
                {
                    contagem++;
                    sb.AppendLine("DETALHES DO PEDIDO........................:");
                    sb.AppendLine($"PRODUTO NOME: {item.Nome} ({item.ProdutoId})");
                    sb.AppendLine($"PEDIDO ID: {item.PedidoVendaId}");
                    sb.AppendLine($"TAMANHO: {item.Tamanho}");
                    sb.AppendLine($"QUANTIDADE PEDIDO: {item.PedidoQuantidade}");
                    sb.AppendLine($"TOTAL: {item.ValorTotalPedido:c}");
                    sb.AppendLine();
                }
            }

            ResultadoQuery = sb.ToString() + Environment.NewLine + "TOTAL DE VENDAS: " + contagem.ToString();
            Produtos.Clear();
        }
        #endregion

        #region Método GroupBy
        //<summary>
        //IGrouping<> = Representa uma coleção de objetos que têm uma chave comum (nesse contexto é tamanho).
        //</summary>
        public void GroupBy()
        {
            var sb = new StringBuilder();
            IEnumerable<IGrouping<string, Produto>> grupoTamanho;

            if (UsarSintaxeQuery)
            {
                grupoTamanho = (from prod in Produtos
                                orderby prod.Tamanho
                                group prod by prod.Tamanho);
            }
            else
            {
                grupoTamanho = Produtos.OrderBy(prod => prod.Tamanho).GroupBy(prod => prod.Tamanho);
            }

            foreach (var grupo in grupoTamanho)
            {
                sb.AppendLine("------------------------------------------------");
                sb.AppendLine($"  ****TAMANHO: {grupo.Key}   TOTAL: {grupo.Count()}****");

                foreach (var prod in grupo)
                {
                    sb.AppendLine($"  PRODUTO ID: {prod.ProdutoId}");
                    sb.AppendLine($"  NOME: {prod.Nome}");
                    sb.AppendLine($"  COR: {prod.Cor}");
                    sb.AppendLine();
                }
            }

            ResultadoQuery = sb.ToString();
            Produtos.Clear();
        }
        #endregion

        #region Método GroupBy - Into e Select
        //<summary>
        //Agrupe produtos por propriedade de tamanho usando 'into' e 'select'.
        //Método OrdenBy() é opcional.
        //</summary>
        public void GroupByIntoSelect()
        {
            var sb = new StringBuilder();
            IEnumerable<IGrouping<string, Produto>> grupoTamanho;

            if (UsarSintaxeQuery)
            {
                grupoTamanho = (from prod in Produtos
                                orderby prod.Tamanho
                                group prod by prod.Tamanho into tamanhos
                                select tamanhos);
            }
            else
            {
                grupoTamanho = Produtos.OrderBy(prod => prod.Tamanho).GroupBy(prod => prod.Tamanho);
            }

            foreach (var grupo in grupoTamanho)
            {
                sb.AppendLine("------------------------------------------------");
                sb.AppendLine($"  ****TAMANHO: {grupo.Key}   TOTAL: {grupo.Count()}****");

                foreach (var prod in grupo)
                {
                    sb.AppendLine($"  PRODUTO ID: {prod.ProdutoId}");
                    sb.AppendLine($"  NOME: {prod.Nome}");
                    sb.AppendLine($"  COR: {prod.Cor}");
                    sb.AppendLine();
                }
            }

            ResultadoQuery = sb.ToString();
            Produtos.Clear();
        }
        #endregion

        #region Método GroupByOrderByKey
        public void GroupByOrderByKey()
        {
            var sb = new StringBuilder();
            IEnumerable<IGrouping<string, Produto>> grupoTamanho;

            if (UsarSintaxeQuery)
            {
                grupoTamanho = (from prod in Produtos
                                group prod by prod.Tamanho into tamanhos
                                orderby tamanhos.Key
                                select tamanhos);
            }
            else
            {
                grupoTamanho = Produtos.GroupBy(prod => prod.Tamanho).OrderBy(tamanhos => tamanhos.Key).Select(tamanhos => tamanhos);
            }

            foreach (var grupo in grupoTamanho)
            {
                sb.AppendLine("------------------------------------------------");
                sb.AppendLine($"  ****TAMANHO: {grupo.Key}   TOTAL: {grupo.Count()}****");

                foreach (var prod in grupo)
                {
                    sb.AppendLine($"  PRODUTO ID: {prod.ProdutoId}");
                    sb.AppendLine($"  NOME: {prod.Nome}");
                    sb.AppendLine($"  COR: {prod.Cor}");
                    sb.AppendLine();
                }
            }

            ResultadoQuery = sb.ToString();
            Produtos.Clear();
        }
        #endregion

        #region Método GroupBy - Where
        //<summary>
        //Simula uma cláusula HAVING em SQL.
        //</summary>
        public void GroupByWhere()
        {
            var sb = new StringBuilder();
            IEnumerable<IGrouping<string, Produto>> grupoTamanho;

            if (UsarSintaxeQuery)
            {
                grupoTamanho = (from prod in Produtos
                                group prod by prod.Tamanho into tamanhos
                                where tamanhos.Count() > 3
                                select tamanhos);
            }
            else
            {
                grupoTamanho = Produtos.GroupBy(prod => prod.Tamanho).Where(tamanhos => tamanhos.Count() > 3).Select(tamanhos => tamanhos);
            }

            foreach (var grupo in grupoTamanho)
            {
                sb.AppendLine("------------------------------------------------");
                sb.AppendLine($"  ****TAMANHO: {grupo.Key}   TOTAL: {grupo.Count()}****");

                foreach (var prod in grupo)
                {
                    sb.AppendLine($"  PRODUTO ID: {prod.ProdutoId}");
                    sb.AppendLine($"  NOME: {prod.Nome}");
                    sb.AppendLine($"  COR: {prod.Cor}");
                    sb.AppendLine();
                }
            }

            ResultadoQuery = sb.ToString();
            Produtos.Clear();
        }
        #endregion

        #region GroupedSubquery
        //<summary>
        //Agrupe as vendas por PedidoVendaId, adicione produtos em um novo objeto de pedido de vendas usando uma subconsulta.
        //</summary>
        public void GroupedSubquery()
        {
            var sb = new StringBuilder();
            IEnumerable<VendaProdutos> vendasGrupo;

            if (UsarSintaxeQuery)
            {
                vendasGrupo = (from ped in Pedidos
                               group ped by ped.PedidoVendaId into peds
                               select new VendaProdutos
                               {
                                   PedidoVendaId = peds.Key,
                                   Produtos = (from prod in Produtos
                                               join ped in Pedidos on prod.ProdutoId equals ped.ProdutoId
                                               where ped.PedidoVendaId == peds.Key
                                               select prod).ToList()
                               });
            }
            else
            {
                vendasGrupo = Pedidos.GroupBy(ped => ped.PedidoVendaId)
                    .Select(peds => new VendaProdutos
                    {
                        PedidoVendaId = peds.Key,
                        Produtos = Produtos.Join(peds,
                                             prod => prod.ProdutoId,
                                             peds => peds.ProdutoId,
                                             (prod, peds) => prod).ToList()
                    });
            }

            foreach (var venda in vendasGrupo)
            {
                sb.AppendLine("------------------------------------------------");
                sb.AppendLine($"  **** VENDA ID: {venda.PedidoVendaId} ****");

                if (venda.Produtos.Count() > 0)
                {
                    foreach (var prod in venda.Produtos)
                    {
                        sb.AppendLine($"  PRODUTO ID: {prod.ProdutoId}");
                        sb.AppendLine($"  NOME: {prod.Nome}");
                        sb.AppendLine($"  COR: {prod.Cor}");
                        sb.AppendLine();
                    }
                }
                else
                {
                    sb.AppendLine($"  PRODUTO ID NÃO ENCONTRADO POR ESSA VENDA.");
                }

            }

            ResultadoQuery = sb.ToString();
            Produtos.Clear();
        }
        #endregion

        #region Métodos GroupBy e FirstOrDefault - Para Usar Distinções por Cor
        public void DistinctUsingGroupByFirstOrDefault()
        {
            List<string> cores;

            if (UsarSintaxeQuery)
            {
                cores = (from prod in Produtos
                         group prod by prod.Cor into grupoCores
                         select grupoCores.FirstOrDefault().Cor).ToList();
            }
            else
            {
                cores = Produtos.GroupBy(prod => prod.Cor).Select(grupoCores => grupoCores.FirstOrDefault().Cor).ToList();
            }

            foreach (var cor in cores)
            {
                Console.WriteLine($"COR: {cor}");
            }
            Console.WriteLine($"TOTAL DE CORES: {cores.Count}");

            Produtos.Clear();
        }
        #endregion

        #region Método Count
        public void Count()
        {
            int valor;

            if (UsarSintaxeQuery)
            {
                valor = (from prod in Produtos
                         select prod).Count();
            }
            else
            {
                valor = Produtos.Count();
            }

            ResultadoQuery = $"TOTAL DE PRODUTOS = {valor}";

            Produtos.Clear();
        }
        #endregion

        #region Método Count - Com filtragem
        public void CountFiltered()
        {
            string pesquisa = "LARANJA";
            int valor;

            if (UsarSintaxeQuery)
            {
                valor = (from prod in Produtos
                         select prod).Count(prod => prod.Cor == pesquisa);
            }
            else
            {
                valor = Produtos.Count(prod => prod.Cor == pesquisa);
            }

            ResultadoQuery = $"TOTAL DE PRODUTOS COM COR '{pesquisa}' = {valor}";

            Produtos.Clear();
        }
        #endregion

        #region Método Minimun - Mínimo
        public void Minimun()
        {
            decimal? valor;

            if (UsarSintaxeQuery)
            {
                valor = (from prod in Produtos
                         select prod.PrecoVenda).Min();
            }
            else
            {
                valor = Produtos.Min(prod => prod.PrecoVenda);
            }

            if (valor.HasValue)
            {
                ResultadoQuery = $"PREÇO MÍNIMO DE VENDA = {valor.Value:c}";
            }
            else
            {
                ResultadoQuery = $"NÃO HÁ PREÇO MÍNIMO DE VENDAS.";
            }

            Produtos.Clear();
        }
        #endregion

        #region Método Maximun - Máximo
        public void Maximun()
        {
            decimal? valor;

            if (UsarSintaxeQuery)
            {
                valor = (from prod in Produtos
                         select prod.PrecoVenda).Max();
            }
            else
            {
                valor = Produtos.Max(prod => prod.PrecoVenda);
            }

            if (valor.HasValue)
            {
                ResultadoQuery = $"PREÇO MÁXIMO DE VENDA = {valor.Value:c}";
            }
            else
            {
                ResultadoQuery = $"NÃO HÁ PREÇO DE VENDAS.";
            }

            Produtos.Clear();
        }
        #endregion

        #region Método Average - Média
        public void Average()
        {
            decimal? valor;

            if (UsarSintaxeQuery)
            {
                valor = (from prod in Produtos
                         select prod.PrecoVenda).Average();
            }
            else
            {
                valor = Produtos.Average(prod => prod.PrecoVenda);
            }

            if (valor.HasValue)
            {
                ResultadoQuery = $"PREÇO MÉDIO DE VENDA = {valor.Value:c}";
            }
            else
            {
                ResultadoQuery = $"NÃO HÁ PREÇOS MÉDIOS DE VENDAS.";
            }

            Produtos.Clear();
        }
        #endregion

        #region Método Sum - Soma
        public void Sum()
        {
            decimal? valor;

            if (UsarSintaxeQuery)
            {
                valor = (from prod in Produtos
                         select prod.PrecoVenda).Sum();
            }
            else
            {
                valor = Produtos.Sum(prod => prod.PrecoVenda);
            }

            if (valor.HasValue)
            {
                ResultadoQuery = $"TOTAL PREÇO DE VENDA = {valor.Value:c}";
            }
            else
            {
                ResultadoQuery = $"NÃO HÁ PREÇO DE VENDAS.";
            }

            Produtos.Clear();
        }
        #endregion

        #region Método Aggregate - Sum
        public void AggregateSum()
        {
            decimal? valor = 0;

            if (UsarSintaxeQuery)
            {
                valor = (from prod in Produtos
                         select prod).Aggregate(0M, (sum, prod) => sum += prod.PrecoVenda);
            }
            else
            {
                valor = Produtos.Aggregate(0M, (sum, prod) => sum += prod.PrecoVenda);
            }

            if (valor.HasValue)
            {
                ResultadoQuery = $"TOTAL DE TODOS OS PREÇOS DE VENDAS = {valor.Value:c}";
            }
            else
            {
                ResultadoQuery = $"NÃO HÁ LISTAS DE PREÇOS DE VENDAS.";
            }

            Produtos.Clear();
        }
        #endregion

        #region Método Aggregate - Custom
        //<summary>
        //Simula o método Sum() utilizando o método Aggregate()
        //</summary>
        public void AggregateCustom()
        {
            decimal? valor = 0;

            if (UsarSintaxeQuery)
            {
                valor = (from ped in Pedidos
                         select ped).Aggregate(0M, (sum, ped) => sum += (ped.PedidoQuantidade * ped.PrecoUnitario));
            }
            else
            {
                valor = Pedidos.Aggregate(0M, (sum, ped) => sum += (ped.PedidoQuantidade * ped.PrecoUnitario));
            }

            if (valor.HasValue)
            {
                ResultadoQuery = $"TOTAL DE TODOS OS PREÇOS DE VENDAS = {valor.Value:c}";
            }
            else
            {
                ResultadoQuery = $"NÃO HÁ LISTAS DE PREÇOS DE VENDAS.";
            }

            Produtos.Clear();
        }
        #endregion

        #region Método Aggregate - Usando Grupos
        //<summary>
        //Agrupe os produtos por propriedade de tamanho e calcule os preços mínimo / máximo / médio.
        //</summary>
        public void AggregateUsingGrouping()
        {
            var sb = new StringBuilder();

            if (UsarSintaxeQuery)
            {
                var estatisticas = (from prod in Produtos
                                    group prod by prod.Tamanho into grupoTamanho
                                    where grupoTamanho.Count() > 0
                                    select new
                                    {
                                        Tamanho = grupoTamanho.Key,
                                        TotalProdutos = grupoTamanho.Count(),
                                        Maximo = grupoTamanho.Max(s => s.PrecoVenda),
                                        Minimo = grupoTamanho.Min(s => s.PrecoVenda),
                                        Media = grupoTamanho.Average(s => s.PrecoVenda)
                                    }
                                    into resultado
                                    orderby resultado.Tamanho
                                    select resultado);

                foreach (var estatica in estatisticas)
                {
                    sb.AppendLine($"  **TAMANHO: {estatica.Tamanho}  CONTAGEM: {estatica.TotalProdutos}**");
                    sb.AppendLine($"  MÍNIMO: {estatica.Minimo:c}");
                    sb.AppendLine($"  MÁXIMO: {estatica.Maximo:c}");
                    sb.AppendLine($"  MÉDIA: {estatica.Media:c}");
                    sb.AppendLine("----------------------------------------");
                }
            }
            else
            {
                var estatisticas = Produtos.GroupBy(ped => ped.Tamanho)
                                    .Where(grupoTamanho => grupoTamanho.Count() > 0)
                                    .Select(grupoTamanho => new
                                    {
                                        Tamanho = grupoTamanho.Key,
                                        TotalProdutos = grupoTamanho.Count(),
                                        Maximo = grupoTamanho.Max(g => g.PrecoVenda),
                                        Minimo = grupoTamanho.Min(g => g.PrecoVenda),
                                        Media = grupoTamanho.Average(g => g.PrecoVenda)
                                    })
                                    .OrderBy(resultado => resultado.Tamanho)
                                    .Select(resultado => resultado);

                foreach (var estatica in estatisticas)
                {
                    sb.AppendLine($"  **TAMANHO: {estatica.Tamanho}  CONTAGEM: {estatica.TotalProdutos}**");
                    sb.AppendLine($"  MÍNIMO: {estatica.Minimo:c}");
                    sb.AppendLine($"  MÁXIMO: {estatica.Maximo:c}");
                    sb.AppendLine($"  MÉDIA: {estatica.Media:c}");
                    sb.AppendLine("----------------------------------------");
                }
            }

            ResultadoQuery = sb.ToString();
            Produtos.Clear();
        }
        #endregion

        #region Método Aggregate - Grupo Mais Eficiente
        public void AggregateUsingGroupingMoreEfficient()
        {
            var sb = new StringBuilder();

            //Apenas sintaxe método
            var estatisticas =
              Produtos.GroupBy(ped => ped.Tamanho)
                      .Where(grupoTamanho => grupoTamanho.Count() > 0)
                      .Select(grupoTamanho =>
                      {
                          var resultado = grupoTamanho.Aggregate(new ProdutoEstatisticas(),
                                    (acm, prod) => acm.Acumular(prod),
                                    cm => cm.ComputarMedia());

                          return new
                          {
                              Tamanho = grupoTamanho.Key,
                              resultado.TotalProdutos,
                              resultado.Minimo,
                              resultado.Maximo,
                              resultado.Media
                          };
                      })
                      .OrderBy(resultado => resultado.Tamanho)
                      .Select(resultado => resultado);

            foreach (var estatica in estatisticas)
            {
                sb.AppendLine($"  **TAMANHO: {estatica.Tamanho}  CONTAGEM: {estatica.TotalProdutos}**");
                sb.AppendLine($"  MÍNIMO: {estatica.Minimo:c}");
                sb.AppendLine($"  MÁXIMO: {estatica.Maximo:c}");
                sb.AppendLine($"  MÉDIA: {estatica.Media:c}");
                sb.AppendLine("----------------------------------------");
            }

            ResultadoQuery = sb.ToString();
            Produtos.Clear();
        }
        #endregion

    }
}
