using FluentValidation;
using Qualyteam.Domain.Interfaces.Repository;
using Qualyteam.Domain.Messagens;
using Qualyteam.Domain.Models;
using System;

namespace Qualyteam.Domain.Validations
{
    class ColetaValidation<TEntity> : AbstractValidator<TEntity> where TEntity : Coleta
    {
        private readonly IColetaRepository _repository;

        public ColetaValidation(IColetaRepository repository)
        {
            _repository = repository;

            ValidarValor();
            ValidarIdIndicadorMensal();
            ValidarExisteColetaParaMesmoMes();
            ValidarColetaDataAnteriorDataInicioIndicador();
        }

        protected void ValidarValor()
        {
            RuleFor(x => x.Valor)
                .GreaterThan(0)
                .WithMessage(Messages.MSG04);
        }

        protected void ValidarIdIndicadorMensal()
        {
            RuleFor(x => x.IndicadorMensal.Id)
                 .GreaterThan(0)
                 .WithMessage(Messages.MSG03);
        }

        /// <summary>
        /// Regra não pode existir uma coleta para uma data anterior à data de início do indicador
        /// </summary>
        protected void ValidarColetaDataAnteriorDataInicioIndicador()
        {
            RuleFor(x => x.IndicadorMensal.DataInicio.Date)
               .LessThanOrEqualTo(x => x.DataColeta.Date)
               .WithMessage(Messages.MSG06);
        }

        /// <summary>
        /// Regra um indicador não pode ter mais de uma coleta para o mesmo mês
        /// </summary>
        protected void ValidarExisteColetaParaMesmoMes()
        {
            RuleFor(p => p)
                .Must(ValidarSeDuplicado())
                .When(x => x.IndicadorMensal.Id > 0)
                .WithMessage(Messages.MSG05);
        }

        private Func<Coleta, bool> ValidarSeDuplicado()
        {
            return (entity) =>
            {
                if (entity.IndicadorMensal.Id == 0)
                    return false;

                if (entity.Id != 0)
                {
                    return !_repository.FindAny(x => x.Id != entity.Id && x.IndicadorMensal.Id == entity.IndicadorMensal.Id && x.DataColeta.Month == DateTime.Now.Month);
                }
                else
                {
                    return !_repository.FindAny(x => x.IndicadorMensal.Id == entity.IndicadorMensal.Id && x.DataColeta.Month == DateTime.Now.Month);
                }
            };
        }
    }
}
