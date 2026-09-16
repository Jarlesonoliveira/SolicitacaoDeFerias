using SolicitacaoDeFerias.Model;

namespace SolicitacaoDeFerias.Services
{
    public interface IValidadorDeFerias
    {
        ResultadoValidacao Validar(SolicitacaoFerias solicitacao);
    }
}