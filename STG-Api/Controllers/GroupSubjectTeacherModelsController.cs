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
    public class GroupSubjectTeacherModelsController : ApiController
    {
        private STGContext db = new STGContext();

        // GET: api/GroupSubjectTeacherModels
        public IQueryable<GroupSubjectTeacherModels> GetGroupSubjectTeacher()
        {
            return db.GroupSubjectTeacher;
        }

        // GET: api/GroupSubjectTeacherModels/5
        [ResponseType(typeof(GroupSubjectTeacherModels))]
        public IHttpActionResult GetGroupSubjectTeacherModels(int id)
        {
            GroupSubjectTeacherModels groupSubjectTeacherModels = db.GroupSubjectTeacher.Find(id);
            if (groupSubjectTeacherModels == null)
            {
                return NotFound();
            }

            return Ok(groupSubjectTeacherModels);
        }

        // PUT: api/GroupSubjectTeacherModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGroupSubjectTeacherModels(int id, GroupSubjectTeacherModels groupSubjectTeacherModels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != groupSubjectTeacherModels.GroupSubjectTeacherID)
            {
                return BadRequest();
            }

            db.Entry(groupSubjectTeacherModels).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupSubjectTeacherModelsExists(id))
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

        // POST: api/GroupSubjectTeacherModels
        [ResponseType(typeof(GroupSubjectTeacherModels))]
        public IHttpActionResult PostGroupSubjectTeacherModels(GroupSubjectTeacherModels groupSubjectTeacherModels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GroupSubjectTeacher.Add(groupSubjectTeacherModels);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = groupSubjectTeacherModels.GroupSubjectTeacherID }, groupSubjectTeacherModels);
        }

        // DELETE: api/GroupSubjectTeacherModels/5
        [ResponseType(typeof(GroupSubjectTeacherModels))]
        public IHttpActionResult DeleteGroupSubjectTeacherModels(int id)
        {
            GroupSubjectTeacherModels groupSubjectTeacherModels = db.GroupSubjectTeacher.Find(id);
            if (groupSubjectTeacherModels == null)
            {
                return NotFound();
            }

            db.GroupSubjectTeacher.Remove(groupSubjectTeacherModels);
            db.SaveChanges();

            return Ok(groupSubjectTeacherModels);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GroupSubjectTeacherModelsExists(int id)
        {
            return db.GroupSubjectTeacher.Count(e => e.GroupSubjectTeacherID == id) > 0;
        }
    }
}