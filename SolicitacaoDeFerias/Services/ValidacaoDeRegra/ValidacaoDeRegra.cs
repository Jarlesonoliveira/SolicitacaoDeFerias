using System;
using System.Collections.Generic;

namespace SolicitacaoDeFerias.Services
{
    public class ValidacaoDeRegra : IValidacaoDeRegra
    {
        private readonly IRegraDeNegocio _validacaoDeRegra;
        public ValidacaoDeRegra(IRegraDeNegocio validacaoDeRegra)
        {
            _validacaoDeRegra = validacaoDeRegra;
        }

        /// <summary>
        /// Valida se as férias correspondem as regras xtxaadasdasd
        /// </summary>
        /// <param name="dataInicial"></param>
        /// <param name="dataFinal"></param>
        /// <returns>Boolean</returns>
        public void ValidaFerias(DateTime dataInicial, DateTime dataFinal)
        {

            bool valida = true;

            #region "Regra 01 :: A data final deve ser maior que a Data Inicial"
            valida = _validacaoDeRegra.DataFinalMaiorQueDataInicio(dataInicial, dataFinal, valida);
            #endregion

            #region "Regra 02 :: As férias deverão ter inicio de Segunda a Quarta"
            List<DayOfWeek> diasDaSemanaLiberados = new List<DayOfWeek>() {
                DayOfWeek.Monday,       // Segunda
                DayOfWeek.Thursday,     // Terça 
                DayOfWeek.Wednesday     // Quarta
            };

            valida = _validacaoDeRegra.DiaDaSemanaLiberado(dataInicial, diasDaSemanaLiberados, valida);

            #endregion

            #region "Regra 03 :: O Periodo de Férias não deve ter inicio aos dias que antecede um feriado"

            valida = _validacaoDeRegra.DataDeInicioAntecedeFeriado(dataInicial, valida);


            #endregion

            #region "Regra 04 :: As férias deverão ser solicitadas com 40 dias de antecedência da data de inicio"
            valida = _validacaoDeRegra.QuarentaDiasDeAntecedencia(dataInicial, dataFinal, valida);

            #endregion

            #region "Regra 05 :: As férias devem ter no máximo 30 dias;"
            var limiteDeDias = 30;
            valida = _validacaoDeRegra.FeriasDentroDoLimiteDeDias(dataInicial, dataFinal, limiteDeDias, valida);

            #endregion

            #region "Regra 06 :: As férias tem que ter o minimo de 10 dias;"
            var MinimoDezDias = -8;
            valida = _validacaoDeRegra.FeriasDentroDoLimiteMinimoDeDias(dataInicial, dataFinal, MinimoDezDias, valida);

            #endregion

            #region "Ferias valida"
            // Caso não ocorra nenhum erro:
            if (valida)
            {
                Console.WriteLine("\r\nFerias registrada com sucesso! \r\n");
                Console.WriteLine("\r\nBoas férias ;)\r\n");
                Console.WriteLine("\r\nClique -> Enter <- para finalizar a solicitação...\r\n");
                Console.ReadKey();
                Environment.Exit(1);
            } else
            {
                Console.WriteLine("\r\nProcesso cancelado! Por favor tecle -> Enter <- para reiniciar a operação.\r\n");
            }
            #endregion
        }
    }
}