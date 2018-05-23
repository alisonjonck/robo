using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using ViewModel;

namespace WebApi.Controllers
{
    /// <summary>
    /// R.O.B.O. API
    /// </summary>
    [Produces("application/json")]
    [Route("api/robo")]
    public class RoboController : Controller
    {
        private readonly IRoboService _roboService;
        private readonly ILogger _logger;
        /// <summary>
        /// R.O.B.O. API
        /// </summary>
        /// <param name="roboService"></param>
        /// <param name="logger"></param>
        public RoboController(IRoboService roboService, ILoggerFactory logger)
        {
            _roboService = roboService;
            _logger = logger.CreateLogger("RoboApi.Controllers.RoboController");
        }

        private Robo Robo { get; set; }

        /// <summary>
        /// GET api/robo
        /// </summary>
        /// <returns>RoboViewModel</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                Robo = _roboService.GetRobo();

                var roboVM = new RoboViewModel();
                roboVM.BracoDireito = Robo.BracoDireito;
                roboVM.BracoEsquerdo = Robo.BracoEsquerdo;
                roboVM.Cabeca = Robo.Cabeca;

                return Ok(roboVM);
            }
            catch (Exception exception)
            {
                if (_logger.IsEnabled(LogLevel.Error))
                {
                    _logger.LogError(exception, "HttpGet api/robo");
                }

                return Ok(new HandledException(exception.Message));
            }
        }

        /// <summary>
        /// PUT api/robo
        /// </summary>
        /// <param name="roboVM">RoboViewModel</param>
        /// <returns>RoboViewModel</returns>
        [HttpPut]
        public IActionResult Put([FromBody]RoboViewModel roboVM)
        {
            try
            {
                var roboAtualizado = _roboService.UpdateRobo(roboVM);

                var roboAtualizadoVM = new RoboViewModel();
                roboAtualizadoVM.BracoDireito = roboAtualizado.BracoDireito;
                roboAtualizadoVM.BracoEsquerdo = roboAtualizado.BracoEsquerdo;
                roboAtualizadoVM.Cabeca = roboAtualizado.Cabeca;

                return Ok(roboAtualizadoVM);
            }
            catch (RoboException exception)
            {
                return Ok(new HandledException(exception.Mensagem));
            }
            catch (Exception exception)
            {
                return Ok(new HandledException(exception.Message));
            }
        }
    }
}