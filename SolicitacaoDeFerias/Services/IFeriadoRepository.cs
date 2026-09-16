using SolicitacaoDeFerias.Domain;
using System.Collections.Generic;

namespace SolicitacaoDeFerias.Services
{
    public interface IFeriadoRepository
    {
        IReadOnlyCollection<Feriado> ObterTodos(int ano);
    }
}