using SolicitacaoDeFerias.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SolicitacaoDeFerias.Services
{
    public sealed class ValidacaoDeRegra : IValidadorDeFerias
    {
        private readonly IReadOnlyCollection<IRegraDeFerias> _regras;
        private readonly IFeriadoRepository _feriadoRepository;
        private readonly IRelogio _relogio;

        public ValidacaoDeRegra(IEnumerable<IRegraDeFerias> regras, IFeriadoRepository feriadoRepository, IRelogio relogio)
        {
            _regras = regras.ToList().AsReadOnly();
            _feriadoRepository = feriadoRepository;
            _relogio = relogio;
        }

        public ResultadoValidacao Validar(SolicitacaoFerias solicitacao)
        {
            if (solicitacao == null)
            {
                throw new ArgumentNullException(nameof(solicitacao));
            }

            var contexto = new ContextoDeValidacao(solicitacao, _relogio.Agora, _feriadoRepository.ObterTodos());
            var erros = _regras.Where(regra => !regra.Validar(contexto)).Select(regra => regra.MensagemDeErro);
            return new ResultadoValidacao(erros);
        }
    }
}