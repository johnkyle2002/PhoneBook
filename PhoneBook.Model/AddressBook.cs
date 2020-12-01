using System;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Model
{
    public class AddressBook
    {
        public int AddressBookID { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [MinLength(11)]
        public string PhoneNo { get; set; }

        [RegularExpression(@"^([\sA-Za-z]+)$")]
        [Required]
        public string Name { get; set; }
    }
}
