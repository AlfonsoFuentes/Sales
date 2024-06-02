

namespace Domain
{
    public class Country
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Filed {0} is required")]
        [MaxLength(100, ErrorMessage ="Max length of {0} is less than {1} characters")]
        [Display(Name = "Country")]
        public string Name { get; set; } = string.Empty;


    }
}
