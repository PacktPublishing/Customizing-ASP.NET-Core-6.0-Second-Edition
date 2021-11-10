using Microsoft.AspNetCore.Identity;

namespace AuthSample.Data;

public class WebAppUser : IdentityUser
{
    [PersonalData]
    public string? Name { get; set; }
    [PersonalData]
    public DateTime DOB { get; set; }
}