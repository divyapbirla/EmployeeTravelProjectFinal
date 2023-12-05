using API_TravelProject.Repository;
using ClassLibrary_APITravelProject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace API_TravelProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _repository;
        public AuthController(IUserRepository repository)
        {
            _repository = repository;
        }

        // api/auth/register
        [HttpPost("Register")]

        public async Task<IActionResult> RegisterAsync([FromBody] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _repository.RegisterUserAsync(model);
                if (result.IsSuccess)
                {
                    return Ok(result);

                }

                return BadRequest(result);
            }
            return BadRequest("some properties are nor valid");

        }
        //api/auth/login

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _repository.LoginUserAsync(model);
                if (result.IsSuccess)
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }
            return BadRequest("some properties are nor valid");
        }
    }
}
