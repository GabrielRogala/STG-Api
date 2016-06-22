namespace STG_Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class czystabaza : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GroupModels",
                c => new
                    {
                        GroupID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Shortname = c.String(nullable: false, maxLength: 10),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GroupID);
            
            CreateTable(
                "dbo.GroupSubjectTeacherModels",
                c => new
                    {
                        GroupSubjectTeacherID = c.Int(nullable: false, identity: true),
                        GroupID = c.Int(nullable: false),
                        SubjectID = c.Int(nullable: false),
                        TeacherID = c.Int(nullable: false),
                        Semester = c.String(),
                        Schedule = c.String(),
                    })
                .PrimaryKey(t => t.GroupSubjectTeacherID)
                .ForeignKey("dbo.GroupModels", t => t.GroupID, cascadeDelete: true)
                .ForeignKey("dbo.SubjectModels", t => t.SubjectID, cascadeDelete: true)
                .ForeignKey("dbo.TeacherModels", t => t.TeacherID, cascadeDelete: true)
                .Index(t => t.GroupID)
                .Index(t => t.SubjectID)
                .Index(t => t.TeacherID);
            
            CreateTable(
                "dbo.SubjectModels",
                c => new
                    {
                        SubjectID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Shortname = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.SubjectID);
            
            CreateTable(
                "dbo.TeacherModels",
                c => new
                    {
                        TeacherID = c.Int(nullable: false, identity: true),
                        Firstname = c.String(nullable: false, maxLength: 50),
                        Lastname = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.TeacherID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GroupSubjectTeacherModels", "TeacherID", "dbo.TeacherModels");
            DropForeignKey("dbo.GroupSubjectTeacherModels", "SubjectID", "dbo.SubjectModels");
            DropForeignKey("dbo.GroupSubjectTeacherModels", "GroupID", "dbo.GroupModels");
            DropIndex("dbo.GroupSubjectTeacherModels", new[] { "TeacherID" });
            DropIndex("dbo.GroupSubjectTeacherModels", new[] { "SubjectID" });
            DropIndex("dbo.GroupSubjectTeacherModels", new[] { "GroupID" });
            DropTable("dbo.TeacherModels");
            DropTable("dbo.SubjectModels");
            DropTable("dbo.GroupSubjectTeacherModels");
            DropTable("dbo.GroupModels");
        }
    }
}
