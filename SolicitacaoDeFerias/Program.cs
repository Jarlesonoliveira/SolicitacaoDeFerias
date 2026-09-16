using Microsoft.Extensions.DependencyInjection;
using SolicitacaoDeFerias.Infrastructure;
using SolicitacaoDeFerias.Model;
using SolicitacaoDeFerias.Services;
using System;
using System.Globalization;
using System.IO;

namespace SolicitacaoDeFerias
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var serviceProvider = ConfigureServices())
            {
                Executar(serviceProvider);
            }
        }

        public static ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IRelogio, RelogioDoSistema>();
            services.AddSingleton<IFeriadoRepository>(_ => new FeriadoCsvRepository(
                Path.Combine(AppContext.BaseDirectory, "Files", "Feriados_Nacionais.csv")));
            services.AddTransient<IRegraDeFerias, RegraDataFinalMaiorQueInicial>();
            services.AddTransient<IRegraDeFerias, RegraDiaInicialPermitido>();
            services.AddTransient<IRegraDeFerias, RegraNaoAntecedeFeriado>();
            services.AddTransient<IRegraDeFerias, RegraAntecedenciaMinima>();
            services.AddTransient<IRegraDeFerias, RegraDuracaoMaxima>();
            services.AddTransient<IRegraDeFerias, RegraDuracaoMinima>();
            services.AddTransient<IValidadorDeFerias, ValidacaoDeRegra>();
            return services.BuildServiceProvider();
        }

        public static void Executar(IServiceProvider services)
        {
            var validador = services.GetRequiredService<IValidadorDeFerias>();
            Console.Write("Digite a data de início das férias (dd/MM/yyyy): ");
            if (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dataInicial))
            {
                Console.WriteLine("Data inicial inválida.");
                return;
            }

            Console.Write("Digite a data final das férias (dd/MM/yyyy): ");
            if (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dataFinal))
            {
                Console.WriteLine("Data final inválida.");
                return;
            }

            var resultado = validador.Validar(new SolicitacaoFerias(dataInicial, dataFinal));
            if (resultado.Valido)
            {
                Console.WriteLine("Férias registradas com sucesso!");
                return;
            }

            foreach (var erro in resultado.Erros)
            {
                Console.WriteLine(erro);
            }
        }
    }
}