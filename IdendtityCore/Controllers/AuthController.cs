using IdendtityCore.Entity;
using IdendtityCore.Entity.UserEntity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdendtityCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<AppRole> roleManager;
        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        [HttpPost, Route("Login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(userLoginDto.Email);
                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(user, userLoginDto.Password, userLoginDto.RememberMe, false);
                    if (result.Succeeded)
                    {
                        return Ok();
                    }
                    else
                    {
                        ModelState.AddModelError("", "E-posta adresiniz veya şifreniz yanlıştır.");
                        return BadRequest();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "E-posta adresiniz veya şifreniz yanlıştır.");
                    return BadRequest();
                }
            }
            else
            {
                return Ok();//ret redirect 
            }
        }

        [HttpPost, Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto changePasswordDto)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(changePasswordDto.Email);

                if (user == null)
                {
                    // Handle invalid email
                    ModelState.AddModelError(string.Empty, "Invalid email address.");
                    return BadRequest(ModelState);
                }

                var result = await userManager.ChangePasswordAsync(user, changePasswordDto.CurrentPassword, changePasswordDto.NewPassword);

                if (result.Succeeded)
                {
                    // Password changed successfully
                    // You may choose not to sign out immediately
                    // await signInManager.SignOutAsync();

                    // Redirect to a success page or return a success response
                    return Ok("Password changed successfully.");
                }
                else
                {
                    // Handle password change failure
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }

                    return BadRequest(ModelState);
                }
            }

            // Handle model state validation errors
            return BadRequest(ModelState);
        }

        [HttpPost, Route("AddRole")]
        public async Task<IActionResult> AddRole(AddRole roleInfo)
        {
            if (ModelState.IsValid)
            {
                // Check if the role already exists
                var roleExists = await roleManager.RoleExistsAsync(roleInfo.RoleName);

                if (!roleExists)
                {
                    // Create the role
                    var role = new AppRole { Name = roleInfo.RoleName }; // Use AppRole instead of IdentityRole

                    var result = await roleManager.CreateAsync(role);

                    if (result.Succeeded)
                    {
                        // Role created successfully
                        return Ok("Role created successfully.");
                    }
                    else
                    {
                        // Handle errors in result.Errors
                        return BadRequest(result.Errors);
                    }
                }
                else
                {
                    // Role already exists
                    return BadRequest("Role already exists.");
                }
            }

            // Handle model state validation errors
            return BadRequest(ModelState);
        }

        [HttpPost, Route("AddUser")]
        public async Task<IActionResult> Register(AddUser model)
        {
            if (ModelState.IsValid)
            {
                // Map RegisterDto properties to ApplicationUser properties
                var user = new AppUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };

                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // Handle successful registration
                    return Ok("Registration successful.");
                }
                else
                {
                    // Handle registration failure
                    return BadRequest(result.Errors);
                }
            }

            // Model is not valid, return validation errors
            return BadRequest(ModelState);
        }
    }

}

