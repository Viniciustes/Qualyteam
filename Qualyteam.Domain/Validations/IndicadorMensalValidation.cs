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
            ValidarDataInicioObrigatorio();
        }

        protected void ValidarNome()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage(Messages.MSG01);
        }

        protected void ValidarDataInicioObrigatorio()
        {
            RuleFor(x => x.DataInicio)
                .Must(DataEhValida)
                .WithMessage(Messages.MSG07);
        }

        protected void ValidarDataInicio()
        {
            RuleFor(x => x.DataInicio)
                .LessThanOrEqualTo(DateTime.Now.Date)
                .WithMessage(Messages.MSG02);
        }

        private bool DataEhValida(DateTime? date)
        {
            if (date == default(DateTime) || !date.HasValue)
                return false;

            return true;
        }
    }
}
