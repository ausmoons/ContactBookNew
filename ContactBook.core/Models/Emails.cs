using System;
using System.ComponentModel.DataAnnotations;

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

        public static implicit operator Emails(string v)
        {
            throw new NotImplementedException();
        }
    }
}