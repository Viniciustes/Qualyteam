using System;

namespace Qualyteam.Domain.Models
{
    public class Coleta
    {
        public int Id { get; private set; }

        public DateTime Data { get; private set; }

        public IndicadorMensal IndicadorMensal { get; private set; }
    }
}
