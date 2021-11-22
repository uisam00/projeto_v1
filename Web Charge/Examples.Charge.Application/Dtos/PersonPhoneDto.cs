using System.ComponentModel.DataAnnotations;

namespace Examples.Charge.Application.Dtos
{
    public class PersonPhoneDto
    {
        public int BusinessEntityID { get; set; }
        public int PhoneNumberTypeID { get; set; }
        public string PhoneNumber { get; set; }
        public PersonDto Person { get; set; }
        public PhoneNumberTypeDto PhoneNumberType { get; set; }

    }
}
