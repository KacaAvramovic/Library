using Domain.Enum;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenresController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var genres = Enum.GetNames(typeof(BookGenre))
                .Select((value, key) => new { id = key, name = value });

            return Ok(genres);
        }
    }
}
