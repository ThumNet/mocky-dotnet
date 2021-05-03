using System;
using Microsoft.AspNetCore.Mvc;
using Mocky.API.Data;

namespace Mocky.API.Controllers
{
    [ApiController]
    [Route("v3")]
    public class V3Controller : ControllerBase
    {
        private readonly IMockyRepository _mockyRepository;

        public V3Controller(IMockyRepository mockyRepository)
        {
            _mockyRepository = mockyRepository;
        }

        [HttpGet("{id}")]
        public IActionResult OnGet(Guid id)
        {
            var mock = _mockyRepository.TouchAndGet(id);
            if (mock == null) { return NotFound(); }

            var response = new ContentResult 
            {
                Content = mock.Content,
                ContentType = mock.ContentType,
                StatusCode = mock.Status
            };

            foreach (var (key, value) in mock.Headers)
            {
                Response.Headers.Add(key, value);
            }

            // note: Content-Length is add Automatically by the framework

            return response;
        }
    }
}
