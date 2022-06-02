using ProyectoWeb.Models.authenticate;

namespace ProyectoWeb.Repository.AuthenticateRepositories
{
    public interface IAuthenticateRepository
    {
        Task<(bool success, AuthenticateResponse authenticate)> LoginAsync();
    }
}
