using SolicitacaoDeFerias.Model;
using SolicitacaoDeFerias.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace SolicitacaoDeFerias.Infrastructure
{
    public sealed class FeriadoCsvRepository : IFeriadoRepository
    {
        private readonly string _caminho;

        public FeriadoCsvRepository(string caminho)
        {
            _caminho = caminho;
        }

        public IReadOnlyCollection<Feriado> ObterTodos()
        {
            var feriados = new List<Feriado>();
            foreach (var registro in File.ReadAllLines(_caminho))
            {
                var dados = registro.Split(',');
                if (dados.Length < 2 || !TentarLerData(dados[0], out var data))
                {
                    continue;
                }

                feriados.Add(new Feriado(data, string.Join(",", dados, 1, dados.Length - 1)));
            }

            return feriados.AsReadOnly();
        }

        private static bool TentarLerData(string valor, out DateTime data)
        {
            if (DateTime.TryParseExact(valor, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out data))
            {
                return true;
            }

            if (DateTime.TryParseExact(valor, "dd/MM", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dataSemAno))
            {
                data = new DateTime(DateTime.Today.Year, dataSemAno.Month, dataSemAno.Day);
                return true;
            }

            data = default(DateTime);
            return false;
        }
    }
}