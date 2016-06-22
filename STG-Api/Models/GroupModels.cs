using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace STG_Api.Models
{
    public class GroupModels
    {
        [Key]
        public int GroupID { get; set; }

        [Required(ErrorMessage = "Wprowadz nazwe grupy")]
        [StringLength(100)]
        public String Name { get; set; }

        [Required(ErrorMessage = "Wprowadz skrót nazwy grupy")]
        [StringLength(10)]
        public String Shortname { get; set; }

        [Required(ErrorMessage = "Wprowadz liczność grupy")]
        public int Count { get; set; }

    }
}