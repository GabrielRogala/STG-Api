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
    public class TeacherModelsController : ApiController
    {
        private STGContext db = new STGContext();

        // GET: api/TeacherModels
        public IQueryable<TeacherModels> GetTeacher()
        {
            return db.Teacher;
        }

        // GET: api/TeacherModels/5
        [ResponseType(typeof(TeacherModels))]
        public IHttpActionResult GetTeacherModels(int id)
        {
            TeacherModels teacherModels = db.Teacher.Find(id);
            if (teacherModels == null)
            {
                return NotFound();
            }

            return Ok(teacherModels);
        }

        // PUT: api/TeacherModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTeacherModels(int id, TeacherModels teacherModels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != teacherModels.TeacherID)
            {
                return BadRequest();
            }

            db.Entry(teacherModels).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherModelsExists(id))
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

        // POST: api/TeacherModels
        [ResponseType(typeof(TeacherModels))]
        public IHttpActionResult PostTeacherModels(TeacherModels teacherModels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Teacher.Add(teacherModels);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = teacherModels.TeacherID }, teacherModels);
        }

        // DELETE: api/TeacherModels/5
        [ResponseType(typeof(TeacherModels))]
        public IHttpActionResult DeleteTeacherModels(int id)
        {
            TeacherModels teacherModels = db.Teacher.Find(id);
            if (teacherModels == null)
            {
                return NotFound();
            }

            db.Teacher.Remove(teacherModels);
            db.SaveChanges();

            return Ok(teacherModels);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TeacherModelsExists(int id)
        {
            return db.Teacher.Count(e => e.TeacherID == id) > 0;
        }
    }
}