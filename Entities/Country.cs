using System.ComponentModel.DataAnnotations;

namespace razor_countries.Entities
{
    public class Country
    {
        public Guid Id { get; set; }

        [Required]
        [MinLength(2)]
        public string Name { get; set; } = string.Empty;
        public Country()
        {
            
        }

        public Country(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
        }
    }
}
