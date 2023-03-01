using System.Collections.Generic;
using System.IO;

namespace SolicitacaoDeFerias.Model
{
    public static class LeitorCSV
    {
        public static IEnumerable<Feriado> ObterFeriados()
        {
            List<Feriado> feriados = new List<Feriado>();
            string pathFileCSV = @"Files\Feriados_Nacionais.csv";
            string[] registrosCSV = File.ReadAllLines(pathFileCSV);

            foreach (var registro in registrosCSV)
            {
                var feriadoInfo = registro.Split(',');
                Feriado feriado = new Feriado(feriadoInfo[0], feriadoInfo[1]);

                feriados.Add(feriado);
            }
            return feriados;
        }
    }
}
