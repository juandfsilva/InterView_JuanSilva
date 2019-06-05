using System;
using System.Collections.Generic;
using System.Text;

namespace InterView_JuanSilva
{
    public class Piloto
    {
        public int numeroPiloto { get; set; }
        public string nomePiloto { get; set; }
        public int? voltaMaisRapida { get; set; }
        public TimeSpan? tempoVoltaMaisRapida { get; set; }
        public int voltaAtual { get; set; }
        public TimeSpan tempoTotalCorrida { get; set; }
        public decimal mediaVelocidadeTotal { get; set; }


        public static Dictionary<int, Piloto> GerarColecaoPiloto(string linha)
        {
            var linhaInput = LinhaInput.GerarLinhaInput(linha);

            Dictionary<int, Piloto> colecaoPiloto = new Dictionary<int, Piloto>();

            foreach (var dadosPiloto in linhaInput)
            {
                if (!colecaoPiloto.TryGetValue(dadosPiloto.numeroPiloto, out var piloto))
                {
                    piloto = new Piloto();
                    piloto.numeroPiloto = dadosPiloto.numeroPiloto;
                    piloto.nomePiloto = dadosPiloto.nomePiloto;

                    colecaoPiloto[dadosPiloto.numeroPiloto] = piloto;
                }

                piloto.AtualizarVolta(dadosPiloto);
            }

            return colecaoPiloto;
        }
        
        internal void AtualizarVolta(LinhaInput dadosPiloto)
        {
            voltaAtual = dadosPiloto.numeroVolta;
            tempoTotalCorrida += dadosPiloto.tempoVolta;

            if (tempoVoltaMaisRapida == null || tempoVoltaMaisRapida > dadosPiloto.tempoVolta)
            {
                tempoVoltaMaisRapida = dadosPiloto.tempoVolta;
                voltaMaisRapida = dadosPiloto.numeroVolta;
            }

            mediaVelocidadeTotal = (mediaVelocidadeTotal + dadosPiloto.velocidadeMedia) / voltaAtual;
        }
    }
}
