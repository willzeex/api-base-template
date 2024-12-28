using NetDevPack.Identity.Model;

namespace Equinox.Domain.Models.Users;

public class RegisterUserModel : RegisterUser
{
    public string PhoneNumber { get; set; }
    public string UserName { get; set; }
}
