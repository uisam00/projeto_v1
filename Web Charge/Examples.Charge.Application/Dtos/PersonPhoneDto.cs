using System.ComponentModel.DataAnnotations;

namespace Examples.Charge.Application.Dtos
{
    public class PersonPhoneDto
    {
        public int BusinessEntityID { get; set; }
        public int PhoneNumberTypeID { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Phone(ErrorMessage = "O campo {0} está com número inválido")]
        public string PhoneNumber { get; set; }
    }
}
