using Api.Contracts;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StockApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<UserResponseContract>> GetAllUsers()
        {
            var result = userService.GetAllUsers();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public ActionResult<UserResponseContract> GetUserById([FromRoute] int id)
        {
            var result = userService.GetUserById(id);
            return Ok(result);
        }
        [HttpPost]
        public ActionResult<UserResponseContract> CreateUser(UserRequestContract userRequestContract)
        {
            var createdUser = userService.CreateUser(userRequestContract);
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
        }
    }
}
