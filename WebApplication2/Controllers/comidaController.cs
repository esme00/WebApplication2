using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;


namespace WebApplication2.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class comidasController : ControllerBase
    {
        private readonly comidasContext _comidasContexto;

        public comidasController(comidasContext equiposContexto)
        {
            _comidasContexto = equiposContexto;
        }

        ///sumary
        /// EndPoint que retorna el listado de todos los equipos existentes
        /// summary
        /// <return></return>
        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<comidas> listadoComida = (from c in _comidasContexto.comidas
                                           select c).ToList();

            if (listadoComida.Count == 0)
            {
                return NotFound();
            }
            return Ok(listadoComida);
        }

        [HttpGet]
        [Route("GetById/{id}")]

        public IActionResult Get(int id)
        {
            comidas? comida = (from c in _comidasContexto.comidas
                               where c.id_comida == id
                               select c).FirstOrDefault();
            if (comida == null)
            {
                return NotFound();
            }
            return Ok(comida);
        }

        [HttpGet]
        [Route("Find/{filtro}")]

        public IActionResult FindByDescription(string filtro)
        {
            comidas? comida = (from c in _comidasContexto.comidas
                               where c.descripcion.Contains(filtro)
                               select c).FirstOrDefault();
            if (comida == null)
            {
                return NotFound();
            }
            return Ok(comida);
        }

        [HttpPost]
        [Route("Add")]

        public IActionResult Guardare([FromBody] comidas comida)
        {
            try
            {
                _comidasContexto.comidas.Add(comida);
                _comidasContexto.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("actualizar/{id}")]

        public IActionResult Actualizare(int id, [FromBody] comidas comidaModificar)
        {
            comidas? comidaActual = (from c in _comidasContexto.comidas
                                     where c.id_comida == id
                                     select c).FirstOrDefault();

            if (comidaActual == null)
            {
                return NotFound();
            }

            comidaActual.nombre = comidaModificar.nombre;
            comidaActual.descripcion = comidaModificar.descripcion;
            comidaActual.durabilidad = comidaModificar.durabilidad;
            comidaActual.fecha_caducidad = comidaModificar.fecha_caducidad;
            comidaActual.fecha_compra = comidaModificar.fecha_compra;
            comidaActual.estado = comidaModificar.estado;
            comidaActual.dias_duracion = comidaModificar.dias_duracion;

            _comidasContexto.Entry(comidaActual).State = EntityState.Modified;
            _comidasContexto.SaveChanges();

            return Ok(comidaModificar);

        }

        [HttpDelete]
        [Route("eliminar/{id}")]
        public IActionResult EliminarE(int id)
        {
            comidas? comidas = (from c in _comidasContexto.comidas
                                where c.id_comida == id
                               select c).FirstOrDefault();

            if (comidas == null)
                return NotFound();

            _comidasContexto.comidas.Attach(comidas);
            _comidasContexto.comidas.Remove(comidas);
            _comidasContexto.SaveChanges();

            return Ok(comidas);
        }

    }
}

