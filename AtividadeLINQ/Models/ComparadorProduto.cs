using System.Collections.Generic;

namespace AtividadeLINQ.Models
{
    public class ComparadorProduto : EqualityComparer<Produto>
    {
        //<summary>
        //Método Equals()
        //Determina se duas instâncias de objeto são iguais. O objeto a ser comparado com o objeto atual.
        //Compara cada propriedade com a outra para determinar a igualdade.
        //True se o objeto especificado for igual ao objeto atual; caso contrário, false.
        //</summary>
        public override bool Equals(Produto x, Produto y)
        {
            return (x.ProdutoId == y.ProdutoId &&
                x.Nome == y.Nome &&
                x.Cor == x.Cor &&
                x.Tamanho == x.Tamanho &&
                x.PrecoVenda == y.PrecoVenda &&
                x.CustoPadrao == y.CustoPadrao);
        }

        //<summary>
        //Método GetHashCode()
        //Código Hash = é um valor numérico que é usado para inserir e identificar um objeto em uma coleção baseada em hash.
        //Método fornece esse código hash para algoritmos que precisam de verificações rápidas de igualdade de objeto
        //</summary>
        public override int GetHashCode(Produto obj)
        {
            return obj.ProdutoId.GetHashCode();
        }
    }
}
