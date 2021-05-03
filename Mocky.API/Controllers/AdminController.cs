using Microsoft.AspNetCore.Mvc;
using Mocky.API.Data;
using Mocky.API.ViewModels;

namespace Mocky.API.Controllers
{
    [ApiController]
    [Route("api")]
    public class AdminController : ControllerBase
    {
        private readonly IMockyRepository _mockyRepository;

        public AdminController(IMockyRepository mockyRepository)
        {
            _mockyRepository = mockyRepository;
        }


        [HttpGet("stats")]
        public Stats OnGet()
        {
            var stats = _mockyRepository.AdminStats();
            return stats;
        }
    }
}