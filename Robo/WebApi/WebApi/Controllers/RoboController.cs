using Microsoft.AspNetCore.Mvc;
using ViewModel;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Robo")]
    public class RoboController : Controller
    {
        // GET api/robo
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new RoboViewModel());
        }

        // PUT api/robo
        [HttpPut]
        public IActionResult Put([FromBody]RoboViewModel robo)
        {
            return Ok(new RoboViewModel());
        }

    }
}