using Domain;
using Microsoft.AspNetCore.Mvc;
using Service;
using ViewModel;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Robo")]
    public class RoboController : Controller
    {
        private readonly IRoboService _roboService;

        public RoboController()
        {
            _roboService = new RoboService();
        }

        /// <summary>
        /// GET api/robo
        /// </summary>
        /// <returns>RoboViewModel</returns>
        [HttpGet]
        public IActionResult Get()
        {
            var robo = _roboService.GetRobo();

            var roboVM = new RoboViewModel();
            roboVM.BracoDireito = robo.BracoDireito;
            roboVM.BracoEsquerdo = robo.BracoEsquerdo;
            roboVM.Cabeca = robo.Cabeca;

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
            Robo robo = new Robo();
            robo.BracoDireito = roboVM.BracoDireito;
            robo.BracoEsquerdo = roboVM.BracoEsquerdo;
            robo.Cabeca = roboVM.Cabeca;

            var roboAtualizado = _roboService.UpdateRobo(robo);

            var roboAtualizadoVM = new RoboViewModel();
            roboAtualizadoVM.BracoDireito = roboAtualizado.BracoDireito;
            roboAtualizadoVM.BracoEsquerdo = roboAtualizado.BracoEsquerdo;
            roboAtualizadoVM.Cabeca = roboAtualizado.Cabeca;

            return Ok(roboAtualizadoVM);
        }

    }
}