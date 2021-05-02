using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mocky.API.Data;
using Mocky.API.ViewModels;

namespace Mocky.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MockController : ControllerBase
    {
        private readonly IMockyRepository _mockyRepository;

        public MockController(IMockyRepository mockyRepository)
        {
            _mockyRepository = mockyRepository;
        }

        [HttpPost]
        public async Task<IActionResult> OnPostAsync(CreateUpdateMock model)
        {
            var mockyId = _mockyRepository.Create(model);
            return new OkObjectResult(mockyId);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var mock = _mockyRepository.Get(id);
            return new OkObjectResult(mock);
        }

        [HttpGet("encodings")]
        public IActionResult GetEncodings()
        {
            return new OkObjectResult(Encoding.GetEncodings());
        }
    }
}
