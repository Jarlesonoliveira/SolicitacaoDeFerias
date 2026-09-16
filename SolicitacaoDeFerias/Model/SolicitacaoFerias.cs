using System;

namespace SolicitacaoDeFerias.Model
{
    public sealed class SolicitacaoFerias
    {
        public SolicitacaoFerias(DateTime dataInicial, DateTime dataFinal)
        {
            DataInicial = dataInicial.Date;
            DataFinal = dataFinal.Date;
        }

        public DateTime DataInicial { get; }
        public DateTime DataFinal { get; }
        public int DuracaoEmDias => (DataFinal - DataInicial).Days + 1;
    }
}