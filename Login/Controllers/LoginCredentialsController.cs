using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Login.Models;

namespace Login.Controllers
{
    public class LoginCredentialsController : ApiController
    {
        private LoginContext db = new LoginContext();

        // GET: api/LoginCredentials
        [Route("Login")]
        public IQueryable<LoginCredential> GetLoginCredentials()
        {
            return db.LoginCredentials;
        }

        // GET: api/LoginCredentials/5
       
        [ResponseType(typeof(LoginCredential))]
        public IHttpActionResult GetLoginCredential(int id)
        {
            LoginCredential loginCredential = db.LoginCredentials.Find(id);
            if (loginCredential == null)
            {
                return NotFound();
            }

            return Ok(loginCredential);
        }

        // PUT: api/LoginCredentials/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLoginCredential(int id, LoginCredential loginCredential)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != loginCredential.userId)
            {
                return BadRequest();
            }

            db.Entry(loginCredential).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginCredentialExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/LoginCredentials
        [ResponseType(typeof(LoginCredential))]
        public IHttpActionResult PostLoginCredential(LoginCredential loginCredential)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (var db = new LoginContext())
            {

                db.LoginCredentials.Add(new LoginCredential()
                {
                    userEmail=loginCredential.userEmail,
                    userPassword=loginCredential.userPassword
                }
                    );
     

                return Ok();
               
            }
        }


       


        [Route("Login")]
        [HttpPost]
        [ResponseType(typeof(LoginCredential))]
        public String PostLogin([FromBody]LoginCredential userCredentials)
        {
            var Obj = db.LoginCredentials.Where(x => x.userEmail == userCredentials.userEmail && x.userPassword == userCredentials.userPassword).FirstOrDefault();

            if (Obj == null)
            {
                return "not found";
            }


            return "successfully";


        }

        // DELETE: api/LoginCredentials/5
        [ResponseType(typeof(LoginCredential))]
        public IHttpActionResult DeleteLoginCredential(int id)
        {
            LoginCredential loginCredential = db.LoginCredentials.Find(id);
            if (loginCredential == null)
            {
                return NotFound();
            }

            db.LoginCredentials.Remove(loginCredential);
            db.SaveChanges();

            return Ok(loginCredential);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LoginCredentialExists(int id)
        {
            return db.LoginCredentials.Count(e => e.userId == id) > 0;
        }
    }
}