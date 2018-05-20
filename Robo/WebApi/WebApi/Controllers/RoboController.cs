using Domain;
using Microsoft.AspNetCore.Mvc;
using Service;
using ViewModel;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/robo")]
    public class RoboController : Controller
    {
        private readonly IRoboService _roboService;

        public RoboController(IRoboService roboService)
        {
            _roboService = roboService;
        }

        private Robo Robo { get; set; }

        /// <summary>
        /// GET api/robo
        /// </summary>
        /// <returns>RoboViewModel</returns>
        [HttpGet]
        public IActionResult Get()
        {
            Robo = _roboService.GetRobo();

            var roboVM = new RoboViewModel();
            roboVM.BracoDireito = Robo.BracoDireito;
            roboVM.BracoEsquerdo = Robo.BracoEsquerdo;
            roboVM.Cabeca = Robo.Cabeca;

            return Ok(roboVM);
        }

        /// <summary>
        /// PUT api/robo
        /// </summary>
        /// <param name="robo">RoboViewModel</param>
        /// <returns>RoboViewModel</returns>
        [HttpPut]
        public IActionResult Put([FromBody]RoboViewModel roboVM)
        {
            Robo = _roboService.GetRobo();
            Robo.BracoDireito = roboVM.BracoDireito;
            Robo.BracoEsquerdo = roboVM.BracoEsquerdo;
            Robo.Cabeca = roboVM.Cabeca;

            var roboAtualizado = _roboService.UpdateRobo(Robo);

            var roboAtualizadoVM = new RoboViewModel();
            roboAtualizadoVM.BracoDireito = roboAtualizado.BracoDireito;
            roboAtualizadoVM.BracoEsquerdo = roboAtualizado.BracoEsquerdo;
            roboAtualizadoVM.Cabeca = roboAtualizado.Cabeca;

            return Ok(roboAtualizadoVM);
        }

    }
}