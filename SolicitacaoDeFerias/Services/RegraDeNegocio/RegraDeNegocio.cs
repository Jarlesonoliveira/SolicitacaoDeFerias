using SolicitacaoDeFerias.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SolicitacaoDeFerias.Services
{
    public class RegraDeNegocio : IRegraDeNegocio
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

        /// <summary>
        /// Valida se a Data de Inicio das férias é um dos dias da semana permitidos
        /// </summary>
        /// <param name="dataInicioFerias"></param>
        /// <param name="diasDaSemanaLiberados"></param>
        /// <returns>boolean</returns>

        public bool DiaDaSemanaLiberado(DateTime dataInicioFerias, List<DayOfWeek> diasDaSemanaLiberados, bool valida)
        {
            if (!diasDaSemanaLiberados.Contains(dataInicioFerias.DayOfWeek))
            {
                Console.WriteLine("\r\nO dia de férias não pode ser nos dias de Quinta, Sexta, Sabado ou Domingo! Escolha outra data.\r\n");
                valida = false;
                return valida;
            }
            return valida;
        }

        /// <summary>
        /// Valida se a Data de Inicio das férias antecede um dia de feriado
        /// - Caso verdadeiro, as férias são invalidas
        /// </summary>
        /// <param name="dataInicioFerias"></param>
        /// <returns>Boolean</returns>       
        public bool DataDeInicioAntecedeFeriado(DateTime dataInicioFerias, bool valida)
        {
            var feriados = LeitorCSV.ObterFeriados();
            var antecede = feriados.Any(feriado => feriado.Data.AddDays(-1) == dataInicioFerias);
            if (antecede)
            {
                Console.WriteLine("\r\nNão é permitido antecipar uma data antes do feriado! Escolha outra data.\r\n");
                valida = false;
                return valida;
            }
            return valida;
        }

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
