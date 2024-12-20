using Entities.Abstract;

namespace Entities.Dtos.Auth
{
    public class RegisterDto : IDto
    {
        public string FirtName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
