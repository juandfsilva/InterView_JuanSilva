using System;
using System.Collections.Generic;
using System.Linq;

namespace InterView_JuanSilva
{
    class Program
    {
        static IList<MenuItem> menuItems;
        
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                 throw new Exception("Você precisa informar o nome do arquivo");
            }

            var colecaoPiloto = Piloto.GerarColecaoPiloto(args[0]);

            IResultadoItem itemSelecionado;
            menuItems = MenuItem.GetMenuItems();

            while (true)
            {
                MenuItem.ImprimirMenuItems(menuItems);
                var opcao = Console.ReadLine();

                int.TryParse(opcao, out int valorOpcao);

                if (valorOpcao == 0)
                {
                    break;
                }

                if (valorOpcao > menuItems.Count)
                {
                    break;
                }

                itemSelecionado = Executar(valorOpcao, colecaoPiloto);
                Console.ReadKey();
            }       
        }        
        private static IResultadoItem Executar(int valorOpcao, Dictionary<int, Piloto> colecaoPiloto)
        {
            IResultadoItem itemSelecionado;
            MenuItem menuItem = menuItems[valorOpcao - 1];
            Type tipoClasse = menuItem.TipoClasse;
            itemSelecionado = (IResultadoItem)Activator.CreateInstance(tipoClasse);

            Console.WriteLine();
            string titulo = $"EXECUTANDO: {menuItem.Titulo}";
            Console.WriteLine(titulo);
            Console.WriteLine(new string('=', titulo.Length));

            itemSelecionado.Executar(colecaoPiloto);
            Console.WriteLine();
            Console.WriteLine("Tecle algo para continuar...");
            return itemSelecionado;
        }
    }
}
