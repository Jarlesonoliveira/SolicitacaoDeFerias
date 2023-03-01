using System;

namespace SolicitacaoDeFerias.Services
{
    public interface IRegra1
    {
        bool DataFinalMaiorQueDataInicio(DateTime dataInicial, DateTime dataFinal, bool valida);
    }
}
