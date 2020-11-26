using System;
using System.Collections.Generic;
using FluentValidation.Results;
using MediatR;
using Qualyteam.Domain.Validations;

namespace Qualyteam.Domain.Models
{
    public class IndicadorMensal : ModelBase, IRequest<IndicadorMensal>
    {
        // For AutoMapper
        public IndicadorMensal() { }

        public IndicadorMensal(int id, string nome, DateTime dataInicio) : base(id)
        {
            Nome = nome;
            DataInicio = dataInicio;
        }

        public string Nome { get; private set; }

        public DateTime DataInicio { get; private set; }

        public ICollection<Coleta> Coletas { get; private set; }

        public bool IsValid()
        {
            ValidationResult = new IndicadorMensalValidation<IndicadorMensal>().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
