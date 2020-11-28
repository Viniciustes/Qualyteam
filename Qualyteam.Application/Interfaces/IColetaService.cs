using Qualyteam.Application.ViewModels;
using Qualyteam.Application.ViewModels.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Qualyteam.Application.Interfaces
{
    public interface IColetaService
    {
        Task<IEnumerable<ColetaViewModel>> Get();
        Task<ColetaViewModel> GetById(int id);
        Task<IEnumerable<ColetaViewModel>> Search(FilterColetaViewModel viewModel);
        Task<ColetaViewModel> Create(ColetaRequestViewModel viewModel);
        Task<ColetaViewModel> Update(ColetaRequestViewModel viewModel);
        Task<int> Remove(int id);
    }
}
