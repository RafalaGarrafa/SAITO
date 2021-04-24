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
    public class FoodController : ControllerBase
    {
      
        private SatioDbContext dbContext;

        public FoodController(SatioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
           
            try
            {
                FoodCore foodCore = new FoodCore(dbContext);
                return Ok(foodCore.GetAll());

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }


        }
        //[HttpGet("{id}")]
        //public string GetAllFromRecipe([FromRoute] int id)
        //{

        //    //FoodCore foodCore = new FoodCore(dbContext);
        //    //foodCore.GetAllFromRecipe(id);
        //    //return "wdad";


        //}

        // GET api/<BlockedWordController>/5
        [HttpGet("{id}")]
        public IEnumerable<Food> Get(int id)
        {
            List<Food> food = dbContext.Food.Where(foodsSingle => foodsSingle.Id == id).ToList();

            return food;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Food food)
        {
            try
            {
                FoodCore foodCore = new FoodCore(dbContext);

                foodCore.Create(food);

                return Ok("food Added Succesfully");
            }
            catch (Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex);

            }
        }

        // PUT
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Food food, [FromRoute] int id)
        {
            try
            {
                FoodCore foodCore = new FoodCore(dbContext);

                foodCore.Update(food, id);

                return Ok("food Word Updated Succesfully");
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
                FoodCore foodCore = new FoodCore(dbContext);


                foodCore.Delete(id);

                return Ok("recipe Word Deleted Succesfully");
            }
            catch (Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex);

            }

        }

    }
}
