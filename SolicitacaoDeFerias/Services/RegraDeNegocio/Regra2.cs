using System;
using System.Collections.Generic;

namespace SolicitacaoDeFerias.Services
{
    public class Regra2 : IRegra2
    {
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
    }
}
