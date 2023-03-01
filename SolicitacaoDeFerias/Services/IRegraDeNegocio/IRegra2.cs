using System;
using System.Collections.Generic;

namespace SolicitacaoDeFerias.Services
{
    public interface IRegra2
    {
        bool DiaDaSemanaLiberado(DateTime dataInicial, List<DayOfWeek> diasDaSemanaLiberados, bool valida);
    }
}
