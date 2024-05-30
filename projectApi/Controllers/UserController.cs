using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projectApi.Models;
using projectApi.Repositories.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace projectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetAllUsers()
        {
            List<UserModel> users = await _userRepository.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetUserById(int id)
        {
            UserModel user = await _userRepository.GetUserById(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> CreateUser([FromBody] UserModel newUser)
        {
            UserModel user = await _userRepository.AddUser(newUser);
            return Ok(user);
        }

        [HttpPut]
        public async Task<ActionResult<UserModel>> UpdateUser([FromBody] UserModel newUser, int id)
        {
            UserModel user = await _userRepository.UpdateUser(newUser, id);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteUser(int id)
        {
            bool deleteStatus = await _userRepository.DeleteUser(id);
            return Ok(deleteStatus);
        }
    }
}
