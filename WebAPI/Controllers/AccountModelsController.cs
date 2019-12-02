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
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class AccountModelsController : ApiController
    {
        private WebAPIContext db = new WebAPIContext();

        // GET: api/AccountModels
        public IQueryable<AccountModel> GetAccountModels()
        {
            return db.AccountModels;
        }

        // GET: api/AccountModels/5
        [ResponseType(typeof(AccountModel))]
        public IHttpActionResult GetAccountModel(int id)
        {
            AccountModel accountModel = db.AccountModels.Find(id);
            if (accountModel == null)
            {
                return NotFound();
            }

            return Ok(accountModel);
        }

        // PUT: api/AccountModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAccountModel(int id, AccountModel accountModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accountModel.userId)
            {
                return BadRequest();
            }

            db.Entry(accountModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountModelExists(id))
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

        // POST: api/AccountModels
        [ResponseType(typeof(AccountModel))]
        public IHttpActionResult PostAccountModel(AccountModel accountModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AccountModels.Add(accountModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = accountModel.userId }, accountModel);
        }

        // DELETE: api/AccountModels/5
        [ResponseType(typeof(AccountModel))]
        public IHttpActionResult DeleteAccountModel(int id)
        {
            AccountModel accountModel = db.AccountModels.Find(id);
            if (accountModel == null)
            {
                return NotFound();
            }

            db.AccountModels.Remove(accountModel);
            db.SaveChanges();

            return Ok(accountModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AccountModelExists(int id)
        {
            return db.AccountModels.Count(e => e.userId == id) > 0;
        }
    }
}