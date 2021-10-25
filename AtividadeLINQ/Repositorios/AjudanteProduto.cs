using System.Collections.Generic;
using System.Linq;
using AtividadeLINQ.Models;

namespace AtividadeLINQ.Repositorios
{
    // <summary>
    // Método de extensão personalizado que filtra a consulta por cor usando where e retorna uma lista de produtos.
    // </summary>
    public static class AjudanteProduto
    {
        public static IEnumerable<Produto> PorCor(this IEnumerable<Produto> consulta, string cor)
        {
            return consulta.Where(p => p.Cor == cor);
        }
    }
}
