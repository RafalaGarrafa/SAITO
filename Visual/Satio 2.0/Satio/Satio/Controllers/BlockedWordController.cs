using Microsoft.AspNetCore.Mvc;
using Satio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Satio.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BlockedWordController : ControllerBase
    {

        SatioDbContext dbContext;

        public BlockedWordController(SatioDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        // GET: api/<BlockedWordController>
        [HttpGet]
        public IEnumerable<BlockedWord> GetAll()
        {
            List<BlockedWord> blockedWords = dbContext.BlockedWord.ToList();

            /*LINQ Examples
             
            //List<BlockedWord> blockedWords = dbContext.BlockedWord.Where(blockedWord => blockedWord.Id > 1).ToList();

            */
            return blockedWords;


        }

        // GET api/<BlockedWordController>/5
        [HttpGet("{id}")]
        public IEnumerable<BlockedWord> Get(int id)
        {
             List<BlockedWord> blockedWord = dbContext.BlockedWord.Where(blockedWordSingle => blockedWordSingle.Id == id).ToList();

            return blockedWord;
        }

    }
}
