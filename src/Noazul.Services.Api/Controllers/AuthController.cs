using Equinox.Domain.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NetDevPack.Identity.Jwt;
using NetDevPack.Identity.Model;
using Noazul.Domain.Core;
using Nudes.Retornator.Core;

namespace Noazul.Services.Api.Controllers;

[Route("api/v1/auth")]
[ApiController]
public class AuthController : ApiController
{
    private readonly SignInManager<IdentityUser> signInManager;
    private readonly UserManager<IdentityUser> userManager;
    private readonly AppJwtSettings appJwtSettings;

    public AuthController(
        SignInManager<IdentityUser> signInManager,
        UserManager<IdentityUser> userManager,
        IOptions<AppJwtSettings> appJwtSettings)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
        this.appJwtSettings = appJwtSettings.Value;
    }

    [HttpPost]
    [Route("register")]
    public async Task<ResultOf<LoginResponse>> Register(RegisterUserModel registerUser)
    {
        if (!ModelState.IsValid) return new BadRequestError();

        var user = new IdentityUser
        {
            UserName = registerUser.Email,
            Email = registerUser.Email,
            EmailConfirmed = true,
            PhoneNumber = registerUser.PhoneNumber
        };

        var result = await userManager.CreateAsync(user, registerUser.Password);

        if (result.Succeeded) return new LoginResponse(GetFullJwt(user.Email));

        foreach (var error in result.Errors)
            AddError(error.Description);

        return new BadRequestError(result.Errors.ToString());
    }

    [HttpPost]
    [Route("login")]
    public async Task<ResultOf<LoginResponse>> Login(LoginUser loginUser)
    {
        if (!ModelState.IsValid) return new BadRequestError();

        var result = await signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

        if (result.Succeeded)
        {
            var fullJwt = GetFullJwt(loginUser.Email);
            return new LoginResponse(fullJwt);
        }

        if (result.IsLockedOut) return new BadRequestError("This user is temporarily blocked");

        return new BadRequestError("Incorrect user or password");
    }

    private string GetFullJwt(string email)
    {
        return new JwtBuilder()
            .WithUserManager(userManager)
            .WithJwtSettings(appJwtSettings)
            .WithEmail(email)
            .WithJwtClaims()
            .WithUserClaims()
            .WithUserRoles()
            .BuildToken();
    }
}

public record LoginResponse(string AccessToken);