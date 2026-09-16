using SolicitacaoDeFerias.Model;
using SolicitacaoDeFerias.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace SolicitacaoDeFerias.Test.Services
{
    public class RegraDeNegocioTests
    {
        [Fact]
        public void DeveAceitarTerçaFeiraComoDataInicial()
        {
            var contexto = CriarContexto(new DateTime(2026, 2, 17), new DateTime(2026, 2, 26));

            Assert.True(new RegraDiaInicialPermitido().Validar(contexto));
        }

        [Fact]
        public void DeveRejeitarInicioNoDiaAnteriorAoFeriado()
        {
            var contexto = CriarContexto(
                new DateTime(2026, 2, 16),
                new DateTime(2026, 2, 25),
                new Feriado(new DateTime(2026, 2, 17), "Feriado"));

            Assert.False(new RegraNaoAntecedeFeriado().Validar(contexto));
        }

        [Fact]
        public void DeveExigirPeloMenosQuarentaDiasDeAntecedencia()
        {
            var contexto = CriarContexto(
                new DateTime(2026, 2, 10),
                new DateTime(2026, 2, 19),
                dataDaSolicitacao: new DateTime(2026, 1, 1));

            Assert.True(new RegraAntecedenciaMinima().Validar(contexto));
        }

        [Fact]
        public void DeveCalcularDuracaoInclusiva()
        {
            var solicitacao = new SolicitacaoFerias(
                new DateTime(2026, 2, 16),
                new DateTime(2026, 2, 25));

            Assert.Equal(10, solicitacao.DuracaoEmDias);
            Assert.True(new RegraDuracaoMinima().Validar(CriarContexto(solicitacao)));
            Assert.True(new RegraDuracaoMaxima().Validar(CriarContexto(solicitacao)));
        }

        private static ContextoDeValidacao CriarContexto(
            DateTime dataInicial,
            DateTime dataFinal,
            Feriado feriado = null,
            DateTime? dataDaSolicitacao = null)
        {
            var feriados = feriado == null
                ? new List<Feriado>()
                : new List<Feriado> { feriado };

            return CriarContexto(
                new SolicitacaoFerias(dataInicial, dataFinal),
                feriados,
                dataDaSolicitacao ?? new DateTime(2026, 1, 1));
        }

        private static ContextoDeValidacao CriarContexto(SolicitacaoFerias solicitacao)
        {
            return CriarContexto(solicitacao, new List<Feriado>(), new DateTime(2026, 1, 1));
        }

        private static ContextoDeValidacao CriarContexto(
            SolicitacaoFerias solicitacao,
            IReadOnlyCollection<Feriado> feriados,
            DateTime dataDaSolicitacao)
        {
            return new ContextoDeValidacao(solicitacao, dataDaSolicitacao, feriados);
        }
    }
}