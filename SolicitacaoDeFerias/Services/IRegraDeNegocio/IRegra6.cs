using System;

namespace SolicitacaoDeFerias.Services
{
    public interface IRegra6
    {
        bool FeriasDentroDoLimiteMinimoDeDias(DateTime dataInicial, DateTime dataFinal, int MinimoDezDias, bool valida);
    }
}
