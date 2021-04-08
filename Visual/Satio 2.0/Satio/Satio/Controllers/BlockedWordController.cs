using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Satio.Classes.Core;
using Satio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Satio.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BlockedWordController : ControllerBase
    {

        private SatioDbContext dbContext;

        public BlockedWordController(SatioDbContext dbContext)
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
                BlockedWordCore blockedWordCore = new BlockedWordCore(dbContext);
                return Ok(blockedWordCore.GetAll());

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }


        }

        // GET api/<BlockedWordController>/5
        [HttpGet("{id}")]
        public IEnumerable<BlockedWord> Get(int id)
        {
            List<BlockedWord> blockedWord = dbContext.BlockedWord.Where(blockedWordSingle => blockedWordSingle.Id == id).ToList();

            return blockedWord;
        }

        [HttpPost]
        public IActionResult Create([FromBody] BlockedWord blockedWord)
        {
            try
            {
                BlockedWordCore blockedWordCore = new BlockedWordCore(dbContext);

                blockedWordCore.Create(blockedWord);

                return Ok("Blocked Word Added Succesfully");
            }
            catch (Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex);

            }
        }

        // PUT
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] BlockedWord blockedWord, [FromRoute] int id)
        {
            try
            {
                BlockedWordCore blockedWordCore = new BlockedWordCore(dbContext);

                blockedWordCore.Update(blockedWord, id);

                return Ok("Blocked Word Updated Succesfully");
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
                BlockedWordCore blockedWordCore = new BlockedWordCore(dbContext);

                blockedWordCore.Update(blockedWord, id);

                return Ok("Blocked Word Updated Succesfully");
            }
            catch (Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex);

            }

        }
    }
}
