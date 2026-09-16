using SolicitacaoDeFerias.Model;
using System;
using System.Collections.Generic;

namespace SolicitacaoDeFerias.Services
{
    public sealed class ContextoDeValidacao
    {
        public ContextoDeValidacao(SolicitacaoFerias solicitacao, DateTime dataDaSolicitacao, IReadOnlyCollection<Feriado> feriados)
        {
            Solicitacao = solicitacao;
            DataDaSolicitacao = dataDaSolicitacao.Date;
            Feriados = feriados;
        }

        public SolicitacaoFerias Solicitacao { get; }
        public DateTime DataDaSolicitacao { get; }
        public IReadOnlyCollection<Feriado> Feriados { get; }
    }
}