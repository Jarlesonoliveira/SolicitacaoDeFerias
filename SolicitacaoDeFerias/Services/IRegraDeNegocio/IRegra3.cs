using System;

namespace SolicitacaoDeFerias.Services
{
    public interface IRegra3
    {
        bool DataDeInicioAntecedeFeriado(DateTime dataInicioFerias, bool valida);
    }
}
