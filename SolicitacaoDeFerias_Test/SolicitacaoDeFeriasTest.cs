using SolicitacaoDeFerias.Model;
using SolicitacaoDeFerias.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace SolicitacaoDeFerias_Test
{
    public class SolicitacaoDeFeriasTest
    {
        [Fact]
        public void DeveAceitarSolicitacaoValida()
        {
            var regras = new IRegraDeFerias[]
            {
                new RegraDataFinalMaiorQueInicial(),
                new RegraDiaInicialPermitido(),
                new RegraNaoAntecedeFeriado(),
                new RegraAntecedenciaMinima(),
                new RegraDuracaoMaxima(),
                new RegraDuracaoMinima()
            };
            var validador = new ValidacaoDeRegra(
                regras,
                new RepositorioDeFeriadosVazio(),
                new RelogioFixo(new DateTime(2026, 1, 1)));

            var resultado = validador.Validar(new SolicitacaoFerias(
                new DateTime(2026, 2, 16),
                new DateTime(2026, 2, 25)));

            Assert.True(resultado.Valido);
        }

        private sealed class RepositorioDeFeriadosVazio : IFeriadoRepository
        {
            public IReadOnlyCollection<Feriado> ObterTodos() => new List<Feriado>();
        }

        private sealed class RelogioFixo : IRelogio
        {
            public RelogioFixo(DateTime agora) => Agora = agora;
            public DateTime Agora { get; }
        }
    }
}
