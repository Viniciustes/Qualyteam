using FluentValidation;
using Qualyteam.Domain.Messagens;
using Qualyteam.Domain.Models;
using System;

namespace Qualyteam.Domain.Validations
{
    class IndicadorMensalValidation<TEntity> : AbstractValidator<TEntity> where TEntity : IndicadorMensal
    {
        public IndicadorMensalValidation()
        {
            ValidarNome();
            ValidarDataInicio();
        }

        protected void ValidarNome()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage(Messages.MSG01);
        }

        protected void ValidarDataInicio()
        {
            RuleFor(x => x.DataInicio)
                .LessThanOrEqualTo(DateTime.Now.Date)
                .WithMessage(Messages.MSG02);
        }
    }
}
