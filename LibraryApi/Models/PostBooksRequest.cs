using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Models
{
    public class PostBooksRequest : IValidatableObject
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        [Required]
        [MaxLength(200)]
        public string Author { get; set; }
        [MaxLength(50)]
        public string Genre { get; set; } = "None Specified";

        [Range(1,int.MaxValue)]
        public int NumberOfPages { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(Title.ToLower() == "it" && Author.ToLower() == "king")
            {
                yield return new ValidationResult("That book is inappropriate for school",
                    new string[] { "Title", "Author" });
            }
        }
    }

}
