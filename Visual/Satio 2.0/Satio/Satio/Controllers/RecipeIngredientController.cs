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
    public class RecipeIngredientController : ControllerBase
    {
        private SatioDbContext dbContext;

        public RecipeIngredientController(SatioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/<BlockedWordController>
        [HttpGet]
        public IActionResult GetAll()
        {
            
            try
            {
                RecipeIngredientCore recipeIngredientCore = new RecipeIngredientCore(dbContext);
                return Ok(recipeIngredientCore.GetAll());

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }


        }


        // GET api/<BlockedWordController>/5
        [HttpGet("{id}")]
        public IEnumerable<RecipeIngredient> Get(int id)
        {
            List<RecipeIngredient> recipeIngredients = dbContext.RecipeIngredient.Where(recipeIngredientsSingle => recipeIngredientsSingle.Id == id).ToList();

            return recipeIngredients;
        }

        [HttpPost]
        public IActionResult Create([FromBody] RecipeIngredient recipeIngredient)
        {
            try
            {
                RecipeIngredientCore recipeIngredientCore = new RecipeIngredientCore(dbContext);

                recipeIngredientCore.Create(recipeIngredient);

                return Ok("recipeIngredient Word Added Succesfully");
            }
            catch (Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex);

            }
        }

        // PUT
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] RecipeIngredient recipeIngredient, [FromRoute] int id)
        {
            try
            {
                RecipeIngredientCore recipeIngredientCore = new RecipeIngredientCore(dbContext);

                recipeIngredientCore.Update(recipeIngredient, id);

                return Ok("recipeIngredient Word Updated Succesfully");
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
                RecipeIngredientCore recipeIngredientCore = new RecipeIngredientCore(dbContext);

                recipeIngredientCore.Delete(id);

                return Ok("recipeIngredientCore  Deleted Succesfully");
            }
            catch (Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex);

            }

        }
    }
}
