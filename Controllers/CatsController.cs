using System;
using System.Collections.Generic;
using cs_cats.DB;
using cs_cats.Models;
using cs_cats.Services;
using Microsoft.AspNetCore.Mvc;

namespace cs_cats.Controllers
{
    [ApiController]
    // This attribute tells dotnet that this class should be registered with the controllers
    [Route("api/[controller]")]
    // The [controller] names the route with whatever the name before the word "Controller" in the Class is:  <-- "api/cats"
    public class CatsController : ControllerBase
    {
        private readonly CatsService _service;

        public CatsController(CatsService service)
        // Dependency Injection:  In order to use this Controller, this Service must be injected on Construction
        {
            _service = service;
        }

        [HttpGet]
        // This attribute defines that the method to follow is a "get" request
        public ActionResult<IEnumerable<Cat>> getAll()
        // IEnumerable takes the place of any collection type (List, Array, etc...)
        // ActionResult <-- "of type" List <-- "of type" Cat
        {
            try
            {
                return Ok(FakeDB.Cats);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GetById  <-- same as :id
        [HttpGet("{id}")]
        public ActionResult<Cat> GetById(string id)
        {
            try
            {
                Cat found = _service.GetById(id);
                return Ok(found);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST
        [HttpPost]
        public ActionResult<Cat> Create([FromBody] Cat newCat)
        // This says that "From the Body" create a Cat called "newCat"
        {
            try
            {
                Cat cat = _service.Create(newCat);
                return Ok(cat);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST
        [HttpPut("{id}")]
        public ActionResult<Cat> Edit([FromBody] Cat editCat, string id)
        {
            try
            {
                editCat.Id = id;
                Cat edit = _service.Edit(editCat);
                return Ok(edit);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(string id)
        {
            try
            {
                _service.DeleteCat(id);
                return Ok("Deleted!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}