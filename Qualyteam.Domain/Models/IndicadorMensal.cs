using System;

namespace Qualyteam.Domain.Models
{
    public class IndicadorMensal
    {
        public IndicadorMensal(string nome, DateTime dataInicio)
        {
            Nome = nome;
            DataInicio = dataInicio;
        }

        public int Id { get; private set; }

        public string Nome { get; private set; }

        public DateTime DataInicio { get; private set; }


        #region Regra de Negócio
        public bool IsValidForCreate()
            => !string.IsNullOrWhiteSpace(Nome) && DataInicio.Date <= DateTime.Now.Date;

        public bool IsValidForUpdate()
           => Id > 0 && !string.IsNullOrWhiteSpace(Nome) && DataInicio.Date <= DateTime.Now.Date;
        #endregion
    }
}
