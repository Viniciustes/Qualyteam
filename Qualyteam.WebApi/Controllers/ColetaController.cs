using MediatR;
using Microsoft.AspNetCore.Mvc;
using Qualyteam.Application.Interfaces;
using Qualyteam.Application.ViewModels;
using Qualyteam.Application.ViewModels.Filters;
using Qualyteam.Domain.Notifications;
using System.Threading.Tasks;

namespace Qualyteam.WebApi.Controllers
{
    [Route("api/coleta")]
    public class ColetaController : ApiControllerBase
    {
        private readonly IColetaService _service;

        public ColetaController(INotificationHandler<DomainNotification> notifications, IColetaService service) : base(notifications)
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
        public async Task<IActionResult> Search([FromBody] FilterColetaViewModel viewModel)
             => Response(await _service.Search(viewModel));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ColetaViewModel viewModel)
             => Response(await _service.Create(viewModel));

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ColetaViewModel viewModel)
             => Response(await _service.Update(viewModel));

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
             => Response(await _service.Remove(id));
    }
}
