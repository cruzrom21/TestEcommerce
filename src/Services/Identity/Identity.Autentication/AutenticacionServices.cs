
using Identity.Autentication.Interface;
using Identity.Domain;
using Identity.Persistence.Database;
using Identity.Persistence.Repository;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Negocio.Negocio
{
    public class AutenticacionServices : IAutenticacionServices
    {
        private IdentityDbContext _db;
        private readonly ConfigJwt _jwt;
        private readonly IRepository<User> _repository;

        public AutenticacionServices(IdentityDbContext dbContext, IOptions<ConfigJwt> jwt, IRepository<User> repository)
        {
            _db = dbContext;
            _jwt = jwt.Value;
            _repository = repository;
        }

        public string InicioSesion(User user)
        {
            try
            {
                User? userExist = _db.Users.Where(x => x.Email == user.Email).FirstOrDefault();
                bool passwordExist = userExist != null ? BCrypt.Net.BCrypt.Verify(user.Password, userExist.Password) : false;

                if (userExist != null && passwordExist)
                {
                    return Token(userExist);
                }
                else
                {
                    return "Usuario no existe.";
                }
            }
            catch (Exception ex)
            {
                return "Ocurrio un error al ejecutar el proceso " + ex.Message;
            }
        }


        public string Registrar(User user)
        {
            try
            {
                User? userExist = _db.Users.Where(x => x.Email == user.Email).FirstOrDefault();

                if (userExist == null)
                {
                    // Crear usuario
                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
                    user.Password = hashedPassword;

                    _repository.Insert(user);

                    // Iniciar sesion
                    string tokenCreado = Token(user);

                    return "Usuario creado con exito.";
                }
                else
                {
                    return "Usuario ya existe.";
                }
            }
            catch (Exception ex)
            {
                return "Ocurrio un error al ejecutar el proceso " + ex.Message;
            }
        }



        private string Token(User userExist)
        {
            try
            {
                var keybytes = Encoding.UTF8.GetBytes(_jwt.secretkey);

                var claims = new ClaimsIdentity();
                claims.AddClaim(new Claim(JwtRegisteredClaimNames.Sub, _jwt.Subject));
                claims.AddClaim(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                claims.AddClaim(new Claim("id", userExist.IdUser.ToString()));
                claims.AddClaim(new Claim("Rol", userExist.IdRolUser.ToString()));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddHours(24),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keybytes), SecurityAlgorithms.HmacSha256)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

                string tokenCreado = tokenHandler.WriteToken(tokenConfig);

                return tokenCreado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}