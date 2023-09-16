using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using ApiAgenda.Models;


namespace ApiAgenda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        public readonly MiAgendaContext DbContext;

        public UsuariosController(MiAgendaContext _context)
        {
            DbContext = _context;
        }

        [HttpGet]
        [Route ("Lista")]

        public IActionResult Lista()
        {
            List <Usuario> lista = new List <Usuario> ();

            try
            {
                lista = DbContext.Usuarios.ToList ();

                return StatusCode(statusCode: 200, new {mensaje ="ok", response = lista});
            }
            catch (Exception ex)
            {
                return StatusCode(statusCode: 200, new { mensaje = ex.Message, response = lista });
            }
        }

        [HttpGet]
        [Route("Obtener/{IdUsuarios:int}")]

        public IActionResult Obtener(int IdUsuarios)
        {
            Usuario oUsuario = DbContext.Usuarios.Find(IdUsuarios);
            
            if (oUsuario == null)
            {
                return BadRequest ("Producto no encontrado");
            }

            try
            {
                oUsuario = DbContext.Usuarios.Where (u => u.IdUsuarios == IdUsuarios).FirstOrDefault();

                return StatusCode(statusCode: 200, new { mensaje = "ok", response = oUsuario });
            }
            catch (Exception ex)
            {
                return StatusCode(statusCode: 200, new { mensaje = ex.Message, response = oUsuario });
            }
        }

        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Usuario objeto)
        {
            try
            {
                DbContext.Usuarios.Add(objeto);
                DbContext.SaveChanges();
                return StatusCode(statusCode: 200, new { mensaje = "ok"});

            }
            catch (Exception ex)
            {
                return StatusCode(statusCode: 200, new { mensaje = ex.Message});
            }
        }


        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Usuario objeto)
        {

            Usuario oUsuario = DbContext.Usuarios.Find(objeto.IdUsuarios);

            if (oUsuario == null)
            {
                return BadRequest("Producto no encontrado");
            }

            try
            {
                oUsuario.Nombre = objeto.Nombre is null ? oUsuario.Nombre : objeto.Nombre;
                oUsuario.Telefono = objeto.Telefono is null ? oUsuario.Telefono : objeto.Telefono;
                oUsuario.Email = objeto.Email is null ? oUsuario.Email : objeto.Email;
                oUsuario.Direccion = objeto.Direccion is null ? oUsuario.Direccion : objeto.Direccion;


                DbContext.Usuarios.Update(oUsuario);
                DbContext.SaveChanges();
                return StatusCode(statusCode: 200, new { mensaje = "ok" });

            }
            catch (Exception ex)
            {
                return StatusCode(statusCode: 200, new { mensaje = ex.Message });
            }
        }

        [HttpDelete]
        [Route("Eliminar/{IdUsuarios:int}")]

        public IActionResult Eliminar(int IdUsuarios)
        {
            Usuario oUsuario = DbContext.Usuarios.Find(IdUsuarios);

            if (oUsuario == null)
            {
                return BadRequest("Producto no encontrado");
            }

            try
            {
                DbContext.Usuarios.Remove(oUsuario);
                DbContext.SaveChanges();
                return StatusCode(statusCode: 200, new { mensaje = "ok" });

            }
            catch (Exception ex)
            {
                return StatusCode(statusCode: 200, new { mensaje = ex.Message });
            }

        }



    }
}
