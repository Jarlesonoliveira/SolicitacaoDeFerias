using System;

namespace SolicitacaoDeFerias.Services
{
    public interface IValidacaoDeRegra
    {
        void ValidaFerias(DateTime dataInicial, DateTime dataFinal);
    }
}
