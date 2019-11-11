using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContactBook.Models
{
    public class Contact
    {

        public Contact()
        {
            Emails = new List<Emails>();
            Addresses = new List<Addresses>();
            PhoneNumbers = new List<PhoneNumbers>();

        }

        public int Id { get; set; }
        [Required(ErrorMessage = "The name is required")]
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        [Required(ErrorMessage = "The surname is required")]
        public string Surname1 { get; set; }
        public string Surname2 { get; set; }       
        public string Notes { get; set; }
        public DateTime? Birthday { get; set; }
        public string Company { get; set; }
        public byte[] Photo { get; set; }
        public virtual ICollection<Emails> Emails { get; set; }
        public virtual ICollection<Addresses> Addresses { get; set; }
        public virtual ICollection<PhoneNumbers> PhoneNumbers { get; set; }
    }
}