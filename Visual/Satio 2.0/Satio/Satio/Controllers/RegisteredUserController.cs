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
    public class RegisteredUserController : ControllerBase
    {
        private SatioDbContext dbContext;

        public RegisteredUserController(SatioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/<BlockedWordController>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                RegisteredUserCore registeredUserCore = new RegisteredUserCore(dbContext);
                return Ok(registeredUserCore.GetAll());

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }


        }

        // GET api/<BlockedWordController>/5
        [HttpGet("{id}")]
        public IEnumerable<RegisteredUser> Get(int id)
        {
            List<RegisteredUser> registeredUsers = dbContext.RegisteredUser.Where(registeredUsersSingle => registeredUsersSingle.Id == id).ToList();

            return registeredUsers;
        }

        [HttpPost]
        public IActionResult Create([FromBody] RegisteredUser registeredUser)
        {
            try
            {
                ContactInfoCore contactInfoCore = new ContactInfoCore(dbContext);

                ContactInfo newContactInfo = new ContactInfo();

                newContactInfo.Facebook = "";
                newContactInfo.Instagram = "";
                newContactInfo.WebPage = "";
                newContactInfo.Twitter = "";
                newContactInfo.YouTube = "";

                contactInfoCore.Create(newContactInfo);

                ContactInfo lastCI = contactInfoCore.GetLastRegistered();

                registeredUser.IdContactInfo = lastCI.Id;
               
                RegisteredUserCore registeredUserCore = new RegisteredUserCore(dbContext);

                registeredUserCore.Create(registeredUser);

                return Ok("registeredUser Added Succesfully");
            }
            catch (Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex);

            }
        }

        // PUT
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] RegisteredUser registeredUser, [FromRoute] int id)
        {
            try
            {
                RegisteredUserCore registeredUserCore = new RegisteredUserCore(dbContext);

                registeredUserCore.Update(registeredUser, id);

                return Ok("registeredUser Word Updated Succesfully");
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

                return Ok("registeredUser Word Deleted Succesfully");
            }
            catch (Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex);

            }

        }
    }
}
