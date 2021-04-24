using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Satio.Classes.Core;
using Satio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Satio.Controllers
{
    //[Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RegisteredUserRecipeController : ControllerBase
    {
        private SatioDbContext dbContext;

        public RegisteredUserRecipeController(SatioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/<BlockedWordController>
        [HttpGet]
        public IActionResult GetAll()
        {


            try
            {
                RegisteredUserRecipeCore registeredUserRecipeCore = new RegisteredUserRecipeCore(dbContext);
                return Ok(registeredUserRecipeCore.GetAll());

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }


        }

        // GET api/<BlockedWordController>/5
        [HttpGet("{id}")]
        public IEnumerable<RegisteredUserRecipe> Get(int id)
        {
            List<RegisteredUserRecipe> registeredUserRecipes = dbContext.RegisteredUserRecipe.Where(registeredUserRecipesingle => registeredUserRecipesingle.Id == id).ToList();

            return registeredUserRecipes;
        }

        [HttpPost]
        public IActionResult Create([FromBody] RegisteredUserRecipe registeredUserRecipe)
        {
            try
            {
                RegisteredUserRecipeCore registeredUserRecipeCore = new RegisteredUserRecipeCore(dbContext);

                registeredUserRecipeCore.Create(registeredUserRecipe);

                return Ok("registeredUserRecipe  Added Succesfully");
            }
            catch (Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex);

            }
        }

        // PUT
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] RegisteredUserRecipe registeredUserRecipe, [FromRoute] int id)
        {
            try
            {
                RegisteredUserRecipeCore registeredUserRecipeCore = new RegisteredUserRecipeCore(dbContext);

                registeredUserRecipeCore.Update(registeredUserRecipe, id);

                return Ok("ingredient Word Updated Succesfully");
            }
            catch (Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex);

            }

        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                RegisteredUserRecipeCore registeredUserRecipeCore = new RegisteredUserRecipeCore(dbContext);

                registeredUserRecipeCore.Delete(id);

                return Ok("ingredient Word Deleted Succesfully");
            }
            catch (Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex);

            }

        }
    }
}
