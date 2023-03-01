using System.Collections.Generic;
using System;

namespace SolicitacaoDeFerias.Services
{
    public interface IRegraDeNegocio
    
    {
        bool DataFinalMaiorQueDataInicio(DateTime dataInicial, DateTime dataFinal, bool valida);
        bool DiaDaSemanaLiberado(DateTime dataInicial, List<DayOfWeek> diasDaSemanaLiberados, bool valida);
        bool DataDeInicioAntecedeFeriado(DateTime dataInicioFerias, bool valida);
        bool QuarentaDiasDeAntecedencia(DateTime dataInicial, DateTime dataFinal, bool valida);
        bool FeriasDentroDoLimiteDeDias(DateTime dataInicial, DateTime dataFinal, int limiteDeDias, bool valida);
        bool FeriasDentroDoLimiteMinimoDeDias(DateTime dataInicial, DateTime dataFinal, int MinimoDezDias, bool valida);

    }
}