using System;

namespace SolicitacaoDeFerias.Services
{
    public class Regra4 : IRegra4
    {
        /// <summary>
        /// Verifica se as ferias tem 40 dias de antecedencia
        /// </summary>
        /// <param name="dataInicial"></param>
        /// <param name="dataFinal"></param>
        /// <returns>bool</returns>}

        public bool QuarentaDiasDeAntecedencia(DateTime dataInicial, DateTime dataFinal, bool valida)
        {
            var dataAtual = DateTime.UtcNow;
            DateTime dataLimitePedido = DateTime.MaxValue.AddDays(-40);
            dataLimitePedido = dataInicial;
            if (dataAtual >= dataLimitePedido)
            {
                Console.Write("\r\nData não tem quarenta dias de antecedencia! Adicione outra data.\r\n\r\n");
                valida = false;
                return valida;
            }
            return valida;
        }
    }
}
