using AutoMapper;
using Qualyteam.Application.Interfaces;
using Qualyteam.Application.ViewModels;
using Qualyteam.Application.ViewModels.Filters;
using Qualyteam.Domain.Interfaces.Mediators;
using Qualyteam.Domain.Interfaces.Repository;
using Qualyteam.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qualyteam.Domain.Services
{
    public class ColetaService : Service, IColetaService
    {
        private readonly IMapper _mapper;
        private readonly IColetaRepository _repository;
        private readonly IIndicadorMensalRepository _repositoryIndicadorMensal;

        public ColetaService(IMediatorHandler mediatorHandler, IMapper mapper, IColetaRepository repository, IIndicadorMensalRepository repositoryIndicadorMensal) : base(mediatorHandler)
        {
            _mapper = mapper;
            _repository = repository;
            _repositoryIndicadorMensal = repositoryIndicadorMensal;
        }

        public async Task<IEnumerable<ColetaViewModel>> Get()
        {
            var entities = await _repository.GetAsync();

            return _mapper.Map<IEnumerable<ColetaViewModel>>(entities.OrderBy(x => x.DataColeta.Value.Date));
        }

        public async Task<ColetaViewModel> GetById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            return _mapper.Map<ColetaViewModel>(entity);
        }

        public async Task<IEnumerable<ColetaViewModel>> Search(FilterColetaViewModel viewModel)
        {
            if (viewModel == null)
                return await Get();

            var entities = await _repository.SearchAsync(x => x.IndicadorMensal.DataInicio.Value.Date >= viewModel.DataIntervaloInicio.Date &&  x.IndicadorMensal.DataInicio.Value.Date <= viewModel.DataIntervaloFim.Date);

            return _mapper.Map<IEnumerable<ColetaViewModel>>(entities.OrderBy(x => x.DataColeta.Value.Date));
        }

        public async Task<ColetaViewModel> Create(ColetaRequestViewModel viewModel)
        {
            var entity = _mapper.Map<Coleta>(viewModel);

            if (viewModel.IdIndicadorMensal > 0)
            {
                var indicadorMensal = await _repositoryIndicadorMensal.GetByIdAsync(viewModel.IdIndicadorMensal);

                entity.AddIndicadorMensal(indicadorMensal);
            }

            if (!entity.IsValid(_repository))
            {
                NotifyValidationErrors(entity);
                return await Task.FromResult(new ColetaViewModel());
            }

            await _repository.CreateAsync(entity);

            return _mapper.Map<ColetaViewModel>(entity);
        }

        public async Task<ColetaViewModel> Update(ColetaRequestViewModel viewModel)
        {
            var entity = _mapper.Map<Coleta>(viewModel);

            if (viewModel.IdIndicadorMensal > 0)
            {
                var indicadorMensal = await _repositoryIndicadorMensal.GetByIdAsync(viewModel.IdIndicadorMensal);

                entity.AddIndicadorMensal(indicadorMensal);
            }

            if (!entity.IsValid(_repository))
            {
                NotifyValidationErrors(entity);
                return await Task.FromResult(new ColetaViewModel());
            }

            _repository.Update(entity);

            return await Task.FromResult(_mapper.Map<ColetaViewModel>(entity));
        }

        public async Task<int> Remove(int id)
           => await _repository.RemoveAsync(id);
    }
}
