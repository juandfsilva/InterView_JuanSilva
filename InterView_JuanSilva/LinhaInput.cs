using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

namespace InterView_JuanSilva
{
    public class LinhaInput
    {
        public int numeroPiloto { get; set; }
        public string nomePiloto  { get; set; }
        public TimeSpan horaVolta { get; set; }
        public int numeroVolta { get; set; }
        public TimeSpan tempoVolta { get; set; }
        public decimal velocidadeMedia { get; set; }
        
        public static IEnumerable<LinhaInput> GerarLinhaInput(string nomeArquivo)
        {
            using (Stream entrada = File.Open(nomeArquivo, FileMode.Open))
            {
                using (StreamReader leitor = new StreamReader(entrada))
                {
                    string linha;
                    while ((linha = leitor.ReadLine()) != null)
                    {
                        yield return InterpretarLinha(linha);
                    }

                }
            }

        }

        internal static LinhaInput InterpretarLinha(string linha)
        {
            var corridaDados = linha.Split("\t");
            return new LinhaInput()
            {
                horaVolta = TimeSpan.ParseExact(corridaDados[0], "g", CultureInfo.InvariantCulture),
                numeroPiloto = int.Parse(corridaDados[1]),
                nomePiloto = corridaDados[2],
                numeroVolta = int.Parse(corridaDados[3]),
                tempoVolta = TimeSpan.ParseExact(corridaDados[4], @"m\:ss\.fff", CultureInfo.InvariantCulture),
                velocidadeMedia = decimal.Parse(corridaDados[5])
            };
        }
    }
}
