using System;

namespace SolicitacaoDeFerias.Domain
{
    public sealed class PeriodoFerias : IEquatable<PeriodoFerias>
    {
        public PeriodoFerias(DateTime dataInicial, DateTime dataFinal)
        {
            DataInicial = dataInicial.Date;
            DataFinal = dataFinal.Date;

            if (DataFinal <= DataInicial)
            {
                throw new ArgumentException("A data final deve ser posterior à data inicial.");
            }
        }

        public DateTime DataInicial { get; }
        public DateTime DataFinal { get; }
        public int DuracaoEmDias => (DataFinal - DataInicial).Days + 1;

        public bool Equals(PeriodoFerias outro)
        {
            return outro != null && DataInicial == outro.DataInicial && DataFinal == outro.DataFinal;
        }

        public override bool Equals(object obj) => Equals(obj as PeriodoFerias);
        public override int GetHashCode() => DataInicial.GetHashCode() ^ DataFinal.GetHashCode();
    }
}