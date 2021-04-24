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
    public class IngredientsController : ControllerBase
    {
        private SatioDbContext dbContext;

        public IngredientsController(SatioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/<BlockedWordController>
        [HttpGet]
        public IActionResult GetAll()
        {


            try
            {
                IngredientCore ingredientCore = new IngredientCore(dbContext);
                return Ok(ingredientCore.GetAll());

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }


        }

        // GET api/<BlockedWordController>/5
        [HttpGet("{id}")]
        public IEnumerable<Ingredient> Get(int id)
        {
            List<Ingredient> ingredient = dbContext.Ingredient.Where(ingredientingle => ingredientingle.Id == id).ToList();

            return ingredient;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Ingredient ingredient)
        {
            try
            {
                IngredientCore ingredientCore = new IngredientCore(dbContext);

                ingredientCore.Create(ingredient);

                return Ok("ingredient Word Added Succesfully");
            }
            catch (Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex);

            }
        }

        // PUT
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Ingredient ingredient, [FromRoute] int id)
        {
            try
            {
                IngredientCore ingredientCore = new IngredientCore(dbContext);

                ingredientCore.Update(ingredient, id);

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
                IngredientCore ingredientCore = new IngredientCore(dbContext);

                ingredientCore.Delete(id);

                return Ok("ingredient Word Deleted Succesfully");
            }
            catch (Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex);

            }

        }
    }
}
