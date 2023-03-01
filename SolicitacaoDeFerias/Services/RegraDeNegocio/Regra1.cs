using System;

namespace SolicitacaoDeFerias.Services
{
    public class Regra1 : IRegra1
    {
        /// <summary>
        /// Verifica se as ferias está dentro do limite de 30 dias
        /// </summary>
        /// <param name="dataInicial"></param>
        /// <param name="dataFinal"></param>
        /// <returns>bool</returns>}
        public bool DataFinalMaiorQueDataInicio(DateTime dataInicial, DateTime dataFinal, bool valida)
        {
            if (dataInicial > dataFinal)
            {
                Console.WriteLine("\r\nA data final deve ser maior que a Data Inicio das férias.\r\n");
                valida = false;
                return valida;
            }
            return valida;
        }
    }
}
