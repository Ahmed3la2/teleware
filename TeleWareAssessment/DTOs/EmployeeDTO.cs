using System.ComponentModel.DataAnnotations;
using TeleWare.Api.DTOs.Validations;

namespace TeleWareAssessment.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^\S+$", ErrorMessage = "The Name Shoudnot Have Spaces")]
        public string Name { get; set; }

        [Range(21, int.MaxValue,ErrorMessage = "The Age Must Be Between 21 And 90")]
        public int Age { get; set; }

        [NotEmptyList(ErrorMessage = "Addresses list shouldn't be empty.")]
        public List<AddressDTO> Addresses { get; set; }
    }
}
