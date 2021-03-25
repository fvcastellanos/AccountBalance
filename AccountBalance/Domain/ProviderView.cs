using System.ComponentModel.DataAnnotations;

namespace AccountBalance.Domain
{
    public class ProviderView
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        [MaxLength(3)]
        public string Country { get; set; }
    }
}