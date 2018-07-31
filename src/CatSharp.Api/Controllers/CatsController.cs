using System;
using System.Collections.Generic;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;

using CatSharp.Services;
using CatSharp.Services.Dtos;
/*
 * Check this namespace
 */

namespace CatSharp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatsController : ControllerBase
    {
        private ICatService _service;

        public CatsController(ICatService service)
        {
            _service = service;
        }

        // GET api/cats
        [HttpGet]
        public ActionResult<IEnumerable<CatGetDto>> Get()
        {
            // TODO: Return a CatResponse
            
            return Ok(_service.GetAll());
        }

        // GET api/cats/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "sample";
        }

        // POST api/cats
        [HttpPost]
        public void Post([FromBody] CatCreateDto cat)
        {
            _service.Create(cat);
        }

        // PUT api/cats/5
        [HttpPut("{id}")]
        public void Put([FromBody] CatUpdateDto cat)
        {
            _service.Update(cat);
        }

        // DELETE api/cats/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
