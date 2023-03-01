using System;

namespace SolicitacaoDeFerias.Services
{
    public class Regra5 : IRegra5
    {
        /// <summary>
        /// Verifica se as ferias está dentro do limite de 30 dias
        /// </summary>
        /// <param name="dataInicial"></param>
        /// <param name="dataFinal"></param>
        /// <param name="limiteDeDias"></param>
        /// <returns>bool</returns>}
        public bool FeriasDentroDoLimiteDeDias(DateTime dataInicial, DateTime dataFinal, int limiteDeDias, bool valida)
        {
            var totalDiasDeFerias = dataFinal.Subtract(dataInicial).TotalDays;

            if (totalDiasDeFerias > limiteDeDias)
            {
                Console.WriteLine($"\r\nVocê estrapolou o prazo máximo de {limiteDeDias} dias! Escolha uma data final menor.\r\n");
                valida = false;
                return valida;
            }
            return valida;
        }
    }
}
