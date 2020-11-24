using MediatR;
using Microsoft.AspNetCore.Mvc;
using Qualyteam.Application.Interfaces;
using Qualyteam.Application.ViewModels;
using Qualyteam.Application.ViewModels.Filters;
using Qualyteam.Domain.Notifications;
using System.Threading.Tasks;

namespace Qualyteam.WebApi.Controllers
{
    [Route("api/indicadormensal")]
    public class IndicadorMensalController : ApiControllerBase
    {
        private readonly IIndicadorMensalService _service;

        public IndicadorMensalController(INotificationHandler<DomainNotification> notifications, IIndicadorMensalService service) : base(notifications)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Response(await _service.Get());

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
            => Response(await _service.GetById(id));

        [HttpPost]
        [Route("search")]
        public async Task<IActionResult> Search([FromBody] FilterIndicadorMensalViewModel viewModel)
             => Response(await _service.Search(viewModel));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] IndicadorMensalViewModel viewModel)
             => Response(await _service.Create(viewModel));

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] IndicadorMensalViewModel viewModel)
             => Response(await _service.Update(viewModel));

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
             => Response(await _service.Remove(id));
    }
}
