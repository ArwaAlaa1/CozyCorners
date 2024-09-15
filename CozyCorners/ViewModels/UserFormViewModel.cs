using Microsoft.AspNetCore.Identity;

namespace CozyCorners.ViewModels
{
    public class UserFormViewModel
    {
        public string? Id { get; set; }

        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string? Photo { get; set; }
        public IFormFile? PhotoFile { get; set; }
        public string Password { get; set; }
        
        public string? RoleId { get; set; }
        public List<RoleUserViewModel>? Roles { get; set; }

    }
}
