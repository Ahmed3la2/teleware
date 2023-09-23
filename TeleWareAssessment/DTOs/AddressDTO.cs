using System.ComponentModel.DataAnnotations;

namespace TeleWareAssessment.DTOs
{
    public class AddressDTO
    {
        [Required(ErrorMessage = "discription is required")]
        public string Description { get; set; }
    }
}
