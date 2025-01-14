﻿using BL.IBLs;
using Microsoft.AspNetCore.Mvc;
using Shared;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly IBL_Personas _bl;

        public PersonasController(IBL_Personas bl)
        {
            _bl = bl;
        }

        // GET: api/<PersonasController>
        [ProducesResponseType(typeof(List<Persona>), 200)]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bl.GetPersonas());
        }

        // GET api/<PersonasController>/5
        [ProducesResponseType(typeof(Persona), 200)]
        [HttpGet("{id}")]
        public IActionResult Get(string ci)
        {
            return Ok(_bl.GetPersona(ci));
        }

        // POST api/<PersonasController>
        [ProducesResponseType(typeof(Persona), 200)]
        [HttpPost]
        public IActionResult Post([FromBody] Persona persona)
        {
            _bl.AddPersona(persona);
            return Ok(persona);
        }

        // PUT api/<PersonasController>/5
        [ProducesResponseType(typeof(Persona), 200)]
        [HttpPut("{id}")]
        public IActionResult Put(string ci, [FromBody] Persona persona)
        {
            persona.Documento = ci;
            _bl.UpdatePersona(persona);
            return Ok(persona);
        }

        // DELETE api/<PersonasController>/5
        [ProducesResponseType(typeof(Persona), 200)]
        [HttpDelete("{Documento}")]
        public IActionResult Delete(string Documento)
        {
            _bl.DeletePersona(Documento);
            return Ok();
        }
    }
}