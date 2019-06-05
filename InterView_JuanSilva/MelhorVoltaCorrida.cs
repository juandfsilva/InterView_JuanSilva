using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterView_JuanSilva
{
    class MelhorVoltaCorrida : IResultadoItem
    {
        public void Executar(Dictionary<int, Piloto> colecaoPiloto)
        {
            var melhorVolta = colecaoPiloto.Values.OrderBy(p => p.tempoVoltaMaisRapida);

            Console.WriteLine("{0,-10} {1,-15} {2,-15} ",
                               "Nº Piloto", "Nome Piloto", "Tempo melhor volta");

            Console.WriteLine($"{melhorVolta.FirstOrDefault().numeroPiloto,-15}{melhorVolta.FirstOrDefault().nomePiloto,-15}{melhorVolta.FirstOrDefault().tempoVoltaMaisRapida}");
        }
    }
}
