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
    public class ContactInfoController : ControllerBase
    {
        private SatioDbContext dbContext;

        public ContactInfoController(SatioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/<BlockedWordController>
        [HttpGet]
        public IActionResult GetAll()
        {
           

            try
            {
                ContactInfoCore contactInfoCore = new ContactInfoCore(dbContext);
                return Ok(contactInfoCore.GetAll());

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }


        }

        // GET api/<BlockedWordController>/5
        [HttpGet("{id}")]
        public IEnumerable<ContactInfo> Get(int id)
        {
            List<ContactInfo> contactInfo = dbContext.ContactInfo.Where(contactInfoingle => contactInfoingle.Id == id).ToList();

            return contactInfo;
        }

        [HttpPost]
        public IActionResult Create([FromBody] ContactInfo contactInfo)
        {
            try
            {
                ContactInfoCore contactInfoCore = new ContactInfoCore(dbContext);


                contactInfoCore.Create(contactInfo);

                return Ok("Contact Info Added Succesfully");
            }
            catch (Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex);

            }
        }

        // PUT
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] ContactInfo contactInfo, [FromRoute] int id)
        {
            try
            {
                ContactInfoCore contactInfoCore = new ContactInfoCore(dbContext);

                contactInfoCore.Update(contactInfo, id);

                return Ok("Contact Info  Updated Succesfully");
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
                ContactInfoCore contactInfoCore = new ContactInfoCore(dbContext);

                contactInfoCore.Delete(id);

                return Ok("Contact Info  Deleted Succesfully");
            }
            catch (Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex);

            }

        }
    }
}
