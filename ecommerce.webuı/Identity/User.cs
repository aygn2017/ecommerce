using Microsoft.AspNetCore.Identity;

namespace ecommerce.webui.Identity
{
    public class User: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}