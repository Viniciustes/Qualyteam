using System;
using FluentValidation.Results;
using MediatR;
using Qualyteam.Domain.Validations;

namespace Qualyteam.Domain.Models
{
    public class IndicadorMensal : ModelBase, IRequest<IndicadorMensal>
    {
        public IndicadorMensal(int id, string nome, DateTime dataInicio) : base(id)
        {
            Nome = nome;
            DataInicio = dataInicio;
        }

        public string Nome { get; private set; }

        public DateTime DataInicio { get; private set; }

        public override bool IsValid()
        {
            ValidationResult = new IndicadorMensalValidation<IndicadorMensal>().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
