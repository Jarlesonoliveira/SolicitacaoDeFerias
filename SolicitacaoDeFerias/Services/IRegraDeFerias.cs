namespace SolicitacaoDeFerias.Services
{
    public interface IRegraDeFerias
    {
        string MensagemDeErro { get; }
        bool Validar(ContextoDeValidacao contexto);
    }
}