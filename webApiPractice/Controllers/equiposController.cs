using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webApiPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace webApiPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class equiposController : ControllerBase
    {
        private readonly equiposContext _equiposContext;

        public equiposController(equiposContext equiposContexto) 
        { 
            _equiposContext = equiposContexto;
        }

        [HttpGet]
        [Route("GetAll")]

        public IActionResult Get() 
        { 
            List<equipos> listadoEquipos = (from e in _equiposContext.equipos select e).ToList();

            if (listadoEquipos.Count == 0)
            {
                return NotFound();
            }
            
            return Ok(listadoEquipos);
        }
    }
}
