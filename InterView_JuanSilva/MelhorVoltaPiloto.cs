using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterView_JuanSilva
{
    class MelhorVoltaPiloto : IResultadoItem
    {
        public void Executar(Dictionary<int, Piloto> colecaoPiloto)
        {
            var melhorVoltaPorPiloto = colecaoPiloto.Values.OrderBy(p => p.tempoVoltaMaisRapida);

            Console.WriteLine("{0,-10} {1,-15} {2,-15} ",
                               "Nº Piloto", "Nome Piloto", "Tempo melhor volta");

            foreach (var x in melhorVoltaPorPiloto)
            {
                Console.WriteLine($"{x.numeroPiloto,-15}{x.nomePiloto,-15}{x.tempoVoltaMaisRapida}");
            }
        }
    }
}
