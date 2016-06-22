using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace STG_Api.Models
{
    public class SubjectModels
    {
        public int SubjectID { get; set; }

        [Required(ErrorMessage = "Wprowadz nazwe przedmiotu")]
        [StringLength(100)]
        public String Name { get; set; }

        [Required(ErrorMessage = "Wprowadz skrót nazwy przedmiotu")]
        [StringLength(10)]
        public String Shortname { get; set; }

    }
}