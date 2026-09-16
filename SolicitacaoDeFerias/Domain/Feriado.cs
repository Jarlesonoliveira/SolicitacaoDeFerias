using System;

namespace SolicitacaoDeFerias.Domain
{
    public sealed class Feriado
    {
        public Feriado(DateTime data, string descricao)
        {
            Data = data.Date;
            Descricao = descricao ?? string.Empty;
        }

        public Feriado(string data, string descricao)
            : this(DateTime.Parse(data), descricao)
        {
        }

        public DateTime Data { get; }
        public string Descricao { get; }
        public string DataFormatada => Data.ToString("dd/MM/yyyy");
    }
}