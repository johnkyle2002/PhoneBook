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
        [RegularExpression(@"^[\+0]\d{2}(\d)?(\([\d-.]+\))?[\d-.]+\d$", ErrorMessage = "Phone Number is not valid")]
        public string PhoneNo { get; set; }

        [RegularExpression(@"^([\sA-Za-z]+)$")]
        [Required]
        public string Name { get; set; }
    }
}
