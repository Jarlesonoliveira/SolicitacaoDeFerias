using SolicitacaoDeFerias.Domain;

namespace SolicitacaoDeFerias.Services
{
    public interface IValidadorDeFerias
    {
        ResultadoValidacao Validar(SolicitacaoFerias solicitacao);
    }
}