using System.ComponentModel.DataAnnotations;

namespace Examples.Charge.Application.Dtos
{
    public class PersonPhoneDto
    {
        public int PersonId { get; set; }
        public int PhoneTypeId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Phone(ErrorMessage = "O campo {0} está com número inválido")]
        public string Number { get; set; }
    }
}
