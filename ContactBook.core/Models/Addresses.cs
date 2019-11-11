using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ContactBook.Models
{
    public class Addresses
    {
        [Key]
        public int AddressID { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PostalCode { get; set; }

        
        public int ContactId { get; set; }
        public virtual Contact Contact { get; set; }
    }
}