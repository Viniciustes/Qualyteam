using Microsoft.AspNetCore.Mvc;
using Qualyteam.Application.Interfaces;
using Qualyteam.Application.ViewModels;
using Qualyteam.Application.ViewModels.Filters;

namespace Qualyteam.WebApi.Controllers
{
    [Route("api/indicadormensal")]
    public class IndicadorMensalController : Controller
    {
        private readonly IIndicadorMensalService _service;

        public IndicadorMensalController(IIndicadorMensalService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
            => View(_service.Get());

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
            => View(_service.GetById(id));
        
        [HttpPost]
        [Route("search")]
        public IActionResult Search([FromBody] FilterIndicadorMensalViewModel viewModel)
             => View(_service.Search(viewModel));

        [HttpPost]
        public IActionResult Post([FromBody] IndicadorMensalViewModel viewModel)
             => View(_service.Create(viewModel));

        [HttpPut]
        public IActionResult Put([FromBody] IndicadorMensalViewModel viewModel)
             => View(_service.Update(viewModel));

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
             => View(_service.Remove(id));
    }
}
