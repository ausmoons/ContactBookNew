using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ContactBook.Models
{
    public class Emails
    {
        [Key]
        public int EmailID { get; set; }
        public string Type { get; set; }

        [Display(Name = "Email address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }



       
        public int ContactId { get; set; }
        public virtual Contact Contact { get; set; }
    }
}