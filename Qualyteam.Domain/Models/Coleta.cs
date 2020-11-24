using System;

namespace Qualyteam.Domain.Models
{
    public class Coleta : ModelBase
    {
        public Coleta(int id, DateTime data, IndicadorMensal indicadorMensal) : base(id)
        {
            Data = data;
            IndicadorMensal = indicadorMensal;
        }

        public DateTime Data { get; private set; }

        public IndicadorMensal IndicadorMensal { get; private set; }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
