using System;

namespace SolicitacaoDeFerias.Services
{
    public sealed class RelogioDoSistema : IRelogio
    {
        public DateTime Agora => DateTime.Today;
    }
}