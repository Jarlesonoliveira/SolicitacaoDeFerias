using System;

namespace SolicitacaoDeFerias.Services
{
    public interface IRegra5
    {
        bool FeriasDentroDoLimiteDeDias(DateTime dataInicial, DateTime dataFinal, int limiteDeDias, bool valida);
    }
}
