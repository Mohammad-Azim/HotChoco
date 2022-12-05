using System.IdentityModel.Tokens.Jwt;
using System.Text;
using HotChoco.GprahQL.Jwt.Auth.Data.Entities;
using HotChoco.GprahQL.Jwt.Auth.Models;
using HotChocolate;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace HotChoco.GprahQL.Mutations;
public class Mutation
{
    private List<User> Users = new List<User>

    {
        new User{
            Id = 1,
            FirstName = "Naveen",
            LastName = "Bommidi",
            Email = "naveen@gmail.com",
            Password="1234",
            PhoneNumber="8888899999"
        },
        new User{
            Id = 2,
            FirstName = "Hemanth",
            LastName = "Kumar",
            Email = "hemanth@gmail.com",
            Password = "abcd",
            PhoneNumber = "2222299999"
        }
    };



    public string UserLogin([Service] IOptions<TokenSettings> tokenSettings, LoginInput login)
    {
        var currentUser = Users.Where(u => u.Email.ToLower() == login.Email &&
        u.Password == login.Password).FirstOrDefault();

        if (currentUser != null)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.Value.Key));
            var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                issuer: tokenSettings.Value.Issuer,
                audience: tokenSettings.Value.Audience,
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: credentials
            );

            string token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return token;
        }
        return "Wrong Email or password";
    }

}
