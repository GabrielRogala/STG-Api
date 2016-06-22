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
    public class SubjectModelsController : ApiController
    {
        private STGContext db = new STGContext();

        // GET: api/SubjectModels
        public IQueryable<SubjectModels> GetSubject()
        {
            return db.Subject;
        }

        // GET: api/SubjectModels/5
        [ResponseType(typeof(SubjectModels))]
        public IHttpActionResult GetSubjectModels(int id)
        {
            SubjectModels subjectModels = db.Subject.Find(id);
            if (subjectModels == null)
            {
                return NotFound();
            }

            return Ok(subjectModels);
        }

        // PUT: api/SubjectModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSubjectModels(int id, SubjectModels subjectModels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subjectModels.SubjectID)
            {
                return BadRequest();
            }

            db.Entry(subjectModels).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectModelsExists(id))
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

        // POST: api/SubjectModels
        [ResponseType(typeof(SubjectModels))]
        public IHttpActionResult PostSubjectModels(SubjectModels subjectModels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Subject.Add(subjectModels);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = subjectModels.SubjectID }, subjectModels);
        }

        // DELETE: api/SubjectModels/5
        [ResponseType(typeof(SubjectModels))]
        public IHttpActionResult DeleteSubjectModels(int id)
        {
            SubjectModels subjectModels = db.Subject.Find(id);
            if (subjectModels == null)
            {
                return NotFound();
            }

            db.Subject.Remove(subjectModels);
            db.SaveChanges();

            return Ok(subjectModels);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubjectModelsExists(int id)
        {
            return db.Subject.Count(e => e.SubjectID == id) > 0;
        }
    }
}