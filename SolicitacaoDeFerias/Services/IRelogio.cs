using System;

namespace SolicitacaoDeFerias.Services
{
    public interface IRelogio
    {
        DateTime Agora { get; }
    }
}