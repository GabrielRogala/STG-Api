using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using STG_Api.Models;

namespace STG_Api.DAL
{
    public class STGContext : DbContext
    {
        public STGContext():base("DataBaseConnection") {

        }

        static STGContext()
        {
            Database.SetInitializer<STGContext>(new STGInitializer());
        }

        public DbSet<GroupModels> Group { get; set; }
        public DbSet<SubjectModels> Subject { get; set; }
        public DbSet<TeacherModels> Teacher { get; set; }
        public DbSet<GroupSubjectTeacherModels> GroupSubjectTeacher { get; set; }
        //public DbSet<AccountBindingModels> Account { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupModels>().HasKey(c => c.GroupID);
            modelBuilder.Entity<SubjectModels>().HasKey(c => c.SubjectID);
            modelBuilder.Entity<TeacherModels>().HasKey(c => c.TeacherID);
            modelBuilder.Entity<GroupSubjectTeacherModels>().HasKey(c => c.GroupSubjectTeacherID);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}