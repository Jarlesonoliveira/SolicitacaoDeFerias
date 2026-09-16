using System;
using System.Collections.Generic;

namespace SolicitacaoDeFerias.Domain
{
    public sealed class SolicitacaoFerias
    {
        private readonly List<IDomainEvent> _eventos = new List<IDomainEvent>();

        public SolicitacaoFerias(DateTime dataInicial, DateTime dataFinal)
            : this(new PeriodoFerias(dataInicial, dataFinal))
        {
        }

        public SolicitacaoFerias(PeriodoFerias periodo)
        {
            Periodo = periodo ?? throw new ArgumentNullException(nameof(periodo));
            Id = Guid.NewGuid();
            _eventos.Add(new SolicitacaoCriadaEvent(Id, Periodo));
        }

        public Guid Id { get; }
        public PeriodoFerias Periodo { get; }
        public DateTime DataInicial => Periodo.DataInicial;
        public DateTime DataFinal => Periodo.DataFinal;
        public int DuracaoEmDias => Periodo.DuracaoEmDias;
        public IReadOnlyCollection<IDomainEvent> Eventos => _eventos.AsReadOnly();
    }
}