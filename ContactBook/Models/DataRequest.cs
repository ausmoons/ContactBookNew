using System;
using System.Collections.Generic;

namespace ContactBook.Models
{
    public class DataRequest
    {
        public int Id { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Surname1 { get; set; }
        public string Surname2 { get; set; }
        public string Notes { get; set; }
        public DateTime Birthday { get; set; }
        public string Company { get; set; }
        public byte[] Photo { get; set; }
        public ICollection<Emails> Email { get; set; }
        public ICollection<Addresses> Address { get; set; }
        public ICollection<PhoneNumbers> PhoneNumbers { get; set; }
        

    }
}