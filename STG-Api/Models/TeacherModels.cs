using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace STG_Api.Models
{
    public class TeacherModels
    {
        public int TeacherID { get; set; }

        [Required(ErrorMessage = "Wprowadz Imię")]
        [StringLength(50)]
        public String Firstname { get; set; }

        [Required(ErrorMessage = "Wprowadz Nazwisko")]
        [StringLength(100)]
        public String Lastname { get; set; }

    }
}