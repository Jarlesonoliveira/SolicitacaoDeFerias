using SolicitacaoDeFerias.Model;
using System;
using System.Linq;

namespace SolicitacaoDeFerias.Services
{
    public class Regra3 : IRegra3
    {
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
    }
}
