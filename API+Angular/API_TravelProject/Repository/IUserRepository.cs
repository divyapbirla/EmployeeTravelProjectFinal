using ClassLibrary_APITravelProject;

namespace API_TravelProject.Repository

{
    public interface IUserRepository
    {
        Task<UserManagerResponse> RegisterUserAsync(RegisterViewModel model);
        Task<UserManagerResponse> LoginUserAsync(LoginViewModel model);
    }
}

