using System;

namespace SolicitacaoDeFerias.Domain
{
    public interface IDomainEvent
    {
        DateTime OcorridoEm { get; }
    }
}