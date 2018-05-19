using Microsoft.AspNetCore.Mvc;
using ViewModel;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Robo")]
    public class RoboController : Controller
    {
        // GET api/values
        [HttpGet]
        public RoboViewModel Get()
        {
            return new RoboViewModel();
        }

    }
}