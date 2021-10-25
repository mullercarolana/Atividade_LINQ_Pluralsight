using System;
using AtividadeLINQ.ViewModels;

namespace AtividadeLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instancia do ProdutosViewModel
            var vm = new ProdutosViewModel
            {
                UsarSintaxeQuery = true
            };

            //Chamada do método
            vm.GroupBy();

            //Display da Coleção de Produtos
            foreach (var item in vm.Produtos)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine(vm.ResultadoQuery);
        }
    }
}
