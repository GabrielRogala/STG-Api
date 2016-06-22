using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STG_Api.Models
{
    public class GroupSubjectTeacherModels
    {
        public int GroupSubjectTeacherID { get; set; }
        public int GroupID { get; set; }
        public int SubjectID { get; set; }
        public int TeacherID { get; set; }
        public string Semester { get; set; }
        public string Schedule { get;  set;}

        public virtual GroupModels Group { get; set; }
        public virtual SubjectModels Subject { get; set; }
        public virtual TeacherModels Teacher { get; set; }

        /// <summary>
        ///         public virtual GroupModels GroupID { get; set; }
        ///         public virtual SubjectModels SubjectID { get; set; }
        ///         public virtual TeacherModels TeacherID { get; set; }
        /// </summary>

    }
}