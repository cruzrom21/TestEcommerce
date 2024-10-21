using Identity.Domain;

namespace Identity.Autentication.Interface
{
    public interface IAutenticacionServices
    {
        string InicioSesion(User user);
        string Registrar(User user);
    }
}
