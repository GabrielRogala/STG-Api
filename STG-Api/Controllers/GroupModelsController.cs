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
using STG_Api.DAL;
using STG_Api.Models;

namespace STG_Api.Controllers
{
    public class GroupModelsController : ApiController
    {
        private STGContext db = new STGContext();

        // GET: api/GroupModels
        public IQueryable<GroupModels> GetGroup()
        {
            return db.Group;
        }

        // GET: api/GroupModels/5
        [ResponseType(typeof(GroupModels))]
        public IHttpActionResult GetGroupModels(int id)
        {
            GroupModels groupModels = db.Group.Find(id);
            if (groupModels == null)
            {
                return NotFound();
            }

            return Ok(groupModels);
        }

        // PUT: api/GroupModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGroupModels(int id, GroupModels groupModels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != groupModels.GroupID)
            {
                return BadRequest();
            }

            db.Entry(groupModels).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupModelsExists(id))
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

        // POST: api/GroupModels
        [ResponseType(typeof(GroupModels))]
        public IHttpActionResult PostGroupModels(GroupModels groupModels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Group.Add(groupModels);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = groupModels.GroupID }, groupModels);
        }

        // DELETE: api/GroupModels/5
        [ResponseType(typeof(GroupModels))]
        public IHttpActionResult DeleteGroupModels(int id)
        {
            GroupModels groupModels = db.Group.Find(id);
            if (groupModels == null)
            {
                return NotFound();
            }

            db.Group.Remove(groupModels);
            db.SaveChanges();

            return Ok(groupModels);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GroupModelsExists(int id)
        {
            return db.Group.Count(e => e.GroupID == id) > 0;
        }
    }
}