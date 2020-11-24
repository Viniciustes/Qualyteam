using AutoMapper;
using Qualyteam.Application.Interfaces;
using Qualyteam.Application.ViewModels;
using Qualyteam.Application.ViewModels.Filters;
using Qualyteam.Domain.Interfaces.Repository;
using Qualyteam.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Qualyteam.Domain.Services
{
    public class IndicadorMensalService : IIndicadorMensalService
    {
        private readonly IMapper _mapper;
        private readonly IIndicadorMensalRepository _repository;

        public IndicadorMensalService(IMapper mapper, IIndicadorMensalRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IndicadorMensalViewModel> Create(IndicadorMensalViewModel viewModel)
        {
            var entity = _mapper.Map<IndicadorMensal>(viewModel);

            if (!entity.IsValidForCreate())
                return null;

            await _repository.CreateAsync(entity);

            return _mapper.Map<IndicadorMensalViewModel>(entity);
        }

        public async Task<IEnumerable<IndicadorMensalViewModel>> Get()
        {
            var entities = await _repository.GetAsync();

            return _mapper.Map<IEnumerable<IndicadorMensalViewModel>>(entities);
        }

        public async Task<IndicadorMensalViewModel> GetById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            return _mapper.Map<IndicadorMensalViewModel>(entity);
        }

        public async Task<IEnumerable<IndicadorMensalViewModel>> Search(FilterIndicadorMensalViewModel filter)
        {
            var entities = await _repository.SearchAsync(x =>
                filter.Id.HasValue && x.Id == filter.Id
                || filter.DataInicio.HasValue && x.DataInicio == filter.DataInicio
                || !string.IsNullOrWhiteSpace(filter.Nome) && x.Nome.ToUpper() == filter.Nome.ToUpper());

            return _mapper.Map<IEnumerable<IndicadorMensalViewModel>>(entities);
        }

        public Task<IndicadorMensalViewModel> Update(IndicadorMensalViewModel viewModel)
        {
            var entity = _mapper.Map<IndicadorMensal>(viewModel);

            if (!entity.IsValidForUpdate())
                return null;

            _repository.Update(entity);

            return Task.FromResult(viewModel);
        }

        public async Task<int> Remove(int id)
            => await _repository.RemoveAsync(id);
    }
}
