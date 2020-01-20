using System.Threading.Tasks;
using Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace ostack.Controllers
{
    [ApiController]
    public class DevController : ControllerBase
    {
        private readonly ILogger<DevController> _logger;
        private readonly IMongoCollection<User> _db;
        private readonly Service _service;

        public DevController(ILogger<DevController> logger, Service service)
        {
            _logger     = logger;
            _service    = service;
        }

        [HttpPost]
        [Route("SaveDev")]
        public async Task<ActionResult<User>> CreateUser([FromBody] BookRequest bookReq)
        {   
            var book = new User();

            book.UserName = bookReq.BookName;
            book.Price = bookReq.Price;

            _service.Create(book);

            return Ok(book);
        }

        public class BookRequest
        {
            public string BookName { get; set; }

            public decimal Price { get; set; }
        }
    }
}
