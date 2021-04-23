﻿using Microsoft.AspNetCore.Authorization;
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
    public class RecipeController : ControllerBase
    {
        private SatioDbContext dbContext;

        public RecipeController(SatioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/<BlockedWordController>
        [HttpGet]
        public IActionResult GetAll()
        {
            /*
                //List<BlockedWord> blockedWords = dbContext.BlockedWord.ToList();

            LINQ Examples
             
            //List<BlockedWord> blockedWords = dbContext.BlockedWord.Where(blockedWord => bldockedWord.Id > 1).ToList();

            
           // return blockedWords;

            */
            try
            {
                RecipeCore recipeCore = new RecipeCore(dbContext);
                return Ok(recipeCore.GetAll());

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }


        }
        [HttpGet("{id}")]
        public string GetAllFromUser([FromRoute] int id)
        {

            RecipeCore recipeCore = new RecipeCore(dbContext);
            recipeCore.GetAllFromUser(id);
            return "wdad";


        }

        // GET api/<BlockedWordController>/5
        [HttpGet("{id}")]
        public IEnumerable<Recipe> Get(int id)
        {
            List<Recipe> recipes = dbContext.Recipe.Where(recipesSingle => recipesSingle.Id == id).ToList();

            return recipes;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Recipe recipe)
        {
            try
            {
                RecipeCore recipeCore = new RecipeCore(dbContext);

                recipeCore.Create(recipe);

                return Ok("recipe Word Added Succesfully");
            }
            catch (Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex);

            }
        }

        // PUT
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Recipe recipe, [FromRoute] int id)
        {
            try
            {
                RecipeCore recipeCore = new RecipeCore(dbContext);

                recipeCore.Update(recipe, id);

                return Ok("recipe Word Updated Succesfully");
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
                RegisteredUserCore registeredUserCore = new RegisteredUserCore(dbContext);

                registeredUserCore.Delete(id);

                return Ok("recipe Word Deleted Succesfully");
            }
            catch (Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex);

            }

        }
    }
}
