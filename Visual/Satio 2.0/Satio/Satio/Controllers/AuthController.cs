using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Satio.Models;
using Satio.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Satio.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration) 
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;

        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserModel createUserModel)
        {
            try
            {
                var result = await _userManager.CreateAsync(new User
                {
                    Email = createUserModel.Email,
                    UserName = createUserModel.UserName,

                }, createUserModel.Password);

                if (!result.Succeeded)
                    return StatusCode(500, "Ocurrió un error durante la creación del usuario");
                
                
                return Ok("Usuario registrado exitosamente!");

            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            try
            {
                // 1. Revisar que el username / existe
                User user = await _userManager.FindByNameAsync(loginModel.UserName);
                //User user = await _userManager.FindByEmailAsync(loginModel.UserName);


                if (user != null)
                {
                    // 2. Verificar contraseña
                    var passwordCheck = await _signInManager.CheckPasswordSignInAsync(user, loginModel.Password, false);

                    if (passwordCheck.Succeeded)
                    {
                        // 3. Generar el token para el usuario
                        var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("SecretKey"));

                        //Definir los claims
                        var claims = new[]
                        {
                            new Claim(ClaimTypes.NameIdentifier, user.Id), // no es recomendable poner el Id, es comprometedor
                            new Claim(ClaimTypes.Name, user.UserName)
                        };

                        var identityClaim = new ClaimsIdentity(claims);

                        // Armamos el token
                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = identityClaim,
                            Expires = DateTime.UtcNow.AddDays(1),
                            SigningCredentials = new SigningCredentials( 
                                    new SymmetricSecurityKey(key),
                                    SecurityAlgorithms.HmacSha256Signature
                                )
                        };

                        var tokenHandler = new JwtSecurityTokenHandler();

                        var createdToken = tokenHandler.CreateToken(tokenDescriptor);
                        return Ok(tokenHandler.WriteToken(createdToken));

                    }
                    else return StatusCode(404, "Esta no es tu contraseña, sigue intentando.");

                }

                return StatusCode(404, "Usuario no existe :(");

            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
