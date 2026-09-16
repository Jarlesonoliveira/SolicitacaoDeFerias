using SolicitacaoDeFerias.Infrastructure;
using SolicitacaoDeFerias.Domain;
using SolicitacaoDeFerias.Services;
using System;
using System.Collections.Generic;
using System.IO;
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

        [Fact]
        public void DeveRejeitarPeriodoComDataFinalAnterior()
        {
            Assert.Throws<ArgumentException>(() => new PeriodoFerias(
                new DateTime(2026, 2, 25),
                new DateTime(2026, 2, 16)));
        }

        [Fact]
        public void DeveCriarAgregadoComEventoDeDominio()
        {
            var solicitacao = new SolicitacaoFerias(
                new DateTime(2026, 2, 16),
                new DateTime(2026, 2, 25));

            var evento = Assert.Single(solicitacao.Eventos);
            var eventoCriado = Assert.IsType<SolicitacaoCriadaEvent>(evento);

            Assert.Equal(solicitacao.Id, eventoCriado.SolicitacaoId);
            Assert.Equal(solicitacao.Periodo, eventoCriado.Periodo);
        }

        [Fact]
        public void DeveLerFeriadoComAnoInformado()
        {
            var caminho = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".csv");
            File.WriteAllText(caminho, "01/01,Ano Novo");

            try
            {
                var repositorio = new FeriadoCsvRepository(caminho);
                var feriado = Assert.Single(repositorio.ObterTodos(2030));

                Assert.Equal(new DateTime(2030, 1, 1), feriado.Data);
            }
            finally
            {
                File.Delete(caminho);
            }
        }

        private sealed class RepositorioDeFeriadosVazio : IFeriadoRepository
        {
            public IReadOnlyCollection<Feriado> ObterTodos(int ano) => new List<Feriado>();
        }

        private sealed class RelogioFixo : IRelogio
        {
            public RelogioFixo(DateTime agora) => Agora = agora;
            public DateTime Agora { get; }
        }
    }
}
