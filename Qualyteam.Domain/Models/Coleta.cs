using Qualyteam.Domain.Validations;
using FluentValidation.Results;
using System;
using Qualyteam.Domain.Interfaces.Repository;

namespace Qualyteam.Domain.Models
{
    public class Coleta : ModelBase
    {
        // For AutoMapper
        public Coleta() { }

        public Coleta(int id, decimal valor, DateTime dataColeta, IndicadorMensal indicadorMensal) : base(id)
        {
            Valor = valor;
            DataColeta = dataColeta;
            IndicadorMensal = indicadorMensal;
        }

        public decimal Valor { get; private set; }

        public DateTime? DataColeta { get; set; }

        public IndicadorMensal IndicadorMensal { get; private set; }

        public void AddIndicadorMensal(IndicadorMensal indicadorMensal)
        {
            IndicadorMensal = indicadorMensal;
        }

        public bool IsValid(IColetaRepository repository)
        {
            ValidationResult = new ColetaValidation<Coleta>(repository).Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
