using System;
using System.Collections.Generic;

namespace InterView_JuanSilva
{
    public class MenuItem
    {

        public string Titulo { get; set; }
        public Type TipoClasse { get; set; }
        public MenuItem()
        {
                
        }
        
        public MenuItem(string titulo, Type tipoClasse)
        {
            Titulo = titulo;
            TipoClasse = tipoClasse;
        }

        public static IList<MenuItem> GetMenuItems()
        {
            return new List<MenuItem>
            {
                new MenuItem("Resultado da Corrida", typeof(ResultadoCorrida)),
                new MenuItem("Melhor volta da Corrida", typeof(MelhorVoltaCorrida)),
                new MenuItem("Melhor volta de cada Piloto", typeof(MelhorVoltaPiloto))
            };
        }

        public static void ImprimirMenuItems(IList<MenuItem> menuItems)
        {
            int i = 1;
            Console.WriteLine("SELECIONE UMA OPÇÃO");
            Console.WriteLine("===================");
            Console.WriteLine("0 - Sair");
            foreach (var menuItem in menuItems)
            {
                Console.WriteLine((i++).ToString() + " - " + menuItem.Titulo);
            }
        }
    }
}