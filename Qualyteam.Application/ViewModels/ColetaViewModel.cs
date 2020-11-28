using System;

namespace Qualyteam.Application.ViewModels
{
    public class ColetaViewModel
    {
        public int Id { get; set; }

        public decimal Valor { get; set; }

        public DateTime DataColeta { get; set; }

        public IndicadorMensalViewModel IndicadorMensal { get; set; }
    }
}
