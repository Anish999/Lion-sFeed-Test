using System.ComponentModel.DataAnnotations;

namespace LionsFeed.ViewModel.Account
{
    public class LogInViewModel
    {
        [Required]
        public string Email { get; set; }

        //[StringLength(8, MinimumLength = 8)]
        //public string WNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
