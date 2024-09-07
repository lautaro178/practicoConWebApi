using BL.IBLs;
using Microsoft.AspNetCore.Mvc;
using Shared;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculosController : ControllerBase
    {

        private readonly IBL_Vehiculos _bl;
        
        public VehiculosController(IBL_Vehiculos bl)
        {
            _bl = bl;
        }

        // GET: api/<VehiculosController>
        [ProducesResponseType(typeof(List<Vehiculo>), 200)]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bl.GetVehiculos());
        }

        // GET api/<VehiculosController>/5
        [ProducesResponseType(typeof(Vehiculo), 200)]
        [HttpGet("{id}")]
        public IActionResult Get(string matricula)
        {
            return Ok(_bl.GetVehiculo(matricula));
        }

        // POST api/<VehiculosController>
        [ProducesResponseType(typeof(Vehiculo), 200)]
        [HttpPost]
        public IActionResult Post([FromBody] Vehiculo vehiculo)
        {
            _bl.AddVehiculo(vehiculo);
            return Ok(vehiculo);
        }

        // PUT api/<VehiculosController>/5
        [ProducesResponseType(typeof(Vehiculo), 200)]
        [HttpPut("{id}")]
        public IActionResult Put(string matricula, [FromBody] Vehiculo vehiculo)
        {
            vehiculo.Matricula = matricula;
            _bl.UpdateVehiculo(vehiculo);
            return Ok(vehiculo);
        }

        // DELETE api/<VehiculosController>/5
        [ProducesResponseType(typeof(Vehiculo), 200)]
        [HttpDelete("{Matricula}")]
        public IActionResult Delete(string Matricula)
        {
            _bl.DeleteVehiculo(Matricula);
            return Ok();
        }

    }
}
