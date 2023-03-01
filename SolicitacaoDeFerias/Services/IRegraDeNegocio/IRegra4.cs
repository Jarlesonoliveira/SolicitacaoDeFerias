using System;

namespace SolicitacaoDeFerias.Services
{
    public interface IRegra4
    {
        bool QuarentaDiasDeAntecedencia(DateTime dataInicial, DateTime dataFinal, bool valida);
    }
}
