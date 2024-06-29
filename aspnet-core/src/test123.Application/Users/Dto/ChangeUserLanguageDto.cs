using System.ComponentModel.DataAnnotations;

namespace test123.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}