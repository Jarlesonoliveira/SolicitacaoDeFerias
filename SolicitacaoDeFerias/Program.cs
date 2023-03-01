using Microsoft.Extensions.DependencyInjection;
using SolicitacaoDeFerias.Services;
using System;

namespace SolicitacaoDeFerias
{
    /// <summary>
    /// Desafio RH - Calculo de Férias
    /// </summary>    
    public class Program
    {
        /// <summary>
        /// Regras:
        ///     - Capturar a Data de Inicio e Fim das férias
        ///     - Validar se as datas são validas seguindo as regras: 
        ///         - Regra 01 :: A data final deve ser maior que a Data Inicial; 
        ///         - Regra 02 :: As férias deverão ter inicio de Segunda a Quarta;
        ///         - Regra 03 :: O Periodo de Férias não deve ter inicio aos dias que antecede um feriado;
        ///         - Regra 04 :: As férias deverão ser solicitadas com 40 dias de antecedência da data de inicio;
        ///         - Regra 05 :: As férias devem ter no máximo 30 dias;
        ///         - Regra 06 :: As férias tem que ter o minimo de 10 dias;
        ///     - Caso exista algum erro, exibir o erro relacionado;
        /// </summary>        
        static void Main(string[] args)
        {         
            CheckDate();
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IValidacaoDeRegra, ValidacaoDeRegra>();
            services.AddScoped<IRegraDeNegocio, RegraDeNegocio>();
            services.AddScoped<IRegra1, Regra1>();
            services.AddScoped<IRegra2, Regra2>();
            services.AddScoped<IRegra3, Regra3>();
            services.AddScoped<IRegra4, Regra4>();
            services.AddScoped<IRegra5, Regra5>();
            services.AddScoped<IRegra6, Regra6>();
        }
        public static void CheckDate()
        {
            DateTime dataInicial, dataFinal;
            bool rotinaSemErro = false;
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var service = serviceCollection.BuildServiceProvider();
            var enventService = service.GetService<IValidacaoDeRegra>();
            var enventService1 = service.GetService<IRegra1>();
            var enventService2 = service.GetService<IRegra2>();
            var enventService3 = service.GetService<IRegra3>();
            var enventService4 = service.GetService<IRegra4>();
            var enventService5 = service.GetService<IRegra5>();
            var enventService6 = service.GetService<IRegra6>();

            do
            {
                try
                {
                    #region Capturar dados de entrada
                    Console.Write("Digite a data de inicio das férias dd/mm/yyyy: ");
                    dataInicial = DateTime.Parse(Console.ReadLine());

                    Console.Write("Digite a data de final das férias dd/mm/yyyy: ");
                    dataFinal = DateTime.Parse(Console.ReadLine());
                    #endregion

                    #region Realizar as validações
                    enventService.ValidaFerias(dataInicial, dataFinal);
                    #endregion
                                      

                } catch (Exception)
                {
                    Console.WriteLine("\r\nErro na leitura dos parâmetros, por favor tente novamente.\r\n");
                } finally
                {
                    Console.ReadKey();
                }

            } while (!rotinaSemErro);
        }
    }
}
public partial class Program { }