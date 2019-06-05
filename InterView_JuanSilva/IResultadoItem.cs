using System.Collections.Generic;

namespace InterView_JuanSilva
{
    internal interface IResultadoItem
    {
        void Executar(Dictionary<int, Piloto> colecaoPiloto);
    }
}