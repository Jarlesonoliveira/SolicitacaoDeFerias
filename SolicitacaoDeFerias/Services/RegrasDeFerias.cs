using System.Linq;

namespace SolicitacaoDeFerias.Services
{
    public sealed class RegraDataFinalMaiorQueInicial : IRegraDeFerias
    {
        public string MensagemDeErro => "A data final deve ser maior que a data inicial das férias.";
        public bool Validar(ContextoDeValidacao contexto) => contexto.Solicitacao.DataFinal > contexto.Solicitacao.DataInicial;
    }

    public sealed class RegraDiaInicialPermitido : IRegraDeFerias
    {
        public string MensagemDeErro => "As férias devem começar entre segunda e quarta-feira.";

        public bool Validar(ContextoDeValidacao contexto)
        {
            var dia = contexto.Solicitacao.DataInicial.DayOfWeek;
            return dia == System.DayOfWeek.Monday || dia == System.DayOfWeek.Tuesday || dia == System.DayOfWeek.Wednesday;
        }
    }

    public sealed class RegraNaoAntecedeFeriado : IRegraDeFerias
    {
        public string MensagemDeErro => "As férias não podem começar no dia anterior a um feriado.";
        public bool Validar(ContextoDeValidacao contexto) =>
            !contexto.Feriados.Any(feriado => feriado.Data == contexto.Solicitacao.DataInicial.AddDays(1));
    }

    public sealed class RegraAntecedenciaMinima : IRegraDeFerias
    {
        public string MensagemDeErro => "As férias devem ser solicitadas com pelo menos 40 dias de antecedência.";
        public bool Validar(ContextoDeValidacao contexto) =>
            (contexto.Solicitacao.DataInicial - contexto.DataDaSolicitacao).TotalDays >= 40;
    }

    public sealed class RegraDuracaoMaxima : IRegraDeFerias
    {
        public string MensagemDeErro => "As férias não podem ter mais de 30 dias.";
        public bool Validar(ContextoDeValidacao contexto) => contexto.Solicitacao.DuracaoEmDias <= 30;
    }

    public sealed class RegraDuracaoMinima : IRegraDeFerias
    {
        public string MensagemDeErro => "As férias devem ter pelo menos 10 dias.";
        public bool Validar(ContextoDeValidacao contexto) => contexto.Solicitacao.DuracaoEmDias >= 10;
    }
}