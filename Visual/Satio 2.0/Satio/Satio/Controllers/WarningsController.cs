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
    public class WarningsController : ControllerBase
    {
        private SatioDbContext dbContext;

        public WarningsController(SatioDbContext dbContext)
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
                WarnignCore warnignsCore = new WarnignCore(dbContext);
                return Ok(warnignsCore.GetAll());

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }


        }
       

        // GET api/<BlockedWordController>/5
        [HttpGet("{id}")]
        public IEnumerable<Warning> Get(int id)
        {
            List<Warning> warnings = dbContext.Warning.Where(warningsSingle => warningsSingle.Id == id).ToList();

            return warnings;
        }


        [HttpPost]
        public IActionResult Create([FromBody] Warning warning)
        {
            try
            {
                WarnignCore warnignsCore = new WarnignCore(dbContext);

                warnignsCore.Create(warning);


                return Ok("warning Word Added Succesfully");
            }
            catch (Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex);

            }
        }

        // PUT
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Warning warning, [FromRoute] int id)
        {
            try
            {
                WarnignCore warnignsCore = new WarnignCore(dbContext);

                warnignsCore.Update(warning, id);

                return Ok("warning Word Updated Succesfully");
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
                WarnignCore warnignsCore = new WarnignCore(dbContext);

                warnignsCore.Delete(id);

                return Ok("warnig Word Deleted Succesfully");
            }
            catch (Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex);

            }

        }
    }
}
