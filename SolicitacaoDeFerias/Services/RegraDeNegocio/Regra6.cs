using System;

namespace SolicitacaoDeFerias.Services
{
    public class Regra6 : IRegra6
    {
        /// <summary>
        /// Verifica se as ferias está dentro do limite minimo de 10 dias
        /// </summary>
        /// <param name="dataInicial"></param>
        /// <param name="dataFinal"></param>
        /// <param name="MinimoDezDias"></param>
        /// <returns>bool</returns>
        public bool FeriasDentroDoLimiteMinimoDeDias(DateTime dataInicial, DateTime dataFinal, int MinimoDezDias, bool valida)
        {
            var totalDiasDeFeriasMinima = dataInicial.Subtract(dataFinal).TotalDays;
            if (totalDiasDeFeriasMinima >= MinimoDezDias)
            {
                Console.WriteLine($"\r\nVocê estrapolou o prazo minimo de 10 dias! Escolha uma data final igual ou acima de 10 dias.\r\n");
                valida = false;
                return valida;
            }
            return valida;
        }
    }
}
