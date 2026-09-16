using System;

namespace SolicitacaoDeFerias.Domain
{
    public sealed class SolicitacaoCriadaEvent : IDomainEvent
    {
        public SolicitacaoCriadaEvent(Guid solicitacaoId, PeriodoFerias periodo)
        {
            SolicitacaoId = solicitacaoId;
            Periodo = periodo;
            OcorridoEm = DateTime.UtcNow;
        }

        public Guid SolicitacaoId { get; }
        public PeriodoFerias Periodo { get; }
        public DateTime OcorridoEm { get; }
    }
}