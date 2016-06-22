using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using STG_Api.Models;
using STG_Api.Migrations;
using System.Data.Entity.Migrations;

namespace STG_Api.DAL
{
    public class STGInitializer : MigrateDatabaseToLatestVersion<STGContext, Configuration>
    {
        //protected override void Seed(STGContext context)
        //{
        //    SeedSTGData(context);
        //    base.Seed(context);
        //}

        public static void SeedSTGData(STGContext context)
        {
            var group = new List<GroupModels> {
                new GroupModels() { GroupID = 1, Name = "grupa 1", Count=10, Shortname="g1" },
                new GroupModels() { GroupID = 2, Name = "grupa 2", Count=20, Shortname="g2" },
                new GroupModels() { GroupID = 3, Name = "grupa 3", Count=30, Shortname="g3" },
                new GroupModels() { GroupID = 4, Name = "grupa 4", Count=15, Shortname="g4" },
                new GroupModels() { GroupID = 5, Name = "grupa 5", Count=25, Shortname="g5" },
                new GroupModels() { GroupID = 6, Name = "grupa 6", Count=35, Shortname="g6" }
            };

            group.ForEach(g => context.Group.AddOrUpdate(g));
            context.SaveChanges();

            var teacher = new List<TeacherModels> {
                new TeacherModels() { TeacherID = 1 , Firstname = "nauczyciel1" , Lastname="naucz1" },
                new TeacherModels() { TeacherID = 2 , Firstname = "nauczyciel2" , Lastname="naucz2" },
                new TeacherModels() { TeacherID = 3 , Firstname = "nauczyciel3" , Lastname="naucz3" },
                new TeacherModels() { TeacherID = 4 , Firstname = "nauczyciel4" , Lastname="naucz4" }
            };

            teacher.ForEach(t => context.Teacher.AddOrUpdate(t));
            context.SaveChanges();

            var subject = new List<SubjectModels>() {
                new SubjectModels() { SubjectID = 1, Name="przedmiot1" , Shortname="p1"},
                new SubjectModels() { SubjectID = 2, Name="przedmiot2" , Shortname="p2"},
                new SubjectModels() { SubjectID = 3, Name="przedmiot3" , Shortname="p3"},
                new SubjectModels() { SubjectID = 4, Name="przedmiot4" , Shortname="p4"},
                new SubjectModels() { SubjectID = 5, Name="przedmiot5" , Shortname="p5"}
            };

            subject.ForEach(s => context.Subject.AddOrUpdate(s));
            context.SaveChanges();
        }
    }
}