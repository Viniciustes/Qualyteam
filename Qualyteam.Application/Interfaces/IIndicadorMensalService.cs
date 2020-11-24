using Qualyteam.Application.ViewModels;
using Qualyteam.Application.ViewModels.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Qualyteam.Application.Interfaces
{
    public interface IIndicadorMensalService
    {
        Task<IEnumerable<IndicadorMensalViewModel>> Get();
        Task<IndicadorMensalViewModel> GetById(int id);
        Task<IEnumerable<IndicadorMensalViewModel>> Search(FilterIndicadorMensalViewModel viewModel);
        Task<IndicadorMensalViewModel> Create(IndicadorMensalViewModel viewModel);
        Task<IndicadorMensalViewModel> Update(IndicadorMensalViewModel viewModel);
        Task<int> Remove(int id);
    }
}
