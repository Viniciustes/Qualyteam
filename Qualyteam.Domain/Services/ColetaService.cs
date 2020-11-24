using Qualyteam.Application.Interfaces;
using Qualyteam.Application.ViewModels;
using Qualyteam.Application.ViewModels.Filters;
using Qualyteam.Domain.Interfaces.Mediators;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Qualyteam.Domain.Services
{
    public class ColetaService : Service, IColetaService
    {
        public ColetaService(IMediatorHandler mediatorHandler) : base(mediatorHandler)
        {
        }

        public Task<ColetaViewModel> Create(ColetaViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ColetaViewModel>> Get()
        {
            throw new System.NotImplementedException();
        }

        public Task<ColetaViewModel> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ColetaViewModel>> Search(FilterColetaViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<ColetaViewModel> Update(ColetaViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }
    }
}
