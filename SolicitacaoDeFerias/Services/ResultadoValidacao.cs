using System.Collections.Generic;
using System.Linq;

namespace SolicitacaoDeFerias.Services
{
    public sealed class ResultadoValidacao
    {
        public ResultadoValidacao(IEnumerable<string> erros)
        {
            Erros = erros.ToList().AsReadOnly();
        }

        public IReadOnlyList<string> Erros { get; }
        public bool Valido => !Erros.Any();
    }
}