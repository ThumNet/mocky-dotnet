using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mocky.API.Data;
using Mocky.API.ViewModels;

namespace Mocky.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
            return mock == null ? NotFound() : Ok(mock);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> OnPutAsync(Guid id, CreateUpdateMock model)
        {
            var updated = _mockyRepository.Update(id, model);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> OnDeleteAsync(Guid id, DeleteMock model)
        {
            var deleted = _mockyRepository.Delete(id, model);
            return deleted ? NoContent() : NotFound();
        }

        [HttpGet("encodings")]
        public IActionResult GetEncodings()
        {
            return new OkObjectResult(Encoding.GetEncodings());
        }
    }
}
