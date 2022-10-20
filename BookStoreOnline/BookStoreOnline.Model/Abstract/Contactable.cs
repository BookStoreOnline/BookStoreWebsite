using System.ComponentModel.DataAnnotations;

namespace BookStoreOnline.Model.Abstract
{
    public class Contactable : IContactable
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(255)]
        public string Address { get; set; }
    }
}