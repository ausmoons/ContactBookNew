using System.ComponentModel.DataAnnotations;

namespace ContactBook.Models
{
    public class PhoneNumbers
    {
        [Key]
        public int PhoneNumberID { get; set; }
        public string Type { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }


        
        public int ContactId { get; set; }
        public virtual Contact Contact { get; set; }
    }
}