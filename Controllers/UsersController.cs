using Microsoft.AspNetCore.Mvc;
using BE_login_Common;
using BE_login_Service;

namespace BE_login.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly Service _Service;

        public UsersController(Service service)
        {
            _Service = service;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var olista = _Service.Listar();
            return Ok(olista); // Cambiado a Ok para respuestas API
        }

        [HttpGet("{id}")]
        public IActionResult Obtener(int id)
        {
            var ocontacto = _Service.Obtener(id);
            if (ocontacto == null)
                return NotFound();
            return Ok(ocontacto);
        }

        [HttpPost]
        public IActionResult Guardar([FromBody] User ocontacto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var respuesta = _Service.Guardar(ocontacto);
            if (respuesta)
                return CreatedAtAction(nameof(Obtener), new { id = ocontacto.IdUsers }, ocontacto);
            else
                return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Editar(int id, [FromBody] User ocontacto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != ocontacto.IdUsers)
                return BadRequest();

            var respuesta = _Service.Editar(ocontacto);
            if (respuesta)
                return NoContent();
            else
                return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            var respuesta = _Service.Eliminar(id);
            if (respuesta)
                return NoContent();
            else
                return NotFound();
        }
    }
}
