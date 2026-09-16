using SolicitacaoDeFerias.Model;
using System.Collections.Generic;

namespace SolicitacaoDeFerias.Services
{
    public interface IFeriadoRepository
    {
        IReadOnlyCollection<Feriado> ObterTodos();
    }
}