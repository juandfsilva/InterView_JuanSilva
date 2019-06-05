using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterView_JuanSilva
{
    public class ResultadoCorrida : IResultadoItem
    {
        
        public void Executar(Dictionary<int, Piloto> colecaoPiloto)
        {
            var pilotosPorOrdemDeChegada = colecaoPiloto.Values.OrderByDescending(p => p.voltaAtual)
                                            .ThenBy(p => p.tempoTotalCorrida);

            var tempoPrimeiroColocado = pilotosPorOrdemDeChegada.FirstOrDefault().tempoTotalCorrida;

            int posicao = 1;
            
            Console.WriteLine("{0,0} {1,-15} {2,-15} {3,-25} {4,-25} {5,-25} {6,-25}",
                               "Posição","Nº Piloto","Nome Piloto","Total de Voltas","Media de velocidada","Tempo total de prova","Diferença primeiro colocado");
            foreach (var x in pilotosPorOrdemDeChegada)
            {
                Console.WriteLine($"{posicao++}\t{x.numeroPiloto,-15}{x.nomePiloto,-25}{x.voltaAtual,-25}{Math.Round(x.mediaVelocidadeTotal,1),-20}{x.tempoTotalCorrida,10}{tempoPrimeiroColocado - x.tempoTotalCorrida,30}");
            }


        }
    }
}
