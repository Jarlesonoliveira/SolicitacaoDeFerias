using System;

namespace SolicitacaoDeFerias.Services
{
    public abstract class AbstractValidacaoDeRegra
    {
        public abstract void ValidaFerias(DateTime dataInicial, DateTime dataFinal);
    } 
}
